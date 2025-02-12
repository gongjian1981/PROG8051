using System.Text;
using System.Text.RegularExpressions;

namespace Task2
{
    public delegate void DoBuildingWireWork(IBuilding building);

    /// <summary>
    /// Class <c>Program</c> is a program that used for task 1
    /// </summary>
    public class Program
    {

        /// <summary>
        /// main entrance for this project
        /// </summary>
        public static void Main(string[] args)
        {
            // define a list which contains all the informations of each building
            List<IBuilding> buildings = new List<IBuilding>();
            /**
             * use loop to get customer's infomation repeatly
             * break loop only when user input 'n'
             */
            while (true)
            {
                Console.WriteLine("is there a new customer?(y for yes, n for no)");
                // get user input
                string hasNewCustomer = Console.ReadLine() ?? "";
                // validate the user's input, it's correct only when user input 'y' or 'n'
                while (hasNewCustomer != "y" && hasNewCustomer != "n")
                {
                    Console.WriteLine("input error, please type 'y' for yes, 'n' for no");
                    hasNewCustomer = Console.ReadLine() ?? "";
                }
                // when user input is 'n', break the loop and start to show information
                if (hasNewCustomer == "n")
                {
                    break;
                }
                // there is a new user, prompt for specific informations
                Console.WriteLine("select the place need to be wired? h for house, b for barn, or g for garage:");
                string selectedPlace = Console.ReadLine() ?? "";
                // validate the user's input for place to wire
                while (selectedPlace != "h" && selectedPlace != "b" && selectedPlace != "g")
                {
                    Console.WriteLine("input error, please type 'h' for house, 'b' for barn, or 'g' for garage");
                    selectedPlace = Console.ReadLine() ?? "";
                }
                // define a building object which hold the the building's information of this customer
                IBuilding building = null;
                if (selectedPlace == "h")
                {
                    building = new House();
                    building.Type = "house";
                }
                else if (selectedPlace == "b")
                {
                    building = new Barn();
                    building.Type = "barn";
                }
                else
                {
                    building = new Garage();
                    building.Type = "garage";
                }
                // prompt for size
                Console.WriteLine("how big is the place(its size)?");
                int size = 0;
                // validate the input
                while (true)
                {
                    try
                    {
                        size = int.Parse(Console.ReadLine() ?? "0");
                    }
                    catch (Exception)
                    {
                    }
                    if (size <= 50000 && size >= 1000)
                    {
                        break;
                    }
                    Console.WriteLine("please input the size(cannot exceed 50000 and not less than 1000)");
                }
                building.BuildingSize = size;
                // prompt for light bulbs number
                Console.WriteLine("how many are the required light bulbs?");
                int bulbs = 0;
                // validate the input
                while (true)
                {
                    try
                    {
                        bulbs = int.Parse(Console.ReadLine() ?? "0");
                    }
                    catch (Exception)
                    {
                    }
                    if (bulbs <= 20 && bulbs > 0)
                    {
                        break;
                    }
                    Console.WriteLine("please input the size(no more than 20 and more than zero)");
                }
                building.LightBulbNumber = bulbs;
                // prompt for outlets number
                Console.WriteLine("how many are the required outlets?");
                int outlets = 0;
                // validate the input
                while (true)
                {
                    try
                    {
                        outlets = int.Parse(Console.ReadLine() ?? "0");
                    }
                    catch (Exception)
                    {
                    }
                    if (outlets <= 50 && outlets > 0)
                    {
                        break;
                    }
                    Console.WriteLine("please input the size(no more than 50 and more than zero)");
                }
                building.OutletNumber = outlets;
                // prompt for credit card number
                Console.WriteLine("Thank you for purchasing our service, please input your credit card in the form of 16-digit string");
                string creditCardNumber = Console.ReadLine() ?? "";
                // validate the input of credit card number
                Regex creditCardRegex = new Regex(@"^\d{16}$");
                while (!creditCardRegex.IsMatch(creditCardNumber))
                {
                    Console.WriteLine("credit card need to be in the form of 16-digit string");
                    creditCardNumber = Console.ReadLine() ?? "";
                }
                building.CreditCardNumber = creditCardNumber;
                // add the building's information to the building list
                buildings.Add(building);
            }
            // first if the customers' list is empty, output on customers
            if (buildings.Count == 0)
            {
                Console.WriteLine("no new customer");
            }
            /*
             * Sort the list by size of house
             */
            buildings.Sort();
            DoBuildingWireWork work = DoWork;
            /*
             * use for to loop the customers list to display customer information, 
             * and output work for each type of place to be wired
             */
            foreach (IBuilding building in buildings)
            {
                Console.WriteLine($"customer asks to wire a {building.Type}, " +
                    $"which size is {building.BuildingSize}." +
                    $"the number of required light bulbs are {building.LightBulbNumber}, " +
                    $"the number of required outlets are {building.OutletNumber}. " +
                    $"User credit card number is {building.CreditCardNumber.Substring(0, 4)} " +
                    $"XXXX XXXX {building.CreditCardNumber.Substring(12)}");
                work(building);
            }
        }

        /**
         * <summary>
         * Provide the output of operations
         * </summary>
         * <param name="operations">The list of operations to be operated</param>
         */
        public static void DoWork(IBuilding building)
        {
            Console.WriteLine($"\n========== START WORKING AT {building.Type} ==========");
            foreach (string operation in building.GetAllOperations())
            {
                Console.WriteLine(operation);
            }
            Console.WriteLine("========== WORK FINISHED ==========\n");
        }
    }
}