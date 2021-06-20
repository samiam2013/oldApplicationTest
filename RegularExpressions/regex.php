<?php

$datetimestamps = ['2014-08-18T13:03:25Z',
                    '2014/08/18T13:03:25Z',
                    '2014-08-18',
                    '2014/08/18'];
$pattern = "/([0-9]{4})[\/-]([0-9]{2})[\/-]([0-9]{2})T?([0-9]{2})?:?([0-9]{2})?:?([0-9]{2})?/";
$pattern_index = ['year','month','day','hour','minute','second'];
 
foreach($datetimestamps as $datetime){
    echo "timestamp: ".$datetime.PHP_EOL;
    preg_match($pattern, $datetime, $output_array);
    for($i = 1; $i <= count($pattern_index); $i++){
        if(isset($output_array[$i])){
            echo $pattern_index[$i-1].": ".$output_array[$i].PHP_EOL;
        }
    }
    echo PHP_EOL;
}