using System;
using System.Threading.Tasks;

namespace noise
{
    class Perlin
    {
        const ushort PERMARRAYSIZE = 512;  // should be 2^n
        private static readonly int[] perm = new int[PERMARRAYSIZE];

        public Perlin()
        {
            FillPermArray();
        }

        private double Fade(double t)
        {
            return Math.Pow(t, 3) * (t * (t * 6 - 15) + 10);  // 6t^5 - 15t^4 + 10t^3
        }


        private void FillPermArray()
        {
            Random rnd = new Random();
            for (int i = 0; i < PERMARRAYSIZE; i++)
            {
                perm[i] = rnd.Next(0, 255);
            }
        }

        public int[] GetPermArray() { return perm; }


    }


}
