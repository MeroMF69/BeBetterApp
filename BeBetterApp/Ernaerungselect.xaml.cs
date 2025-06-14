using Serilog;
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

namespace BeBetterApp
{
    /// <summary>
    /// Interaction logic for Ernaerungselect.xaml
    /// </summary>
    public partial class Ernaerungselect : Window
    {
        public Ernaerungselect()
        {
            InitializeComponent();
        }

        private void Button_erstellePlan(object sender, RoutedEventArgs e)
        {
            this.Close();
            WindowEssensplanErstellung windowEssensplanErstellung = new WindowEssensplanErstellung();
            windowEssensplanErstellung.Show();
            Log.Verbose("Fittnesplan wird aufgerufen");
        }

        

        private void Button_Koerperteile(object sender, RoutedEventArgs e)
        {
            this.Close();
            Kalorienzähler kalorienzähler = new Kalorienzähler();
            kalorienzähler.Show();
            Log.Verbose("Körperteile werden aufgerufen");
        }

        private void Button_Zueruck(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
