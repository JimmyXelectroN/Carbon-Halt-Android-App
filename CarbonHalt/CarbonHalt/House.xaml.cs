using System;
using CarbonHalt.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarbonHalt
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class House : ContentPage
    {
        private bool solarPanels;
        private bool solarHeating;
        private bool heatPump;
        private bool heatingGrid;
        private double utilityEmissions;
        private double houseEmissionsScale;
        private int numOfPeople;
        private double totalEmissions = 20;
        public House(double _utilityEmissions, double _houseEmissionsScale, bool _solarPanels, bool _solarHeating, bool _heatPump, bool _heatingGrid, int _numOfPeople)
        {
            InitializeComponent();
            utilityEmissions = _utilityEmissions;
            houseEmissionsScale = _houseEmissionsScale;
            solarPanels = _solarPanels;
            solarHeating = _solarHeating;
            heatPump = _heatPump;
            heatingGrid = _heatingGrid;
            numOfPeople = _numOfPeople;
        }

        async void OnNextClicked(object sender, EventArgs e)
        {
            await App.Database.SaveEmissionLevelAsync(new emissionLevel
            {
                TimeRecorded = DateTime.Now.ToString("MMMM dd"),
                Co2 = (int) totalEmissions
            });

            await Navigation.PushAsync(new Dashboard());

        }
    }
}