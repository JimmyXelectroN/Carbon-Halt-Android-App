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
    public partial class People : ContentPage
    {
        private double StepValue;
        public People()
        {
            StepValue = 1.0;
            InitializeComponent();
            people.Value = CO2EmissionCalculator.peopleInHousehold;
        }

        async void OnNextClicked(object sender, EventArgs e)
        {
            CO2EmissionCalculator.peopleInHousehold = people.Value;
            await Navigation.PushAsync(new House());
        }

        async void OnBackClicked(object sender, EventArgs e)
        {
            CO2EmissionCalculator.peopleInHousehold = people.Value;
            await Navigation.PopAsync();
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        async void OnValueChanged(object sender, ValueChangedEventArgs e)
        {
            var newStep = Math.Round(e.NewValue / StepValue);
            people.Value = newStep * StepValue;
            label.Text = "" + people.Value;
        }
    }
}