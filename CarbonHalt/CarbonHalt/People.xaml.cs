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
        public People()
        {
            InitializeComponent();
        }

        async void OnNextClicked(object sender, EventArgs e)
        {
            /*
            await Navigation.PushAsync(new House(utilityEmissions, houseEmissionsScale, solarPanels, solarHeating, heatPump, heatingGrid, people.Value)
            {
            });*/
            await Navigation.PushAsync(new House()
            {
            });
        }
    }
}