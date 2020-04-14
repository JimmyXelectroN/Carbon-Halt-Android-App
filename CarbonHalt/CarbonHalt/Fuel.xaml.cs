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
        private double fuelEconomy = 0;
        private int carType;
        public Fuel(int _carType)
        {
            InitializeComponent();
            carType = _carType;
        }

        async void OnNextClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new KilometersPerWeek(fuelEconomy)
            {
            });
        }
    }
}