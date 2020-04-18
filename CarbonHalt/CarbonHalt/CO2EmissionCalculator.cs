// co2 calculator. 
// Disclaimer: These CO2 rates are just averges an are not very accurate as they come form a variety of sources who conduct different experiments. 
// However, the result of the calculation is a good estimate of how much co2 a person is producing in terms of good or bad. A low co2 emission level will be calculated
// if the user truly has a low co2 emission level and vice versa

namespace CarbonHalt
{
    static class CO2EmissionCalculator
    {
        // private transport fields
        public static int vehicleType;
        public static int fuelType;
        public static double kilometersTravelledPrivate;

        // public transport fields
        public static double trainKm;
        public static double metroKm;
        public static double busKm;

        // aviation fields
        public static double flightHours;

        // final and total co2 emissions calculator (result displayed to user)
        public static int CalculateCO2() {
            double co2 = 0;
            co2 += CalculatePrivateTransportEmissions();
            co2 += CalculatePublicTransportEmissions();
            co2 += CalculateAviationEmissions();
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
            double  emissionAmounts = 0;
            emissionAmounts += (trainKm * 0.1);
            emissionAmounts += (metroKm * 0.07);
            emissionAmounts += (busKm * 0.089);
            return emissionAmounts;
        }

        // calculates the amount of co2 released per passenger for number of hours flying. This number is then dived by 52 , to be distrubuted into your weekly emissions.
        // So  if you flew 12 hours in total a year, the emissions returned will be 58 kg
        private static double CalculateAviationEmissions() 
        {
            double emissionAmount = 0;

            emissionAmount = (flightHours * 250) / 52;

            return emissionAmount;
        }
    }
}
