# AupFontExtractor

[AviUtl](http://spring-fragrance.mints.ne.jp/aviutl/)
プロジェクトファイルから拡張編集で使用したフォントをリストアップするツールです。

## インストール

[Releases](https://github.com/karoterra/AupFontExtractor/releases)
から最新版の ZIP ファイルをダウンロードし、好きな場所に展開してください。

.NET 5 をインストール済みの方は `AupFontExtractor-xxx-win-x64-fd.zip` をダウンロードしてください。
.NET 5 をインストールせずに利用したい方やよく分からない方は `AupFontExtractor-xxx-win-x64-sc.zip` をダウンロードしてください。

アンインストール時には展開したフォルダを削除してください。

## 使い方

AviUtl プロジェクトファイル (*.aup) を `AupFontExtractor.exe` にドラッグ&ドロップしてください。
プロジェクトファイルと同じ場所に `<元のファイル名>_font.txt` が生成されます。
テキストファイルにはテキストオブジェクトで設定したフォント、制御文字で使用したフォントが出力されます。

以下、コマンドラインから使いたい人向けのオプション
```
Usage:
  AupFontExtractor [options] aup-file

Option:
  -h, --help  ヘルプを表示する
  -s          フォントリストをソートして出力(デフォルト)
  -S          フォントリストをソートせずに出力
  -o <file>   フォントリストを <file> に出力する
```

## 更新履歴

更新履歴は [CHANGELOG](CHANGELOG.md) を参照してください。

## ライセンス

このソフトウェアは MIT ライセンスのもとで公開されます。
詳細は [LICENSE](LICENSE) を参照してください。

使用したライブラリ等については [CREDITS](CREDITS.md) を参照してください。
