<?php
     $pass =$_POST["pass"];
     $time =escapeshellarg($_POST["time"]);
     $data =escapeshellarg($_POST["data"]); 
     $pass_hash = "";#�p�X���[�h�̃n�b�V���l����͂��Ă����Ă�������
     $command ="sudo sh data/rureserve.sh ";
     if (hash('sha256',$pass)== $pass_hash){
         exec($command.$time." ".$data,$output);
         echo "���M���܂����I";
     }
     else{
         echo "�p�X���[�h���Ⴂ�܂�";
     }

?>