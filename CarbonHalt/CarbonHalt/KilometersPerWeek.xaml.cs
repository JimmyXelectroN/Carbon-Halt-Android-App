using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CarbonHalt.Models;

namespace CarbonHalt
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KilometersPerWeek : ContentPage
    {
        private double km;

        public KilometersPerWeek()
        {
            InitializeComponent();
        }

        async void OnNextClicked(object sender, EventArgs e)
        {
            km = slider.Value;
            CO2EmissionCalculator.kilometersTravelledPrivate = km;
            /*
            await App.Database.SaveEmissionLevelAsync(new emissionLevel
            {
                TimeRecorded = DateTime.Now.Date.ToString("MMMM dd"),
                Co2 = CO2EmissionCalculator.CalculateCO2()
            });*/
            await Navigation.PushAsync(new publicTransport()
            {
            });
        }
    }
}