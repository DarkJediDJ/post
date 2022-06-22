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
using Npgsql;

namespace post
{
    /// <summary>
    /// Interaction logic for Clients.xaml
    /// </summary>
    public partial class Clients : Window

    { 
                   string connectionString;
            NpgsqlDataAdapter adapter;
            System.Data.DataTable clients;
        public Clients()
        {
            InitializeComponent();
            connectionString = "User ID=admin;Password=admin;Host=172.28.197.127;Port=5432;Database=kursach;";

        }
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        void Window_Loaded(object sender, RoutedEventArgs e)
        {
            clients = new System.Data.DataTable();
            NpgsqlConnection connection = null;
            try
            {
                connection = new NpgsqlConnection(connectionString);

                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand("SELECT DISTINCT name FROM users", connection);
                NpgsqlDataReader reader = command.ExecuteReader();
                List<Package> names = new List<Package>();
                while (reader.Read())
                {
                    string _Name = Convert.ToString(reader["name"]);
                    names.Add(new Package {Name = _Name});
                }
                clientsGrid.ItemsSource = names;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

    }
}
