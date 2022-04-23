
#!/bin/bash

if [ $# -eq 1 ] && [ -f $1 ]
then
input=$1
while IFS= read -r line
do
kell=${#line}
if kell <= 72
then
while kell>=0
do 
printf " "
kell=kell-1
done
printf "$line\n"
else
printf "$line\n"
fi
	
done < "$input"
  
else
echo ERROR
exit 1
fi




if [ wc -c line <= 72]
     hossz= wc -c line
     kell=hossz-72
     while kell >= 0
     do
      printf " "
      kell=kell-1
     done