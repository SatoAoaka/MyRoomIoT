# MyRoomIot
私の環境は 
Visual Studio Enterprise 2017 Version 15.9.17
Xamarin 4.12.3.83
ラズパイのOS　Raspbian
php　7.2.9-1+b2
python 3.7.3
Raspberry Pi 3 Model b+
赤外線モジュール ADRSIR(BitTradeOne)
です。


ラズパイサーバーとADRSIR を用いてオンライン操作可能なマルチ赤外線リモコンを作りました。
操作インターフェースとしてXamarinを採用し、各種媒体から操作できるようにしました。
Macを持っていないのでIOSの動作確認はできていません。
Windowsとandroidは動作確認済みです。

ラズパイにADRSIRを積んで各種設定。
赤外線データのファイルを用意。
MyData.csを編集。
MyDataに用意したファイル名を使ってボタンを作成(MainPage.xaml)とイベントの設定(MainPageViewModel.cs)
starter.phpにハッシュ値を設定。サーバーにファイルを配置してApache起動
VSでデバッグ起動してリモコン操作

で動くと思います。

リリースビルドした場合にはUWPの配置やAndroidアプリの配置方法に従ってください。
