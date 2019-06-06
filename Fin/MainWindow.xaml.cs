﻿using System;
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
        int y = 100;
        Rectangle hero = new Rectangle();
        DispatcherTimer timer = new DispatcherTimer();
        int currentFrame = 10;
        int[] animations = new int[] { 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28};
        int animationIndex = 1;

        int frameCount = 27;
        double frameW = 36;
        double frameH = 36;

        
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
            //ib.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/Resource/Sprite/Sprite.png", UriKind.Absolute));
            //hero.Fill = ib;
            hero.Fill = Brushes.HotPink;
            hero.Margin = new Thickness(x, y, 0, 0);
            scene.Children.Add(hero);
            scene.Focusable = true;
            //timer.Tick += new EventHandler(dispatcherTimer_Tick);
            //timer.Interval = new TimeSpan(0, 0, 0, 0, 120);            
            //timer.Start();
            scene.KeyDown += new KeyEventHandler(Hero_KeyDown);
            scene.Focusable = true;

        }

        private void Hero_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Escape: MainPage.NavigationService.Navigate(new Menu()); break;
                case Key.Left: hero.RenderTransform = new TranslateTransform(x-2, y); x -= 2; break;
                case Key.Right: hero.RenderTransform = new TranslateTransform(x+2, y); x += 2; break;
                case Key.Down: hero.RenderTransform = new TranslateTransform(x,y+2); y += 2; break;
                case Key.Up: hero.RenderTransform = new TranslateTransform(x,y-2); y -= 2; break;
                case Key.A: hero.RenderTransform = new TranslateTransform(x - 2, y); x -= 2; break;
                case Key.D: hero.RenderTransform = new TranslateTransform(x + 2, y); x += 2; break;
                case Key.S: hero.RenderTransform = new TranslateTransform(x, y + 2); y += 2; break;
                case Key.W: hero.RenderTransform = new TranslateTransform(x, y - 2); y -= 2; break;

            }
        }

      
        //private void dispatcherTimer_Tick(object sender, EventArgs e)
        //{
        //    //if (currentFrame == 7) currentFrame = 0;
        //    currentFrame = (currentFrame + 1 + frameCount) % frameCount;
        //    var frameLeft = currentFrame * frameW;
        //    var frameTop = animationIndex * frameH;// currentRow * frameH;
        //    (hero.Fill as ImageBrush).Viewbox = new Rect(frameLeft, frameTop, frameLeft + frameW, frameTop + frameH);

        //    if (currentFrame == animations[animationIndex] - 1)
        //    {
                
        //        animationIndex++;
                
        //        if (animationIndex == animations.Length) animationIndex = 0;
        //        frameCount = animations[animationIndex];
        //        currentFrame = 0;
        //    }
           

        //}


        private void Page_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainPage.NavigationService.Navigate(new Fight());

        }


        
    }
}