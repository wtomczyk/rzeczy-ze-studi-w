//sensory s� tak ustawione, aby dzia�a�y od 19 wiecz�r do 7 rano
//aby zmnieni� godzin� od kt�rej zaczynana jest symulacja trzeba
//zmieni� warto�� hour w transmitter.csc
loop
int hour 0
loop
if(hour==23)
	set hour 0
else
	plus hour hour 1
end
print hour
delay 1000