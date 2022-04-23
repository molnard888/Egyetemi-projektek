#!/usr/bin/perl

while ($szam=<>) {
chomp($szam);
push(@tomb, $szam); }

for ($i=0; $i<=$#tomb; $i++)
{
print $tomb[$i]."\n";
for ($j=-1; $j<$i; $j++)
{
print $tomb[$i]." ";
}
print "\n";
}





