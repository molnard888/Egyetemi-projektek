
#!/usr/bin/perl

$limit=<>;
chomp($limit);
print "limit:$limit\n";


while ($limit > 0)
{
$sor=<>
chomp($sor);
$size=length($sor);
if ($size <= $limit)
{
$limit=$limit-$size;
push(@tomb, $sor);
print "limit:$limit\n"
}
else
{
print "nem fer bele a limitbe!\n";
print "limit:$limit\n";
}
}


@sorted_words = sort @tomb;
for($i=0;$i<$#tomb;$i++)
{
print "$sorted_words[$i] ";
}
