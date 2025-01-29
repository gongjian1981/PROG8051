using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Declares a namespace called Assignment1 because this project is for Assignment 1
namespace Assignment1
{
    // Defines a class named Jian_Gong_As1_Task_2 because it is for the task 2
    internal class Jian_Gong_As1_Task_2
    {
        // Enumeration 'Seat' listing the types of seats Joe can afford at a game
        enum Seat
        {
            Purple,    // Represents a Purple seat, typically the least expensive
            Green,     // Represents a Green seat, more expensive than Purple
            Blue       // Represents a Blue seat, the most expensive option
        }

        // Main entry point of the program, named simply 'Main'
        public static void Main(string[] args)
        {
            // Prints a welcome message to the console for Joe
            Console.WriteLine("Welcome Joe");
            // Define a variable to store the total money spent by Joe on seats
            double totalMoney = 0;
            // Define a variable to count the total number of games Joe watched
            int gameCount = 0;

            // Iterates over each seat type defined in the Seat enum
            foreach (Seat seat in Enum.GetValues(typeof(Seat)))
            {
                // Infinite loop to handle user input until valid data is entered
                while (true)
                {
                    // Asks the user for the number of seats they want to buy of a particular type
                    Console.WriteLine($"How many tickets for {seat} seats would you like to buy?");
                    int times = 0; // Initializes the seat count
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
                    // Validates that the number of seats is non-negative
                    if (times < 0)
                    {
                        // Error message if the number is negative, then continues the loop
                        Console.WriteLine("The number of tickets must be zero or greater.");
                        continue;
                    }
                    // Adds the number of seats to the total game count
                    gameCount += times;
                    // Calculates total money spent based on the seat type
                    if (seat == Seat.Purple)
                    {
                        totalMoney += 50 * times; // Cost for Purple seats
                    }
                    else if (seat == Seat.Green)
                    {
                        totalMoney += 80 * times; // Cost for Green seats
                    }
                    else if (seat == Seat.Blue)
                    {
                        totalMoney += 100 * times; // Cost for Blue seats
                    }
                    break; // Breaks the infinite loop after processing valid input
                }
            }
            // Checks if Joe watched any games
            if (gameCount == 0)
            {
                // Message indicating Joe didn't watch any games
                Console.WriteLine("Joe did not watch any games.");
            }
            else
            {
                // Output total spent and average cost per game watched
                Console.WriteLine($"Joe spent a total of {totalMoney.ToString("C")}, " +
                    $"with an average cost of {(totalMoney / gameCount).ToString("C")} per game.");
            }
        }
    }
}
