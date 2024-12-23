//Router
loop
dreadsensor x
wait
read v
atget id a
atget id b
plus a a 3
if (x==0)
	send v * a
end