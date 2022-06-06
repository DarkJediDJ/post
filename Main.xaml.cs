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
            connectionString = "User ID=admin;Password=admin;Host=172.31.108.50;Port=5432;Database=kursach;";
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
                NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM deposits", connection);
                NpgsqlDataReader reader = command.ExecuteReader();
                    List<Package> DBPackage = new List<Package>();
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["ID"]);
                        string _ClientName = Convert.ToString(reader["ClientName"]);
                        int _DepositAmount = Convert.ToInt32(reader["DepositAmount"]);
                        DateTime _DepositTerm = Convert.ToDateTime(reader["DepositTerm"]);
                        int _InterestRate = Convert.ToInt32(reader["InterestRate"]);
                        string _Currency = Convert.ToString(reader["Currency"]);
                    DBPackage.Add(new Package() {  });
                    }
                    CardGrid.ItemsSource = DBPackage;
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
            Window_Loaded();
        }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (goodsGrid.SelectedItems != null)
            {
                for (int i = 0; i < goodsGrid.SelectedItems.Count; i++)
                {
                    DataRowView datarowView = goodsGrid.SelectedItems[i] as DataRowView;
                    if (datarowView != null)
                    {
                        DataRow dataRow = (DataRow)datarowView.Row;
                        dataRow.Delete();
                    }
                }
            }
            UpdateDB();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NpgsqlConnection connection = null;
            string sql = "SELECT * FROM Goods ORDER BY Amount";
            connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand command = new NpgsqlCommand(sql, connection);
            adapter = new NpgsqlDataAdapter(command);
            connection.Open();
            goodsTable.Clear();
            adapter.Fill(goodsTable);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NpgsqlConnection connection = null;
            string sql = "SELECT * FROM Goods WHERE Type LIKE '%Водка%'";
            connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand command = new NpgsqlCommand(sql, connection);
            adapter = new NpgsqlDataAdapter(command);
            connection.Open();
            goodsTable.Clear();
            adapter.Fill(goodsTable);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            NpgsqlConnection connection = null;
            string sql = "SELECT * FROM Goods WHERE Type LIKE '%Коньяк%'";
            connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand command = new NpgsqlCommand(sql, connection);
            adapter = new NpgsqlDataAdapter(command);
            connection.Open();
            goodsTable.Clear();
            adapter.Fill(goodsTable);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            NpgsqlConnection connection = null;
            string sql = "SELECT * FROM Goods WHERE Type LIKE '%Бальзам%'";
            connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand command = new NpgsqlCommand(sql, connection);
            adapter = new NpgsqlDataAdapter(command);
            connection.Open();
            goodsTable.Clear();
            adapter.Fill(goodsTable);
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            NpgsqlConnection connection = null;
            string sql = "SELECT * FROM Goods WHERE Type LIKE '%Вино%'";
            connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand command = new NpgsqlCommand(sql, connection);
            adapter = new NpgsqlDataAdapter(command);
            connection.Open();
            goodsTable.Clear();
            adapter.Fill(goodsTable);
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            NpgsqlConnection connection = null;
            string sql = "SELECT * FROM Goods ORDER BY Price";
            connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand command = new NpgsqlCommand(sql, connection);
            adapter = new NpgsqlDataAdapter(command);
            connection.Open();
            goodsTable.Clear();
            adapter.Fill(goodsTable);
        }
    }
}
