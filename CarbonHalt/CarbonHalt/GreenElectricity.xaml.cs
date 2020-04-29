using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CarbonHalt.Models;

namespace CarbonHalt
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GreenElectricity : ContentPage
    {
        private bool green;
        private bool buttonPressed;
        public GreenElectricity()
        {

            InitializeComponent();
            green = CO2EmissionCalculator.green;
        }

        async void OnNextClicked(object sender, EventArgs e)
        {
            if (buttonPressed) {
                CO2EmissionCalculator.green = green;
                await Navigation.PushAsync(new RenewableEnergy());
            }
        }

        async void OnBackClicked(object sender, EventArgs e)
        {
            CO2EmissionCalculator.green = green;
            await Navigation.PopAsync();
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        async void OnYesClicked(object sender, EventArgs e)
        {
            nextLabel.TextColor = Color.DimGray;
            nextIcon.Source = "next.png";

            buttonPressed = true;
            green = true;
            yes.BackgroundColor = Color.AliceBlue;
            no.BackgroundColor = Color.Transparent;
        }

        async void OnNoClicked(object sender, EventArgs e)
        {
            nextLabel.TextColor = Color.DimGray;
            nextIcon.Source = "next.png";

            buttonPressed = true;
            green = false;
            yes.BackgroundColor = Color.Transparent;
            no.BackgroundColor = Color.AliceBlue;
        }
    }
}