using System.Collections.Generic;

namespace perlin
{

    class Octave
    {
        public double noise;
        public double amplitude;
    }

    class OctavesCollection
    {
        private List<Octave> octaves = new List<Octave>();

        public List<Octave> getOctaves() { return octaves; }
        public void AddToOctaves(Octave oct)
        {
            octaves.Add(oct);
        }
    }
}
