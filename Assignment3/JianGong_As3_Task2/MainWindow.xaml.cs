using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;

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

        /// <summary>
        /// Constructs a SQL connection using predefined constants.
        /// </summary>
        /// <returns>A new SqlConnection object configured with the necessary parameters.</returns>
        private SqlConnection getConnection()
        {
            string constr = $"Data Source={server};Initial Catalog={database};User ID={username};Password={password}";
            return new SqlConnection(constr);
        }

        /// <summary>
        /// Loads data from the database and populates the customers ObservableCollection.
        /// </summary>
        private void LoadData()
        {
            customers = new ObservableCollection<Customer>();
            // to open the connection
            SqlConnection conn = getConnection();
            conn.Open();
            // execute select query
            string sql = "Select CustomerID, Name, Telephone from Customers";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dreader = cmd.ExecuteReader();
            // iterate through the data
            while (dreader.Read())
            {
                customers.Add(new Customer
                {
                    CustomerID = dreader.GetInt32(0),
                    Name = dreader.GetString(1),
                    Telephone = dreader.GetString(2)
                });
            }
            // set data to the DataGrid
            customerGrid.ItemsSource = customers;

            // to close the connection
            dreader.Close();
            cmd.Dispose();
            conn.Close();
        }

        /// <summary>
        /// Saves changes made to the customers. Creates new customers or updates existing ones.
        /// </summary>
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to save the changes?", "Confirm Save", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                foreach (Customer customer in customers)
                {
                    if (customer.CustomerID == 0)
                    {
                        CreateCustomer(customer);
                    }
                    else
                    {
                        UpdateCustomer(customer);
                    }
                }
            }
        }

        /// <summary>
        /// Inserts a new customer into the database.
        /// </summary>
        private void CreateCustomer(Customer customer)
        {
            // to open the connection
            SqlConnection conn = getConnection();
            conn.Open();
            // execute insert query
            string sql = @"INSERT INTO Customers (Name, Telephone) VALUES (@Name, @Telephone)";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@Name", customer.Name);
            cmd.Parameters.AddWithValue("@Telephone", customer.Telephone);
            cmd.ExecuteNonQuery();

            // to close the connection
            cmd.Dispose();
            conn.Close();
        }

        /// <summary>
        /// Updates an existing customer's details in the database.
        /// </summary>
        private void UpdateCustomer(Customer customer)
        {
            // to open the connection
            SqlConnection conn = getConnection();
            conn.Open();
            // execute update query
            string sql = @"UPDATE Customers SET Name=@Name, Telephone=@Telephone WHERE CustomerID=@CustomerID";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@Name", customer.Name);
            cmd.Parameters.AddWithValue("@Telephone", customer.Telephone);
            cmd.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
            cmd.ExecuteNonQuery();

            // to close the connection
            cmd.Dispose();
            conn.Close();
        }

        /// <summary>
        /// Deletes a customer from the database.
        /// </summary>
        private void DeleteCustomer(Customer customer)
        {
            // to open the connection
            SqlConnection conn = getConnection();
            conn.Open();
            // execute delete query
            string sql = @"DELETE FROM Customers WHERE CustomerID=@CustomerID";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
            cmd.ExecuteNonQuery();

            // to close the connection
            cmd.Dispose();
            conn.Close();
        }

        /// <summary>
        /// Handles the delete button click. Confirms deletion and removes the customer if confirmed.
        /// </summary>
        private void Delete_Click(object sender, RoutedEventArgs e)
        {

            var button = sender as Button;
            var customer = button.DataContext as Customer;

            if (customer != null)
            {
                MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete '{customer.Name}'?", "Confirm Deletion", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    // 执行删除操作
                    DeleteCustomer(customer);
                    (customerGrid.ItemsSource as ObservableCollection<Customer>).Remove(customer);
                }
            }
        }

        /// <summary>
        /// Refreshes the data displayed in the DataGrid by reloading from the database.
        /// </summary>
        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
    }

    /// <summary>
    /// Represents a customer with ID, Name, and Telephone properties.
    /// </summary>
    public class Customer
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
    }
}