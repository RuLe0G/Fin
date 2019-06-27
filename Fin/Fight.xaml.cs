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
using System.Data.SQLite;


namespace Fin
{
    /// <summary>
    /// Логика взаимодействия для Fight.xaml
    /// </summary>
    public partial class Fight : Page
    {
        MediaPlayer player = new MediaPlayer();


        Random random = new Random();
        SQLiteConnection dbskills;
        //int[] HpE = new int[4];
        int damage;
        Dictionary<string, int> HpE = new Dictionary<string, int>();
        Dictionary<string, int> HpH = new Dictionary<string, int>();
        DispatcherTimer Enem_Timer = new DispatcherTimer();
        DispatcherTimer HPCh = new DispatcherTimer();
        DispatcherTimer Hero_Timer = new DispatcherTimer();
        int[] bl = new int[3];
        string Enem_Name = "Xorn";


        int i = 800;

        public Fight()
        {
            InitializeComponent();
            Timer_Enem.Value = 1000;

            //player.Open(new Uri(System.AppDomain.CurrentDomain.BaseDirectory + "\\Resource\\OST\\Fight_theme.mp3", UriKind.Relative));
            //player.Open(new Uri("D://Prog//Fin//Fin//Resource//OST//Fight_theme.mp3", UriKind.Absolute));
            player.Volume = 0.10;
            player.Play();
            player.MediaEnded += player_Media_Ended;

           

            dbskills = new SQLiteConnection("Data Source="+ System.AppDomain.CurrentDomain.BaseDirectory + "\\Resource\\DB\\DBMain.db;Version=3;");
            //dbskills = new SQLiteConnection("Data Source=C://Users//Admin//Source//Repos//Fin//Fin//Resource//DB//DBMain.db;Version=3;");
            dbskills.Open();

            ListBoxItem l1 = new ListBoxItem();
            l1.Content = "Hero1"; 
            ListBoxItem l2 = new ListBoxItem();
            l2.Content = "Hero2";
            ListBoxItem l3 = new ListBoxItem();
            l3.Content = "Hero3";


            list.Items.Add(l1);
            list.Items.Add(l2);
            list.Items.Add(l3);


            
            Enem_Timer.Tick += Enem_Timer_Tick;
            Enem_Timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            Enem_Timer.Start();

            Hero_Timer.Tick += Hero_Timer_Tick;
            Hero_Timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            Hero_Timer.Start();



            HPCh.Tick += HPCh_Timer_Tick;
            HPCh.Interval = new TimeSpan(0, 0, 0, 0, 10);
            HPCh.Start();


            string SQLHERO = "SELECT Name, HP FROM Heroes ";
            SQLiteCommand command = new SQLiteCommand(SQLHERO, dbskills);
            SQLiteDataReader reador = command.ExecuteReader();
            while (reador.Read())
            {
                HpH.Add(reador["Name"].ToString(), Int32.Parse(reador["HP"].ToString()));
            

            }


            //text = text.Substring(0, text.Length - 2);

            for (int f = 0; f < random.Next(1, 4); f++)
            {
                List_enem.Items.Add(Enem_Name +  f.ToString());

            }
            string sql1 = "SELECT HP FROM Enemy WHERE Enemy.Name = '" + Enem_Name.Substring(0, Enem_Name.Length - 1) + "'";
            SQLiteCommand commando = new SQLiteCommand(sql1, dbskills);
            SQLiteDataReader reader = commando.ExecuteReader();
            while (reader.Read())
            {
                HpE.Add(Enem_Name.Substring(0, Enem_Name.Length - 1), Int32.Parse(reader["HP"].ToString()));
                break;

            }

            //List_enem.Items.Add("Snake");
            //string sql = "SELECT HP FROM Enemy WHERE Enemy.Name = 'Snake'";
            //SQLiteCommand command1 = new SQLiteCommand(sql, dbskills);
            //SQLiteDataReader reader1 = command1.ExecuteReader();
            //while (reader1.Read())
            //{
            //    HpE.Add("Snake", Int32.Parse(reader1["HP"].ToString()));
            //    break;

            //}


            foreach (var Item in list.Items)
            {
                string st = ((ListBoxItem)(Item)).Content.ToString();

                List_hl.Items.Add(st);
            }

        }


        private void player_Media_Ended(object sender, EventArgs e)
        {
            player.Stop();
            player.Play();
        }

