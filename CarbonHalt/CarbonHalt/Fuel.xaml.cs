using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarbonHalt
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Fuel : ContentPage
    {
        private int fuelType;
        public Fuel()
        {

            InitializeComponent();

            fuelType = CO2EmissionCalculator.fuelType;

            if (fuelType == 1)
            {
                nextLabel.TextColor = Color.DimGray;
                nextIcon.Source = "next.png";

                diesel.BackgroundColor = Color.AliceBlue;
                petrol.BackgroundColor = Color.Transparent;
                electricity.BackgroundColor = Color.Transparent;
            }
            else if (fuelType == 2)
            {
                nextLabel.TextColor = Color.DimGray;
                nextIcon.Source = "next.png";

                diesel.BackgroundColor = Color.Transparent;
                petrol.BackgroundColor = Color.AliceBlue;
                electricity.BackgroundColor = Color.Transparent;
            }
            else if (fuelType == 3)
            {
                nextLabel.TextColor = Color.DimGray;
                nextIcon.Source = "next.png";

                diesel.BackgroundColor = Color.Transparent;
                petrol.BackgroundColor = Color.Transparent;
                electricity.BackgroundColor = Color.AliceBlue;
            }

        }

        async void OnNextClicked(object sender, EventArgs e)
        {
            CO2EmissionCalculator.fuelType = fuelType;

            if (fuelType == 3) {
                await Navigation.PushAsync(new publicTransport());
            }
            else if (fuelType > 0) {
                await Navigation.PushAsync(new KilometersPerWeek());
            }
        }

        async void OnBackClicked(object sender, EventArgs e)
        {
            CO2EmissionCalculator.fuelType = fuelType;
            await Navigation.PopAsync();
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        async void OnDieselClicked(object sender, EventArgs e) 
        {
            nextLabel.TextColor = Color.DimGray;
            nextIcon.Source = "next.png";

            fuelType = 1;

            diesel.BackgroundColor = Color.AliceBlue;
            petrol.BackgroundColor = Color.Transparent;
            electricity.BackgroundColor = Color.Transparent;
        }

        async void OnPetrolClicked(object sender, EventArgs e)
        {
            nextLabel.TextColor = Color.DimGray;
            nextIcon.Source = "next.png";

            fuelType = 2;

            diesel.BackgroundColor = Color.Transparent;
            petrol.BackgroundColor = Color.AliceBlue;
            electricity.BackgroundColor = Color.Transparent;
        }

        async void OnElectricityClicked(object sender, EventArgs e)
        {
            nextLabel.TextColor = Color.DimGray;
            nextIcon.Source = "next.png";

            fuelType = 3;

            diesel.BackgroundColor = Color.Transparent;
            petrol.BackgroundColor = Color.Transparent;
            electricity.BackgroundColor = Color.AliceBlue;
        }

    }
}