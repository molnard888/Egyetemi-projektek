#!/usr/bin/perl

while ($szam=<>) 
{
chomp($szam);
push(@tomb, $szam); 
}

for ($i = 0; $i < $#tomb; ++$i) 
{
for ($j = $i + 1; $j < $#tomb; ++$j) 
{
if ($tomb[$i] < $tomb[$j]) 
{
$a = $tomb[$i];
$tomb[$i] = $tomb[$j];
$tomb[$j] = $a;
}
}
}
 
for ($i = 0; $i < $#tomb; ++$i) 
{
print $tomb[$i];
}