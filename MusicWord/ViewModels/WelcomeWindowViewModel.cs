using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MusicWord.Models;
using MySql.Data.MySqlClient;

namespace MusicWord.ViewModels
{
    class WelcomeWindowViewModel : BaseNotify
    {
        private WelcomeWindow window;
        public WelcomeWindowViewModel(WelcomeWindow win)
        {
            window = win;
        }
        public bool whiteBackGround = true;
        public string playerName = "";
        public string changeColor
        {
            get
            {
                if (whiteBackGround)
                {
                    return "white";
                }
                else
                {
                    return "Pink";
                }

            }
        }

        public ICommand startCommand;
        public ICommand StartCommand
        {
            get
            {
                return startCommand ?? (startCommand = new CommandHandler(() => OnStart()));
            }
        }

        // pressed on start 
        private void OnStart()
        {
            string connectionString = "SERVER = localhost; DATABASE=players; UID= root; PASSWORD=035342770Rl";
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand palyersTableCmd = new MySqlCommand("SELECT * FROM players", connection);

            connection.Open();
            MySqlCommand insertCmd = new MySqlCommand($"INSERT INTO players(Name,Category,Score) VALUES('{playerName}','',0);", connection);
            insertCmd.ExecuteNonQuery();
            connection.Close();
            
            var catWindow = new SelectCategoryWindow();
            catWindow.Show();
            this.window.Close();

        }

        public string userInput
        {
            get
            {
                return playerName;
            }
            set
            {
                playerName = value;
                // in case there is nothing written the background should be white
                if (playerName == "")
                {
                    whiteBackGround = true;
                }
                else
                {
                    whiteBackGround = false;
                }
                NotifyPropertyChanged("inputString");
                NotifyPropertyChanged("changeColor");
            }
        }
    }
}
