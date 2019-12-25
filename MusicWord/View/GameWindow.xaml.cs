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
using MusicWord.View;
using MusicWord.ViewModel;
namespace MusicWord.View
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        public GameWindow()
        {
            InitializeComponent();
           // TextBox textBoxNewInput = new TextBox();
          //  textBoxNewInput.Text = "Ron";
            Label labelInput = new Label();
            labelInput.Content = "rrrrrrr";
            gameGrid.Children.Add(labelInput);
           // gameGrid.Children.Add(textBoxNewInput);
        }
    }
}
