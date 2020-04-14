using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CarbonHalt.Models;
using Syncfusion.SfGauge.XForms;
using System.Collections.ObjectModel;

namespace CarbonHalt
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dashboard : ContentPage
    {
        public Dashboard()
        {
            InitializeComponent();

            if (App.Database.GetEmissionLevels().Result.LastOrDefault() != null)
            {
                header1.Text = "" + App.Database.GetEmissionLevels().Result.Last().Co2;
                marker.Value = App.Database.GetEmissionLevels().Result.Last().Co2;
            }
        }

        async void OnEvaluateClicked(object sender, EventArgs e) {

            await Navigation.PushAsync(new JourneyMode()
            {
            }); 
        }

        async void OnHistoryClicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new History()
            { 
            });
        }
    }
}