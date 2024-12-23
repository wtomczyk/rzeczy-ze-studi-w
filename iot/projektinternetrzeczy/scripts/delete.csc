loop
dreadsensor x
wait
read v
if(x==0)
	send v 0 2
end
delay 1000