using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JianGong_As3_Task1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Variable to store the current input from the user as a string.
        private string input = string.Empty;

        // Variables to store the first and second numbers in the operation.
        private int num1;
        private int num2;

        // Variable to store the current operation selected by the user.
        private char operation;

        // Event handler for the 'C' button click.
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            // Reset the input and the display to their initial states.
            input = string.Empty;
            txtDisplay.Text = "0";
            operation = ' ';
        }

        // Event handlers for each operation button click.
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Symbol_Click('+');
        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            Symbol_Click('-');
        }

        private void Multiply_Click(object sender, RoutedEventArgs e)
        {
            Symbol_Click('*');
        }

        private void Divided_Click(object sender, RoutedEventArgs e)
        {
            Symbol_Click('/');
        }

        // General method to handle operation button clicks.
        private void Symbol_Click(char c) 
        {
            // Check if no operation has been selected yet.
            if ((operation != '+') && (operation != '-') && (operation != '*') && (operation != '/'))
            {
                // Parse the current input as the first number.
                num1 = int.Parse(input);
                // Set the selected operation.
                operation = c;
                // Add the operation symbol to the current input display.
                input += c;
                // Update the text display to show the current input.
                txtDisplay.Text = input;
            }
        }

        // Event handler for the '=' button click.
        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            // Perform the calculation based on the operation selected.
            if (operation == '+')
            {
                // Parse the second number and calculate the sum.
                num2 = int.Parse(input.Substring(input.IndexOf('+') + 1));
                input = (num1 + num2).ToString();
            }
            else if (operation == '-')
            {
                // Parse the second number and calculate the difference.
                num2 = int.Parse(input.Substring(input.IndexOf('-') + 1));
                input = (num1 - num2).ToString();
            }
            else if (operation == '*')
            {
                // Parse the second number and calculate the product.
                num2 = int.Parse(input.Substring(input.IndexOf('*') + 1));
                input = (num1 * num2).ToString();
            }
            else if (operation == '/')
            {
                // Parse the second number and calculate the quotient.
                num2 = int.Parse(input.Substring(input.IndexOf('/') + 1));
                input = (num1 / num2).ToString();
            }
            // Update the display with the result.
            txtDisplay.Text = input;
            // Reset the operation to allow a new calculation.
            operation = ' ';
        }

        // Event handler for numeric button clicks.
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Get the content of the button that was clicked.
            var button = sender as Button;
            // Add the button's content to the current input.
            input += button.Content.ToString();
            // Update the text display to show the current input.
            txtDisplay.Text = input;
        }
    }
}