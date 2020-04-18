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
    public partial class Food : ContentPage
    {
        private double foodEmissions = 0;
        public Food()
        {
            InitializeComponent();
        }

        async void OnNextClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GreenElectricity()
            {
            });
        }

        async void OnMeatAllClicked(object sender, EventArgs e) 
        {
            foodEmissions = 0;        
        }

        async void OnMeatSomeClicked(object sender, EventArgs e)
        {
            foodEmissions = 0;
        }

        async void OnNoBeefClicked(object sender, EventArgs e)
        {
            foodEmissions = 0;
        }

        async void OnVegetarianClicked(object sender, EventArgs e)
        {
            foodEmissions = 0;
        }

        async void OnVeganClicked(object sender, EventArgs e)
        {
            foodEmissions = 0;
        }
    }
}