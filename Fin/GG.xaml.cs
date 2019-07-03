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
    /// Логика взаимодействия для GG.xaml
    /// </summary>
    public partial class GG : Page
    {
        string st;
        public GG(string s)
        {
            st = s;
            InitializeComponent();
            Tut1.Visibility = Visibility.Hidden; tut2.Visibility = Visibility.Hidden;
            if (st == "hehe") { Exit.Visibility = Visibility.Visible; lb.Text = "🔥🔥🔥🔥🔥🔥🔥🔥🔥🔥🔥🔥🔥🔥🔥\nПоздравляем Ваши герои сгорели!\nИ они благодарны Вам\n🔥🔥🔥🔥🔥🔥🔥🔥🔥🔥🔥🔥🔥🔥🔥";  }
            if (st == "gg ez") { lb.Text = "Вы умудрились проиграть\nэтим легчайшим противникам.\n Один вопрос - «КАК???»"; Exit.Visibility = Visibility.Visible; };
            if (st == "how") { Tut1.Visibility = Visibility.Visible; tut2.Visibility = Visibility.Visible; lb.Text = ""; Exit.Visibility = Visibility.Hidden; }

        }

        private void Ah_s00t_here_we_go_again_Click(object sender, RoutedEventArgs e)
        {
            GGPage.NavigationService.Navigate(new Menu());
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
