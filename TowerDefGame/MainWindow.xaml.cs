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
using System.Threading;

namespace TowerDefGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ImageBrush towerBrush = new ImageBrush();
        ImageBrush towerBrush2 = new ImageBrush();
        ImageBrush towerBrush3 = new ImageBrush();
        ImageBrush towerBrush4 = new ImageBrush();

        ImageBrush enemyBrush = new ImageBrush();
        ImageBrush enemyBrush2 = new ImageBrush();
        ImageBrush enemyBrush3 = new ImageBrush();
        ImageBrush enemyBrush4 = new ImageBrush();

        ImageBrush templeBrush = new ImageBrush();
        ImageBrush templeBrush2 = new ImageBrush();
        ImageBrush trackBrush = new ImageBrush();

        Random rand = new Random();

        DispatcherTimer timer = new DispatcherTimer();
        DispatcherTimer rateTimer = new DispatcherTimer();

        public int balance;
        public int health;
        public int round;
        public int temple;
        public bool isBuying = false;
        public int buyingTypeOf;
        public int numTowers;

        public int mousex;
        public int mousey;

        public bool notPaused = false;

        int enemysLeft;
        public int timerCount = 10;
        public int cooldownCount = 0;
        public bool isCool = false;

        public MainWindow()
        {
            InitializeComponent();

            //Makes the start overlay visible
            startScreenOverlay.Visibility = Visibility.Visible;
            temple1Select.Visibility = Visibility.Visible;
            temple2Select.Visibility = Visibility.Visible;
            startText.Visibility = Visibility.Visible;

            templeBrush.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/Temple_1.png"));
            templeBrush2.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/Temple_2.png"));
            trackBrush.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/Track.png"));

            temple1Select.Background = templeBrush;
            temple2Select.Background = templeBrush2;


            
        }

        private void temple1Select_Click(object sender, RoutedEventArgs e)
        {
            temple = 1;
            templeRec.Fill = templeBrush;
            gameInitialize();
        }

        private void temple2Select_Click(object sender, RoutedEventArgs e)
        {
            temple = 2;
            templeRec.Fill = templeBrush2;
            gameInitialize();
        }
        private void gameInitialize()
        {
            //track.Visibility = Visibility.Visible;
            track.Fill = trackBrush;
            startScreenOverlay.Visibility = Visibility.Collapsed;
            temple1Select.Visibility = Visibility.Collapsed;
            temple2Select.Visibility = Visibility.Collapsed;
            startText.Visibility = Visibility.Collapsed;
            round = 1;
            roundText.Text = "Round: " + round;
            health = 100;
            healthText.Text = "Health = " + health;
            balance = 700;
            ballanceText.Text = "Ballance = " + balance;
            if (temple == 1)
            {
                //initialize temple 1
            }
            else if (temple == 2)
            {
                //initialize temple 2
            }
            towerBrush.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/Tower_1.png"));
            tower1Buy.Background = towerBrush;
            towerBrush2.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/Tower_2.png"));
            tower2Buy.Background = towerBrush2;
            towerBrush3.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/Tower_3.png"));
            tower3Buy.Background = towerBrush3;
            towerBrush4.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/Tower_4.png"));
            tower4Buy.Background = towerBrush4;

        }

        private void gameCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (isBuying == true)
            {
                test.Fill = Brushes.Black;
                isBuying = false;
                switch (buyingTypeOf)
                {
                    case 1:
                        if (balance >= 150)
                        {
                            balance = balance - 150;
                            ballanceText.Text = "Balance: " + balance;
                        }
                        else
                            break;
                        Rectangle tower1 = new Rectangle
                        {
                            Width = 50,
                            Height = 50,
                            Tag = "tower1",
                            Fill = towerBrush
                        };
                        Canvas.SetZIndex(tower1, 2);
                        Canvas.SetLeft(tower1, mousex);
                        Canvas.SetTop(tower1, mousey);
                        
                        gameCanvas.Children.Add(tower1);
                        break;
                    case 2:
                        if (balance >= 300)
                        {
                            balance = balance - 300;
                            ballanceText.Text = "Balance: " + balance;
                        }
                        else
                            break;
                        Rectangle tower2 = new Rectangle
                        {
                            Width = 50,
                            Height = 50,
                            Tag = "tower2",
                            Fill = towerBrush2
                        };
                        Canvas.SetLeft(tower2, mousex);
                        Canvas.SetTop(tower2, mousey);
                        Canvas.SetZIndex(tower2, 2);
                        gameCanvas.Children.Add(tower2);
                        break;
                    case 3:
                        if (balance >= 500)
                        {
                            balance = balance - 500;
                            ballanceText.Text = "Balance: " + balance;
                        }
                        else
                            break;
                        Rectangle tower3 = new Rectangle
                        {
                            Width = 50,
                            Height = 50,
                            Tag = "tower3",
                            Fill = towerBrush3
                        };
                        Canvas.SetLeft(tower3, mousex);
                        Canvas.SetTop(tower3, mousey);
                        Canvas.SetZIndex(tower3, 2);
                        gameCanvas.Children.Add(tower3);
                        break;
                    case 4:
                        if (balance >= 800)
                        {
                            balance = balance - 150;
                            ballanceText.Text = "Balance: " + balance;
                        }
                        else
                            break;
                        Rectangle tower4 = new Rectangle
                        {
                            Width = 50,
                            Height = 50,
                            Tag = "tower4",
                            Fill = towerBrush4
                        };
                        Canvas.SetLeft(tower4, mousex);
                        Canvas.SetTop(tower4, mousey);
                        Canvas.SetZIndex(tower4, 2);
                        gameCanvas.Children.Add(tower4);
                        break;
                }
            }
        }

        private void tower1Buy_Click(object sender, RoutedEventArgs e)
        {
            isBuying = true;
            buyingTypeOf = 1;
            test.Fill = Brushes.Red;
            numTowers++;
        }

        private void gameCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            System.Windows.Point pointer = e.GetPosition(this);
            double px = pointer.X;
            double py = pointer.Y;

            mousex = Convert.ToInt32(px);
            mousey = Convert.ToInt32(py);
        }

        private void tower2Buy_Click(object sender, RoutedEventArgs e)
        {
            isBuying = true;
            buyingTypeOf = 2;
            test.Fill = Brushes.Red;
            numTowers++;
        }

        private void tower3Buy_Click(object sender, RoutedEventArgs e)
        {
            isBuying = true;
            buyingTypeOf = 3;
            test.Fill = Brushes.Red;
            numTowers++;
        }

        private void tower4Buy_Click(object sender, RoutedEventArgs e)
        {
            isBuying = true;
            buyingTypeOf = 4;
            test.Fill = Brushes.Red;
            numTowers++;
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
                timer.Tick += gameEngine;
                timer.Interval = TimeSpan.FromMilliseconds(20);
                timer.Start();
                enemysLeft = 20;
        }
        private void gameEngine(object sender, EventArgs e)
        {
            cooldowm();
            makeEnemys();
            timerCount++;
            try
            {
                foreach (var x in gameCanvas.Children.OfType<Rectangle>())
                {
                    try
                    {
                        switch (x.Tag)
                        {

                            case "enemyDown":
                                Canvas.SetTop(x, Canvas.GetTop(x) + 10);
                                Rect enemyD = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);
                                foreach (var y in gameCanvas.Children.OfType<Rectangle>())
                                {
                                    if ((string)y.Tag == "turnR")
                                    {
                                        Rect turn = new Rect(Canvas.GetLeft(y), Canvas.GetTop(y), y.Width, y.Height);
                                        if (enemyD.IntersectsWith(turn))
                                        {
                                            x.Tag = "enemyRight";
                                        }
                                    }
                                    else if ((string)y.Tag == "turnL")
                                    {
                                        Rect turn = new Rect(Canvas.GetLeft(y), Canvas.GetTop(y), y.Width, y.Height);
                                        if (enemyD.IntersectsWith(turn))
                                        {
                                            x.Tag = "enemyLeft";
                                        }
                                    }
                                    else if ((string)y.Tag == "turnU")
                                    {
                                        Rect turn = new Rect(Canvas.GetLeft(y), Canvas.GetTop(y), y.Width, y.Height);
                                        if (enemyD.IntersectsWith(turn))
                                        {
                                            x.Tag = "enemyUp";
                                        }
                                    }
                                }
                                break;

                            case "enemyUp":
                                Canvas.SetTop(x, Canvas.GetTop(x) - 10);
                                Rect enemyU = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);
                                foreach (var y in gameCanvas.Children.OfType<Rectangle>())
                                {
                                    if ((string)y.Tag == "turnR")
                                    {
                                        Rect turn = new Rect(Canvas.GetLeft(y), Canvas.GetTop(y), y.Width, y.Height);
                                        if (enemyU.IntersectsWith(turn))
                                        {
                                            x.Tag = "enemyRight";
                                        }
                                    }
                                    else if ((string)y.Tag == "turnL")
                                    {
                                        Rect turn = new Rect(Canvas.GetLeft(y), Canvas.GetTop(y), y.Width, y.Height);
                                        if (enemyU.IntersectsWith(turn))
                                        {
                                            x.Tag = "enemyLeft";
                                        }
                                    }
                                    else if ((string)y.Tag == "turnD")
                                    {
                                        Rect turn = new Rect(Canvas.GetLeft(y), Canvas.GetTop(y), y.Width, y.Height);
                                        if (enemyU.IntersectsWith(turn))
                                        {
                                            x.Tag = "enemyDown";
                                        }
                                    }
                                }
                                break;

                            case "enemyLeft":
                                Canvas.SetLeft(x, Canvas.GetLeft(x) - 10);
                                Rect enemyL = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);
                                foreach (var y in gameCanvas.Children.OfType<Rectangle>())
                                {
                                    if ((string)y.Tag == "turnR")
                                    {
                                        Rect turn = new Rect(Canvas.GetLeft(y), Canvas.GetTop(y), y.Width, y.Height);
                                        if (enemyL.IntersectsWith(turn))
                                        {
                                            x.Tag = "enemyRight";
                                        }
                                    }
                                    else if ((string)y.Tag == "turnD")
                                    {
                                        Rect turn = new Rect(Canvas.GetLeft(y), Canvas.GetTop(y), y.Width, y.Height);
                                        if (enemyL.IntersectsWith(turn))
                                        {
                                            x.Tag = "enemyDown";
                                        }
                                    }
                                    else if ((string)y.Tag == "turnU")
                                    {
                                        Rect turn = new Rect(Canvas.GetLeft(y), Canvas.GetTop(y), y.Width, y.Height);
                                        if (enemyL.IntersectsWith(turn))
                                        {
                                            x.Tag = "enemyUp";
                                        }
                                    }
                                }
                                break;

                            case "enemyRight":
                                Canvas.SetLeft(x, Canvas.GetLeft(x) + 10);
                                Rect enemyR = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);
                                foreach (var y in gameCanvas.Children.OfType<Rectangle>())
                                {
                                    if ((string)y.Tag == "turnD")
                                    {
                                        Rect turn = new Rect(Canvas.GetLeft(y), Canvas.GetTop(y), y.Width, y.Height);
                                        if (enemyR.IntersectsWith(turn))
                                        {
                                            x.Tag = "enemyDown";
                                        }
                                    }
                                    else if ((string)y.Tag == "turnL")
                                    {
                                        Rect turn = new Rect(Canvas.GetLeft(y), Canvas.GetTop(y), y.Width, y.Height);
                                        if (enemyR.IntersectsWith(turn))
                                        {
                                            x.Tag = "enemyLeft";
                                        }
                                    }
                                    else if ((string)y.Tag == "turnU")
                                    {
                                        Rect turn = new Rect(Canvas.GetLeft(y), Canvas.GetTop(y), y.Width, y.Height);
                                        if (enemyR.IntersectsWith(turn))
                                        {
                                            x.Tag = "enemyUp";
                                        }
                                    }

                                    else if ((string)y.Tag == "temple")
                                    {
                                        Rect templeRect = new Rect(Canvas.GetLeft(y), Canvas.GetTop(y), y.Width, y.Height);
                                        if (enemyR.IntersectsWith(templeRect))
                                        {
                                            gameCanvas.Children.Remove(x);
                                            health--;
                                            healthText.Text = "Health: " + health;
                                            break;
                                        }
                                    }
                                }
                                break;
                        }
                    }
                    catch (Exception)
                    {
                        break;
                    }
                }
            }
            catch (Exception)
            {

            }
            foreach (var x in gameCanvas.Children.OfType<Rectangle>())
            {
                switch (x.Tag)
                {
                    case "bulletL":
                        Canvas.SetLeft(x, Canvas.GetLeft(x) - 20);
                        Rect bulletL = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);
                        foreach (var y in gameCanvas.Children.OfType<Rectangle>())
                        {
                            if ((string)y.Tag == "enemyLeft" || (string)y.Tag == "enemyRight" || (string)y.Tag == "enemyDown" || (string)y.Tag == "enemyUp")
                            {
                                Rect enemy = new Rect(Canvas.GetLeft(y), Canvas.GetTop(y), y.Width, y.Height);
                                if (bulletL.IntersectsWith(enemy))
                                {
                                    gameCanvas.Children.Remove(y);
                                    gameCanvas.Children.Remove(x);
                                    balance = balance + 10;
                                    ballanceText.Text = "Ballance: " + balance;
                                    return;
                                }
                            }
                        }
                        break;
                    case "bulletR":
                        Canvas.SetLeft(x, Canvas.GetLeft(x) + 20);
                        Rect bulletR = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);
                        foreach (var y in gameCanvas.Children.OfType<Rectangle>())
                        {
                            if ((string)y.Tag == "enemyLeft" || (string)y.Tag == "enemyRight" || (string)y.Tag == "enemyDown" || (string)y.Tag == "enemyUp")
                            {
                                Rect enemy = new Rect(Canvas.GetLeft(y), Canvas.GetTop(y), y.Width, y.Height);
                                if (bulletR.IntersectsWith(enemy))
                                {
                                    gameCanvas.Children.Remove(y);
                                    gameCanvas.Children.Remove(x);
                                    balance = balance + 10;
                                    ballanceText.Text = "Ballance: " + balance;
                                    return;
                                }
                            }
                        }
                        break;
                    case "bulletU":
                        Canvas.SetTop(x, Canvas.GetTop(x) - 20);
                        Rect bulletU = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);
                        foreach (var y in gameCanvas.Children.OfType<Rectangle>())
                        {
                            if ((string)y.Tag == "enemyLeft" || (string)y.Tag == "enemyRight" || (string)y.Tag == "enemyDown" || (string)y.Tag == "enemyUp")
                            {
                                Rect enemy = new Rect(Canvas.GetLeft(y), Canvas.GetTop(y), y.Width, y.Height);
                                if (bulletU.IntersectsWith(enemy))
                                {
                                    gameCanvas.Children.Remove(y);
                                    gameCanvas.Children.Remove(x);
                                    balance = balance + 10;
                                    ballanceText.Text = "Ballance: " + balance;
                                    return;
                                }
                            }
                        }
                        break;
                    case "bulletD":
                        Canvas.SetTop(x, Canvas.GetTop(x) + 20);
                        Rect bulletD = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);
                        foreach (var y in gameCanvas.Children.OfType<Rectangle>())
                        {
                            if ((string)y.Tag == "enemyLeft" || (string)y.Tag == "enemyRight" || (string)y.Tag == "enemyDown" || (string)y.Tag == "enemyUp")
                            {
                                Rect enemy = new Rect(Canvas.GetLeft(y), Canvas.GetTop(y), y.Width, y.Height);
                                if (bulletD.IntersectsWith(enemy))
                                {
                                    gameCanvas.Children.Remove(y);
                                    gameCanvas.Children.Remove(x);
                                    balance = balance + 10;
                                    ballanceText.Text = "Ballance: " + balance;
                                    return;
                                }
                            }
                        }
                        break;
                    case "bulletUL":
                        Canvas.SetLeft(x, Canvas.GetLeft(x) - 20);
                        Canvas.SetTop(x, Canvas.GetTop(x) - 20);
                        Rect bulletUL = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);
                        foreach (var y in gameCanvas.Children.OfType<Rectangle>())
                        {
                            if ((string)y.Tag == "enemyLeft" || (string)y.Tag == "enemyRight" || (string)y.Tag == "enemyDown" || (string)y.Tag == "enemyUp")
                            {
                                Rect enemy = new Rect(Canvas.GetLeft(y), Canvas.GetTop(y), y.Width, y.Height);
                                if (bulletUL.IntersectsWith(enemy))
                                {
                                    gameCanvas.Children.Remove(y);
                                    gameCanvas.Children.Remove(x);
                                    balance = balance + 10;
                                    ballanceText.Text = "Ballance: " + balance;
                                    return;
                                }
                            }
                        }
                        break;
                    case "bulletUR":
                        Canvas.SetLeft(x, Canvas.GetLeft(x) + 20);
                        Canvas.SetTop(x, Canvas.GetTop(x) - 20);
                        Rect bulletUR = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);
                        foreach (var y in gameCanvas.Children.OfType<Rectangle>())
                        {
                            if ((string)y.Tag == "enemyLeft" || (string)y.Tag == "enemyRight" || (string)y.Tag == "enemyDown" || (string)y.Tag == "enemyUp")
                            {
                                Rect enemy = new Rect(Canvas.GetLeft(y), Canvas.GetTop(y), y.Width, y.Height);
                                if (bulletUR.IntersectsWith(enemy))
                                {
                                    gameCanvas.Children.Remove(y);
                                    gameCanvas.Children.Remove(x);
                                    balance = balance + 10;
                                    ballanceText.Text = "Ballance: " + balance;
                                    return;
                                }
                            }
                        }
                        break;
                    case "bulletDL":
                        Canvas.SetLeft(x, Canvas.GetLeft(x) - 20);
                        Canvas.SetTop(x, Canvas.GetTop(x) + 20);
                        Rect bulletDL = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);
                        foreach (var y in gameCanvas.Children.OfType<Rectangle>())
                        {
                            if ((string)y.Tag == "enemyLeft" || (string)y.Tag == "enemyRight" || (string)y.Tag == "enemyDown" || (string)y.Tag == "enemyUp")
                            {
                                Rect enemy = new Rect(Canvas.GetLeft(y), Canvas.GetTop(y), y.Width, y.Height);
                                if (bulletDL.IntersectsWith(enemy))
                                {
                                    gameCanvas.Children.Remove(y);
                                    gameCanvas.Children.Remove(x);
                                    balance = balance + 10;
                                    ballanceText.Text = "Ballance: " + balance;
                                    return;
                                }
                            }
                        }
                        break;
                    case "bulletDR":
                        Canvas.SetLeft(x, Canvas.GetLeft(x) + 20);
                        Canvas.SetTop(x, Canvas.GetTop(x) + 20);
                        Rect bulletDR = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);
                        foreach (var y in gameCanvas.Children.OfType<Rectangle>())
                        {
                            if ((string)y.Tag == "enemyLeft" || (string)y.Tag == "enemyRight" || (string)y.Tag == "enemyDown" || (string)y.Tag == "enemyUp")
                            {
                                Rect enemy = new Rect(Canvas.GetLeft(y), Canvas.GetTop(y), y.Width, y.Height);
                                if (bulletDR.IntersectsWith(enemy))
                                {
                                    gameCanvas.Children.Remove(y);
                                    gameCanvas.Children.Remove(x);
                                    balance = balance + 10;
                                    ballanceText.Text = "Ballance: " + balance;
                                    return;
                                }
                            }
                        }
                        break;
                }
            }
            for (int i = 0; i < numTowers; i++)
            {
                try
                {
                    foreach (var x in gameCanvas.Children.OfType<Rectangle>())
                    {
                        switch (x.Tag)
                        {

                            case "tower1":
                                Rect range1 = new Rect(Canvas.GetLeft(x) + 25, Canvas.GetTop(x) + 25, 300, 300);
                                foreach (var y in gameCanvas.Children.OfType<Rectangle>())
                                {
                                    if ((string)y.Tag == "enemyLeft" || (string)y.Tag == "enemyRight" || (string)y.Tag == "enemyDown" || (string)y.Tag == "enemyUp")
                                    {
                                        Rect enemy = new Rect(Canvas.GetLeft(y), Canvas.GetTop(y), y.Width, Height);
                                        if (enemy.IntersectsWith(range1) && isCool == false)
                                        {
                                            double difx = Canvas.GetLeft(x) + 50 - Canvas.GetLeft(y);
                                            double dify = Canvas.GetTop(x) + 50 - Canvas.GetTop(y);
                                            if (difx > 0 && dify > 0) //Top Left
                                            {
                                                if (difx > 75 && dify > 75)
                                                {
                                                    Rectangle bullet = new Rectangle
                                                    {
                                                        Width = 5,
                                                        Height = 5,
                                                        Tag = "bulletUL",
                                                        Fill = new SolidColorBrush(Colors.Black)
                                                    };
                                                    Canvas.SetZIndex(bullet, 2);
                                                    Canvas.SetLeft(bullet, Canvas.GetLeft(x) - x.Width);
                                                    Canvas.SetTop(bullet, Canvas.GetTop(x) - x.Height);
                                                    gameCanvas.Children.Add(bullet);
                                                    break;
                                                }
                                                else if (dify < 75)
                                                {
                                                    Rectangle bullet = new Rectangle
                                                    {
                                                        Width = 5,
                                                        Height = 5,
                                                        Tag = "bulletL",
                                                        Fill = new SolidColorBrush(Colors.Black)
                                                    };
                                                    Canvas.SetZIndex(bullet, 2);
                                                    Canvas.SetLeft(bullet, Canvas.GetLeft(x) - x.Width);
                                                    Canvas.SetTop(bullet, Canvas.GetTop(x));
                                                    gameCanvas.Children.Add(bullet);
                                                    break;
                                                }
                                                else if (difx < 75)
                                                {
                                                    Rectangle bullet = new Rectangle
                                                    {
                                                        Width = 5,
                                                        Height = 5,
                                                        Tag = "bulletU",
                                                        Fill = new SolidColorBrush(Colors.Black)
                                                    };
                                                    Canvas.SetZIndex(bullet, 2);
                                                    Canvas.SetLeft(bullet, Canvas.GetLeft(x));
                                                    Canvas.SetTop(bullet, Canvas.GetTop(x) - x.Height);
                                                    gameCanvas.Children.Add(bullet);
                                                    break;
                                                }
                                            }
                                            else if (difx < 0 && dify > 0) //Top Right
                                            {
                                                if (difx < -75 && dify > 75)
                                                {
                                                    Rectangle bullet = new Rectangle
                                                    {
                                                        Width = 5,
                                                        Height = 5,
                                                        Tag = "bulletUR",
                                                        Fill = new SolidColorBrush(Colors.Black)
                                                    };
                                                    Canvas.SetZIndex(bullet, 2);
                                                    Canvas.SetLeft(bullet, Canvas.GetLeft(x) + x.Width);
                                                    Canvas.SetTop(bullet, Canvas.GetTop(x) - x.Height);
                                                    gameCanvas.Children.Add(bullet);
                                                    break;
                                                }
                                                else if (dify < 75)
                                                {
                                                    Rectangle bullet = new Rectangle
                                                    {
                                                        Width = 5,
                                                        Height = 5,
                                                        Tag = "bulletR",
                                                        Fill = new SolidColorBrush(Colors.Black)
                                                    };
                                                    Canvas.SetZIndex(bullet, 2);
                                                    Canvas.SetLeft(bullet, Canvas.GetLeft(x) + x.Width);
                                                    Canvas.SetTop(bullet, Canvas.GetTop(x));
                                                    gameCanvas.Children.Add(bullet);
                                                    break;
                                                }
                                                else if (difx > -75)
                                                {
                                                    Rectangle bullet = new Rectangle
                                                    {
                                                        Width = 5,
                                                        Height = 5,
                                                        Tag = "bulletU",
                                                        Fill = new SolidColorBrush(Colors.Black)
                                                    };
                                                    Canvas.SetZIndex(bullet, 2);
                                                    Canvas.SetLeft(bullet, Canvas.GetLeft(x));
                                                    Canvas.SetTop(bullet, Canvas.GetTop(x) - x.Height);
                                                    gameCanvas.Children.Add(bullet);
                                                    break;
                                                }
                                            }
                                            else if (difx < 0 && dify < 0) //Bottom Right
                                            {
                                                if (difx < -75 && dify < -75)
                                                {
                                                    Rectangle bullet = new Rectangle
                                                    {
                                                        Width = 5,
                                                        Height = 5,
                                                        Tag = "bulletDR",
                                                        Fill = new SolidColorBrush(Colors.Black)
                                                    };
                                                    Canvas.SetZIndex(bullet, 2);
                                                    Canvas.SetLeft(bullet, Canvas.GetLeft(x) + x.Width);
                                                    Canvas.SetTop(bullet, Canvas.GetTop(x) + x.Height);
                                                    gameCanvas.Children.Add(bullet);
                                                    break;
                                                }
                                                else if (dify > -75)
                                                {
                                                    Rectangle bullet = new Rectangle
                                                    {
                                                        Width = 5,
                                                        Height = 5,
                                                        Tag = "bulletR",
                                                        Fill = new SolidColorBrush(Colors.Black)
                                                    };
                                                    Canvas.SetZIndex(bullet, 2);
                                                    Canvas.SetLeft(bullet, Canvas.GetLeft(x) + x.Width);
                                                    Canvas.SetTop(bullet, Canvas.GetTop(x));
                                                    gameCanvas.Children.Add(bullet);
                                                    break;
                                                }
                                                else if (difx > -75)
                                                {
                                                    Rectangle bullet = new Rectangle
                                                    {
                                                        Width = 5,
                                                        Height = 5,
                                                        Tag = "bulletD",
                                                        Fill = new SolidColorBrush(Colors.Black)
                                                    };
                                                    Canvas.SetZIndex(bullet, 2);
                                                    Canvas.SetLeft(bullet, Canvas.GetLeft(x));
                                                    Canvas.SetTop(bullet, Canvas.GetTop(x) + x.Height);
                                                    gameCanvas.Children.Add(bullet);
                                                    break;
                                                }
                                            }
                                            else if (difx > 0 && dify < 0) //Bottom Left
                                            {
                                                if (difx > 75 && dify < -75)
                                                {
                                                    Rectangle bullet = new Rectangle
                                                    {
                                                        Width = 5,
                                                        Height = 5,
                                                        Tag = "bulletDL",
                                                        Fill = new SolidColorBrush(Colors.Black)
                                                    };
                                                    Canvas.SetZIndex(bullet, 2);
                                                    Canvas.SetLeft(bullet, Canvas.GetLeft(x) - x.Width);
                                                    Canvas.SetTop(bullet, Canvas.GetTop(x) - x.Height);
                                                    gameCanvas.Children.Add(bullet);
                                                    break;
                                                }
                                                else if (dify > -75)
                                                {
                                                    Rectangle bullet = new Rectangle
                                                    {
                                                        Width = 5,
                                                        Height = 5,
                                                        Tag = "bulletL",
                                                        Fill = new SolidColorBrush(Colors.Black)
                                                    };
                                                    Canvas.SetZIndex(bullet, 2);
                                                    Canvas.SetLeft(bullet, Canvas.GetLeft(x) - x.Width);
                                                    Canvas.SetTop(bullet, Canvas.GetTop(x));
                                                    gameCanvas.Children.Add(bullet);
                                                    break;
                                                }
                                                else if (difx < 75)
                                                {
                                                    Rectangle bullet = new Rectangle
                                                    {
                                                        Width = 5,
                                                        Height = 5,
                                                        Tag = "bulletD",
                                                        Fill = new SolidColorBrush(Colors.Black)
                                                    };
                                                    Canvas.SetZIndex(bullet, 2);
                                                    Canvas.SetLeft(bullet, Canvas.GetLeft(x));
                                                    Canvas.SetTop(bullet, Canvas.GetTop(x) + x.Height);
                                                    gameCanvas.Children.Add(bullet);
                                                    break;
                                                }
                                            }

                                        }
                                    }
                                }
                                break;
                        }

                    }
                }
                catch (Exception)
                {
                }
            }
            isCool = true;
            //GC.Collect();

        }
        
        private void cooldowm()
        {
            if (cooldownCount == 10)
            {
                isCool = false;
                cooldownCount = 0;
            }
            cooldownCount++;
        }

        private void makeEnemys()
        {
            if (enemysLeft > 0 && timerCount == 10)
            {
                Rectangle baddy = new Rectangle()
                {
                    Width = 25,
                    Height = 25,
                    Tag = "enemyDown",
                    Fill = new SolidColorBrush(Colors.Black)
                };
                Canvas.SetLeft(baddy, 90);
                Canvas.SetTop(baddy, 0);
                Canvas.SetZIndex(baddy, 2);
                gameCanvas.Children.Add(baddy);

                timerCount = 0;
                enemysLeft--;
            }
        }

        private void gameCanvas_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
