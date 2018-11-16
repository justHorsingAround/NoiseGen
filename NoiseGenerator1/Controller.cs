using System;
using System.Drawing;

namespace noise
{
    class Controller : IController
    {
        OctavesCollection oc = new OctavesCollection();
        private const ushort OPTIMAL_LAYER_NUMBER = 8;
        private readonly int IMAGE_WIDTH;
        private readonly int IMAGE_HEIGHT;
        private readonly double FREQUENCY_X;
        private readonly double FREQUENCY_Y;
        private readonly string OUTPUT_FILE_PATH;
        private Bitmap bmp;

        public Controller(int IMAGE_WIDTH, int IMAGE_HEIGHT, double FREQUENCY_X, double FREQUENCY_Y, string OUTPUT_FILE_PATH)
        {
            this.IMAGE_WIDTH = IMAGE_WIDTH;
            this.IMAGE_HEIGHT = IMAGE_HEIGHT;
            this.FREQUENCY_X = FREQUENCY_X;
            this.FREQUENCY_Y = FREQUENCY_Y;
            this.OUTPUT_FILE_PATH = OUTPUT_FILE_PATH;
            bmp = new Bitmap(IMAGE_WIDTH, IMAGE_HEIGHT);
        }

        public void Run()
        {
            InitPerlinObjectList();
            GenerateNoise();
        }

        private void InitPerlinObjectList()
        {
            for (int i = 1; i <= OPTIMAL_LAYER_NUMBER; i++)
            {
                oc.AddToOctaves(new Octave(new Perlin(), Math.Pow(0.5, i)));
            }
        }

        private void GenerateNoise()
        {
            double dx = FREQUENCY_X / IMAGE_WIDTH;
            double dy = FREQUENCY_Y / IMAGE_HEIGHT;

            for (int y = 0; y < IMAGE_HEIGHT; ++y)
            {
                for (int x = 0; x < IMAGE_WIDTH; ++x)
                {
                    double xpos = x * dx;
                    double ypos = y * dy;
                    double res = 0;

                    IterateOverStoredLayers(ref res, OPTIMAL_LAYER_NUMBER, xpos, ypos);
                    RaiseDifference(ref res);
                    BurnResultIntoImage(res, x, y);
                }
            }
            SaveBmpFileAsPng(bmp);
        }

        private int EvalGrayscale(double value)
        {
            return (int)(255 * (value + 1) / 2);
        }

        private void IterateOverStoredLayers(ref double result, int collectionLen, double xpos, double ypos)
        {
            for (int i = 0; i < collectionLen; i++)
            {
                Octave current = oc.octaves[i];
                double scale = current.GetAmplitude();
                result += current.perlin.Generate(xpos * (i + 1) * (i + 1), ypos * (i + 1) * (i + 1)) * scale;   
            }
        }

        private double RaiseDifference(ref double result)
        {
            return result *= Math.Sqrt(2);
        }

        private void SaveBmpFileAsPng(Bitmap bmp)
        {
            bmp.Save(OUTPUT_FILE_PATH);
        }

        private void BurnResultIntoImage(in double result, in int x, in int y)
        {
            int rgb = EvalGrayscale(result);
            bmp.SetPixel(x, y, Color.FromArgb(255, rgb, rgb, rgb));
        }
    }
}

