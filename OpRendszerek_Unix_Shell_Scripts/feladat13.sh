
#!/usr/bin/perl

$max=<>;

$tomb[0]=0;

for ($i = 1; $i <= $max; $i++)
{
$tomb[$i] = ($tomb[$i-1]-1) ;
}

print "0=0\n";
for ($i=1; $i<=$max; $i++)
{
for ($j=0; $j<=i; $j++)
{
say for @tomb[0 .. $j];
@MyArray = (1..$j);
foreach my $k (0 .. $#MyArray)
{
        $sum += $_ for @MyArray;
}
        print "=$sum";
}
}

