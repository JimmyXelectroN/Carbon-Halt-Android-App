using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CarbonHalt.Models;
namespace CarbonHalt
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class JourneyMode : ContentPage
    {
        private int vehicleType;
        private bool firstSurvey;
        public JourneyMode(bool _firstSurvey)
        {
            firstSurvey = _firstSurvey;
            InitializeComponent();
            vehicleType = CO2EmissionCalculator.vehicleType;
            if (firstSurvey) 
            {
                exit.IsEnabled = false;
                exit.ShowIcon = false;
            }

            if (vehicleType == 1)
            {
                nextLabel.TextColor = Color.DimGray;
                nextIcon.Source = "next.png";

                vanBlur.IsVisible = false;
                suvBlur.IsVisible = true;
                sportscarBlur.IsVisible = true;
                smallcarBlur.IsVisible = true;
                motorbikeBlur.IsVisible = true;
                naturalBlur.IsVisible = true;
            }
            else if (vehicleType == 2) 
            {
                nextLabel.TextColor = Color.DimGray;
                nextIcon.Source = "next.png";

                vanBlur.IsVisible = true;
                suvBlur.IsVisible = false;
                sportscarBlur.IsVisible = true;
                smallcarBlur.IsVisible = true;
                motorbikeBlur.IsVisible = true;
                naturalBlur.IsVisible = true;
            }
            else if (vehicleType == 3)
            {
                nextLabel.TextColor = Color.DimGray;
                nextIcon.Source = "next.png";

                vanBlur.IsVisible = true;
                suvBlur.IsVisible = true;
                sportscarBlur.IsVisible = false;
                smallcarBlur.IsVisible = true;
                motorbikeBlur.IsVisible = true;
                naturalBlur.IsVisible = true;
            }
            else if (vehicleType == 4)
            { 
                nextLabel.TextColor = Color.DimGray;
                nextIcon.Source = "next.png";

                vanBlur.IsVisible = true;
                suvBlur.IsVisible = true;
                sportscarBlur.IsVisible = true;
                smallcarBlur.IsVisible = false;
                motorbikeBlur.IsVisible = true;
                naturalBlur.IsVisible = true;
            }
            else if (vehicleType == 5)
            {
                nextLabel.TextColor = Color.DimGray;
                nextIcon.Source = "next.png";

                vanBlur.IsVisible = true;
                suvBlur.IsVisible = true;
                sportscarBlur.IsVisible = true;
                smallcarBlur.IsVisible = true;
                motorbikeBlur.IsVisible = false;
                naturalBlur.IsVisible = true;
            }
            else if (vehicleType == 6)
            {
                nextLabel.TextColor = Color.DimGray;
                nextIcon.Source = "next.png";

                vanBlur.IsVisible = true;
                suvBlur.IsVisible = true;
                sportscarBlur.IsVisible = true;
                smallcarBlur.IsVisible = true;
                motorbikeBlur.IsVisible = true;
                naturalBlur.IsVisible = false;
            }
        }

        async void OnNextClicked(object sender, EventArgs e)
        {

            CO2EmissionCalculator.vehicleType = vehicleType;

            if (vehicleType > 0) 
            {
                if (vehicleType != 6)
                {
                    await Navigation.PushAsync(new Fuel());
                }
                else
                {
                    CO2EmissionCalculator.fuelType = 3;
                    CO2EmissionCalculator.kilometersTravelledPrivate = 0;
                    await Navigation.PushAsync(new publicTransport());
                }
            }
        }

        async void OnExitClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        async void OnVanClicked(object sender, EventArgs e)
        {
            nextLabel.TextColor = Color.DimGray;
            nextIcon.Source = "next.png";

            vehicleType = 1;

            vanBlur.IsVisible = false;
            suvBlur.IsVisible = true;
            sportscarBlur.IsVisible = true;
            smallcarBlur.IsVisible = true;
            motorbikeBlur.IsVisible = true;
            naturalBlur.IsVisible = true;
        }

        async void OnSUVClicked(object sender, EventArgs e)
        {
            nextLabel.TextColor = Color.DimGray;
            nextIcon.Source = "next.png";

            vehicleType = 2;
            vanBlur.IsVisible = true;
            suvBlur.IsVisible = false;
            sportscarBlur.IsVisible = true;
            smallcarBlur.IsVisible = true;
            motorbikeBlur.IsVisible = true;
            naturalBlur.IsVisible = true;
        }

        async void OnSportscarClicked(object sender, EventArgs e)
        {
            nextLabel.TextColor = Color.DimGray;
            nextIcon.Source = "next.png";

            vehicleType = 3;
            vanBlur.IsVisible = true;
            suvBlur.IsVisible = true;
            sportscarBlur.IsVisible = false;
            smallcarBlur.IsVisible = true;
            motorbikeBlur.IsVisible = true;
            naturalBlur.IsVisible = true;
        }

        async void OnSmallCarClicked(object sender, EventArgs e)
        {
            nextLabel.TextColor = Color.DimGray;
            nextIcon.Source = "next.png";

            vehicleType = 4;
            vanBlur.IsVisible = true;
            suvBlur.IsVisible = true;
            sportscarBlur.IsVisible = true;
            smallcarBlur.IsVisible = false;
            motorbikeBlur.IsVisible = true;
            naturalBlur.IsVisible = true;
        }

        async void OnMotorcycleClicked(object sender, EventArgs e)
        {
            nextLabel.TextColor = Color.DimGray;
            nextIcon.Source = "next.png";

            vehicleType = 5;
            vanBlur.IsVisible = true;
            suvBlur.IsVisible = true;
            sportscarBlur.IsVisible = true;
            smallcarBlur.IsVisible = true;
            motorbikeBlur.IsVisible = false;
            naturalBlur.IsVisible = true;
        }

        async void OnNaturalClicked(object sender, EventArgs e)
        {
            nextLabel.TextColor = Color.DimGray;
            nextIcon.Source = "next.png";

            vehicleType = 6;
            vanBlur.IsVisible = true;
            suvBlur.IsVisible = true;
            sportscarBlur.IsVisible = true;
            smallcarBlur.IsVisible = true;
            motorbikeBlur.IsVisible = true;
            naturalBlur.IsVisible = false;
        }
    }
}