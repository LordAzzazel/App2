using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace App2.Models
{
    public class UserConnection
    {
        public bool isStopped;
        public async void AddData(string number, string password)
        {

            using (var client = new HttpClient())
            {
                var apiLogin = "http://cabinets.itmit-studio.ru/api/login";
                var data = "{\"phone\" : \"" + number + "\", \"password\" : \"" + password + "\"}";
                var contentRequest = new StringContent(data, Encoding.UTF8, "application/json");

                var responce = await client.PostAsync(apiLogin, contentRequest);
                if (responce.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    HttpContent content = responce.Content;
                    string jsonString = await content.ReadAsStringAsync();
                    var x = JObject.Parse(jsonString);
                    UserRepository ur = new UserRepository();
                    var token = x["data"]["access_token"];
                    var name = x["data"]["client"]["name"];
                    var birthday = x["data"]["client"]["birthday"];
                    var phone = x["data"]["client"]["phone"];
                    var email = x["data"]["client"]["email"];

                    Item a = new Item { access_key = token.ToString(), name = name.ToString(), birthday = birthday.ToString(), phone = phone.ToString(), email = email.ToString() };
                    ur.Add(a);


                    App.Current.MainPage = new MainPage();

                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Login", "Login Failed", "Ok");
                    return;
                }
            }
            
        }
    }
}
