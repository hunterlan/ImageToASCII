using System;
using System.Linq;
using ImageMagick;

namespace Application
{
    class Program
    {
        private readonly char[] asciiTable = {'.', ',', ':', '+', '*', '?', '%', 'S', '#', '@'};
        
        static void Main(string[] args)
        {
            Console.WriteLine($"{args.Length} and {args}");

            var pathToImage = "";
            using (var image = new MagickImage(pathToImage))
            {
                image.Alpha(AlphaOption.Transparent);
                //Separate the alpha layer from the image
                var result = image.Separate(Channels.Alpha).First();

                //Set the clip path
                result.Clip();

                //Inverse all colors inside the path
                result.Negate();

                //Copy the resulting mask back into the image as new alpha layer
                image.Composite(result, CompositeOperator.CopyAlpha);

                var acs = new char[image.Height][];

                for (int i = 0; i < image.Height; i++)
                {
                    acs[i] = new char[image.Width];
                    for (int j = 0; j < image.Width; j++)
                    {
                        
                    }
                }
            }
        }

        private float Map(float valueToMap, float start1, float stop1, float start2, float stop2)
        {
            
        }
    }
}
