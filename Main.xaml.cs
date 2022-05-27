using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System;
using Npgsql;
using NpgsqlTypes;
using System.Windows.Data;

namespace post
{
    /// <summary>  
    /// Interaction logic for MainWindow.xaml  
    /// </summary>   
    public partial class Goods : Window
    {
        string connectionString;
        NpgsqlDataAdapter adapter;
        System.Data.DataTable goodsTable;
        public Goods()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string sql = "SELECT * FROM Goods";
            goodsTable = new System.Data.DataTable();
            NpgsqlConnection connection = null;
            try
            {
                connection = new NpgsqlConnection(connectionString);
                NpgsqlCommand command = new NpgsqlCommand(sql, connection);

                adapter = new NpgsqlDataAdapter(command);

                // установка команды на добавление для вызова хранимой процедуры
                adapter.InsertCommand = new NpgsqlCommand("sp_InsertGoods", connection);
                adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                adapter.InsertCommand.Parameters.Add(new NpgsqlParameter("@name", NpgsqlDbType.Varchar, 50, "Name"));
                adapter.InsertCommand.Parameters.Add(new NpgsqlParameter("@capacity", NpgsqlDbType.Double, 0, "Capacity"));

                NpgsqlParameter parameter = adapter.InsertCommand.Parameters.Add("@Id", NpgsqlDbType.Integer, 0, "Id");
                parameter.Direction = ParameterDirection.Output;

                connection.Open();
                adapter.Fill(goodsTable);
                goodsGrid.ItemsSource = goodsTable.DefaultView;
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
        private void UpdateDB()
        {
            NpgsqlCommandBuilder comandbuilder = new NpgsqlCommandBuilder(adapter);
            adapter.Update(goodsTable);
        }
        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateDB();
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
