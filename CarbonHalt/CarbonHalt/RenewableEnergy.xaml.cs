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
        private bool solarPanels = false;
        private bool solarHeating = false;
        private bool heatPump = false;
        private bool heatingGrid = false;

        public RenewableEnergy()
        {
            InitializeComponent();
        }

        async void OnNextClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new People()
            {
            });
        }

        async void OnSolarPanelsClicked(object sender, EventArgs e)
        {
            solarPanels = !solarPanels;
        }

        async void OnSolarHeatingClicked(object sender, EventArgs e)
        {
            solarHeating = !solarHeating;
        }

        async void OnHeatPumpClicked(object sender, EventArgs e)
        {
            heatPump = !heatPump;
        }

        async void OnHeatingGridClicked(object sender, EventArgs e)
        {
            heatingGrid = !heatingGrid;
        }
    }
}