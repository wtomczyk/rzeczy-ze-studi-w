//sensory s¹ tak ustawione, aby dzia³a³y od 19 wieczór do 7 rano
//aby zmnieniæ godzinê od której zaczynana jest symulacja trzeba
//zmieniæ wartoœæ hour w transmitter.csc
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