using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Text;
using System.Windows;

namespace JianGong_As3_Task2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        // define a list for the customers data
        private ObservableCollection<Customer> customers;

        // define constants for the connection string
        private const string server = @"BHSLAPTOP\SQLEXPRESS22";
        private const string database = "Jian_8956828_PROG8051_A3";
        private const string username = "sa";
        private const string password = "Conestoga1";

        private SqlConnection getConnection()
        {
            string constr = $"Data Source={server};Initial Catalog={database};User ID={username};Password={password}";
            return new SqlConnection(constr);
        }

        private void LoadData()
        {
            customers = new ObservableCollection<Customer>();
            SqlConnection conn = getConnection();
            // to open the connection
            conn.Open();
            string sql = "Select CustomerID, Name, Telephone from Customers";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dreader = cmd.ExecuteReader();

            while (dreader.Read())
            {
                customers.Add(new Customer
                {
                    CustomerID = dreader.GetInt32(0),
                    Name = dreader.GetString(1),
                    Telephone = dreader.GetString(2)
                });
            }
            customerGrid.ItemsSource = customers;

            // to close the connection
            dreader.Close();
            cmd.Dispose();
            conn.Close();
        }
    }

    public class Customer
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
    }
}