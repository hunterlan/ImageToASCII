using System;
using System.IO;
using System.Linq;
using ImageMagick;

namespace Core
{
    public class ImageToAscii
    {
        private readonly char[] asciiTable = {'.', ',', ':', '+', '*', '?', '%', 'S', '#', '@'};
        
        public char[][] ConvertImageToASCII(string path)
        {
            var pathToImage = path;
            using var image = new MagickImage(pathToImage);
            image.Alpha(AlphaOption.Transparent);
            //Separate the alpha layer from the image
            var result = image.Separate(Channels.Alpha).First();

            //Inverse all colors inside the path
            result.Negate();

            //Copy the resulting mask back into the image as new alpha layer
            image.Composite(result, CompositeOperator.CopyAlpha);

            var pixels = image.GetPixels();

            var acs = new char[image.Height][];

            for (int i = 0; i < image.Height; i++)
            {
                acs[i] = new char[image.Width];
                for (int j = 0; j < image.Width; j++)
                {
                    var mapIndex = (int) Map(pixels[j, i].ToColor().R, 0, 255, 0, asciiTable.Length - 1);
                    acs[i][j] = asciiTable[mapIndex];
                }
            }

            return acs;
        }
        
        private static float Map(float valueToMap, float start1, float stop1, float start2, float stop2)
        {
            return (valueToMap - start1) / (stop1 - start1) * (stop2 - start2) + start2;
        }
    }
}