using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CarbonHalt.Models;

namespace CarbonHalt
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class publicTransport : ContentPage
    {
        public publicTransport()
        {
            InitializeComponent();
            train.Value = CO2EmissionCalculator.trainKm;
            metro.Value = CO2EmissionCalculator.metroKm;
            bus.Value = CO2EmissionCalculator.busKm;
        }

        async void OnNextClicked(object sender, EventArgs e)
        {
            CO2EmissionCalculator.trainKm = train.Value;
            CO2EmissionCalculator.metroKm = metro.Value;
            CO2EmissionCalculator.busKm = bus.Value;

            await Navigation.PushAsync(new AirTransport());
        }

        async void OnBackClicked(object sender, EventArgs e)
        {
            CO2EmissionCalculator.trainKm = train.Value;
            CO2EmissionCalculator.metroKm = metro.Value;
            CO2EmissionCalculator.busKm = bus.Value;
            await Navigation.PopAsync();
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        async void OnTrainChanged(object sender, EventArgs e)
        {
            label.Text = "" + train.Value;
        }

        async void OnMetroChanged(object sender, EventArgs e)
        {
            label2.Text = "" + metro.Value;
        }

        async void OnBusChanged(object sender, EventArgs e)
        {
            labe3.Text = "" + bus.Value;
        }
    }
}