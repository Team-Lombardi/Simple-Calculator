using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

Line 16 shall break the code
    This shall as well

namespace Simple_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public enum Operation
        {
            None,
            Addition,
            Subtraction,
            Multiplication,
            Division,
            Modulo,
        }
        decimal inp1, inp2, resultnum = 0.0m;
        bool isSecond = false;
        bool isDecimal = false;
        bool isNew = true;
        decimal decimalPlace = 1.0m;
        string currentExpression = "";
        Operation op = Operation.None;

        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            string? content = button.Content.ToString();
            decimal contentDecimal = Decimal.Parse(content);

            if (isNew)
            {
                Resetter();
                isNew = false;
            }

            Number_Handler(contentDecimal);
            Input_Display();
        }

        private void OperatorButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender; 

            string? content = button.Content.ToString();

            switch(content)
            {
                case "+":
                    op = Operation.Addition; break;
                case "-":
                    op = Operation.Subtraction; break;
                case "*": 
                    op = Operation.Multiplication; break;
                case "/":
                    op = Operation.Division; break;
                case "Modulo":
                    op = Operation.Modulo; break;
            }

            Expression_Display(content);
            
            isDecimal = false;
            decimalPlace = 1.0m;
            isSecond = true;
            isNew = false;
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            switch(op)
            {
                case Operation.Addition:
                    resultnum = inp1 + inp2; break;
                case Operation.Subtraction:
                    resultnum = inp1 - inp2; break;
                case Operation.Multiplication:
                    resultnum = inp1 * inp2; break;
                case Operation.Division:
                    resultnum = inp1 / inp2; break;
                case Operation.Modulo:
                    resultnum = inp1 % inp2; break;
                default:
                    resultnum = 0; break;
            }

            Expression_Display("");
            Result_Display();

            inp1 = resultnum;
            inp2 = 0;
            isSecond = false;
            currentExpression = "";
            isNew = true;
        }

        private void DecimalButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            isDecimal = true;

        }

        private void Number_Handler(decimal input)
        {
            if (!isDecimal)
            {
                if (!isSecond)
                {
                    inp1 = (inp1 * 10) + input;
                }
                else
                {
                    inp2 = (inp2 * 10) + input;
                }
            }
            else
            {
               if(!isSecond)
               {
                    inp1 = inp1 + (input / (10 * decimalPlace));
                    decimalPlace *= 10;
               }
                else
                {
                    inp2 = inp2 + (input / (10 * decimalPlace));
                    decimalPlace *= 10;
                }
            }
        }

        private void Input_Display() { 
            
            if (!isSecond)
            {
                result.Content = inp1; 
            }
            else
            {
                result.Content = inp2;
            }
        }


        private void Expression_Display(string operatorStr)
        {

            if (!isSecond)
            {
                if (inp1 % 1 == 0)
                {
                    int wholenum = (int)inp1;
                    currentExpression = $"{wholenum.ToString()} {operatorStr}";
                    expression.Content = $"{wholenum.ToString()} {operatorStr}";
                }
                else
                {
                    currentExpression = $"{inp1.ToString()} {operatorStr}";
                    expression.Content = $"{inp1.ToString()} {operatorStr}";
                }
            }
            else
            {
                expression.Content = $"{currentExpression} {inp2.ToString()} = ";
            }

        }

        private void Result_Display()
        {
            if (resultnum % 1 == 0)
            {
                int wholenum = (int)resultnum;
                result.Content = wholenum.ToString();
            }
            else
                result.Content = resultnum;
        }


        private void Resetter()
        {

            inp1 = inp2 = resultnum = 0;
            isSecond = false;
            isDecimal = false;
            decimalPlace = 1.0m;
            currentExpression = "";
            op = Operation.None;
            result.Content = 0;
            expression.Content = "";

        }
        private void ClearerButton_Click(object sender,  EventArgs e)
        {
            Button button = (Button)sender;
            Resetter();
        }
    }
}
