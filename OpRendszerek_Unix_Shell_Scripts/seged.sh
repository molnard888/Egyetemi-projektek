for ($i = 0; $i < $n; ++$i) 
        {
            for ($j = $i + 1; $j < n; ++$j) 
            {
                $if ($tomb[$i] < $tomb[$j]) 
                {
                    $a = $tomb[$i];
                    $tomb[$i] = $tomb[$j];
                    $tomb[$j] = $a;
                }
            }
        }
 
        for ($i = 0; $i < n; ++$i) 
        {
            print $tomb[$i];
        }