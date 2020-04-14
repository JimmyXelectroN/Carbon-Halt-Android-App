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
        private double utilityEmissions;
        private double houseEmissionsScale;

        public RenewableEnergy(double _utilityEmissions, double _houseEmissionsScale)
        {
            InitializeComponent();
            utilityEmissions = _utilityEmissions;
            houseEmissionsScale = _houseEmissionsScale;
        }

        async void OnNextClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new People(utilityEmissions, houseEmissionsScale, solarPanels, solarHeating, heatPump, heatingGrid)
            {
            });
        }
    }
}