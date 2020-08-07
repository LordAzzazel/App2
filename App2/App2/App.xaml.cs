using App2.Models;
using App2.Views;
using Realms;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2
{
    public partial class App : Application
    {
        private Realm realm;

        public App()
        {
            InitializeComponent();

            realm = Realm.GetInstance();


            try
            {
                var results = realm.All<RealmItem>().First();

            }
            catch (System.InvalidOperationException)
            {
                MainPage = new LoginPage();
                return;
            }
            
             App.Current.MainPage = new MainPage();

            
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
