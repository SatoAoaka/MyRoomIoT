<?php
     $pass =$_POST["pass"];
     $time =escapeshellarg($_POST["time"]);
     $data =escapeshellarg($_POST["data"]); 
     $pass_hash = "";#パスワードのハッシュ値を入力しておいてください
     $command ="sudo sh data/rureserve.sh ";
     if (hash('sha256',$pass)== $pass_hash){
         exec($command.$time." ".$data,$output);
         echo "送信しました！";
     }
     else{
         echo "パスワードが違います";
     }

?>