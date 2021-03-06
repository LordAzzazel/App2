﻿using App2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace App2.ViewModels
{
    public class NewsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Posts> postsList { get; set; }
        public ObservableCollection<Posts> PostsList
        {
            get
            {
                return postsList;
            }
            set
            {
                if (value != postsList)
                {
                    postsList = value;
                    NotifyPropertyChanged();
                }
            }
        }
        /*private Posts selectedPost { get; set; }
        public Posts SelectedPost
        {
            get { return selectedPost; }
            set
            {
                if (selectedPost != value)
                {
                    selectedPost = value;
                    HandleSelectedItem();
                    NotifyPropertyChanged();
                }
            }

        }
        private void HandleSelectedItem()
        {
            Page page = new Page();
            page.DisplayAlert("Selected item", "Name: " + SelectedPost.head, "Ok");
        }*/

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public NewsViewModel()
        {
            GetDataAsync();
        }
        private async void GetDataAsync()
        {
            var access_token = Application.Current.Properties["token"].ToString();
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access_token);
            var result = await client.GetAsync("http://cabinets.itmit-studio.ru/api/news");
            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(content);
                PostsList = myDeserializedClass.Data;
            }


        }
    }
}
