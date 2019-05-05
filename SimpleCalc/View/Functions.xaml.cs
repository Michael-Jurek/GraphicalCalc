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
using SimpleCalc.Model;
using SimpleCalc.Model.SyntaxNodes.Functions;
using SimpleCalc.ViewModel;

namespace SimpleCalc.View
{
    /// <summary>
    /// Interaction logic for Functions.xaml
    /// </summary>
    public partial class Functions : Window
    {
        private FunctionsViewModel functions = new FunctionsViewModel();
        private FunctionColor fc = new FunctionColor();
        private double minX, maxX, minY, maxY;
        private int i = 0;

        public Functions()
        {
            InitializeComponent();
        }

        private void FunctionsLoaded(object sender, RoutedEventArgs e)
        {

            this.minX = Convert.ToDouble(MinX.Text);
            this.maxX = Convert.ToDouble(MaxX.Text);
            this.minY = Convert.ToDouble(MinY.Text);
            this.maxY = Convert.ToDouble(MaxY.Text);

            functions.Loaded(GraphFunctions, minX, maxX, minY, maxY);
            
            if (FunctionsList.Items.IsEmpty)
            {
                fc.Color = Color.FromRgb(255, 255, 0);
                fc.Function = "sin(x)";
                FunctionsList.Items.Add(fc);
                functions.DrawFunction(GraphFunctions, fc.Function, fc.Color);

            }
        }


        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            functions.Refresh(GraphFunctions, FunctionsList, MinX, MinY, MaxX, MaxY);
        }


        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

            //AddFunction addFunction = new AddFunction(fc);
            //if (i % 2 != 0)
            //{
            //    FunctionsList.Items.Add((string) addFunction.Fc.Function);
            //    functions.DrawFunction(GraphFunctions, fc.Function, fc.Color);
            //    (sender as Button).Content = "Add";
            //}
            //else
            //{
            //    Console.WriteLine(i);
            //    addFunction.Show();
            //    (sender as Button).Content = "Confirm";
            //}

            //i++;
            AddFunction addFunction = new AddFunction(fc);
            if (addFunction.ShowDialog() == DialogResult.HasValue)
            {
                Console.WriteLine("pokus");
                if(addFunction.Fc == null)
                {
                    return;
                }
                FunctionsList.Items.Add((FunctionColor)addFunction.Fc);
                functions.DrawFunction(GraphFunctions, addFunction.Fc.Function, addFunction.Fc.Color);
            }




        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (FunctionsList.SelectedItems == null) return;
            AddFunction addFunction = new AddFunction(FunctionsList.SelectedItem as FunctionColor);

            if (addFunction.ShowDialog() == DialogResult.HasValue)
            {
                FunctionsList.Items.Remove(FunctionsList.SelectedItem);
                FunctionsList.Items.Add(addFunction.Fc);

                functions.Loaded(GraphFunctions, minX, maxX, minY, maxY);

                for (int i = 0; i < FunctionsList.Items.Count; i++)
                {
                    fc = FunctionsList.Items[i] as FunctionColor;
                    functions.DrawFunction(GraphFunctions, fc.Function, fc.Color);
                }
            }

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            
            FunctionsList.Items.Remove(FunctionsList.SelectedItem);

        }

    }
}
