using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MusicFactory.Models
{
    public abstract class PianoKey : ButtonDown
    {
        public virtual Size Size { get; set; }

        public int RelativeIndex { get; set; }

        public int Frequency { get; set; }

        public Color KeyColor { get { return BackgroundColor; } protected set { BackgroundColor = value; } }

        public PianoKey()
        {
            Padding = new Xamarin.Forms.Thickness(0, 0, 0, 0);
            BorderWidth = 1;
            BorderColor = Color.Gray;
        }
    }

    public class WhiteKey : PianoKey
    {
        public WhiteKey()
        {
            KeyColor = Color.White;
        }
    }

    public class BlackKey : PianoKey
    {
        private float Scale = 0.5F;

        public BlackKey()
        {
            KeyColor = Color.Black;
        }

        public override Size Size => new Size { Height = (int)(Size.Height * Scale), Width = (int)(Size.Width * Scale) };

    }
}
