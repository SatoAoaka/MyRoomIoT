<?php
     $pass =$_POST["pass"];
     $data =escapeshellarg($_POST["data"]); 
     $pass_hash = "fb0be50d6e9a1e65d5717baade2fef09ab2a2f40ab4e6e315f403cabd1f20245";
     $command ="sudo sh data/run.sh ";
     if (hash('sha256',$pass)== $pass_hash){
         exec($command.$data,$output);
         echo "送信しました！";
     }
     else{
         echo "パスワードが違います";
     }

?>

