using CarbonHalt.Models;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Syncfusion;
using Syncfusion.XForms.Buttons;

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

                await App.Database.SaveEmissionLevelAsync(new emissionLevel
                {
                    TimeRecorded = DateTime.Now.Date.ToString("MMMM dd"),
                    Co2 = CO2EmissionCalculator.CalculateCO2()
                });

                carousel.ItemsSource = App.Database.GetHints().Result;
            }

            CO2EmissionCalculator.questionsDone = false;

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
            if (App.Database.hintIsEmpty())
            {
                noHintMessgae.IsVisible = true;
            }

            App.Database.RemoveHintAsync((hint) carousel.CurrentItem);
            carousel.ItemsSource = App.Database.GetHints().Result;
            var checkButton = (SfCheckBox)sender;
            checkButton.IsChecked = false;
        }
    }
}