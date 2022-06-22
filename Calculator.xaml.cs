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

namespace post
{
    /// <summary>
    /// Логика взаимодействия для Calculator.xaml
    /// </summary>
    public partial class Calculator : Window
    {
        public Calculator()
        {
            InitializeComponent();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void calculator_Click(object sender, RoutedEventArgs e)
        {

            if (Weight.Text.Length == 0)
            {
                MessageBox.Show("Введите вес");
            }
            else
            {
                int weight = Convert.ToInt32(Weight.Text);
                if (Check.IsChecked == true)
                {
                    MessageBox.Show(Convert.ToString(weight * 2 * 5));
                }
                else
                {
                    MessageBox.Show(Convert.ToString(weight * 5));
                }
            }

        }
    }
}