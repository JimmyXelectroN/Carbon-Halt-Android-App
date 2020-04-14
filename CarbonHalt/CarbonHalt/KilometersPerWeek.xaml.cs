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
        private double fuelEconomy;
        public KilometersPerWeek(double _fuelEconomy)
        {
            InitializeComponent();
            fuelEconomy = _fuelEconomy;
        }

        async void OnNextClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new publicTransport(fuelEconomy)
            {
            });
        }
    }
}