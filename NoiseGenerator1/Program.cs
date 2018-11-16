using noise;
using System.Runtime.InteropServices;

class Program
{
    public static void Main(string[] args)
    {
        main();

        const int IMAGE_WIDTH = 512;
        const int IMAGE_HEIGTH = IMAGE_WIDTH;
        double FREQUENCY_X = 4;
        double FREQUENCY_Y = FREQUENCY_X;
        const string OUTPUT_FILE = "C:/Users/Stable-tec/Pictures/test.png";

        //IController generator = new Controller(IMAGE_WIDTH, IMAGE_HEIGTH, FREQUENCY_X, FREQUENCY_Y, OUTPUT_FILE);
        //generator.Run();
    }

    [DllImport("cpp4.dll", EntryPoint = "main")]
    public static extern void main();
}

