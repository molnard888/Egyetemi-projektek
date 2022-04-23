#!/bin/bash

declare -i x=$1
declare -i y=$2

moszt () 
{
if [ $1 -eq 0 ] || [ $2 -eq 0 ]
then
echo ERROR
else 
answer=$(echo $(( x % y )))
echo $answer	
fi
}

moszt