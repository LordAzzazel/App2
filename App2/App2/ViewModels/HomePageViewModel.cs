using App2.Models;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace App2.ViewModels
{
    public class HomePageViewModel
    {
        private readonly Realm realm;
        public IEnumerable<RealmItem> Items { get; }
        public Command OnTapped { get; set; }
        public HomePageViewModel()
        {
            realm = Realm.GetInstance();
            Items = realm.All<RealmItem>().ToList();
            Init();
            
        }
        private void Init()
        {
            var realm = Realm.GetInstance();
            var tok = realm.All<RealmItem>().First();
            Application.Current.Properties["token"] = tok.access_key;
        }

        
    }
}
