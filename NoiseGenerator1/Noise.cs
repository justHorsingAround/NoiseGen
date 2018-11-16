using System;

namespace noise
{
    class Perlin
    {
        const ushort PERM_ARRAY_SIZE = 512;  // should be 2^n
        private readonly int[] perm = new int[PERM_ARRAY_SIZE];

        public Perlin()
        {
            FillPermArray();
        }

        private double Fade(double t)
        {
            return Math.Pow(t, 3) * (t * (t * 6 - 15) + 10);  // 6t^5 - 15t^4 + 10t^3
        }

        private double Lerp(double t, double a, double b)
        {
            return a + t * (b - a);
        }

        private double Grad(int hash, double x, double y, double z)
        {
            var h = hash & 15;
            var u = h < 8 ? x : y;
            var v = h < 4 ? y : h == 12 || h == 14 ? x : z;
            return ((h & 1) == 0 ? u : -u) + ((h & 2) == 0 ? v : -v);
        }

        private double Noise(double x, double y, double z)
        {
            var unit_x = (int)Math.Floor(x) & 255;
            var unit_y = (int)Math.Floor(y) & 255;
            var unit_z = (int)Math.Floor(z) & 255;
            var sub_x = x - Math.Floor(x);
            var sub_y = y - Math.Floor(y);
            var sub_z = z - Math.Floor(z);

            var u = Fade(sub_x);
            var v = Fade(sub_y);
            var w = Fade(sub_z);

            var a = perm[unit_x] + unit_y;
            var aa = perm[a] + unit_z;
            var ab = perm[a + 1] + unit_z;
            var b = perm[unit_x + 1] + unit_y;
            var ba = perm[b] + unit_z;
            var bb = perm[b + 1] + unit_z;

            return Lerp(w, Lerp(v, Lerp(u, Grad(perm[aa], sub_x, sub_y, sub_z), Grad(perm[ba], sub_x - 1, sub_y, sub_z)),
                           Lerp(u, Grad(perm[ab], sub_x, sub_y - 1, sub_z), Grad(perm[bb], sub_x - 1, sub_y - 1, sub_z))
                        ),
                            Lerp(v, Lerp(u, Grad(perm[aa + 1], sub_x, sub_y, sub_z - 1), Grad(perm[ba + 1], sub_x - 1, sub_y, sub_z - 1)),
                            Lerp(u, Grad(perm[ab + 1], sub_x, sub_y - 1, sub_z - 1), Grad(perm[bb + 1], sub_x - 1, sub_y - 1, sub_z - 1))
                        )
                    );
        }

        public double Generate(double x = 0.0, double y = 0.0, double z = 0.0)
        {
           return Noise(x, y, z);
        }


        private void FillPermArray()
        {
            Random rnd = new Random();
            for (int i = 0; i < PERM_ARRAY_SIZE; i++)
            {
                perm[i] = rnd.Next(0, 255);
            }
        }

        public int[] GetPermArray() { return perm; }


    }


}
