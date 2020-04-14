﻿using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections;
using SQLite;
using Android.Arch.Lifecycle;
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
            //(BindingContext as ViewModel).Data = App.Database.GetEmissionLevels();
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

            isRowEven = !isRowEven;
        }

    }
}