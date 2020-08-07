using System;
using Realms;
using System.Collections.Generic;
using System.Text;

namespace App2.Models
{
    public class RealmItem : RealmObject
    {
        public string access_key { get; set; }
        public string name { get; set; }
        public string birthday { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
    }
}
