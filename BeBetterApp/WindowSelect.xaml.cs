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
using System.Windows.Shapes;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace BeBetterApp
{
    /// <summary>
    /// Interaction logic for WindowSelect.xaml
    /// </summary>
    public partial class WindowSelect : Window
    {
        public WindowSelect()
        {

            InitializeComponent();
            //Textblock_Text.Text = Texttest;
 
        }

        private void Button_zuruck(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            
            
        }

        private void Button_Koerperteile(object sender, RoutedEventArgs e)
        {

        }

        private void Button_erstellePlan(object sender, RoutedEventArgs e)
        {
            WindowTrainingsplanerstellung windowTrainingsplanerstellung = new WindowTrainingsplanerstellung();
            windowTrainingsplanerstellung.Show();
        }
    }
}
