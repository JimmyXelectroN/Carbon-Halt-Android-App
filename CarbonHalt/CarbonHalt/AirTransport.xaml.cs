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
        private double landTransportation;
        private double airTransportation = 0;
        public AirTransport(double _landTransportation)
        {
            InitializeComponent();
            landTransportation = _landTransportation;
        }

        async void OnNextClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Food(landTransportation + airTransportation)
            {
            });
        }
    }
}