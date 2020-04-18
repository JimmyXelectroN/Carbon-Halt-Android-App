using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarbonHalt
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class JourneyMode : ContentPage
    {
        private int vehicleType = 0;
        public JourneyMode()
        {
            InitializeComponent();
        }

        async void OnNextClicked(object sender, EventArgs e)
        {
            CO2EmissionCalculator.vehicleType = vehicleType;
            if (vehicleType != 6)
            {
                await Navigation.PushAsync(new Fuel()
                {
                });
            }
            else 
            {
                CO2EmissionCalculator.fuelType = 3;
                CO2EmissionCalculator.kilometersTravelledPrivate = 0;
                await Navigation.PushAsync(new publicTransport()
                {
                });
            }
        }

        async void OnVanClicked(object sender, EventArgs e)
        {
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