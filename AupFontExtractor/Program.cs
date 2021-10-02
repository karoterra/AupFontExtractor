﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Karoterra.AupDotNet;
using Karoterra.AupDotNet.ExEdit;
using Karoterra.AupDotNet.ExEdit.Effects;

namespace AupFontExtractor
{
    class Program
    {
        static int Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var opt = new AppOption(args);
            if (opt.inputPath == null)
            {
                Console.Error.WriteLine("ファイル名を指定してください");
                WaitEnterKey();
                return 1;
            }
            if (opt.outputPath == null)
            {
                Console.Error.WriteLine("出力ファイル名を指定してください");
                WaitEnterKey();
                return 1;
            }
            if (!File.Exists(opt.inputPath))
            {
                Console.Error.WriteLine($"\"{opt.inputPath}\" が見つかりません");
                WaitEnterKey();
                return 1;
            }

            AviUtlProject aup;
            try
            {
                using (BinaryReader br = new BinaryReader(File.OpenRead(opt.inputPath)))
                {
                    aup = new AviUtlProject(br);
                }
            }
            catch (FileFormatException ex)
            {
                Console.Error.WriteLine($"\"{opt.inputPath}\" はAviUtlプロジェクトファイルではないか破損している可能性があります");
                Console.Error.WriteLine($"詳細: {ex.Message}");
                WaitEnterKey();
                return 1;
            }
            catch (EndOfStreamException)
            {
                Console.Error.WriteLine($"\"{opt.inputPath}\" はAviUtlプロジェクトファイルではないか破損している可能性があります");
                Console.Error.WriteLine("詳細: ファイルの読み込み中に終端に達しました");
                WaitEnterKey();
                return 1;
            }

            ExEditProject exedit = null;
            foreach (var filter in aup.FilterProjects)
            {
                if (filter is RawFilterProject f && f.Name == "拡張編集")
                {
                    exedit = new ExEditProject(f);
                    break;
                }
            }
            if (exedit == null)
            {
                Console.Error.WriteLine("拡張編集のデータが見つかりません");
                WaitEnterKey();
                return 1;
            }

            var fonts = new HashSet<string>();
            foreach (var obj in exedit.Objects)
            {
                if (obj.Effects[0] is TextEffect te)
                {
                    fonts.Add(te.Font);
                }
            }

            try
            {
                using (var sw = new StreamWriter(opt.outputPath, false))
                {
                    foreach (var font in fonts)
                    {
                        sw.WriteLine(font);
                    }
                }
            }
            catch (IOException)
            {
                Console.Error.WriteLine($"\"{opt.outputPath}\" への書き込みに失敗しました");
                WaitEnterKey();
                return 1;
            }

            return 0;
        }

        static void WaitEnterKey()
        {
            Console.WriteLine("終了するにはEnterを押してください...");
            Console.ReadLine();
        }
    }
}
