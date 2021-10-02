using System.IO;

namespace AupFontExtractor
{
    class AppOption
    {
        public string inputPath;
        public string outputPath;

        public AppOption(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case "-o":
                        if (i + 1 < args.Length)
                        {
                            i++;
                            outputPath = args[i];
                        }
                        break;
                    default:
                        if (inputPath == null)
                        {
                            inputPath = args[i];
                        }
                        break;
                }
            }

            if (inputPath != null && outputPath == null)
            {
                outputPath = Path.Combine(
                    Path.GetDirectoryName(inputPath),
                    Path.GetFileNameWithoutExtension(inputPath) + "_font.txt");
            }
        }
    }
}
