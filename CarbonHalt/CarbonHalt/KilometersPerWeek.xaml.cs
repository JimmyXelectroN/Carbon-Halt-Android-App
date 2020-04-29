using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CarbonHalt.Models;

namespace CarbonHalt
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KilometersPerWeek : ContentPage
    {

        public KilometersPerWeek()
        {
            InitializeComponent();
            slider.Value = CO2EmissionCalculator.kilometersTravelledPrivate;
        }

        async void OnNextClicked(object sender, EventArgs e)
        {
            CO2EmissionCalculator.kilometersTravelledPrivate = slider.Value;

            await Navigation.PushAsync(new publicTransport());
        }

        async void OnBackClicked(object sender, EventArgs e)
        {
            CO2EmissionCalculator.kilometersTravelledPrivate = slider.Value;
            await Navigation.PopAsync();
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        async void OnValueChanged(object sender, EventArgs e) 
        {
            label.Text = "" + slider.Value;
        }
    }
}