using MusicFactory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MusicFactory.Views
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

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PianoPage : ContentPage
    {
        public List<ButtonDown> WhiteKeys { get; set; }

        public List<ButtonDown> BlackKeys { get; set; }

        public Size PageSize { get; }

        public PianoPage()
        {
            InitializeComponent();

            SizeChanged += (s, a) => DrawKeyboard();
        }

        private void DrawKeyboard()
        {
            MainKeyboard.HeightRequest = Height * 0.8;
            var PageSize = new Size() { Height = this.Height, Width = this.Width };

            var relativeLen = Width / 42;

            // math rule for black keys in section
            var BlackRule = new Dictionary<int, int>
            {
                {0, 6 },
                {1, 0 },
                {2, 6 },
                {3, 0 },
                {4, 0 }
            };

            // relative size for white key. Same as values from BlackRule
            //var WhiteRelativeSize = new System.Drawing.Size { Width = 6 };

            BlackKeyboard.Spacing = relativeLen * 2;
            BlackKeyboard.Padding = new Thickness(relativeLen * -2, 0, 0, 0);

            // 12 keys in one section
            var section = 12;

            int i = 0;
            foreach(BlackKey bk in BlackKeyboard.Children)
            { 
                bk.Clicked += (s, a) => PlayTone((Keys)i);
                bk.WidthRequest = relativeLen * 4;
                bk.Margin = new Thickness(BlackRule[i % section] * relativeLen, 0, 0, PageSize.Height * 0.4);
                i++;
            }

            foreach (WhiteKey wk in WhiteKeyboard.Children)
            {
                wk.Clicked += (s, a) => PlayTone((Keys)i);
                wk.WidthRequest = relativeLen * 6;
                i++;
            }
        }

        /*
        for (var i = 1; i < 13; i++)
        {
            if (BlackRule.Keys.Contains(i))
            {
                var bk = new BlackKey() { RelativeIndex = i, WidthRequest = relativeLen * 4 };
                bk.Margin = new Thickness(BlackRule[i % section].Width * relativeLen, 0, 0, PageSize.Height * 0.4);
                BlackKeys.Add(bk);
            }
            else
                WhiteKeys.Add(new WhiteKey() { RelativeIndex = i, WidthRequest = relativeLen * 6, VerticalOptions = LayoutOptions.FillAndExpand });
        }


        foreach (var wk in WhiteKeys)
            WhiteKeyboard.Children.Add(wk);

        foreach (var bk in BlackKeys)
            BlackKeyboard.Children.Add(bk);
            */

        public void PlayTone(Keys key)
        {
            DependencyService.Get<IFrequencyPlayer>().Play(200, 200);
        }
    }



}

