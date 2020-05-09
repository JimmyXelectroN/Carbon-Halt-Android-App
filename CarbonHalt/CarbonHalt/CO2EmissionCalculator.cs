// CO2 Calculator. 
// Disclaimer: These CO2 rates are just averges an are not very accurate as they come form a variety of sources who conduct different experiments. 
// However, the result of the calculation is a good estimate of how much co2 a person is producing in terms of good or bad. A low co2 emission level will be calculated
// if the user truly has a low co2 emission level and vice versa
// NOTE: This calculator focuses on the carbon footprint of factors that can be controlled by the user
using CarbonHalt.Models;

namespace CarbonHalt
{
    static class CO2EmissionCalculator
    {


        // has questionaire been done
        public static bool questionsDone = false;

        // private transport fields
        public static int vehicleType = 0;
        public static int fuelType = 0;
        public static double kilometersTravelledPrivate = 0;

        // public transport fields
        public static double trainKm = 0;
        public static double metroKm = 0;
        public static double busKm = 0;

        // aviation fields
        public static double flightHours = 0;

        // diet fields 
        public static int dietType = 0;

        // household fields
        public static double energyConsumption = 0;
        public static bool solar = false;
        public static bool solarHeatng = false;
        public static bool geoSystem = false;
        public static bool wind = false;
        public static bool green = false;
        public static double peopleInHousehold = 1;

        // final and total co2 emissions calculator (result displayed to user)
        public static int CalculateCO2() {
            double co2 = 0;
            // add up all emissions for grand total carbon footprint
            co2 += CalculatePrivateTransportEmissions();
            co2 += CalculatePublicTransportEmissions();
            co2 += CalculateAviationEmissions();
            co2 += CalculateFoodEmissions();
            co2 += CalculateHouseholdEmissions();

            // add necessary hints, depending on user's responses
            AddHints();

            return (int) co2;
        }

        // calculates the amount of emissions produced by the person with their private transportation
        private static double CalculatePrivateTransportEmissions()
        {
            double emissionAmount = 0;
            /*
            IMPORTANT: I wish I could implement this method without so may if else staetements, and rather just create a formula for finding the emission rate. 
                        if you know how to do so please create a new branch and reimplement. Arigatou! */
            // different fueltype release different amounts of tailpipe co2 emissions. 
            // type 1 = diesel, 
            // type 2 = petrol, 
            // type 3 = electricity
            // for more information on how different diferent cars and fuel types affect your carbon footprint consult reference number 1

            if (fuelType == 1)
            {
                // different vehicle types relase co2 at different rates. 
                // type 1 = van, 
                // type 2 = suv, 
                // type 3 = high-end sportscar, 
                // type 4 = smaller cars (includes sedans, coupes, hatchbacks, and cuvs)
                // type 5 = motorbikes
                // type 6 = walking / biking
                if (vehicleType == 1)
                {
                    // emissionAmount would be the rate at which the car produces co2 in kg per km, multiplied by the kilometers travelled
                    emissionAmount = 0.259 * kilometersTravelledPrivate;
                }
                else if (vehicleType == 2)
                {
                    emissionAmount = 0.267 * kilometersTravelledPrivate;
                }
                else if (vehicleType == 3)
                {
                    emissionAmount = 0.345 * kilometersTravelledPrivate;
                }
                else if (vehicleType == 4)
                {
                    emissionAmount = 0.198 * kilometersTravelledPrivate;
                }
                else if (vehicleType == 5)
                {
                    emissionAmount = 0.108 * kilometersTravelledPrivate;
                }
                // if vehicle type is 6, emissionAmount is left at 0
                
            }
            else if (fuelType == 2)
            {
                if (vehicleType == 1)
                {
                    emissionAmount = 0.263 * kilometersTravelledPrivate;
                }
                else if (vehicleType == 2)
                {
                    emissionAmount = 0.271 * kilometersTravelledPrivate;
                }
                else if (vehicleType == 3)
                {
                    emissionAmount = 0.350 * kilometersTravelledPrivate;
                }
                else if (vehicleType == 4)
                {
                    emissionAmount = 0.198 * kilometersTravelledPrivate;
                }
                else if (vehicleType == 5)
                {
                    emissionAmount = 0.11 * kilometersTravelledPrivate;
                }
                // if vehicle type is 6, emissionAmount is left at 0
            }
            // if fuelType is 3 then emissionAmount will be left at 0

            return emissionAmount;
        }

