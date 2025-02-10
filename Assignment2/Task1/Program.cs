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
        /**
         * use loop to get customer's infomation repeatly
         * break loop only when user input 'n'
         */
        while (true)
        {
            // prompt user's input
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
            Console.WriteLine("select the palace need to be wired?h for house, b for barn, or g for garages:");
            string palace = Console.ReadLine() ?? "";
            // validate the user's input for palace
            while (palace != "h" && palace != "b" && palace != "g")
            {
                Console.WriteLine("input error, please type 'h' for house, 'b' for barn, or 'g' for garages");
                palace = Console.ReadLine() ?? "";
            }
            // add information to the the information list
            customerInfoList.Add(hasNewCustomer);
        }
        // check if the customers' list is empty, output on customers
        if (customerInfoList.Count == 0)
        {
            Console.WriteLine("no new customer");
        }
        else
        {
            // use for to loop the customers list to display customer information
            foreach (string customerInfo in customerInfoList)
            {
                Console.WriteLine(customerInfo);
            }
        }
    }
}