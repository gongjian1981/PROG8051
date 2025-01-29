using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Declares a namespace called Assignment1 because this project is for Assignment 1
namespace Assignment1
{
    // Defines a class named Jian_Gong_As1_Task_1 because it is for the task 1
    internal class Jian_Gong_As1_Task_1
    {
        // Enumeration 'City' listing the cities Carlo can travel to
        enum City
        {
            Calgary,    // Represents the city of Calgary
            Vancouver,  // Represents the city of Vancouver
            Montreal    // Represents the city of Montreal
        }

        // Main entry point of the program, with 'Main2' as an alternative entry point name
        public static void Main2(string[] args)
        {
            // Prints a welcome message to the console
            Console.WriteLine("Welcome Carlo");
            // Define a variable named totalMoney to store the total money spent by Carlo
            double totalMoney = 0;
            // Define a variable named tripCount to count the total number of trips Carlo took
            int tripCount = 0;

            // Iterates over each city defined in the City enum
            foreach (City city in Enum.GetValues(typeof(City)))
            {
                // Infinite loop to handle user input until valid data is entered
                while (true)
                {
                    // Asks the user for the number of trips to the current city in the loop
                    Console.WriteLine($"How many trips do you want to take to {city}?");
                    int times = 0; // Initializes the trips count
                    try
                    {
                        // Attempts to parse the user input into an integer
                        times = int.Parse(Console.ReadLine() ?? "");
                    }
                    catch (Exception)
                    {
                        // Error message if input is not an integer, then continues the loop
                        Console.WriteLine("Please input a valid integer.");
                        continue;
                    }
                    // Validates that the number of trips is non-negative
                    if (times < 0)
                    {
                        // Error message if the number is negative, then continues the loop
                        Console.WriteLine("The number of trips must be zero or greater.");
                        continue;
                    }
                    // Adds the number of trips to the total trip count
                    tripCount += times;
                    // Calculates total money spent based on the city
                    if (city == City.Calgary)
                    {
                        totalMoney += 1350 * times; // Costs for Calgary trips
                    }
                    else if (city == City.Vancouver)
                    {
                        totalMoney += 1500 * times; // Costs for Vancouver trips
                    }
                    else if (city == City.Montreal)
                    {
                        totalMoney += 575 * times; // Costs for Montreal trips
                    }
                    break; // Breaks the infinite loop after processing valid input
                }
            }
            // Checks if Carlo took any trips
            if (tripCount == 0)
            {
                // Message indicating no trips were taken
                Console.WriteLine("Carlo didn't go anywhere!");
            }
            else
            {
                // Output total spent and average cost per trip
                Console.WriteLine($"Carlo spent a total of {totalMoney.ToString("C")}, " +
                    $"and the average cost per trip is {(totalMoney / tripCount).ToString("C")}.");
            }
        }
    }
}
