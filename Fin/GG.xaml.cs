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

            if (st == "hehe") { lb.Text = "🔥🔥🔥🔥🔥🔥🔥🔥🔥🔥🔥🔥🔥🔥🔥\nПоздравляем Ваши герои сгорели!\nИ они благодарны вам\n🔥🔥🔥🔥🔥🔥🔥🔥🔥🔥🔥🔥🔥🔥🔥"; heImg.Visibility = Visibility.Visible; }
            if (st == "gg ez") lb.Text = "Вы умудрились проиграть\nэтим легчайшим противникам.\n Один вопрос - «КАК???»";
            if (st == "stupid end") { lb.Text = "На этом всё!\nТеперь ничего нет"; ah_s00t_here_we_go_again.Visibility = Visibility.Hidden; }

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
