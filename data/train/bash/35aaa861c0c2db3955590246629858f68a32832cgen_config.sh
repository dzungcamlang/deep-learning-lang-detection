#initial process_num
process_num=0;
l1_nsets=0
for bsize in 32 64 ; do
	for assoc in 1 2 4 8 ; do
		let "nsets=2048*2*128/4/${assoc}/${bsize}"
				gen_config.py -a "256 64 4 f" -b "${nsets} ${bsize} ${assoc} l" -c "dl2" -d "4096 64 8 l" -r "64 2 1 1 1" -s "1 2 2 2" -f "./config/l2_bsize_${bsize}_assoc_${assoc}_nsets_${nsets}.cfg" &
				
				#control process
				let "process_num = $process_num +1"        
				echo  "there are $process_num  processes runing now. bsize=${bsize} assoc=${assoc}"
				if [ $process_num -ge 12 ]; then
				        wait
				        let "process_num = 0"
				fi	
	done
done
wait
