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
    public partial class Fuel : ContentPage
    {
        private int fuelType;
        public Fuel()
        {
            InitializeComponent();
        }

        async void OnNextClicked(object sender, EventArgs e)
        {
            CO2EmissionCalculator.fuelType = fuelType;
            await Navigation.PushAsync(new KilometersPerWeek()
            {
            });
        }

        async void OnDieselClicked(object sender, EventArgs e) 
        {
            fuelType = 1;

            diesel.BackgroundColor = Color.AliceBlue;
            petrol.BackgroundColor = Color.Transparent;
            electricity.BackgroundColor = Color.Transparent;
        }

        async void OnPetrolClicked(object sender, EventArgs e)
        {
            fuelType = 2;

            diesel.BackgroundColor = Color.Transparent;
            petrol.BackgroundColor = Color.AliceBlue;
            electricity.BackgroundColor = Color.Transparent;
        }

        async void OnElectricityClicked(object sender, EventArgs e)
        {
            fuelType = 3;
            diesel.BackgroundColor = Color.Transparent;
            petrol.BackgroundColor = Color.Transparent;
            electricity.BackgroundColor = Color.AliceBlue;
        }
    }
}