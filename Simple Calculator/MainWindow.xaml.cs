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
        public enum Operation
        {   
            None,
            Addition, 
            Subtraction,
            Multiplication,
            Division,
        }
        Operation op = Operation.None;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            string? content = button.Content.ToString();
            double contentVal = double.Parse(content);

            if (isFirst)
            {
                contentVal = Number_Handler(inp1, contentVal);
                inp1 = contentVal;
            }
            else
            {
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
                    isFirst = !isFirst;
                    break;
                case "-":  
                    op = Operation.Subtraction;
                    isFirst = !isFirst;
                    break;
                case "*":
                    op = Operation.Multiplication;
                    isFirst = !isFirst;
                    break; 
                case "/":
                    op = Operation.Division;
                    isFirst = !isFirst;
                    break;
                default:
                    op = Operation.None;
                    break;
            }
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button )sender;

            switch (op)
            {
                case Operation.Addition:
                    resultnum = inp1 + inp2;
                    result.Content = (resultnum);
                    break;
            }

        }


        private double Number_Handler(double currentInp, double newInp)
        {
            return (currentInp * 10 + newInp);
        }
    }
}
