<?php
     $pass =$_POST["pass"];
     $data =escapeshellarg($_POST["data"]); 
     $pass_hash = "";#パスワードのハッシュ値を入力しておいてください
     $command ="sudo sh data/run.sh ";
     if (hash('sha256',$pass)== $pass_hash){
         exec($command.$data,$output);
         echo "送信しました！";
     }
     else{
         echo "パスワードが違います";
     }

?>

