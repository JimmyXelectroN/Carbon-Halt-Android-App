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
    public partial class KilometersPerWeek : ContentPage
    {
        private double emissionRate;
        private double km;
        public KilometersPerWeek(double _emissionRate)
        {
            InitializeComponent();
            emissionRate = _emissionRate;
        }

        async void OnNextClicked(object sender, EventArgs e)
        {
            //km = Slider.Value;
            await Navigation.PushAsync(new publicTransport(emissionRate * km)
            {
            });
        }
    }
}