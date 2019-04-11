using System;
using System.Collections.Generic;
using System.Text;

namespace MusicFactory.Models
{
    public class SectionFrequency
    {
        public int Octave { get; }

        public Dictionary<Keys, float> Frequencies { get; }

        public SectionFrequency(int octave)
        {
            switch (octave)
            {
                case 1:
                    {
                        Frequencies = new Dictionary<Keys, float>()
                        {
                            {Keys.C, 32.703f },
                            {Keys.Cd, 34.648f },
                            {Keys.D, 36.708f },
                            {Keys.Dd, 38.891f },
                            {Keys.E, 41.203f },
                            {Keys.F, 43.654f },
                            {Keys.Fd, 46.249f },
                            {Keys.G, 48.999f },
                            {Keys.Gd, 51.913f },
                            {Keys.A, 55f },
                            {Keys.Ad, 58.27f },
                            {Keys.B, 61.735f }
                        };
                        break;
                    }
                case 4:
                    {
                        Frequencies = new Dictionary<Keys, float>()
                        {
                            {Keys.C, 261.63f },
                            {Keys.Cd, 277.18f },
                            {Keys.D, 293.66f },
                            {Keys.Dd, 311.13f },
                            {Keys.E, 329.63f },
                            {Keys.F, 349.23f },
                            {Keys.Fd, 369.99f },
                            {Keys.G, 392f },
                            {Keys.Gd, 415.3f },
                            {Keys.A, 440f },
                            {Keys.Ad, 466.16f },
                            {Keys.B, 493.88f }
                        };
                        break;
                    }
            }
        }
    }
}
