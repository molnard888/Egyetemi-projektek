#!/usr/bin/perl

while ($sor=<>) {
chomp($sor);
push(@tomb, $sor); }

for ($i=0; $i<=($#tomb-1); $i++)
{
$tomb[$i] =~ s/([0-9]+)/00/eg;
print $tomb[$i]."\n";
}
