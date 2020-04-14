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
        private double transportEmissions;
        private double foodEmissions = 0;
        public Food(double _transportEmissions)
        {
            InitializeComponent();
            transportEmissions = _transportEmissions;
        }

        async void OnNextClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GreenElectricity(foodEmissions + foodEmissions)
            {
            });
        }
    }
}