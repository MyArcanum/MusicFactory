using Plugin.SimpleAudioPlayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Xamarin.Forms;
using Utilities;
using MusicFactory.Models;
using Xamarin.Forms.Xaml;

namespace MusicFactory.Views
{
    public enum DrumType
    {
        TomTom,
        Snare1,
        Snare2,
        Clap,
        HiHat1,
        HiHat2,
        Shake,
        Bass1,
        Bass2,
        count
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DrumPage : ContentPage
    {
        ISimpleAudioPlayer[] players = new ISimpleAudioPlayer[(int)DrumType.count];
        Animation[] animations = new Animation[(int)DrumType.count];

        List<Note> recording = new List<Note>();

        bool isRecording = false;
        bool isPlaying = false;
        long recordingStart;

        public DrumPage()
        {
            //force color scheme for now
            Preferences.Intstance.ColorScheme = ColorSchemes.Schemes[0];

            var player = CrossSimpleAudioPlayer.Current;


            for (int i = 0; i < (int)DrumType.count; i++)
            {
                players[i] = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
                players[i].Loop = false;
            }

            InitializeComponent();

            int j = 0;
            foreach (ButtonDown button in gridButtons.Children)
            {
                DrumType drum = (DrumType)j;
                button.Pressed += (s, e) => OnDrumButton(drum);
                j++;
            }

            btnRecord.Pressed += BtnRecordClicked;
            btnPlay.Pressed += BtnPlayClicked;

            btnSettings.Pressed += (s, e) => Navigation.PushAsync(new ColorSchemePage());

            Preferences.Intstance.ColorSchemeUpdated += ColorSchemeUpdated;

            //to set the animations
            ColorSchemeUpdated(this, Preferences.Intstance.ColorScheme.SchemeType);
        }

        void ColorSchemeUpdated(object sender, ColorSchemeType e)
        {
            Color colorButton = XFUtilities.GetColorFromInt(Preferences.Intstance.ColorScheme.ButtonColor);
            Color colorMain = XFUtilities.GetColorFromInt(Preferences.Intstance.ColorScheme.MainColor);
            Color colorHighlight = XFUtilities.GetColorFromInt(Preferences.Intstance.ColorScheme.HighlightColor);

            int j = 0;
            foreach (Button button in gridButtons.Children)
            {
                button.BackgroundColor = colorButton;
                button.TextColor = colorHighlight;
                animations[j++] = new Animation(v => button.BackgroundColor = GetBlendedColor(colorButton, colorMain, v), 0, 1);
                
            }

            //imgLogo.Source = ImageSource.FromResource("DrumPad.Images." + Preferences.Intstance.ColorScheme.Logo);
        }

        private void BtnPlayClicked(object sender, EventArgs e)
        {
            if (isRecording || recording.Count == 0)
                return;

            isPlaying = !isPlaying;

            int index = 0;

            var start = DateTime.Now.Ticks;

            //8ms ~ 120hz (ideal)

            Device.StartTimer(new TimeSpan(0, 0, 0, 0, 8), () =>
            {
                if (!isPlaying)
                    return false;

                if (index >= recording.Count)
                {
                    index = 0;
                    start = DateTime.Now.Ticks;
                    //return false;
                }

                    if (DateTime.Now.Ticks - start >= recording[index].Ticks)
                {
                    index++;
                    OnDrumButton(recording[index - 1].DrumType);
                }

                return true;
            });

        }

        private void BtnRecordClicked(object sender, EventArgs e)
        {
            isPlaying = false;

            if (isRecording == true)
            {
                isRecording = false;
                btnRecord.Text = "Record";
                return;
            }

            btnRecord.Text = "Recording";
            recording.Clear();
            isRecording = true;
            recordingStart = DateTime.Now.Ticks;
        }

        void PickerKitsSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = sender as Picker;

            LoadSamples(picker.SelectedIndex + 1);
        }

        void OnDrumButton(DrumType drumType)
        {
            if (isRecording)
                recording.Add(new Note(DateTime.Now.Ticks - recordingStart, drumType));

            players[(int)drumType]?.Play();
            animations[(int)drumType]?.Commit(this, drumType.ToString());
        }

        void LoadSamples(int index)
        {
            if (index < 1 || index > 2)
                return;

            var folder = (index == 1) ? "Rock" : "Techno";

            try
            {

                players[(int)DrumType.Bass1].Load(GetStreamFromFile($"Audio.{folder}.bd1.wav"));
                players[(int)DrumType.Bass2].Load(GetStreamFromFile($"Audio.{folder}.bd2.wav"));
                players[(int)DrumType.Clap].Load(GetStreamFromFile($"Audio.{folder}.clap.wav"));
                players[(int)DrumType.HiHat1].Load(GetStreamFromFile($"Audio.{folder}.hh1.wav"));
                players[(int)DrumType.HiHat2].Load(GetStreamFromFile($"Audio.{folder}.hh2.wav"));
                players[(int)DrumType.Shake].Load(GetStreamFromFile($"Audio.{folder}.shake.wav"));
                players[(int)DrumType.Snare1].Load(GetStreamFromFile($"Audio.{folder}.sd1.wav"));
                players[(int)DrumType.Snare2].Load(GetStreamFromFile($"Audio.{folder}.sd2.wav"));
                players[(int)DrumType.TomTom].Load(GetStreamFromFile($"Audio.{folder}.tt1.wav"));
            }
            catch (Exception e)
            {

            }
        }
      
        Stream GetStreamFromFile(string filename)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream("MusicFactory." + filename);

            return stream;
        }

        Color GetBlendedColor(Color color1, Color color2, double percentage)
        {
            return new Color(percentage * color1.R + (1 - percentage) * color2.R,
                             percentage * color1.G + (1 - percentage) * color2.G,
                             percentage * color1.B + (1 - percentage) * color2.B);
        }
    }
}