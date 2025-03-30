using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace JianGong_As3_Task1
{
    /// <summary>
    /// doubleeraction logic for MainWindow.xaml
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
        private double num1;
        private double num2;

        // Variable to store the current operation selected by the user.
        private char operation;

        // Variable to store the current state of the input.
        private bool isTyping = false;

        // Event handler for the 'C' button click.
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            // Reset the input and the display to their initial states.
            input = string.Empty;
            operation = ' ';
            if (isTyping)
            {
                txtDisplay.Text = "";
            }
            else
            {
                txtDisplay.Text = "0";
            }
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
        private void Symbol_Click(char operationSymbol)
        {
            if (isTyping)
            {
                return;
            }
            if (input == string.Empty)
            {
                return;
            }
            // Check if the input has reached the maximum length.
            if (input.Length == 14)
            {
                txtDisplay.Text = "data overflow";
                input = string.Empty;
                return;
            }
            // Check if no operation has been selected yet.
            if ((operation != '+') && (operation != '-') && (operation != '*') && (operation != '/'))
            {
                // Parse the current input as the first number.
                num1 = double.Parse(input);
                // Set the selected operation.
                operation = operationSymbol;
                // Add the operation symbol to the current input display.
                input += operationSymbol;
                // Update the text display to show the current input.
                txtDisplay.Text = input;
            }
        }

        // Event handler for the '=' button click.
        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            if (isTyping)
            {
                calculateStr(txtDisplay.Text);
            } 
            else
            {
                if (operation == ' ')
                {
                    return;
                }
                if (num1.ToString().Length + 1 == input.Length)
                {
                    return;
                }
                // Perform the calculation based on the operation selected.
                if (operation == '+')
                {
                    // Parse the second number and calculate the sum.
                    num2 = double.Parse(input.Substring(input.IndexOf('+') + 1));
                    input = (num1 + num2).ToString();
                }
                else if (operation == '-')
                {
                    // Parse the second number and calculate the difference.
                    num2 = double.Parse(input.Substring(input.IndexOf('-') + 1));
                    input = (num1 - num2).ToString();
                }
                else if (operation == '*')
                {
                    // Parse the second number and calculate the product.
                    num2 = double.Parse(input.Substring(input.IndexOf('*') + 1));
                    input = (num1 * num2).ToString();
                }
                else if (operation == '/')
                {
                    // Parse the second number and calculate the quotient.
                    num2 = double.Parse(input.Substring(input.IndexOf('/') + 1));
                    if (num2 == 0)
                    {
                        input = "Error";
                    }
                    else
                    {
                        input = (num1 / num2).ToString();
                        if (input.Length > 14)
                        {
                            input = input.Substring(0, 14);
                        }
                    }
                }

                // Update the display with the result.
                txtDisplay.Text = input;
                if (input == "Error")
                {
                    input = String.Empty;
                }
                // Check if the input has reached the maximum length.
                if (input.Length > 14)
                {
                    txtDisplay.Text = "data overflow";
                    input = string.Empty;
                    return;
                }
                // Reset the operation to allow a new calculation.
                operation = ' ';
            }
        }

        /// <summary>
        /// Processes a string containing a mathematical expression and evaluates it.
        /// The method checks for text length to prevent overflow and validates the format of the input string.
        /// It supports basic arithmetic operations: addition, subtraction, multiplication, and division.
        /// Displays the result in txtDisplay or an error message if the input is invalid or a division by zero occurs.
        /// </summary>
        /// <param name="text">The text string containing the arithmetic expression to be evaluated.</param>
        private void calculateStr(string text)
        {
            // Check if the input text is too long to process
            if (text.Length > 14)
            {
                txtDisplay.Text = "data overflow";
                return;
            }

            // Regular expressions to validate the input text format
            string allNumberPattern = @"^\d+$";
            string numberAndSymbolPattern = @"^\d+[\+\-\*\/]$";

            // Return if the input is empty or matches basic number or number with an operation symbol patterns
            if (text == string.Empty || Regex.IsMatch(text, allNumberPattern) || Regex.IsMatch(text, numberAndSymbolPattern))
            {
                return;
            }

            // Pattern to match simple arithmetic expressions
            string calculatablePattern = @"^(\d+)([\+\-\*\/])(\d+)$";
            Match match = Regex.Match(text, calculatablePattern);

            // If the pattern matches, process the arithmetic expression
            if (match.Success)
            {
                string firstNumber = match.Groups[1].Value;
                string operatorSymbol = match.Groups[2].Value;
                string secondNumber = match.Groups[3].Value;

                // Convert matched strings to doubles for calculation
                double firstNum = double.Parse(firstNumber);
                double secondNum = double.Parse(secondNumber);

                // Perform calculation based on the operator symbol
                if (operatorSymbol == "+")
                {
                    txtDisplay.Text = (firstNum + secondNum).ToString();
                }
                else if (operatorSymbol == "-")
                {
                    txtDisplay.Text = (firstNum - secondNum).ToString();
                }
                else if (operatorSymbol == "*")
                {
                    txtDisplay.Text = (firstNum * secondNum).ToString();
                }
                else if (operatorSymbol == "/")
                {
                    // Handle division by zero
                    if (secondNum == 0)
                    {
                        txtDisplay.Text = "Error";
                    }
                    else
                    {
                        // Calculate division and handle long results
                        string result = (firstNum / secondNum).ToString();
                        if (result.Length > 14)
                        {
                            result = result.Substring(0, 14);
                        }
                        txtDisplay.Text = result;
                    }
                }
            }
            else
            {
                // Display error if the expression doesn't match the expected format
                txtDisplay.Text = "Error";
            }
        }


        // Event handler for numeric button clicks.
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (isTyping)
            {
                return;
            }
            // Check if the input has reached the maximum length.
            if (input.Length == 14)
            {
                txtDisplay.Text = "data overflow";
                input = string.Empty;
                return;
            }
            // Get the content of the button that was clicked.
            var button = sender as Button;
            // Add the button's content to the current input.
            input += button.Content.ToString();
            // Update the text display to show the current input.
            txtDisplay.Text = input;
        }

        /// <summary>
        /// Handles the click event for the input button, toggling the typing state of the application.
        /// Changes the button's background color based on whether the user is currently typing or not,
        /// clears the current input and operation, and resets the display text appropriately.
        /// </summary>
        private void InputButton_Click(object sender, RoutedEventArgs e)
        {
            if (isTyping)
            {
                Input_Button.Background = new SolidColorBrush(Color.FromRgb(224, 224, 224));
                input = string.Empty;
                txtDisplay.Text = "0";
                operation = ' ';
                isTyping = false;
            }
            else
            {
                Input_Button.Background = new SolidColorBrush(Color.FromRgb(32, 32, 32));
                input = string.Empty;
                txtDisplay.Text = "";
                operation = ' ';
                isTyping = true;
            }
        }
    }
}