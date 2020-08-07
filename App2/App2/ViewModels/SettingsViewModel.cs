using App2.Views;
using Realms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace App2.ViewModels
{
    public class SettingsViewModel
    {
        public SettingsViewModel()
        {
            Leave = new Command(() =>
            {
                var realm = Realm.GetInstance();
                realm.Write(() =>
                {
                    realm.RemoveAll();
                });
                App.Current.MainPage = new LoginPage();
            });
        }
        public Command Leave { get; set; }

    }
}
