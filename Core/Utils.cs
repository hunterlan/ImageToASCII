using System.IO;

namespace Core
{
    public class Utils
    {
        public static void WriteToFile(string path, char[][] data, int height, int weight)
        {
            using StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default);
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < weight; j++)
                {
                    sw.Write(data[i][j]);
                }

                sw.Write('\n');
            }
        }
    }
}