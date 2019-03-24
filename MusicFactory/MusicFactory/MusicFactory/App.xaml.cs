using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MusicFactory.Views;
using Utilities;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MusicFactory
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();


            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public static void UpdateThemeColors(ColorScheme scheme)
        {
            Current.Resources["mainColor"] = XFUtilities.GetColorFromInt(scheme.MainColor);
            Current.Resources["highlightColor"] = XFUtilities.GetColorFromInt(scheme.HighlightColor);
            Current.Resources["buttonColor"] = XFUtilities.GetColorFromInt(scheme.ButtonColor);
            Current.Resources["backgroundColor"] = XFUtilities.GetColorFromInt(scheme.BackgroundColor);
        }
    }
}
