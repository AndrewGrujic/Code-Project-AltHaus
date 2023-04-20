using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Code_Project_AltHaus
{
    internal class BMIApp
    {
        //Enums classes for the weight class BMI calculates.
        enum BMIClass
        {
            Underweight,
            Healthy,
            Overweight,
            Obese
        };

        public static void BMI()
        {
            Console.WriteLine("Welcome to the BMI Calculator.");
        BMIStart:
            Console.WriteLine("Please enter your weight in KG:");

        UserWeight:
        //Parses and validates the input for the user weight.
            bool weightCheck = Double.TryParse(Console.ReadLine(), out double userWeight);
            if (userWeight <= 0 || !weightCheck)
            {
                Console.WriteLine("This is not a valid weight, please try again.");
                goto UserWeight;
            }

            Console.WriteLine("Please enter your height in meters:");

        UserHeight:
        //Parses and validates the input for the user height.
            bool heightCheck = Double.TryParse(Console.ReadLine(), out double userHeight);
            if (userHeight <= 0 || !heightCheck )
            {
                Console.WriteLine("This is not a valid height, please try again.");
                goto UserHeight;
            }

            //Main calculation and rounding for the user BMI to be output.
            double squaredHeight = userHeight * userHeight;
            double outBMI = Math.Round(userWeight / squaredHeight, 2);

            Console.Clear();

            //Range simply makes sure that that BMI range fits within 1 of the 4 classes.
            switch (outBMI)
            {
                case double range when range < 18.5:
                    Console.WriteLine($"Your BMI is {outBMI} which means your class is {BMIClass.Underweight}.");
                    Console.WriteLine();
                    break;

                case double range when range >= 18.5 && range < 25:
                    Console.WriteLine($"Your BMI is {outBMI} which means your class is {BMIClass.Healthy}");
                    Console.WriteLine();
                    break;

                case double range when range >= 25 && range < 30:
                    Console.WriteLine($"Your BMI is {outBMI} which means your class is {BMIClass.Overweight}");
                    Console.WriteLine();
                    break;

                case double range when range >= 30:
                    Console.WriteLine($"Your BMI is {outBMI} which means your class is {BMIClass.Obese}");
                    Console.WriteLine();
                    break;
            }

            SelectionRetry:
            Console.WriteLine("Would you like to quit BMI Calculator or retry?");
            Console.WriteLine("0: Quit BMI Calculator");
            Console.WriteLine("1: Retry BMI Calculation");

            bool isValid = Int32.TryParse(Console.ReadLine(), out int selection);

            if (selection < 0 || !isValid)
            {
                Console.WriteLine("This is not a valid selection, please try again.");
                goto SelectionRetry;
            }

            switch (selection)
            {
                case 0:
                    Console.Clear();
                    return;
                case 1:
                    Console.Clear();
                    goto BMIStart;
                default:
                    Console.Clear();
                    Console.WriteLine("This is not a valid selection, please try again.");
                    goto SelectionRetry;
            }
        }
    }
}
