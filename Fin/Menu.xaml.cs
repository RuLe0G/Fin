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
        MediaPlayer player = new MediaPlayer();

        public Menu()
        {
            InitializeComponent();
            //player.Source;
            player.Play();
        }

       //ВЫХОД
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        //Переход в на поле
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            timer.Tick += dispatcherTimer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            timer.Start();
            try
            {
                player.Stop();
            }
            catch { }
        }

        //Анимация 
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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MenuPage.NavigationService.Navigate(new GG("stupid end"));
        }
    }
}

