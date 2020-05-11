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
                questions(true);
            }

            InitializeComponent();

            carousel.ItemsSource = App.Database.GetHints().Result;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();


            if (CO2EmissionCalculator.questionsDone)
            {
                int co2 = CO2EmissionCalculator.CalculateCO2();
                await App.Database.SaveEmissionLevelAsync(new emissionLevel
                {
                    TimeRecorded = DateTime.Now.Date.ToString("MMMM dd"),
                    Co2 = co2
                });
            }

            CO2EmissionCalculator.questionsDone = false;

            carousel.ItemsSource = App.Database.GetHints().Result;

            if (App.Database.GetEmissionLevels().Result.LastOrDefault() != null)
            {
                header1.Text = "" + App.Database.GetEmissionLevels().Result.Last().Co2;
                marker.Value = App.Database.GetEmissionLevels().Result.Last().Co2;
            }

            if (App.Database.hintIsEmpty())
            {
                noHintMessgae.IsVisible = true;
            }
            else
            {
                noHintMessgae.IsVisible = false;
            }

        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        protected void OnEvaluateClicked(object sender, EventArgs e)
        {
            questions(false);
        }

        async void OnHistoryClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new History());
        }


        async void questions(bool firstSurvey)
        {
            await Navigation.PushAsync(new JourneyMode(firstSurvey));
        }
        protected void OnHintCheckClicked(object sender, EventArgs e)
        {
            App.Database.RemoveHintAsync((hint) carousel.CurrentItem);
            carousel.ItemsSource = App.Database.GetHints().Result;
            if (App.Database.hintIsEmpty())
            {
                noHintMessgae.IsVisible = true;
            }
            else {
                carousel.Position = 0;
            }
        }
    }
}