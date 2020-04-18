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
    public partial class AirTransport : ContentPage
    {
        public AirTransport()
        {
            InitializeComponent();
        }

        async void OnNextClicked(object sender, EventArgs e)
        {
            CO2EmissionCalculator.flightHours = hours.Value;
            await Navigation.PushAsync(new Food()
            {
            });
        }
    }
}