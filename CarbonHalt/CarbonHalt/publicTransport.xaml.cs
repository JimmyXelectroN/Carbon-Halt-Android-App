﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarbonHalt
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class publicTransport : ContentPage
    {
        private double privateTransportEmissions;
        private double publicTransportEmissions = 0;
        public publicTransport(double _privateTransportEmissions)
        {
            InitializeComponent();
            privateTransportEmissions = _privateTransportEmissions;
        }

        async void OnNextClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AirTransport(privateTransportEmissions + publicTransportEmissions)
            {
            });
        }
    }
}