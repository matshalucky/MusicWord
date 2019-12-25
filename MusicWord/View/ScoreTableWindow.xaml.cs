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
using MySql.Data.MySqlClient;
using MusicWord.Model;

namespace MusicWord.View
{
    /// <summary>
    /// Interaction logic for ScoreTableWindow.xaml
    /// </summary>
    public partial class ScoreTableWindow : Window
    {
        public ScoreTableWindow()
        {
            InitializeComponent();

            string connectionString = "SERVER = localhost; DATABASE=players; UID= root; PASSWORD=035342770Rl";
            MySqlConnection connection = new MySqlConnection(connectionString);
            int limit = 10;
            MySqlCommand topPalyersCmd = new MySqlCommand("SELECT Name, Category, Score FROM Players ORDER BY score Desc Limit " + limit, connection);

            connection.Open();
            var reader = topPalyersCmd.ExecuteReader();
            List<TableEntryClass> scoreTable = new List<TableEntryClass>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    TableEntryClass entry = new TableEntryClass();
                    entry.PlayerName = reader.GetString(0);
                    entry.Category = reader.GetString(1);
                    entry.PlayerScore = reader.GetInt32(2);
                    scoreTable.Add(entry);
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            reader.Close();
            connection.Close();

            int index = 0;
            foreach (TableEntryClass entry in scoreTable)
            {
                Label name = new Label();
                name.Content = entry.PlayerName;
                Grid.SetColumn(name, 0);
                Grid.SetRow(name, index);
                MyGrid.Children.Add(name);

                Label category = new Label();
                category.Content = entry.Category;
                Grid.SetColumn(category, 1);
                Grid.SetRow(category, index);
                MyGrid.Children.Add(category);

                Label score = new Label();
                score.Content = entry.PlayerScore;
                Grid.SetColumn(score, 0);
                Grid.SetRow(score, index);
                MyGrid.Children.Add(score);

                index++;
            }
        }
    }
}
