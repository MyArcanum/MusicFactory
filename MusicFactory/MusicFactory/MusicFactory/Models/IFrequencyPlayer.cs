using System;
using System.Collections.Generic;
using System.Text;

namespace MusicFactory.Models
{
    public interface IFrequencyPlayer
    {
        void Init(Dictionary<Keys, float> frequencies);

        void Play(Keys key);
    }
}
