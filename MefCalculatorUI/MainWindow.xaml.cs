using MefCompositionHelper;
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
using System.ComponentModel.Composition;

namespace MefCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CalciCompositionHelper objCompHelper = null;

        public MainWindow()
        {
            InitializeComponent();

            objCompHelper = new CalciCompositionHelper();

            //Assembles the calculator components that will participate in composition
            objCompHelper.AssembleCalculatorComponents();

            if (objCompHelper != null
                && objCompHelper.CalciPlugins != null
                && objCompHelper.CalciPlugins.Count() > 0)
            {
                foreach (var CalciPlugin in objCompHelper.CalciPlugins)
                {
                    comboBox.Items.Add(CalciPlugin.Metadata["CalciMetaData"]);
                }

                //comboBox.SelectedIndex = 0;
            }

            
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //int result = GetResult(Convert.ToInt32(value1_textBox.Text),
            //        Convert.ToInt32(value2_textBox.Text),
            //        comboBox.SelectedItem.ToString());

            if (!string.IsNullOrWhiteSpace(value1_textBox.Text)
                && !string.IsNullOrWhiteSpace(value2_textBox.Text))
            {
                int result = objCompHelper.GetResult(Convert.ToInt32(value1_textBox.Text),
                    Convert.ToInt32(value2_textBox.Text),
                    comboBox.SelectedItem.ToString());

                result_textBox.Text = result.ToString();
            }


            ////Assembles the calculator components that will participate in composition
            //objCompHelper.AssembleCalculatorComponents();

            ////Gets the result
            //var result = objCompHelper.GetResult(Convert.ToInt32(value1_textBox.Text),
            //        Convert.ToInt32(value2_textBox.Text));

            ////Display the result
            //txtResult.Text = result.ToString();
        }
        
    }
}
