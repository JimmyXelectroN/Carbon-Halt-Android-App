using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarbonHalt
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class JourneyMode : ContentPage
    {
        private int carType = 0;
        public JourneyMode()
        {
            InitializeComponent();
        }

        async void OnNextClicked(object sender, EventArgs e)
        {
            if (carType != 6)
            {
                await Navigation.PushAsync(new Fuel(carType)
                {
                });
            }
            else 
            {
                await Navigation.PushAsync(new publicTransport(0)
                {
                });
            }
        }

        async void OnVanClicked(object sender, EventArgs e)
        {
            carType = 1;
            vanBlur.IsVisible = false;
            suvBlur.IsVisible = true;
            sportscarBlur.IsVisible = true;
            smallcarBlur.IsVisible = true;
            motorbikeBlur.IsVisible = true;
            naturalBlur.IsVisible = true;
        }

        async void OnSUVClicked(object sender, EventArgs e)
        {
            carType = 2;
            vanBlur.IsVisible = true;
            suvBlur.IsVisible = false;
            sportscarBlur.IsVisible = true;
            smallcarBlur.IsVisible = true;
            motorbikeBlur.IsVisible = true;
            naturalBlur.IsVisible = true;
        }

        async void OnSportscarClicked(object sender, EventArgs e)
        {
            carType = 3;
            vanBlur.IsVisible = true;
            suvBlur.IsVisible = true;
            sportscarBlur.IsVisible = false;
            smallcarBlur.IsVisible = true;
            motorbikeBlur.IsVisible = true;
            naturalBlur.IsVisible = true;
        }

        async void OnSmallCarClicked(object sender, EventArgs e)
        {
            carType = 4;
            vanBlur.IsVisible = true;
            suvBlur.IsVisible = true;
            sportscarBlur.IsVisible = true;
            smallcarBlur.IsVisible = false;
            motorbikeBlur.IsVisible = true;
            naturalBlur.IsVisible = true;
        }

        async void OnMotorcycleClicked(object sender, EventArgs e)
        {
            carType = 5;
            vanBlur.IsVisible = true;
            suvBlur.IsVisible = true;
            sportscarBlur.IsVisible = true;
            smallcarBlur.IsVisible = true;
            motorbikeBlur.IsVisible = false;
            naturalBlur.IsVisible = true;
        }

        async void OnNaturalClicked(object sender, EventArgs e)
        {
            carType = 6;
            vanBlur.IsVisible = true;
            suvBlur.IsVisible = true;
            sportscarBlur.IsVisible = true;
            smallcarBlur.IsVisible = true;
            motorbikeBlur.IsVisible = true;
            naturalBlur.IsVisible = false;
        }
    }
}