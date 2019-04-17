using MusicFactory.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MusicFactory.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            //MenuPages.Add((int)MenuItemType.Drums, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            try
            {
                if (!MenuPages.ContainsKey(id))
                {
                    switch (id)
                    {
                        //case (int)MenuItemType.Browse:
                        //    MenuPages.Add(id, new NavigationPage(new ItemsPage()));
                        //    break;
                        case (int)MenuItemType.Drums:
                            MenuPages.Add(id, new NavigationPage(new DrumPage()));
                            break;
                        case (int)MenuItemType.Piano:
                            MenuPages.Add(id, new NavigationPage(new PianoPage()));
                            break;
                        case (int)MenuItemType.About:
                            MenuPages.Add(id, new NavigationPage(new AboutPage()));
                            break;
                        case (int)MenuItemType.Metronom:
                            DependencyService.Get<IControlBridge>().ToggleMetronom(out int freq);
                            PianoPage.MetronomFreq = freq;
                            break;
                            //case (int)MenuItemType.Record:
                            //    DependencyService.Get<IControlBridge>().OpenRecorder();
                            //    break;
                    }
                }

                if (id == (int)MenuItemType.Metronom) return;

                var newPage = MenuPages[id];

                if (newPage != null && Detail != newPage)
                {
                    Detail = newPage;

                    if (Device.RuntimePlatform == Device.Android)
                        await Task.Delay(100);

                    IsPresented = false;
                }
            }
            catch(Exception e)
            {
                DependencyService.Get<MusicFactory.Models.IErrorHandle>().SendTrace(e);
            }
        }
    }
}