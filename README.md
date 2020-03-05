# MyRoomIot
マスターのログに個人情報が含まれるため。デベロップブランチのみリモートに挙げています
私の環境は 
Visual Studio Enterprise 2017 Version 15.9.17
Xamarin 4.12.3.83
ラズパイのOS　Raspbian
php　7.2.9-1+b2
python 3.7.3
です。


ラズパイサーバーとADRSIR を用いてオンライン操作可能なマルチ赤外線リモコンを作りました。
操作インターフェースとしてXamarinを採用し、各種媒体から操作できるようにしました。
Macを持っていないのでIOSの動作確認はできていません。
Windowsとandroidは動作確認済みです。

ラズパイにADRSIRを積んで各種設定。
赤外線データのファイルを用意。
ファイルを配置して、MyData.csを編集。
starter.phpにハッシュ値を設定。
VSでコンパイルしてリモコン操作

で動くと思います。

