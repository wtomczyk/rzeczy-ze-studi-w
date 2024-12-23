//Transmitter
loop
dreadsensor x
if(x==1)
	send x * 111
else
	send 0 111
end

delay 1000