        // calculates the amount of emissions produced by a person as a passenger of a form of public transportation. 
        // calculated by total co2 output of transport divided by amount of people in the transport
        private static double CalculatePublicTransportEmissions() {
            // for more information on how different public transports affect your footprint, check reference number 2 on repository
            double emissionAmounts = 0;
            emissionAmounts += (trainKm * 0.1);
            emissionAmounts += (metroKm * 0.07);
            emissionAmounts += (busKm * 0.089);
            return emissionAmounts;
        }

        // calculates the amount of co2 released per passenger for number of hours flying. This number is then dived by 52 , to be distributed into your weekly emissions.
        // So  if you flew 12 hours in total a year, the emissions returned will be 58 kg
        private static double CalculateAviationEmissions()
        {
            // for more information on how different aviation travel affects your footprint, check reference number 2 on repository
            double emissionAmount = 0;

            emissionAmount = (flightHours * 250) / 52;

            return emissionAmount;
        }

        // calculates the amount of co2 from an individual's food
        private static double CalculateFoodEmissions() {
            double emissionAmounts = 0;

            // different diet types result in different emission levels, emission levels increasing with the amount of meat eaten
            // for more information on how different diets result in different emission levels, consult the reference number 3 on the reference list on repository
            // type 1 = meat lover
            // type 2 = average
            // type 3 = no beef
            // type 4 = vegetarian 
            // type 5 = vegan

            if (dietType == 1)
            {
                emissionAmounts = 63.5;
            }
            else if (dietType == 2)
            {
                emissionAmounts = 48.1;
            }
            else if (dietType == 3)
            {
                emissionAmounts = 36.5;
            }
            else if (dietType == 4)
            {
                emissionAmounts = 32.7;
            }
            else if (dietType == 5) 
            {
                emissionAmounts = 28.5;
            }

            return emissionAmounts;
        }

        private static double CalculateHouseholdEmissions() {
            double emissionAmount = 0;
            double energyUsed = energyConsumption;
            double heatingEnergy = (energyConsumption / 0.22) - energyConsumption;

            if (geoSystem) {
                heatingEnergy = heatingEnergy * 0.625;
            }

            if (solarHeatng) {
                heatingEnergy = 0;
            }

            // if you utilise green energy, only 75 percent of your total energy consumption produces co2
            if (green)
            {
                energyUsed = 0.75 * energyConsumption;
            }

            //

            // your personal emissions are calculated as an the result of the total households emissions divided by the number of people in the household
            energyUsed = ((energyUsed + heatingEnergy)/52) / peopleInHousehold;

            if (solar && wind)
            {
                // co2 emission factor for solar is 0.05 kge /kWh
                emissionAmount = energyUsed * 0.061;
            }
            else if (solar) 
            {
                emissionAmount = energyUsed * 0.05;
            }
            else if (wind)
            {
                emissionAmount = energyUsed * 0.011;
            }
            else
            {

                // co2 emission factor is 0.309 kge /kWh
                emissionAmount = energyUsed * 0.309;
            }

            return emissionAmount;
        }

