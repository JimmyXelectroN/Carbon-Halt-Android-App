using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarbonHalt
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class House : ContentPage
    {
        private double energy;
        public House()
        {
            energy = CO2EmissionCalculator.energyConsumption;
            InitializeComponent();


            if (energy == 7000) 
            {
                finish.ImageSource = "finish2.png";

                bigHouseBlur.IsVisible = false;
                mediumHouseBlur.IsVisible = true;
                smallHouseBlur.IsVisible = true;
                dormBlur.IsVisible = true;
            }
            else if (energy == 4800)
            {
                finish.ImageSource = "finish2.png";

                bigHouseBlur.IsVisible = true;
                mediumHouseBlur.IsVisible = false;
                smallHouseBlur.IsVisible = true;
                dormBlur.IsVisible = true;
            }
            else if (energy ==  3000)
            {
                finish.ImageSource = "finish2.png";

                bigHouseBlur.IsVisible = true;
                mediumHouseBlur.IsVisible = true;
                smallHouseBlur.IsVisible = false;
                dormBlur.IsVisible = true;
            }
            else if (energy == 2000)
            {
                finish.ImageSource = "finish2.png";

                bigHouseBlur.IsVisible = true;
                mediumHouseBlur.IsVisible = true;
                smallHouseBlur.IsVisible = true;
                dormBlur.IsVisible = false;
            }
        }

        async void OnFinishClicked(object sender, EventArgs e)
        {
            CO2EmissionCalculator.questionsDone = true;
            App.Database.ClearHints();
            CO2EmissionCalculator.energyConsumption = energy;

            if (energy > 0)
            {
                await Navigation.PushAsync(new Dashboard());
            }

        }

        async void OnBackClicked(object sender, EventArgs e)
        {
            CO2EmissionCalculator.energyConsumption = energy;
            await Navigation.PopAsync();
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        protected void OnBigHouseClicked(object sender, EventArgs e) 
        {
            finish.ImageSource = "finish2.png";

            energy = 7000;

            bigHouseBlur.IsVisible = false;
            mediumHouseBlur.IsVisible = true;
            smallHouseBlur.IsVisible = true;
            dormBlur.IsVisible = true;
        }

        protected void OnMediumClicked(object sender, EventArgs e)
        {
            finish.ImageSource = "finish2.png";

            energy = 4800;

            bigHouseBlur.IsVisible = true;
            mediumHouseBlur.IsVisible = false;
            smallHouseBlur.IsVisible = true;
            dormBlur.IsVisible = true;
        }

        protected void OnSmallClicked(object sender, EventArgs e)
        {
            finish.ImageSource = "finish2.png";

            energy = 3000;

            bigHouseBlur.IsVisible = true;
            mediumHouseBlur.IsVisible = true;
            smallHouseBlur.IsVisible = false;
            dormBlur.IsVisible = true;
        }

        protected void OnDormClicked(object sender, EventArgs e)
        {
            finish.ImageSource = "finish2.png";

            energy = 2000;

            bigHouseBlur.IsVisible = true;
            mediumHouseBlur.IsVisible = true;
            smallHouseBlur.IsVisible = true;
            dormBlur.IsVisible = false;
        }
    }
}