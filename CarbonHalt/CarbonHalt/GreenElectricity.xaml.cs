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
        private double houseEmissionsScale = 1;
        public GreenElectricity()
        {
            InitializeComponent();
        }

        async void OnNextClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RenewableEnergy()
            {
            });
        }

        async void OnYesClicked(object sender, EventArgs e)
        {
            houseEmissionsScale = 0.05;
        }

        async void OnNoClicked(object sender, EventArgs e)
        {
            houseEmissionsScale = 1;
        }
    }
}