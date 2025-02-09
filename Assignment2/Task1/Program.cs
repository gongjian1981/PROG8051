public class Program
{
    public static void Main(string[] args)
    {
        List<string> customerInfoList = new List<string>();
        while (true)
        {
            Console.WriteLine("is there a new customer?(y for yes, n for no)");
            string hasNewCustomer = Console.ReadLine() ?? "";
            while (hasNewCustomer != "y" && hasNewCustomer != "n")
            {
                Console.WriteLine("input error, please type 'y' for yes, 'n' for no");
                hasNewCustomer = Console.ReadLine() ?? "";
            }
            if (hasNewCustomer == "n")
            {
                break;
            }
            Console.WriteLine("select the palace need to be wired?h for house, b for barn, or g for garages:");
            string palace = Console.ReadLine() ?? "";
            while (palace != "h" && palace != "b" && palace != "g")
            {
                Console.WriteLine("input error, please type 'h' for house, 'b' for barn, or 'g' for garages");
                palace = Console.ReadLine() ?? "";
            }
            customerInfoList.Add(hasNewCustomer);
        }
        if (customerInfoList.Count == 0)
        {
            Console.WriteLine("no new customer");
        }
        else
        {
            foreach (string customerInfo in customerInfoList)
            {
                Console.WriteLine(customerInfo);
            }
        }
    }
}