        // create and adds new hints for the user
        async static void AddHints() {

            // hints for vehicle type emissions
            if (vehicleType == 1)
            {
                // adds hint, along with corresponding image
                await App.Database.SaveHintAsync(new hint
                {
                    Hint = "Big cars usually consume more fuel that regular cars. Switching to a smaller vehicle will reduce you CO2 emissions by about 25%.",
                    Image = "bigCarHint.png"
                });
                await App.Database.SaveHintAsync(new hint
                {
                    Hint = "Motorbikes emit nearly 50% less CO2 than cars.",
                    Image = "motorbikeHint.png"
                });
            }
            else if (vehicleType == 2)
            {
                await App.Database.SaveHintAsync(new hint
                {
                    Hint = "SUVs are second only to the energy industry as the leading causes of global warming. Switching out your SUV for a more environmentally friendly one goes a long way.",
                    Image = "suvHint.png"
                });
                await App.Database.SaveHintAsync(new hint
                {
                    Hint = "Motorbikes emit nearly 50% less CO2 than cars.",
                    Image = "motorbikeHint.png"
                });
            }
            else if (vehicleType == 3)
            {
                await App.Database.SaveHintAsync(new hint
                {
                    Hint = "If not electric, your sportscar's powerful engine uses up more fuel (resulting in a greater carbon footprint) than any other type of car. Switching it out for a car that has a good fuel economy will greatly help in the fight against climate change, by reducing emissions by over 50% per kilometer.",
                    Image = "sportcarHint.png"
                });
                await App.Database.SaveHintAsync(new hint
                {
                    Hint = "Motorbikes emit nearly 50% less CO2 than cars.",
                    Image = "motorbikeHint.png"
                });
            }
            else if (vehicleType == 4)
            {
                await App.Database.SaveHintAsync(new hint
                {
                    Hint = "Motorbikes emit nearly 50% less CO2 than cars.",
                    Image = "motorbikeHint.png"
                });
            }

            // hints for fuel emissions
            if (fuelType == 1)
            {
                await App.Database.SaveHintAsync(new hint
                {
                    Hint = "Fossil fuel powered cars are one of the major contributors to CO2 emissions. Going electric would be a smart choice in slashing your CO2 emissions.",
                    Image = "electricCarHint.png"
                });
            }
            else if (fuelType == 2)
            {
                await App.Database.SaveHintAsync(new hint
                {
                    Hint = "Diesel fuels are \"lean-burn\", meaning they use less fuel and air to get the same amount of performance as a petrol engine. So although diesel fuel contains more CO2 than petrol, overall the emissions of a diesel car tend to be lower by about 10%.",
                    Image = "petrolHint.png"
                });

                await App.Database.SaveHintAsync(new hint
                {
                    Hint = "Fossil fuel powered cars are one of the major contributors to CO2 emissions. Going electric would be a smart choice in slashing your CO2 emissions.",
                    Image = "electricCarHint.png"
                });
            }

            // hints for time spent on private transportation 
            if (kilometersTravelledPrivate > 150)
            {
                await App.Database.SaveHintAsync(new hint
                {
                    Hint = "Driving less with private transportation and using public transport more often will have a noticeable impact on your carbon footprint.",
                    Image = "publicTransportHint.png"
                });
            }

            // hints for time spent on public transportation, and the best ones to use
            if (busKm > 150)
            {
                await App.Database.SaveHintAsync(new hint
                {
                    Hint = "Although using more of public transport is a good way of cutting your individual carbon footprint, some public transportation is better than others at doing this. Buses fall at the bottom of the list for good public transport. If your region has a metro system, use it.",
                    Image = "busHint.jpg"
                });
            }

            // hints for travelling on an airplane 
            if (flightHours > 0)
            {
                await App.Database.SaveHintAsync(new hint
                {
                    Hint = "Airplane transportation contributes about 250kg of CO2 to your carbon footprint per hour flying. Travelling cross-country or continental? A great alternative is a train, which cuts your CO2 emissions by over 85%.",
                    Image = "planeHint.jpg"
                });
            }

            // hints for diet
            if (dietType == 1)
            {
                await App.Database.SaveHintAsync(new hint
                {
                    Hint = "Meat production, especially red meat, is very carbon intensive. So cutting back on the the amount of red meat you eat helps reduce your footprint.",
                    Image = "meatHint.png"
                });
                await App.Database.SaveHintAsync(new hint
                {
                    Hint = "A vegetarian's carbon footprint from food is two thirds that of an average person's. This is even lower for vegans.",
                    Image = "vegetarian.jpg"
                });
                await App.Database.SaveHintAsync(new hint
                {
                    Hint = "Dairy production is very carbon intensive. Cutting back on the dairy has the benefits of reducing your footprint.",
                    Image = "dairyHint.jpg"
                });
                await App.Database.SaveHintAsync(new hint
                {
                    Hint = "Swapping out beef for chicken cuts off about a quarter of CO2 emissions from food.",
                    Image = "chickenHint.png"
                });
            }
            else if (dietType == 2)
            {
                await App.Database.SaveHintAsync(new hint
                {
                    Hint = "Meat production, especially red meat, is very carbon intensive. So cutting back on the the amount of red meat you eat helps reduce your footprint.",
                    Image = "meatHint.png"
                });
                await App.Database.SaveHintAsync(new hint
                {
                    Hint = "A vegetarian's carbon footprint from food is two thirds that of an average person's. This is even lower for vegans.",
                    Image = "vegetarian.jpg"
                });
                await App.Database.SaveHintAsync(new hint
                {
                    Hint = "Dairy production is very carbon intensive. Cutting back on the dairy has the benefits of reducing your footprint.",
                    Image = "dairyHint.jpg"
                });
                await App.Database.SaveHintAsync(new hint
                {
                    Hint = "Swapping out beef for chicken cuts off about a quarter of CO2 emissions from food.",
                    Image = "chickenHint.png"
                });
            }
            else if (dietType == 3)
            {
                await App.Database.SaveHintAsync(new hint
                {
                    Hint = "A vegetarian's carbon footprint from food is two thirds that of an average person's. This is even lower for vegans.",
                    Image = "vegetarian.jpg"
                });
                await App.Database.SaveHintAsync(new hint
                {
                    Hint = "Dairy production is very carbon intensive. Cutting back on the dairy has the benefits of reducing your footprint.",
                    Image = "dairyHint.jpg"
                });
            }
            else if (dietType == 4)
            {
                await App.Database.SaveHintAsync(new hint
                {
                    Hint = "A vegetarian's carbon footprint from food is two thirds that of an average person's. This is even lower for vegans.",
                    Image = "vegetarian.jpg"
                });
            }
            else if (dietType == 5)
            {
                await App.Database.SaveHintAsync(new hint
                {
                    Hint = "A vegan diet is great for keeping your carbon footprint low. Keep it up!",
                    Image = "fruitHint.png"
                });
            }

            // hints for green electricity
            if (!green)
            {
                await App.Database.SaveHintAsync(new hint
                {
                    Hint = "Getting a green tariff reduces CO2 emissions from household electricity usage by about 25%.",
                    Image = "greenHint.png"
                });
            }

            // hints for renewable energy
            if (!solar) 
            {
                await App.Database.SaveHintAsync(new hint
                {
                    Hint = "Installing and powering your house via solar panels will directly reduce your carbon footprint by over 85%. Complementing this with a battery can help you go completely off the grid!",
                    Image = "solarHint.png"
                });
            }

            if (!solarHeatng || !geoSystem)
            {
                await App.Database.SaveHintAsync(new hint
                {
                    Hint = "Heating counts up to about 78% of your household electricity usage. So its no surprise that switching to a renewable source for heating your water and household will generously reduce your carbon footprint.",
                    Image = "heatingHint.png"
                });
            }

            if (!wind)
            {
                await App.Database.SaveHintAsync(new hint
                {
                    Hint = "Installing a residential wind turbine will greatly help in cutting carbon footprint.",
                    Image = "wind.jpg"
                });
            }
        }
    }
}