using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MusicFactory.Models;

[assembly: Xamarin.Forms.Dependency(typeof(MusicFactory.Droid.GmailSender))]
namespace MusicFactory.Droid
{
    public class GmailSender : IErrorHandle
    {
        public void SendTrace(Exception e)
        {
            var email = new Intent(Intent.ActionSend);

            email.PutExtra(Intent.ExtraText, e.Message + "\n"+ e.StackTrace);
            var l = new List<string>();
            l.Add("ja.mishaka@gmail.com");
            email.PutExtra(Intent.ExtraEmail, l.ToArray());
            email.PutExtra(Intent.ExtraSubject, "Crash report");
            email.SetType("message/rfc822");

            MainActivity.Current.StartActivity(email);
        }
    }
}