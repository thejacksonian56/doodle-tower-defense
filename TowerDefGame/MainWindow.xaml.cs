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

        public int balance;
        public int health;
        public int round;
        public int temple;
        public bool isBuying = false;
        public int buyingTypeOf;

        public int mousex;
        public int mousey;

        public bool notPaused = false;

        int enemyCounter;

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
            track.Visibility = Visibility.Visible;
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
        }

        private void tower3Buy_Click(object sender, RoutedEventArgs e)
        {
            isBuying = true;
            buyingTypeOf = 3;
            test.Fill = Brushes.Red;
        }

        private void tower4Buy_Click(object sender, RoutedEventArgs e)
        {
            isBuying = true;
            buyingTypeOf = 4;
            test.Fill = Brushes.Red;
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            notPaused = true;
            while (notPaused)
            {
                timer.Tick += gameEngine;
                timer.Interval = TimeSpan.FromMilliseconds(20);
                timer.Start();
            }
            
        }

        private void gameEngine(object? sender, EventArgs e)
        {

            
        }
    }
    public class Enemy
    {
        public int health;
        public int type;
        public int reward;
        public int speed;
    }
    public class tower
    {
        public int cost;
        public int type;
        public int attackDamage;
        public int attackSpeed;
    }
    public class Round
    {
        public int roundNumber;
        public int reward;
        public float speedModifier;
    }
}
