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

    public partial class JourneyMode : ContentPage
    {
        private int carType = 0;
        public JourneyMode()
        {
            InitializeComponent();
        }

        async void OnNextClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Fuel(carType)
            { 
            });
        }
    }
}