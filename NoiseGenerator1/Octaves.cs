using System.Collections.Generic;

namespace noise
{

    class Octave
    {
        internal Perlin perlin;
        private double amplitude;

        public Octave(Perlin p, double amplitude)
        {
            this.perlin = p;
            this.amplitude = amplitude;
        }

        public double GetAmplitude() { return amplitude; }
    }

    class OctavesCollection
    {
        internal List<Octave> octaves = new List<Octave>();

        public int Size() { return octaves.Count; }
        public void AddToOctaves(Octave oct)
        {
            octaves.Add(oct);
        }
    }
}
