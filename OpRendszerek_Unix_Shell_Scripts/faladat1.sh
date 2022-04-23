#!/bin/bash

if test -d $1
then 
for directory in /$1/*
do
if [ -d "$directory" ]
then
mv "${directory}" "${directory}dir"
fi
				
if [ -s "$directory" ]
then
mv "${directory}" "${directory}softlink"
fi
				
if ! [ -s "$directory" ] || [ -d "$directory" ]
then
mv "${directory}" "${directory}etc"
fi
		
done
	
else
echo ERROR
fi		
