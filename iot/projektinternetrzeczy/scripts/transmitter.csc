//hour - startowa godzina, ka¿de przejœcie loopa odpowiada 1 godzinie
int hour 0
loop
if(hour==23)
	set hour 0
else
	plus hour hour 1
end
dreadsensor x
if((hour>=19) || (hour<7)) 
	if(x==1)
		send x 0 2
	else
		atget id a
		minus a a 1
		send 0 a
	end
else
	send 0 0 2
end
delay 1000