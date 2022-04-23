#!/usr/bin/perl

$elso=<>;
$masodik=<>;
$b=$masodik-$elso;
chomp($elso);
chomp($masodik);


for($i=0;$i<=$b;$i++)
{
$tomb[$i]=$elso;
$elso++;
}


for($j=0; $j<=$b ; $j++)
{
$c=($tomb[$j])%2;
if ($c == 0)
{
print $tomb[$j];
print "0 ";
}
}
print "\n";

for($j=0; $j<=$b ; $j++)
{
$c=$tomb[$j]%2;
if ($c == 1)
{
print $tomb[$j];
print "1 ";
}
}

