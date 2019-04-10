using System;
using System.Collections.Generic;
using System.Text;

namespace MusicFactory.Models
{
    /// <summary>
    /// Note representations of piano keys. Firstly there go 5 black keys (with 'd' char that means 'dies') for convenience in next algorithms.
    /// Then there go white keys.
    /// </summary>
    public enum Keys
    {
        Cd = 0,
        Dd,
        Fd,
        Gd,
        Ad,
        C,
        D,
        E,
        F,
        G,
        A,
        B
    }
}
