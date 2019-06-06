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
using System.Windows.Threading;

namespace Fin
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {
        int opa = 0;
        DispatcherTimer timer = new DispatcherTimer();
        private MediaPlayer player;

        public Menu()
        {
            InitializeComponent();
           
        }

        public Menu(MediaPlayer player)
        {
            InitializeComponent();
            this.player = player;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            timer.Tick += dispatcherTimer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            timer.Start();
            player.Stop();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (opa != 100)
            {
                Menu_Canvas.Opacity -= 0.05;
            }
            else
            {
                Menu_Canvas.Opacity = 100;
                MenuPage.NavigationService.Navigate(new MainWindow());
                timer.Stop();
            }
            opa += 1;
        }

        
    }
}

