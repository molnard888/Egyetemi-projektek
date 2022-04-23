
#!/bin/bash

read var
i=1
j=0
while (( i > j ))
do
if [ -f "$var" ] || [ -L "$var" ]
then
echo $var
ls -l $var | tail -c +2 | head -c 9 | xargs -n 1
wc < $var | xargs -n 1
j=2
exit 1
else read var;
fi
done
