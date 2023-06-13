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

namespace Simple_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double inp1, inp2, resultnum = 0;
        bool isFirst = true;
        bool equalsClicked = false;
        string currExpr = "";
        public enum Operation
        {   
            None,
            Addition, 
            Subtraction,
            Multiplication,
            Division,
            Modulo,
        }
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
            double contentVal = double.Parse(content);

            if (isFirst)
            {
                expression.Content = Expression_Updater(currExpr, content.ToString());
                contentVal = Number_Handler(inp1, contentVal);
                inp1 = contentVal;
            }
            else
            {
                Expression_Updater(currExpr, content.ToString());
                contentVal = Number_Handler(inp2, contentVal);
                inp2 = contentVal;
            }

            result.Content = (contentVal);
        }

        private void OperatorButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button )sender; 

            string? content = button.Content.ToString();

            switch(content)
            {
                case "+":
                    op = Operation.Addition;
                    isFirst = false;
                    expression.Content = Expression_Updater(currExpr, " + ");
                    break;
                case "-":  
                    op = Operation.Subtraction;
                    isFirst = false;
                    expression.Content = Expression_Updater(currExpr, " - ");
                    break;
                case "*":
                    op = Operation.Multiplication;
                    isFirst = false;
                    expression.Content = Expression_Updater(currExpr, " x ");
                    break;
                case "/":
                    op = Operation.Division;
                    isFirst = false;
                    expression.Content = Expression_Updater(currExpr, " / ");
                    break;
                case "Modulo":
                    op = Operation.Modulo; 
                    isFirst = false;
                    expression.Content = Expression_Updater(currExpr, " mod ");
                    break;
                default:
                    op = Operation.None;
                    break;
            }
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            switch (op)
            {
                case Operation.Addition:
                    resultnum = inp1 + inp2;
                    inp1 = resultnum;
                    inp2 = 0;
                    isFirst = true;
                    break;
                case Operation.Subtraction:
                    resultnum = inp1 - inp2;
                    inp1 = resultnum;
                    inp2 = 0;
                    isFirst = true;
                    break;
                case Operation.Multiplication:
                    resultnum = inp1 * inp2;
                    inp1 = resultnum;
                    inp2 = 0;
                    isFirst = true;
                    break;
                case Operation.Division:   
                    resultnum = inp1 / inp2;
                    inp1 = resultnum;
                    inp2 = 0;
                    isFirst = true;
                    break;
                case Operation.Modulo:
                    resultnum = inp1 % inp2;
                    inp1 = resultnum;
                    inp2 = 0;
                    isFirst = true;
                    break;
            }
            expression.Content = currExpr + " = ";
            currExpr = resultnum.ToString();
            result.Content = resultnum;

        }

        private double Number_Handler(double currentInp, double newInp)
        {
            return (currentInp * 10 + newInp);
        }

        private string Expression_Updater(string curr, string entry)
        {
                currExpr = curr + entry;
                return currExpr;  
        }

        private void ClearerButton_Click(object sender,  EventArgs e)
        {
            Button button = (Button)sender;

            inp1 = inp2 = resultnum = 0;
            isFirst = true;
            op = Operation.None;
            currExpr = "";
            result.Content = resultnum;
            expression.Content = "";
        }
    }
}
