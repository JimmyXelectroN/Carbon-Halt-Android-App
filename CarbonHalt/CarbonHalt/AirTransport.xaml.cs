using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarbonHalt
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AirTransport : ContentPage
    {
        public AirTransport()
        {
            InitializeComponent();
            hours.Value = CO2EmissionCalculator.flightHours;
        }

        async void OnNextClicked(object sender, EventArgs e)
        {

            CO2EmissionCalculator.flightHours = hours.Value;
            await Navigation.PushAsync(new Food());
        }

        async void OnBackClicked(object sender, EventArgs e)
        {
            CO2EmissionCalculator.flightHours = hours.Value;
            await Navigation.PopAsync();
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        protected void OnValueChanged(object sender, EventArgs e)
        {
            label.Text = "" + hours.Value;
        }

    }
}