using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;
using CarbonHalt.Models;
using System;

namespace CarbonHalt
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class History : ContentPage
    {
        private bool isRowEven;
        public History()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var list = App.Database.GetEmissionLevels().Result;
            list.Reverse();
            listView.ItemsSource = new List<emissionLevel>(list);
        }

        private void CellAppearing(object sender, EventArgs e) 
        {
            if (isRowEven)
            {
                var viewCell = (ViewCell)sender;
                if (viewCell.View != null)
                {
                    viewCell.View.BackgroundColor = Color.White;
                }
            }
            else 
            {
                var viewCell = (ViewCell)sender;
                if (viewCell.View != null)
                {
                    viewCell.View.BackgroundColor = Color.Gainsboro;
                }
            }

            isRowEven = !isRowEven;
        }

        async void OnDashboardClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

    }
}