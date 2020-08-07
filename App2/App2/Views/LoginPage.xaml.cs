using App2.Models;
using App2.ViewModels;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            Init();
            BindingContext = new LoginPageViewModel();
        }

        private void Init()
        {
            BackgroundColor = Constants.backgroundColor;
            labelName.TextColor = Constants.mainTextColor;
            labelPassoword.TextColor = Constants.mainTextColor;
            activitySpinner.IsVisible = false;
            LoginIcon.HeightRequest = Constants.loginIconHeight;
            entryNumber.Completed += (s, e) => entryPassword.Focus();
            entryPassword.Completed += (s, e) => signInButton.Focus();
        }
    }
}