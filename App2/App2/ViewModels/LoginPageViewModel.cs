using App2.Models;
using App2.Views;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Runtime.Serialization;

namespace App2.ViewModels
{
    public class LoginPageViewModel
    {
        string number;
        string password;
        public Command connect { get; set; }
        public string Number
        {
            get => number;
            set
            {
                number = value;
            }
        }
        public string Password
        {
            get => password;
            set
            {
                password = value;
            }
        }

        public LoginPageViewModel()
        {
            Init();
            connect = new Command(() =>
            {
                Connection();
            });
        }
        
        public void Init()
        {
            Password = "x5410041";
            Number = "+7 (911) 447-11-83";
        }
        public async void Connection()
        {

            var number = Number;
            var password = Password;
            if (string.IsNullOrEmpty(number) && string.IsNullOrEmpty(password))
            {
                await Application.Current.MainPage.DisplayAlert("Login", "Login Not Correct", "Ok");
                return;
            }
            UserConnection ur = new UserConnection();
        
            ur.AddData(number, password);
           

            App.Current.MainPage = new MainPage();
        }
        

    }
}
