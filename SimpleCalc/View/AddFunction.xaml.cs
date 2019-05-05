using SimpleCalc.Model;
using SimpleCalc.ViewModel;
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
using System.Windows.Shapes;

namespace SimpleCalc.View
{
    /// <summary>
    /// Interaction logic for AddFunction.xaml
    /// </summary>
    public partial class AddFunction : Window
    {
        private AddFunctionsViewModel addFunctions = new AddFunctionsViewModel();
        private int cursorPos = 0;
        private FunctionColor fc;
        private Color color = new Color();

        public FunctionColor Fc
        {
            get { return fc; }
            set { fc = value; }
        }

        public AddFunction(FunctionColor fc)
        {
            InitializeComponent();
            this.fc = fc;

            Functions.Text = fc.Function;
            cp.SelectedColor = fc.Color;

        }

        private void SelectedColorChanged1(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            if (cp.SelectedColor.HasValue)
            {
                Color C = cp.SelectedColor.Value;
                var Red = C.R;
                var Green = C.G;
                var Blue = C.B;
                long colorVal = Convert.ToInt64(Blue * (Math.Pow(256, 0)) + Green * (Math.Pow(256, 1)) +
                                                Red * (Math.Pow(256, 2)));
                color = C;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cursorPos = Functions.SelectionStart;
            Functions.Text = Functions.Text.Insert(Functions.SelectionStart, (sender as Button).Content.ToString());
            Functions.SelectionStart = cursorPos + (sender as Button).Content.ToString().Length;
            Functions.IsReadOnlyCaretVisible = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            fc = null;
            this.Close();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
           
            fc.Function = Functions.Text;
            fc.Color = color;
            this.Close();
        }

        private void Functions_TextChanged(object sender, RoutedEventArgs e)
        {
            addFunctions.Display = Functions.Text;
        }
    }
}

