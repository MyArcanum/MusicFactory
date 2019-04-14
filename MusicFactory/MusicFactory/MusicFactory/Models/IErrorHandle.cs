using System;
using System.Collections.Generic;
using System.Text;

namespace MusicFactory.Models
{
    public interface IErrorHandle
    {
        void SendTrace(Exception e);
    }
}
