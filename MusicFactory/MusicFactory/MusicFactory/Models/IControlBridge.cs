using System;
using System.Collections.Generic;
using System.Text;

namespace MusicFactory.Models
{
    public interface IControlBridge
    {
        void OpenRecorder();

        void ToggleMetronom(out int freq);
    }
}
