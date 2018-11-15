using System;
using noise;
using System.Drawing;
using System.IO;

class Program
{
     public static void Main(string[] args)
    {
        Perlin noise = new Perlin();
        Random rnd = new Random();

        const int IMAGE_WIDTH = 1024; // read from file
        const int IMAGE_HEIGHT = 1024; // read from file
        double FREQUENCY_X = 0;
        double FREQUENCY_Y = 0;

        var bmp = new Bitmap(IMAGE_WIDTH, IMAGE_HEIGHT);

        

        double dx = FREQUENCY_X / IMAGE_WIDTH;
        double dy = FREQUENCY_Y / IMAGE_HEIGHT;
        for (int y = 0; y < IMAGE_HEIGHT; ++y)
        {
            for (int x = 0; x < IMAGE_WIDTH; ++x)
            {
                double xpos = x * dx;
                double ypos = y * dy;
                double val = noise.Generate(xpos, ypos);
                int rgb = EvalGrayscale(val);
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

