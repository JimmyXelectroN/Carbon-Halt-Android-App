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
        private double emissionRate = 0;
        private int carType;
        public Fuel(int _carType)
        {
            InitializeComponent();
            carType = _carType;
        }

        async void OnNextClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new KilometersPerWeek(emissionRate)
            {
            });
        }

        async void OnDieselClicked(object sender, EventArgs e) 
        {
            if (carType == 1)
            {
                emissionRate = 0.158;
            }
            else if (carType == 2)
            {
                emissionRate = 0.163;
            }
            else if (carType == 3)
            {
                emissionRate = 0.210;
            }
            else if (carType == 4)
            {
                emissionRate = 0.119;
            }
            else if (carType == 5)
            {
                emissionRate = 0.066;
            }

            diesel.BackgroundColor = Color.AliceBlue;
            petrol.BackgroundColor = Color.Transparent;
            electricity.BackgroundColor = Color.Transparent;
        }

        async void OnPetrolClicked(object sender, EventArgs e)
        {
            if (carType == 1)
            {
                emissionRate = 0.263;
            }
            else if (carType == 2)
            {
                emissionRate = 0.271;
            }
            else if (carType == 3)
            {
                emissionRate = 0.350;
            }
            else if (carType == 4)
            {
                emissionRate = 0.198;
            }
            else if (carType == 5) {
                emissionRate = 0.11;
            }

            diesel.BackgroundColor = Color.Transparent;
            petrol.BackgroundColor = Color.AliceBlue;
            electricity.BackgroundColor = Color.Transparent;
        }

        async void OnElectricityClicked(object sender, EventArgs e)
        {
            emissionRate = 0;
            diesel.BackgroundColor = Color.Transparent;
            petrol.BackgroundColor = Color.Transparent;
            electricity.BackgroundColor = Color.AliceBlue;
        }
    }
}