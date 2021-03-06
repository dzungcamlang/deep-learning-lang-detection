    type 'a IList = INode of  Id: int * Hd: 'a * Tl : 'a IList | INil
    
    /// internal data constructor which takes garbage collector as a parameter
    /// iCons will be derived from this after gc is defined
    let iCons' gcAlloc h t = INode( Id = gcAlloc t, Hd=h, Tl=t)
    
    let iHd x =
        match x with
        | INode(i,h,t) -> h
        | _ -> failwithf "IList node expected"
    
    let iTl x =
        match x with
        | INode(i,h,t) -> t
        | _ -> failwithf "IList node expected"
    
    
    let iId = function
        | INode(i, h, t) -> i
        | INil -> -1 // give a negative integer instead of failing
    
    let (|IMatch|_|) = function
        | INode (i, h, t) -> Some (h,t)
        | _ -> None
    
    
    type Data = float IList // Type of all data used in simulations
    
    /// type of stack frame containing data referenced by one function call
    /// each stack frame contains a fixed number of name, Data associations for the values of local variables
    /// the variables values are mutable
    /// garbage collection will assume that all data accessible from a stack frame is alive
    type StackFrame = Map<string, Data Ref> 
    
    /// global stack of stack frames used by garbage Collections
    /// each function call will push a new frame by consing to the head of the list
    /// each function return will pop a stack frame by taking the tail of the list
    let mutable GlobalStack: StackFrame list = []
    
    
    
    
    /// create a two parameter stack oriented function by wrapping the provided functionUsingStack
    /// the stack frame creation and deletion is handled here. The wrapped function is given the current stack StackFrame
    /// and the created function as parameters.
    /// Note that it must be given the created function in case it needs to implement recursive function calls
    /// in simple use cases the function parameters are the only local data needed and localNames = [].
    /// the return type is Data -> Data -> Data (a two-parameter function)
    let ManageCallTwoParameters p1Name p2Name localNames (functionUsingStack: StackFrame -> (Data -> Data -> Data) -> Data) =
        let rec innerFunc p1 p2 = // this is the function returned
            let oldStack = GlobalStack
            /// stack frame with locals initialised from parameters given by calling function
            /// extra local variables (if needed) are initialised to INil
            let newFrame = Map.ofList <| [ p1Name, ref p1 ; p2Name, ref p2 ] @ (List.map (fun lName -> lName, ref INil) localNames) // create the new stack frame for this function call
            GlobalStack <- newFrame :: oldStack
            let returnedData = functionUsingStack newFrame innerFunc
            GlobalStack <- oldStack // destroy the stack frame for this call which is no longer needed
            returnedData
        innerFunc
    
    /// create a one parameter stack oriented function by wrapping the provided functionUsingStack
    /// the stack frame creation and deletion is handled here. The wrapped function is given the current stack StackFrame
    /// and the created function as parameters.
    /// in simple use cases the function parameters are the only local data needed and localNames = [].
    /// the return type is Data -> Data (a one-parameter function)
    let ManageCallOneParameter p1Name localNames (functionUsingStack: StackFrame -> (Data -> Data) -> Data) =
        let rec innerFunc p1 = // this is the function returned
            let oldStack = GlobalStack
            /// stack frame with locals initialised from parameters given by calling function
            /// extra local variables (if needed) are initialised to INil
            let newFrame = Map.ofList <| [ p1Name, ref p1 ] @ (List.map (fun lName -> lName, ref INil) localNames) // create the new stack frame for this function call
            GlobalStack <- newFrame :: oldStack
            let returnedData = functionUsingStack newFrame innerFunc
            GlobalStack <- oldStack // destroy the stack frame for this call which is no longer needed
            returnedData
        innerFunc
    
    //-----------------------------------
    // demo 'simplest' storage management
    //-----------------------------------
    
    /// simple simulated memory allocation using infinite memory
    let nextGenerator() =
        let mutable currentId = 0
        let next() =
            currentId <- currentId + 1
            currentId
        next
    /// nextId is the generator function used by iCons
    let nextId = nextGenerator()
    
    
    let checkConsistency (lst:Data) =
        let rec getIdListFromData: Data -> int list = function
            | INode(id,h,t) -> id :: getIdListFromData t
            | _ -> []
        let aliveIdList =
           GlobalStack
           |> List.collect (Map.toList >> List.map (fun (_, x) -> !x) >> List.collect getIdListFromData)
        let checkAlive id =
            match List.exists ((=) id) aliveIdList with
            | true -> () // normal case
            | false -> failwithf "Inconsistent data id %d discovered, id not on stack %A" id aliveIdList
        List.iter checkAlive (getIdListFromData lst)
        
    
    
    // this function returns the id of a new IList cell guaranteed to be free
    // in the simulation each id represents a possible list cell sized element of heap
    // lst will be the tail of the cell, and therefore all its elements must be alive
    // this function can check for consistency that all elements of lst are reachable from GlobalStack
    // it can perform garbage collection to find free ids, using a fixed size heap of ids
    // or it can just allocate new ids without even doing garbage collection
    let gcAlloc lst =
        checkConsistency lst
        let i = nextId()
        printfn "Creating Data id=%d" i
        i
    
    let iCons = iCons' gcAlloc
    
    //----------------------
    // Demo Application Code
    //----------------------
    
    /// turn a float list into a Data item (float IList)
    /// the partly constructed IList is held in tmpVar on stack
    /// ensuring all Data cells are alive at all times
    let makeDataList (lst: float list) =
        let oldStack = GlobalStack
        let tmpVar = ref INil
        GlobalStack <- Map.ofList [ "x", tmpVar ] :: oldStack
        List.iter (fun f -> tmpVar := iCons f !tmpVar) (List.rev lst) 
        GlobalStack <- oldStack
        !tmpVar

    // Ticked Exercise

    let mergeUsingStack (frame: StackFrame) merge =
        let x, y = frame.["x"], frame.["y"]
        match !x, !y with
        | IMatch(a, x'), IMatch(b, y') when a > b -> 
            y := merge x' !y
            iCons a !y
        | IMatch(_), IMatch(b, y') -> 
            x := merge !x y'
            iCons b !x
        | INil, IMatch(_) -> !y
        | IMatch(_), INil -> !x
        | _ -> INil
    let merge = ManageCallTwoParameters "x" "y" [] mergeUsingStack
    let evenElementsUsingStack (frame: StackFrame) evenElements =
        let x, ly = frame.["x"], frame.["ly"]
        match !x with
        | IMatch (a, IMatch (_, lst')) -> 
            ly := evenElements lst'
            iCons a !ly
        | IMatch(a, INil) -> !x
        | _ -> !ly
    let evenElements = ManageCallOneParameter "x" ["ly"] evenElementsUsingStack
    let mergeSortUsingStack (frame: StackFrame) mergeSort =
        let lst = frame.["lst"]
        match !lst with
        | IMatch(a, INil) -> !lst
        | IMatch (a, lst') -> 
            merge (evenElements !lst |> mergeSort) (evenElements lst' |> mergeSort)
        | _ -> failwithf "do not pass empty lists"

    let mergeSort = ManageCallOneParameter "lst" [] mergeSortUsingStack

//    mergeSort (makeDataList [13.4 ; 52.9; 27.0; -145.9; 1533.1; -200.1]);;