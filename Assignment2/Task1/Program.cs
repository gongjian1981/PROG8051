using System.Text;
using System.Text.RegularExpressions;

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
        // define a list which contains all the informations of each customers
        List<string> customerInfoList = new List<string>();
        // define a list to record each customer's building type
        List<string> workPlaceList = new List<string>();
        // index for the customer
        int customerIndex = 0;
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
            // define the actual name of place to be wired bases on the user's input
            string placeToWire;
            if (selectedPlace == "h")
            {
                placeToWire = "house";
            }
            else if (selectedPlace == "b")
            {
                placeToWire = "barn";
            }
            else
            {
                placeToWire = "garage";
            }
            // make the index of the customer increased by 1
            customerIndex++;
            // define a string builder which will hold the information of the customer
            StringBuilder info = new StringBuilder();
            // first append customer's index and place to be wired
            info.Append("customer ").Append(customerIndex).Append(" asks to wire a ").Append(placeToWire);

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
            info.Append(" which size is ").Append(size);
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
            info.Append(", the number of required light bulbs are ").Append(bulbs);
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
            info.Append(", the number of required outlets are ").Append(bulbs);
            // prompt for credit card number
            Console.WriteLine("Thank you for purchasing our service, please input your credit card in the form of 16-digit string");
            string creditCardNumber = Console.ReadLine()??"";
            // validate the input of credit card number
            Regex creditCardRegex = new Regex(@"^\d{16}$");
            while (!creditCardRegex.IsMatch(creditCardNumber))
            {
                Console.WriteLine("credit card need to be in the form of 16-digit string");
                creditCardNumber = Console.ReadLine() ?? "";
            }
            info.Append(". credit card number is ").Append(creditCardNumber.Substring(0, 4))
                .Append(" XXXX XXXX ").Append(creditCardNumber.Substring(12));
            // add the customer's information to the information list
            customerInfoList.Add(info.ToString());
            // add the place to be wired to the work list
            workPlaceList.Add(placeToWire);
        }
        // first if the customers' list is empty, output on customers
        if (customerInfoList.Count == 0)
        {
            Console.WriteLine("no new customer");
        }
        /*
         * use for to loop the customers list to display customer information, 
         * and output work for each type of place to be wired
         */
        for (int i = 0; i < customerInfoList.Count; i++)
        {
            Console.WriteLine(customerInfoList[i]);
            work(workPlaceList[i]);
        }
    }

    /**
     * <summary>
     * Provide the output of operations based on the type of place to be wired
     * </summary>
     * <param name="place">The type of place to be wired</param>
     */
    private static void work(string place)
    {
        Console.WriteLine("\n========== START WORKING ==========");
        Console.WriteLine("Create wiring schemas ... DONE!");
        Console.WriteLine("Purchase necessary parts ... DONE!");
        if (place == "house")
        {
            Console.WriteLine("Install fire alarms ... DONE!");
        }
        else if (place == "barn")
        {
            Console.WriteLine("Wire milking equipment ... DONE!");
        }
        else if (place == "garage")
        {
            Console.WriteLine("Install install automatic doors ... DONE!");
        }
        Console.WriteLine("========== WORK FINISHED ==========\n");
    }
}