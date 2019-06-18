using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Fin
{
    /// <summary>
    /// Логика взаимодействия для Start.xaml
    /// </summary>
    public partial class Start : Window
    {
        
        MediaPlayer player = new MediaPlayer();
        public Start()
        {
           

            
            InitializeComponent();

            //Музыкальная тема и переход в Menu
            player.Play();
            player.MediaEnded += player_Media_Ended;
            frame.NavigationService.Navigate(new Menu());
            
        }

        private void player_Media_Ended(object sender, EventArgs e)
        {
            player.Stop();
            player.Play();
        }
    }
}
