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


namespace timer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
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
    }
}
