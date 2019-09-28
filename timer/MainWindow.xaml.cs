using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace timer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            b_close.BorderBrush = new SolidColorBrush(Colors.DimGray);
        }

        private void B_close_MouseLeave(object sender, MouseEventArgs e)
        {
            b_close.BorderBrush = default;
        }


        private void B_close_MouseDown(object sender, MouseButtonEventArgs e)
        {
            b_close.BorderBrush = new SolidColorBrush(Colors.OrangeRed);
        }

        private void B_close_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (interval != null)
            {
                interval.Enabled = false;
            }
            
            this.Close();
        }

        private void B_min_MouseDown(object sender, MouseButtonEventArgs e)
        {
            b_min.BorderBrush = new SolidColorBrush(Colors.LightGray);
        }

        private void B_min_MouseEnter(object sender, MouseEventArgs e)
        {
            b_min.BorderBrush = new SolidColorBrush(Colors.DimGray);
        }

        private void B_min_MouseLeave(object sender, MouseEventArgs e)
        {
            b_min.BorderBrush = default;
        }

        private void B_min_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void B_pin_MouseDown(object sender, MouseButtonEventArgs e)
        {
            b_pin.BorderBrush = new SolidColorBrush(Colors.LightGray);
        }

        private void B_pin_MouseEnter(object sender, MouseEventArgs e)
        {
            b_pin.BorderBrush = new SolidColorBrush(Colors.DimGray);
        }

        private void B_pin_MouseLeave(object sender, MouseEventArgs e)
        {
            b_pin.BorderBrush = default;
        }

        private void B_pin_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Topmost = !this.Topmost;
        }
        private static Timer interval;
        public int timeLeft;
        public int totalTime;
        private void Start_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (start_stop_text.Content.ToString() == "Start")
            {
                int s = int.Parse(i_Seconds.Text) * 1000;
                int m = int.Parse(i_Minutes.Text) * 60 * 1000;
                int h = int.Parse(i_Hours.Text) * 60 * 60 * 1000;

                totalTime = s + m + h;
                Console.WriteLine(totalTime);
                if (totalTime > 0)
                {
                    interval = new Timer
                    {
                        Interval = 1000
                    };


                    interval.Elapsed += OnTimedEvent;

                    interval.AutoReset = true;

                    
                    timeLeft = totalTime;
                    i_Seconds.IsEnabled = false;
                    i_Minutes.IsEnabled = false;
                    i_Hours.IsEnabled = false;

                    start_stop_text.Content = "Stop";
                    // Start the timer
                    interval.Enabled = true;
                }
                else
                {
                    b_start_stop.IsEnabled = false;
                    b_start_stop.Background = new SolidColorBrush(Colors.Red);
                }
                       
                
            }
            else
            {
                start_stop_text.Content = "Start";
                interval.Enabled = false;
                i_Seconds.IsEnabled = true;
                i_Minutes.IsEnabled = true;
                i_Hours.IsEnabled = true;
                i_Days.Visibility = Visibility.Hidden;
            }
        }
        

            private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            timeLeft -= 1000;
            this.Dispatcher.Invoke((Action)(() =>
            {//this refers to form in WPF application
                
                TimeSpan timeLeft_s = TimeSpan.FromSeconds(timeLeft / 1000);

                i_Seconds.Text = timeLeft_s.ToString(@"ss");
                i_Minutes.Text = timeLeft_s.ToString(@"mm");
                i_Hours.Text = timeLeft_s.ToString(@"hh");
                i_Days.Text = timeLeft_s.ToString(@"dd");
                if (timeLeft_s.Days >= 1)
                {
                    i_Days.Visibility = Visibility.Visible;
                }
            }));
        
            if (timeLeft  <= 0)
            {
                Console.WriteLine("end");
                var psi = new ProcessStartInfo("shutdown", "/s /t 0")
                {
                    CreateNoWindow = true,
                    UseShellExecute = false
                };
                Process.Start(psi);
            }
   
        }

        private readonly Regex rx = new Regex(@"^[\d]+$");
        private void I_TextInput(object sender, TextCompositionEventArgs e)
        {
            i_Seconds.Text = rx.Match(e.Text).ToString();
            



        }

        private void I_Seconds_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.IsLoaded)
            {
                if (rx.IsMatch(i_Seconds.Text))
                {
                    b_start_stop.IsEnabled = true;
                    b_start_stop.Background = (Brush)FindResource("input_background");
                }
                else
                {
                    b_start_stop.IsEnabled = false;
                    b_start_stop.Background = new SolidColorBrush(Colors.Red);
                }
            }
        }

        private void I_Minutes_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.IsLoaded)
            {
                if (rx.IsMatch(i_Minutes.Text))
                {
                    b_start_stop.IsEnabled = true;
                    b_start_stop.Background = (Brush)FindResource("input_background");
                }
                else
                {
                    b_start_stop.IsEnabled = false;
                    b_start_stop.Background = new SolidColorBrush(Colors.Red);
                }
            }
        }

        private void I_Hours_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.IsLoaded)
            {
                if (rx.IsMatch(i_Hours.Text))
                {
                    b_start_stop.IsEnabled = true;
                    b_start_stop.Background = (Brush)FindResource("input_background");
                }
                else
                {
                    b_start_stop.IsEnabled = false;
                    b_start_stop.Background = new SolidColorBrush(Colors.Red);
                }
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

    public static class ExtensionMethods
    {

        
        public static float Map(this float from, float fromMin, float fromMax, float toMin, float toMax)
        {
            var fromAbs = from - fromMin;
            var fromMaxAbs = fromMax - fromMin;

            var normal = fromAbs / fromMaxAbs;

            var toMaxAbs = toMax - toMin;
            var toAbs = toMaxAbs * normal;

            var to = toAbs + toMin;

            return to;
        }

    }
    


}
