using System;
using System.Windows;
using System.Windows.Controls;
using SimpleCalc.View;
using SimpleCalc.ViewModel;

namespace SimpleCalc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CalculatorViewModel calculator = new CalculatorViewModel();

        public MainWindow()
        {
            InitializeComponent();
            Display.Text = calculator.Display;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            calculator.Button((sender as Button).Content.ToString());
            Display.Text = calculator.Display;
        }

        private void DigitButton_Click(object sender, RoutedEventArgs e)
        {
            calculator.DigitButton((sender as Button).Content.ToString());
            Display.Text = calculator.Display;
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            calculator.OperationButton((sender as Button).Content.ToString());
            Display.Text = calculator.Display;
        }

        private void SingleOperationButton_Click(object sender, RoutedEventArgs e)
        {
            calculator.SingleOperationButton((sender as Button).Content.ToString());
            Display.Text = calculator.Display;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Functions functions = new Functions();
            string text = (e.AddedItems[0] as ComboBoxItem).Content.ToString();
            
            if (text == "FUNCTIONS")
            {
                functions.Show();
            } else if (text == "STANDARD")
            {
                this.Show();
            }
            else
            {
                functions.Close();
                Application.Current.Shutdown();
            }
        }
    }
}
