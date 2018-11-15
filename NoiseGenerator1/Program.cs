using System;
using noise;

class Program
{
    static void Main(string[] args)
    {
        Perlin core = new Perlin();
        Console.WriteLine(core.Generate(0.5));
        Console.Read();
       
    }
}

