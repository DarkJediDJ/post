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
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;
using System.Text.RegularExpressions;
using System;
using Npgsql;
using NpgsqlTypes;

namespace post
{
    /// <summary>
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        private NpgsqlConnection NpgsqlConnection = null;
        string connectionString = "User ID=admin;Password=admin;Host=172.25.230.95;Port=5432;Database=kursach;";
        public Add()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = Convert.ToString(UName.Text);
            string reciever = Convert.ToString(Reciever.Text);
            string adress = Convert.ToString(Adress.Text);
            string departure = Convert.ToString(Departure.Text);
            string recieving = Convert.ToString(Recieving.Text);
            string item = Convert.ToString(Item.Text);
            string status = Convert.ToString(Status.Text);
            string phone = Convert.ToString(Phone.Text);
            int price = Convert.ToInt32(Price.Text);
            string type = Convert.ToString(Type.Text);
            int bid = 0;
            NpgsqlConnection connection = connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string sql = $"INSERT INTO packages (departure_time, recieving_time, type, item, price,status) VALUES (N'{departure}', N'{recieving}', N'{type}', N'{item}',{price},N'{status}')";
            string sql2 = "SELECT MAX(id) FROM packages AS integer";
            NpgsqlCommand command = new NpgsqlCommand(sql, connection);
            NpgsqlCommand command2 = new NpgsqlCommand(sql2, connection);
            command.ExecuteNonQuery();
            bid = Convert.ToInt32(command2.ExecuteScalar());
            string sql1 = $"INSERT INTO users (name, adress, phone, reciever, package_id) VALUES (N'{name}', N'{adress}', N'{phone}', N'{reciever}',{bid})";
            NpgsqlCommand command1 = new NpgsqlCommand(sql1, connection);
            command1.ExecuteNonQuery();
            connection.Close();
                MessageBox.Show("Посылка добавлена");
                this.Close();
        }

        private void Recieving_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
