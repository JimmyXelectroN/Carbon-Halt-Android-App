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
    public partial class People : ContentPage
    {
        private bool solarPanels;
        private bool solarHeating;
        private bool heatPump;
        private bool heatingGrid;
        private double utilityEmissions;
        private double houseEmissionsScale;
        public People(double _utilityEmissions, double _houseEmissionsScale, bool _solarPanels, bool _solarHeating, bool _heatPump, bool _heatingGrid)
        {
            InitializeComponent();
            utilityEmissions = _utilityEmissions;
            houseEmissionsScale = _houseEmissionsScale;
            solarPanels = _solarPanels;
            solarHeating = _solarHeating;
            heatPump = _heatPump;
            heatingGrid = _heatingGrid;
        }

        async void OnNextClicked(object sender, EventArgs e)
        {
            /*
            await Navigation.PushAsync(new House(utilityEmissions, houseEmissionsScale, solarPanels, solarHeating, heatPump, heatingGrid, people.Value)
            {
            });*/
            await Navigation.PushAsync(new House(utilityEmissions, houseEmissionsScale, solarPanels, solarHeating, heatPump, heatingGrid, 1)
            {
            });
        }
    }
}