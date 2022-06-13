using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System;
using Npgsql;
using NpgsqlTypes;
using System.Windows.Data;
using System.Collections.Generic;

namespace post
{
    /// <summary>  
    /// Interaction logic for MainWindow.xaml  
    /// </summary>   
    public partial class Packages : Window
    {
        string connectionString;
        NpgsqlDataAdapter adapter;
        System.Data.DataTable goodsTable;
        public Packages()
        {
            InitializeComponent();
            connectionString = "User ID=admin;Password=admin;Host=172.28.235.40;Port=5432;Database=kursach;";
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string sql = "SELECT * FROM package";
            goodsTable = new System.Data.DataTable();
            NpgsqlConnection connection = null;
            try
            {
                connection = new NpgsqlConnection(connectionString);

                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand("SELECT packages.departure_time,packages.recieving_time,packages.type,packages.price, packages.item,packages.status, users.name, users.phone, users.adress,users.reciever FROM users JOIN packages ON users.package_id = packages.id", connection);
                NpgsqlDataReader reader = command.ExecuteReader();
                List<Package> DBPackage = new List<Package>();
                while (reader.Read())
                {
                    string _Departure = Convert.ToString(reader["departure_time"]);
                    string _Recieving = Convert.ToString(reader["recieving_time"]);
                    string _Type = Convert.ToString(reader["type"]);
                    string _Item = Convert.ToString(reader["item"]);
                    string _Name = Convert.ToString(reader["name"]);
                    string _Phone = Convert.ToString(reader["phone"]);
                    string _Adress = Convert.ToString(reader["adress"]);
                    string _Reciever = Convert.ToString(reader["reciever"]);
                    string _Price = Convert.ToString(reader["price"]);
                    string _Status = Convert.ToString(reader["status"]);
                    DBPackage.Add(new Package() { Name = _Name, Departure = _Departure, Recieving = _Recieving, Type = _Type, Item = _Item, Phone = _Phone, Adress = _Adress, Reciever = _Reciever, Price = _Price, Status = _Status });
                }
                goodsGrid.ItemsSource = DBPackage;
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

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

    private void calculator_Click(object sender, RoutedEventArgs e)
    {

    }

    private void clients_Click(object sender, RoutedEventArgs e)
    {

    }

    private void deleteButton_Click(object sender, RoutedEventArgs e)
    {
        NpgsqlConnection connection = null;

    }

    private void report_Click(object sender, RoutedEventArgs e)
    {
    }
}
}
