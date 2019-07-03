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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Page
    {

        int x = 100;
        int y = 120;
        Rectangle hero = new Rectangle();
        //Ellipse myEllipse = new Ellipse();
        DispatcherTimer timer = new DispatcherTimer();
        int currentFrame = 10;
        int[] animations = new int[] { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2};
        int animationIndex = 1;
        Rectangle[] recArray = new Rectangle[100];
        int frameCount = 2;
        double frameW = 36;
        double frameH = 36;

        Random Random = new Random();
        
        public MainWindow()
        {
            InitializeComponent();

            FocusManager.SetFocusedElement(MainPage, scene);

            hero.Height = 36;
            hero.Width = 36;
            ImageBrush ib = new ImageBrush();
            ib.AlignmentX = AlignmentX.Left;
            ib.AlignmentY = AlignmentY.Top;
            ib.Stretch = Stretch.None;
            ib.Viewbox = new Rect(0, 0, 36, 36);
            ib.ViewboxUnits = BrushMappingMode.Absolute;
            ib.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/Resource/Image/Sprite.png", UriKind.Absolute));
            hero.Fill = ib;
           // hero.Fill = Brushes.HotPink;
            hero.RenderTransform = new TranslateTransform(x, y);
            scene.Children.Add(hero);
            scene.Focusable = true;
            timer.Tick += new EventHandler(dispatcherTimer_Tick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 120);            
            timer.Start();
            scene.KeyDown += new KeyEventHandler(Hero_KeyDown);
            scene.Focusable = true;
            Enemy_zone1.RenderTransform = new TranslateTransform(419, 56);
            Enemy_zone2.RenderTransform = new TranslateTransform(1010, 183);
            floor_is_lava.RenderTransform = new TranslateTransform(1791, 10);



            DeepDarkForest1.RenderTransform = new TranslateTransform(43, 426);
            DeepDarkForest2.RenderTransform = new TranslateTransform(370, 467);
            DeepDarkForest3.RenderTransform = new TranslateTransform(506, 512);



            //SolidColorBrush mySolidColorBrush = new SolidColorBrush();
            //mySolidColorBrush.Color= Color.FromArgb(255, 255, 255, 0);
            //myEllipse.Fill= mySolidColorBrush;
            //myEllipse.StrokeThickness = 2;
            //myEllipse.Stroke = Brushes.Black;
            //myEllipse.Width = 100;
            //myEllipse.Height = 100;
            ////myEllipse.Margin = new Thickness(250, 250, 0, 0);
            //myEllipse.RenderTransform = new TranslateTransform(250, 250);

            //scene.Children.Add(myEllipse);


        }

        private void Hero_KeyDown(object sender, KeyEventArgs e)
        {
            Rect LAVA = floor_is_lava.RenderTransform.TransformBounds(floor_is_lava.RenderedGeometry.Bounds);
            Rect Enemy_zonee1 = Enemy_zone1.RenderTransform.TransformBounds(Enemy_zone1.RenderedGeometry.Bounds);
            Rect Enemy_zonee2 = Enemy_zone2.RenderTransform.TransformBounds(Enemy_zone2.RenderedGeometry.Bounds);
            Rect Herorect = hero.RenderTransform.TransformBounds(hero.RenderedGeometry.Bounds);
            
            //Перес
            Rect Deep = DeepDarkHole.RenderTransform.TransformBounds(DeepDarkHole.RenderedGeometry.Bounds);
            if (Herorect.IntersectsWith(Deep) == true)
            {
                if ((Deep.X + Deep.Width) >= Herorect.X) { hero.RenderTransform = new TranslateTransform(x + 2, y); x += 2; }
            }
            Rect Forest1 = DeepDarkForest1.RenderTransform.TransformBounds(DeepDarkForest1.RenderedGeometry.Bounds);
            if (Herorect.IntersectsWith(Forest1) == true)
            {
                if (Forest1.Y >= (Herorect.Y - Herorect.Height)) { hero.RenderTransform = new TranslateTransform(x, y - 3); y -= 3; goto br; }
                if ((Forest1.Y + Forest1.Height) <= Herorect.Y) { hero.RenderTransform = new TranslateTransform(x, y + 3); y += 3; goto br; }
                if ((Forest1.X + Forest1.Width) >= Herorect.X) { hero.RenderTransform = new TranslateTransform(x + 3, y); x += 3; goto br; }
                if (Forest1.X <= (Herorect.X + Herorect.Width)) { hero.RenderTransform = new TranslateTransform(x - 3, y); x -= 3; goto br; }

            br:;
            }
            Rect Forest2 = DeepDarkForest2.RenderTransform.TransformBounds(DeepDarkForest2.RenderedGeometry.Bounds);
            if (Herorect.IntersectsWith(Forest2) == true)
            {
                if (Forest2.Y >= (Herorect.Y - Herorect.Height)) { hero.RenderTransform = new TranslateTransform(x, y - 2); y -= 2; goto br; }
                if ((Forest2.Y + Forest2.Height) <= Herorect.Y) { hero.RenderTransform = new TranslateTransform(x, y + 2); y += 2; goto br; }
                if ((Forest2.X + Forest2.Width) >= Herorect.X) { hero.RenderTransform = new TranslateTransform(x + 2, y); x += 2; goto br; }
                if (Forest2.X <= (Herorect.X + Herorect.Width)) { hero.RenderTransform = new TranslateTransform(x - 2, y); x -= 2; goto br; }

            br:;
            }
            Rect Forest3 = DeepDarkForest3.RenderTransform.TransformBounds(DeepDarkForest3.RenderedGeometry.Bounds);
            if (Herorect.IntersectsWith(Forest3) == true)
            {
                if (Forest3.Y >= (Herorect.Y - Herorect.Height)) { hero.RenderTransform = new TranslateTransform(x, y - 2); y -= 2; goto br; }
                if ((Forest3.Y + Forest3.Height) <= Herorect.Y) { hero.RenderTransform = new TranslateTransform(x, y + 2); y += 2; goto br; }
                if ((Forest3.X + Forest3.Width) >= Herorect.X) { hero.RenderTransform = new TranslateTransform(x + 2, y); x += 2; goto br; }
                if (Forest3.X <= (Herorect.X + Herorect.Width)) { hero.RenderTransform = new TranslateTransform(x - 2, y); x -= 2; goto br; }

            br:;
            }




            Scroll.ScrollToHorizontalOffset((Herorect.Left - 100)/1.5);
            if (Herorect.IntersectsWith(Enemy_zonee1) == true)
            {
                try
                {
                    int r = Random.Next(0, 300);
                    if (r == 1) MainPage.NavigationService.Navigate(new Fight("Snake"));
                }
                catch { }
            }
            if (Herorect.IntersectsWith(Enemy_zonee2) == true)
            {
                try
                {
                    int r = Random.Next(0, 400);
                    if (r <= 1)
                        MainPage.NavigationService.Navigate(new Fight("Xorn"));
                }
                catch { }
            }
            if (Herorect.IntersectsWith(LAVA) == true)
            {
                try
                {
                    
                        MainPage.NavigationService.Navigate(new GG("hehe"));
                }
                catch { }
            }
            


                timer.Start();
            switch (e.Key)
            {
                case Key.Escape: MainPage.NavigationService.Navigate(new Menu()); break;
                case Key.Left: hero.RenderTransform = new TranslateTransform(x-2, y); x -= 2; break;
                case Key.Right: hero.RenderTransform = new TranslateTransform(x+2, y); x += 2; break; 
                case Key.Down: hero.RenderTransform = new TranslateTransform(x,y+2); y += 2; break;
                case Key.Up: hero.RenderTransform = new TranslateTransform(x,y-2); y -= 2; break;
                case Key.A: hero.RenderTransform = new TranslateTransform(x - 2, y); x -= 2;   animationIndex = 4; break;
                case Key.D:  hero.RenderTransform = new TranslateTransform(x + 2, y); x += 2; animationIndex = 3; break;
                case Key.S: hero.RenderTransform = new TranslateTransform(x, y + 2); y += 2; animationIndex = 1; break;
                case Key.W: hero.RenderTransform = new TranslateTransform(x, y - 2); y -= 2; animationIndex = 2; break;

            }
        }




        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            
            
            currentFrame = (currentFrame + 1 + frameCount) % frameCount;
            var frameLeft = currentFrame * frameW;
            var frameTop = animationIndex * frameH;// currentRow * frameH;
            (hero.Fill as ImageBrush).Viewbox = new Rect(frameLeft, frameTop, frameLeft + frameW, frameTop + frameH);


            //if (currentFrame == animations[animationIndex] - 1)
            //{
            //    //currentRow++;
            //    animationIndex++;
            //    //if (currentRow > 20) currentRow = 0; 
            //    if (animationIndex == animations.Length) animationIndex = 0;
            //    frameCount = animations[animationIndex];
            //    currentFrame = 0;
            //}


        }


        private void Page_KeyUp(object sender, KeyEventArgs e)
        {

            if (animationIndex == 1)
            { animationIndex = 1; var frameTop = animationIndex * frameH; (hero.Fill as ImageBrush).Viewbox = new Rect(0, frameTop, frameW, frameTop + frameH); timer.Stop(); }
            if (animationIndex == 2)
            { animationIndex = 2; var frameTop = animationIndex * frameH; (hero.Fill as ImageBrush).Viewbox = new Rect(0, frameTop, frameW, frameTop + frameH); timer.Stop(); }
            if (animationIndex == 3)
            { animationIndex = 3; var frameTop = animationIndex * frameH; (hero.Fill as ImageBrush).Viewbox = new Rect(0, frameTop, frameW, frameTop + frameH); timer.Stop(); }
            if (animationIndex == 4)
            { animationIndex = 4; var frameTop = animationIndex * frameH; (hero.Fill as ImageBrush).Viewbox = new Rect(0, frameTop, frameW, frameTop + frameH); timer.Stop(); }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainPage.NavigationService.Navigate(new Fight("Xorn"));
        }


        
    }
}
