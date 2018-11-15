using System;
using noise;
using System.Drawing;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Perlin noise = new Perlin();
        Random rnd = new Random();

        int width = 256; // read from file
        int height = 256; // read from file
        var bmp = new Bitmap(width, height);

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                double pn = noise.Generate(rnd.NextDouble(), rnd.NextDouble());
                int rgb = EvalGrayscale(pn);
                bmp.SetPixel(x, y, Color.FromArgb(255, rgb, rgb, rgb));
            }
        }
        bmp.Save("C:/Users/Stable-tec/Pictures/test.png");
        Console.WriteLine("Done");
        Console.Read();
    }

    public static int EvalGrayscale(double value)
    {
        return (int)(255 * (value + 1) / 2);

    }
}

