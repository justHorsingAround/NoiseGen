using System;
using noise;

class Program
{
    static void Main(string[] args)
    {
        Perlin core = new Perlin();
        int[] test = core.GetPermArray();
        foreach(int element in test)
        {
            Console.Write(element + " ");

        }
        Console.Read();
       
    }
}

