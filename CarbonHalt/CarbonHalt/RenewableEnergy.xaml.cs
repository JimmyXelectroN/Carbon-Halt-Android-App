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
    public partial class RenewableEnergy : ContentPage
    {
        private bool solarPanels;
        private bool solarHeating;
        private bool geoSystem;
        private bool wind;

        public RenewableEnergy()
        {
            InitializeComponent();

            solarPanels = CO2EmissionCalculator.solar;
            solarHeating = CO2EmissionCalculator.solarHeatng;
            geoSystem = CO2EmissionCalculator.geoSystem;
            wind = CO2EmissionCalculator.wind;

            if (solarPanels) 
            {
                solarButton.BorderColor = Color.Black;
            }

            if (solarHeating)
            {
                solarHeatingButton.BorderColor = Color.Black;
            }

            if (geoSystem)
            {
                geoButton.BorderColor = Color.Black;
            }

            if (wind)
            {
                windButton.BorderColor = Color.Black;
            }
        }

        async void OnNextClicked(object sender, EventArgs e)
        {

            CO2EmissionCalculator.solar = solarPanels;
            CO2EmissionCalculator.solarHeatng = solarHeating;
            CO2EmissionCalculator.geoSystem = geoSystem;
            CO2EmissionCalculator.wind = wind;

            await Navigation.PushAsync(new People());
        }

        async void OnBackClicked(object sender, EventArgs e)
        {
            CO2EmissionCalculator.solar = solarPanels;
            CO2EmissionCalculator.solarHeatng = solarHeating;
            CO2EmissionCalculator.geoSystem = geoSystem;
            CO2EmissionCalculator.wind = wind;

            await Navigation.PopAsync();
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        async void OnSolarPanelsClicked(object sender, EventArgs e)
        {
            solarPanels = !solarPanels;
            if (solarPanels)
            {
                solarButton.BorderColor = Color.Black;

            }
            else 
            {
                solarButton.BorderColor = Color.LightGray;
            }
        }

        async void OnSolarHeatingClicked(object sender, EventArgs e)
        {
            solarHeating = !solarHeating;
            if (solarHeating)
            {
                solarHeatingButton.BorderColor = Color.Black;
            }
            else
            {
                solarHeatingButton.BorderColor = Color.LightGray;
            }
        }

        async void OnHeatPumpClicked(object sender, EventArgs e)
        {
            geoSystem = !geoSystem;
            if (geoSystem)
            {
                geoButton.BorderColor = Color.Black;
            }
            else
            {
                geoButton.BorderColor = Color.LightGray;
            }
        }

        async void OnWindClicked(object sender, EventArgs e)
        {
            wind = !wind;
            if (wind)
            {
                windButton.BorderColor = Color.Black;
            }
            else
            {
                windButton.BorderColor = Color.LightGray;
            }
        }
    }
}
