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
using System.Data.SQLite;

namespace Fin
{
    /// <summary>
    /// Логика взаимодействия для Fight.xaml
    /// </summary>
    public partial class Fight : Page
    {
        Random random = new Random();
        SQLiteConnection dbskills;
        //int[] HpE = new int[4];
        int damage;
        Dictionary<string, int> HpE = new Dictionary<string, int>();
        Dictionary<string, int> HpH = new Dictionary<string, int>();
        bool turn = true;
        public Fight()
        {
            InitializeComponent();

            

            //dbskills = new SQLiteConnection("Data Source=D://Prog//Fin//Fin//Resource//DB//Skills.db;Version=3;");
            dbskills = new SQLiteConnection("Data Source=D:\\Prog\\Fin\\Fin\\Resource\\DB\\DBMain.db;Version=3;");
            dbskills.Open();
            
            list.Items.Add("Hero1");
            list.Items.Add("Hero2");
            list.Items.Add("Hero3");


            List_enem.Items.Add("Xorn");
            
            string sql1 = "SELECT HP FROM Enemy WHERE Enemy.Name = 'Xorn'";
            SQLiteCommand command = new SQLiteCommand(sql1, dbskills);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                HpE.Add("Xorn", Int32.Parse(reader["HP"].ToString()));
                break;

            }
            List_enem.Items.Add("Snake");
            string sql = "SELECT HP FROM Enemy WHERE Enemy.Name = 'Snake'";
            SQLiteCommand command1 = new SQLiteCommand(sql, dbskills);
            SQLiteDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                HpE.Add("Snake", Int32.Parse(reader1["HP"].ToString()));
                break;

            }
            

            

        }
               
                     
        private void skill_1(object sender, RoutedEventArgs e)
        {

            
            string sql = "SELECT Cost, Damage, element FROM Skills WHERE Skills.Name = '" + ((Button)sender).Content.ToString() + "'";
            SQLiteCommand command = new SQLiteCommand(sql, dbskills);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                
                lb.Content = reader["Cost"].ToString();
                damage = Int32.Parse(reader["Damage"].ToString());
                break;           
            
            }
            if (reader["element"].ToString() != "heal")
            {
                t_Copy.Visibility = Visibility.Hidden;
                //Listtoheal.Visibility = Visibility.Visible;
            }

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                t.Visibility = Visibility.Hidden;
                lb.Content = list.SelectedItem.ToString();
                string sql1 = "SELECT Skil1, Skil2, Skil3, Skil4 FROM Heroes WHERE Heroes.Name = '" + list.SelectedItem.ToString() + "'";
                SQLiteCommand command1 = new SQLiteCommand(sql1, dbskills);
                SQLiteDataReader reader1 = command1.ExecuteReader();
                while (reader1.Read())
                {
                    But_skill1.Content = reader1["Skil1"].ToString();
                    But_skill2.Content = reader1["Skil2"].ToString();
                    But_skill3.Content = reader1["Skil3"].ToString();
                    But_skill4.Content = reader1["Skil4"].ToString();
                    break;
                }
                
            }
            catch { }
        }

        private void List_enem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (List_enem.Items.Count != 0)
                try
                {
                    
                    But_skill1.Content = "";
                    But_skill4.Content = "";
                    But_skill3.Content = "";
                    But_skill2.Content = "";



                    HpE[List_enem.SelectedItem.ToString()] -= damage;
                    HP_enem.Content = HpE[List_enem.SelectedItem.ToString()];
                    if (HpE[List_enem.SelectedItem.ToString()] <= 0)
                    {
                        List_enem.Items.RemoveAt(List_enem.SelectedIndex);
                        HpE.Remove(List_enem.SelectedItem.ToString());
                    };
                    List_enem.SelectedIndex = -1;
                    list.SelectedIndex = -1;
                    t.Visibility = Visibility.Visible;
                    t_Copy.Visibility = Visibility.Visible;
                    


                }
                catch
                {
                    List_enem.SelectedIndex = -1;
                    list.SelectedIndex = -1;
                    t.Visibility = Visibility.Visible;
                    t_Copy.Visibility = Visibility.Visible;
                }
            else
            { Win();           }
        }

        private void Win()
        {
            // Fight_page.NavigationService.Navigate(new Uri("MainWindow.xaml", UriKind.Relative));
            Fight_page.NavigationService.GoBack();
        }

        //private void Listtoheal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    try
        //    {

        //        MessageBox.Show("QWE");



        //    }
        //    catch { }
        //}
    }
}
