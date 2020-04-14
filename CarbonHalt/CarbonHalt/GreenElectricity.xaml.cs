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
    public partial class GreenElectricity : ContentPage
    {
        private double utilityEmissions;
        private double houseEmissionsScale = 0.05;
        public GreenElectricity(double _utilityEmissions)
        {
            InitializeComponent();
            utilityEmissions = _utilityEmissions;
        }

        async void OnNextClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RenewableEnergy(utilityEmissions, houseEmissionsScale)
            {
            });
        }
    }
}