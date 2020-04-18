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
    public partial class publicTransport : ContentPage
    {
        public publicTransport()
        {
            InitializeComponent();
        }

        async void OnNextClicked(object sender, EventArgs e)
        {
            CO2EmissionCalculator.trainKm = train.Value;
            CO2EmissionCalculator.metroKm = metro.Value;
            CO2EmissionCalculator.busKm = bus.Value;
            await Navigation.PushAsync(new AirTransport()
            {
            });
        }
    }
}