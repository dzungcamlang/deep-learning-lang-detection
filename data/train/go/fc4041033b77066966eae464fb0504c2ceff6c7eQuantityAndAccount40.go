package iso20022

// Details on the quantity, account and other related information involved in a transaction.
type QuantityAndAccount40 struct {

	// Quantity of financial instrument effectively settled.
	SettledQuantity *Quantity6Choice `xml:"SttldQty"`

	// Quantity of financial instrument previously settled.
	PreviouslySettledQuantity *FinancialInstrumentQuantity1Choice `xml:"PrevslySttldQty,omitempty"`

	// Quantity of financial instrument remaining to be settled.
	RemainingToBeSettledQuantity *FinancialInstrumentQuantity1Choice `xml:"RmngToBeSttldQty,omitempty"`

	// Amount of money previously settled.
	PreviouslySettledAmount *AmountAndDirection5 `xml:"PrevslySttldAmt,omitempty"`

	// Amount of money remaining to be settled.
	RemainingToBeSettledAmount *AmountAndDirection5 `xml:"RmngToBeSttldAmt,omitempty"`

	// Party that legally owns the account.
	AccountOwner *PartyIdentification98 `xml:"AcctOwnr,omitempty"`

	// Account to or from which a securities entry is made.
	SafekeepingAccount *SecuritiesAccount19 `xml:"SfkpgAcct"`

	// Account to or from which a cash entry is made.
	CashAccount *CashAccountIdentification5Choice `xml:"CshAcct,omitempty"`

	// Place where the securities are safe-kept, physically or notionally.  This place can be, for example, a local custodian, a Central Securities Depository (CSD) or an International Central Securities Depository (ICSD).
	SafekeepingPlace *SafeKeepingPlace1 `xml:"SfkpgPlc,omitempty"`
}

func (q *QuantityAndAccount40) AddSettledQuantity() *Quantity6Choice {
	q.SettledQuantity = new(Quantity6Choice)
	return q.SettledQuantity
}

func (q *QuantityAndAccount40) AddPreviouslySettledQuantity() *FinancialInstrumentQuantity1Choice {
	q.PreviouslySettledQuantity = new(FinancialInstrumentQuantity1Choice)
	return q.PreviouslySettledQuantity
}

func (q *QuantityAndAccount40) AddRemainingToBeSettledQuantity() *FinancialInstrumentQuantity1Choice {
	q.RemainingToBeSettledQuantity = new(FinancialInstrumentQuantity1Choice)
	return q.RemainingToBeSettledQuantity
}

func (q *QuantityAndAccount40) AddPreviouslySettledAmount() *AmountAndDirection5 {
	q.PreviouslySettledAmount = new(AmountAndDirection5)
	return q.PreviouslySettledAmount
}

func (q *QuantityAndAccount40) AddRemainingToBeSettledAmount() *AmountAndDirection5 {
	q.RemainingToBeSettledAmount = new(AmountAndDirection5)
	return q.RemainingToBeSettledAmount
}

func (q *QuantityAndAccount40) AddAccountOwner() *PartyIdentification98 {
	q.AccountOwner = new(PartyIdentification98)
	return q.AccountOwner
}

func (q *QuantityAndAccount40) AddSafekeepingAccount() *SecuritiesAccount19 {
	q.SafekeepingAccount = new(SecuritiesAccount19)
	return q.SafekeepingAccount
}

func (q *QuantityAndAccount40) AddCashAccount() *CashAccountIdentification5Choice {
	q.CashAccount = new(CashAccountIdentification5Choice)
	return q.CashAccount
}

func (q *QuantityAndAccount40) AddSafekeepingPlace() *SafeKeepingPlace1 {
	q.SafekeepingPlace = new(SafeKeepingPlace1)
	return q.SafekeepingPlace
}
