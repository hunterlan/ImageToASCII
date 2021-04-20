using System;
using System.IO;
using System.Linq;
using Core;
using ImageMagick;

namespace Application
{
    class Program
    {
        private static readonly ImageToAscii ImageToAscii = new ImageToAscii();

        private static void Main(string[] args)
        {
            if (args.Length == 2)
            {
                AutomaticMode(args);
            }
            else
            {
                Help();
            }
        }

        private static void AutomaticMode(string[] args)
        {
            var table = ImageToAscii.ConvertImageToASCII(args[0]);
            ImageToAscii.WriteToFile(args[1], table, table.Length, table[0].Length);
        }

        private static void Help()
        {
            Console.WriteLine("Example of using: <script> ./test/image.img ./test/result.txt");
        }
    }
}
