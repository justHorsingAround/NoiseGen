using System;
using noise;
using System.Drawing;
using System.IO;

class Program
{
     public static void Main(string[] args)
     {
        const int IMAGE_WIDTH = 512; 
        const int IMAGE_HEIGHT = IMAGE_WIDTH; 
        double FREQUENCY_X = 2.5;
        double FREQUENCY_Y = FREQUENCY_X;

        OctavesCollection oc = new OctavesCollection();
        const ushort OPTIMAL_LAYER_NUMBER = 8;

        for (int i = 1; i <= OPTIMAL_LAYER_NUMBER; i++)
        {
            oc.AddToOctaves(new Octave(new Perlin(), Math.Pow(0.5, i)));
          
        }

        var bmp = new Bitmap(IMAGE_WIDTH, IMAGE_HEIGHT);
        double dx = FREQUENCY_X / IMAGE_WIDTH;
        double dy = FREQUENCY_Y / IMAGE_HEIGHT;
        for (int y = 0; y < IMAGE_HEIGHT; ++y)
        {
            for (int x = 0; x < IMAGE_WIDTH; ++x)
            {
                double xpos = x * dx;
                double ypos = y * dy;
                int collectionLen = oc.Size();
                double res = 0;
                for (int i = 0; i < collectionLen; i++)
                {
                    Octave current = oc.octaves[i];
                    double scale = current.GetAmplitude();
                    res += current.perlin.Generate(xpos * (i + 1) * (i + 1), ypos * (i + 1) * (i + 1)) * scale;
                }
                res *= Math.Sqrt(2);
                int rgb = EvalGrayscale(res);                   
                bmp.SetPixel(x, y, Color.FromArgb(255, rgb, rgb, rgb));
            }
        }

        bmp.Save("C:/Users/Stable-tec/Pictures/test.png");
        //Console.Read();
    }

    public static int EvalGrayscale(double value)
    {
   
        return (int)(255 * (value + 1) / 2);
    }
}