        private void Hero_Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < 3; i++)
                {
                    if (bl[i] > 0)
                    {
                        bl[i]--;
                    }
                    else
                    {
                        ((ListBoxItem)list.Items[i]).IsEnabled = true;
                    }

                }
            }
            catch { }
        }

       
        private void HPCh_Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                HP_Hero1.Content = HpH["Hero1"]; 
                  HP_Hero2.Content = HpH["Hero2"];  
                 HP_Hero3.Content = HpH["Hero3"]; 
                HP_enem1.Content = HpE["Xorn"];  
                 HP_enem2.Content = HpE["Snake"];  

            }
            catch { }
        }

        private void Enem_Timer_Tick(object sender, EventArgs e)
        {
            if (i == 0)
            {
                int a;
                int b;
                try
                {
                    Timer_Enem.Value = 800;
                    i = 800;
                    a = random.Next(0, List_enem.Items.Count);
                    b = random.Next(0, list.Items.Count);
                    int cuD = 0;
                    string sql = "SELECT Damage FROM Enemy WHERE Enemy.Name  = '" + List_enem.Items.GetItemAt(a).ToString().Substring(0, Enem_Name.Length - 1)+ "'";
                    SQLiteCommand command = new SQLiteCommand(sql, dbskills);
                    SQLiteDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (List_hl.Items.Count == 0)
                            Lose();
                        else
                            cuD = random.Next(int.Parse(reader["Damage"].ToString()) - 5, int.Parse(reader["Damage"].ToString()) + 5);
                        if (HpH[List_hl.Items.GetItemAt(b).ToString()] - cuD <= 0)
                        { HpH.Remove(List_hl.Items.GetItemAt(b).ToString()); List_hl.Items.RemoveAt(b); list.Items.RemoveAt(b); }
                        else
                            HpH[List_hl.Items.GetItemAt(b).ToString()] -= cuD;



                        break;

                    }
                }
                catch
                {
                    a = -1;
                    b = -1;
                }
            }
            else
            {
                i -= 1;
                Timer_Enem.Value -= 1;
                
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
            if (reader["element"].ToString() == "heal")
            {
                
                List_hl.Visibility = Visibility.Visible;
            }
            t_Copy.Visibility = Visibility.Hidden;

          //  MessageBox.Show(list.Items[list.SelectedIndex].ToString());

          
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
               
           
                t.Visibility = Visibility.Hidden;
                lb.Content = ((ListBoxItem)(list.SelectedItem)).Content.ToString();

                string sql1 = "SELECT Skil1, Skil2, Skil3, Skil4 FROM Heroes WHERE Heroes.Name = '" + lb.Content.ToString() + "'";
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
            ((ListBoxItem)(list.Items[list.SelectedIndex])).IsEnabled = false;
            bl[list.SelectedIndex] = 300;

            if (List_enem.Items.Count != 0)
                try
                {

                   
                    But_skill1.Content = "";
                    But_skill4.Content = "";
                    But_skill3.Content = "";
                    But_skill2.Content = "";




                    HpE[List_enem.SelectedItem.ToString()] -= damage;

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

        private void Lose()
        {
            // Fight_page.NavigationService.Navigate(new Uri("MainWindow.xaml", UriKind.Relative));

            Fight_page.NavigationService.Navigate(new Menu());
        }


        private void List_hl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                int MaxHP = 0;
                But_skill1.Content = "";
                But_skill4.Content = "";
                But_skill3.Content = "";
                But_skill2.Content = "";
                string sql = "SELECT HP FROM Heroes WHERE Heroes.Name = '" + List_hl.SelectedItem.ToString() + "'";
                SQLiteCommand command1 = new SQLiteCommand(sql, dbskills);
                SQLiteDataReader reader1 = command1.ExecuteReader();
                while (reader1.Read())
                {
                    MaxHP = Int32.Parse(reader1["HP"].ToString());
                    break;

                }

                

                if ((HpH[List_hl.SelectedItem.ToString()] + damage)< MaxHP)
                {
                    HpH[List_hl.SelectedItem.ToString()] += damage;
                }
                else
                {
                    HpH[List_hl.SelectedItem.ToString()] = MaxHP;
                }

               
                List_hl.SelectedIndex = -1;
                list.SelectedIndex = -1;
                t.Visibility = Visibility.Visible;
                t_Copy.Visibility = Visibility.Visible;
            }
            catch {

                list.SelectedIndex = -1;
                List_hl.SelectedIndex = -1;
                t.Visibility = Visibility.Visible;
                t_Copy.Visibility = Visibility.Visible;
                List_hl.Visibility = Visibility.Hidden;
            }
            }

       
    }
}
