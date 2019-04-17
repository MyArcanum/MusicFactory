using System;
using System.Collections.Generic;
using System.Text;

namespace MusicFactory.Models
{
    public interface IControlBridge
    {
        void SendTrace(Exception e);

        void Share();
    }
}
