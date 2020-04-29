using CarbonHalt.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarbonHalt
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Food : ContentPage
    {
        private int dietType;
        public Food()
        {
            InitializeComponent();

            dietType = CO2EmissionCalculator.dietType;

            if (dietType == 1)
            {
                nextLabel.TextColor = Color.DimGray;
                nextIcon.Source = "next.png";

                meatButton.BorderColor = Color.Black;
                averageButton.BorderColor = Color.Gray;
                noBeefButton.BorderColor = Color.Gray;
                vegetarianButton.BorderColor = Color.Gray;
                veganButton.BorderColor = Color.Gray;

                meatCheck.IsVisible = true;
                averageCheck.IsVisible = false;
                noBeefCheck.IsVisible = false;
                vegetarianCheck.IsVisible = false;
                veganCheck.IsVisible = false;
            }
            else if (dietType == 2)
            {
                nextLabel.TextColor = Color.DimGray;
                nextIcon.Source = "next.png";

                meatButton.BorderColor = Color.Gray;
                averageButton.BorderColor = Color.Black;
                noBeefButton.BorderColor = Color.Gray;
                vegetarianButton.BorderColor = Color.Gray;
                veganButton.BorderColor = Color.Gray;

                meatCheck.IsVisible = false;
                averageCheck.IsVisible = true;
                noBeefCheck.IsVisible = false;
                vegetarianCheck.IsVisible = false;
                veganCheck.IsVisible = false;
            }
            else if (dietType == 3)
            {
                nextLabel.TextColor = Color.DimGray;
                nextIcon.Source = "next.png";

                meatButton.BorderColor = Color.Gray;
                averageButton.BorderColor = Color.Gray;
                noBeefButton.BorderColor = Color.Black;
                vegetarianButton.BorderColor = Color.Gray;
                veganButton.BorderColor = Color.Gray;

                meatCheck.IsVisible = false;
                averageCheck.IsVisible = false;
                noBeefCheck.IsVisible = true;
                vegetarianCheck.IsVisible = false;
                veganCheck.IsVisible = false;
            }
            else if (dietType == 4)
            {
                nextLabel.TextColor = Color.DimGray;
                nextIcon.Source = "next.png";

                meatButton.BorderColor = Color.Gray;
                averageButton.BorderColor = Color.Gray;
                noBeefButton.BorderColor = Color.Gray;
                vegetarianButton.BorderColor = Color.Black;
                veganButton.BorderColor = Color.Gray;

                meatCheck.IsVisible = false;
                averageCheck.IsVisible = false;
                noBeefCheck.IsVisible = false;
                vegetarianCheck.IsVisible = true;
                veganCheck.IsVisible = false;
            }
            else if (dietType == 5)
            {
                nextLabel.TextColor = Color.DimGray;
                nextIcon.Source = "next.png";

                meatButton.BorderColor = Color.Gray;
                averageButton.BorderColor = Color.Gray;
                noBeefButton.BorderColor = Color.Gray;
                vegetarianButton.BorderColor = Color.Gray;
                veganButton.BorderColor = Color.Black;

                meatCheck.IsVisible = false;
                averageCheck.IsVisible = false;
                noBeefCheck.IsVisible = false;
                vegetarianCheck.IsVisible = false;
                veganCheck.IsVisible = true;
            }
        }

        async void OnNextClicked(object sender, EventArgs e)
        {
            CO2EmissionCalculator.dietType = dietType;

            if (dietType > 0) {
                await Navigation.PushAsync(new GreenElectricity());
            }
        }

        async void OnBackClicked(object sender, EventArgs e)
        {
            CO2EmissionCalculator.dietType = dietType;
            await Navigation.PopAsync();
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        async void OnMeatLoverClicked(object sender, EventArgs e) 
        {
            nextLabel.TextColor = Color.DimGray;
            nextIcon.Source = "next.png";

            dietType = 1;

            meatButton.BorderColor = Color.Black;
            averageButton.BorderColor = Color.Gray;
            noBeefButton.BorderColor = Color.Gray;
            vegetarianButton.BorderColor = Color.Gray;
            veganButton.BorderColor = Color.Gray;

            meatCheck.IsVisible = true;
            averageCheck.IsVisible = false;
            noBeefCheck.IsVisible = false;
            vegetarianCheck.IsVisible = false;
            veganCheck.IsVisible = false;
        }

        async void OnAverageClicked(object sender, EventArgs e)
        {
            nextLabel.TextColor = Color.DimGray;
            nextIcon.Source = "next.png";

            dietType = 2;

            meatButton.BorderColor = Color.Gray;
            averageButton.BorderColor = Color.Black;
            noBeefButton.BorderColor = Color.Gray;
            vegetarianButton.BorderColor = Color.Gray;
            veganButton.BorderColor = Color.Gray;

            meatCheck.IsVisible = false;
            averageCheck.IsVisible = true;
            noBeefCheck.IsVisible = false;
            vegetarianCheck.IsVisible = false;
            veganCheck.IsVisible = false;
        }

        async void OnNoBeefClicked(object sender, EventArgs e)
        {
            nextLabel.TextColor = Color.DimGray;
            nextIcon.Source = "next.png";

            dietType = 3;
            
            meatButton.BorderColor = Color.Gray;
            averageButton.BorderColor = Color.Gray;
            noBeefButton.BorderColor = Color.Black;
            vegetarianButton.BorderColor = Color.Gray;
            veganButton.BorderColor = Color.Gray;

            meatCheck.IsVisible = false;
            averageCheck.IsVisible = false;
            noBeefCheck.IsVisible = true;
            vegetarianCheck.IsVisible = false;
            veganCheck.IsVisible = false;
        }

        async void OnVegetarianClicked(object sender, EventArgs e)
        {
            nextLabel.TextColor = Color.DimGray;
            nextIcon.Source = "next.png";

            dietType = 4;

            meatButton.BorderColor = Color.Gray;
            averageButton.BorderColor = Color.Gray;
            noBeefButton.BorderColor = Color.Gray;
            vegetarianButton.BorderColor = Color.Black;
            veganButton.BorderColor = Color.Gray;

            meatCheck.IsVisible = false;
            averageCheck.IsVisible = false;
            noBeefCheck.IsVisible = false;
            vegetarianCheck.IsVisible = true;
            veganCheck.IsVisible = false;
        }

        async void OnVeganClicked(object sender, EventArgs e)
        {
            nextLabel.TextColor = Color.DimGray;
            nextIcon.Source = "next.png";

            dietType = 5;

            meatButton.BorderColor = Color.Gray;
            averageButton.BorderColor = Color.Gray;
            noBeefButton.BorderColor = Color.Gray;
            vegetarianButton.BorderColor = Color.Gray;
            veganButton.BorderColor = Color.Black;

            meatCheck.IsVisible = false;
            averageCheck.IsVisible = false;
            noBeefCheck.IsVisible = false;
            vegetarianCheck.IsVisible = false;
            veganCheck.IsVisible = true;
        }
    }
}