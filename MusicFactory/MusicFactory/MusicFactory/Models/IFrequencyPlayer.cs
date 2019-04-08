using System;
using System.Collections.Generic;
using System.Text;

namespace MusicFactory.Models
{
    public interface IFrequencyPlayer
    {
        void Play(int frequency, int duration);
    }
}
