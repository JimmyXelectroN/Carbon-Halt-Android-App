using CarbonHalt.Models;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarbonHalt
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dashboard : ContentPage
    {

        public Dashboard()
        {
            if (App.Database.hintIsEmpty())
            {
                questions();
            }

            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (CO2EmissionCalculator.questionsDone) 
            {
                carousel.ItemsSource = App.Database.GetHints().Result;

                await App.Database.SaveEmissionLevelAsync(new emissionLevel
                {
                    TimeRecorded = DateTime.Now.Date.ToString("MMMM dd"),
                    Co2 = CO2EmissionCalculator.CalculateCO2()
                });
            }

            CO2EmissionCalculator.questionsDone = false;

            carousel.ItemsSource = App.Database.GetHints().Result;

            if (App.Database.GetEmissionLevels().Result.LastOrDefault() != null)
            {
                header1.Text = "" + App.Database.GetEmissionLevels().Result.Last().Co2;
                marker.Value = App.Database.GetEmissionLevels().Result.Last().Co2;
            }

        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        protected void OnEvaluateClicked(object sender, EventArgs e)
        {
            App.Database.ClearHints();
            questions();
        }

        async void OnHistoryClicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new History());
        }


        async void questions()
        {
            await Navigation.PushAsync(new JourneyMode());
        }
    }
}