using App2.Models;
using App2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewsPage : ContentPage
    {
        public NewsPage()
        {
            InitializeComponent();
        }
        private async void OnItemSelected(object sender, ItemTappedEventArgs e)
        {

            var mydetails = e.Item as Posts;
            await Navigation.PushAsync(new MyListPageDetail(mydetails.head, mydetails.body, mydetails.preview_picture));
        }
        private void Cell_OnTapped(object sender, EventArgs e)
        {
            var viewCell = (ViewCell)sender;
            if (viewCell.View != null)
            {
                ;
                viewCell.View.BackgroundColor = Color.White;
            }
        }
    }
}