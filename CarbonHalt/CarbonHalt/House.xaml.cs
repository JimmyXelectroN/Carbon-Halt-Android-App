using System;
using CarbonHalt.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarbonHalt
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class House : ContentPage
    {
        public House()
        {
            InitializeComponent();
        }

        async void OnNextClicked(object sender, EventArgs e)
        {
            /*
            await App.Database.SaveEmissionLevelAsync(new emissionLevel
            {
                TimeRecorded = DateTime.Now.ToString("MMMM dd"),
                Co2 = (int) totalEmissions
            });*/

            await Navigation.PushAsync(new Dashboard());

        }
    }
}