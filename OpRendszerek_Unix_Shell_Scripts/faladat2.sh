#!/bin/bash

if [ $# -eq 1 ] && [ -f $1 ]
then
input=$1
while IFS= read -r line
do
len=`echo $line | wc -c`
len=72-$len
if [ $len -le 72 ]
then
while $len -ge 0
do
printf " "
len=$len-1
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
