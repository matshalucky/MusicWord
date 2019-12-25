using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWord.Model
{
    class Player
    {
        private static Player instance = null;
        private string name;
        private string category;
        private int score; 
        private Player()
        { }
        
        public static Player Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Player();
                }
                return instance;
            }
        }

        public string Name
        {
            get { return name; }   
            set { name = value; } 
        }

        public string Category
        {
            get { return category; }
            set { category = value; }
        }

        public int Score
        {
            get { return score; }
            set { score = value; }
        }
    }
}
