using System;
using System.Collections.Generic;
using System.Data;
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
using MySql;
using MySql.Data.MySqlClient;

namespace MusicWord
{
    /// <summary>
    /// Interaction logic for ConnectToServerWindow.xaml
    /// </summary>
    public partial class ConnectToServerWindow : Window
    {
        public ConnectToServerWindow()
        {
            InitializeComponent();

            string connectionString = "SERVER = localhost; DATABASE=playlistGame; UID= root; PASSWORD=";

            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM playlistGame.artists", connection);
            connection.Open();

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            connection.Close();

            dtGrid.DataContext = dt;
        }
    }
}
