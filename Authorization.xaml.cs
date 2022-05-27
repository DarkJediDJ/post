using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Npgsql;
namespace post
{
    /// <summary>  
    /// Interaction logic for MainWindow.xaml  
    /// </summary>   
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxEmail.Text.Length == 0)
            {
                errormessage.Text = "Enter an login.";
                textBoxEmail.Focus();
            }
            else
            {
                string login = textBoxEmail.Text;
                string password = passwordBox1.Password;
                if (login == "admin" && password == "admin")
                {
                    Goods goods = new Goods();
                    goods.Show();
                    Close();
                }
                else
                {
                    errormessage.Text = "Sorry! Please enter existing login/password.";
                }
            }
        }
        private void buttonRegister_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}