using System;
using Core;

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
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static void AutomaticMode(string[] args)
        {
            var table = ImageToAscii.ConvertImageToASCII(args[0]);
            Utils.WriteToFile(args[1], table, table.Length, table[0].Length);
        }

        private static void Help()
        {
            Console.WriteLine("Example of using: <script> ./test/image.img ./test/result.txt");
        }
    }
}
