//Receiver
loop
wait
read rp
rdata rp rid v
if(v==A)
  mark 1
else
  mark 0
end