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
    /// Interaction logic for Gespeichertselect.xaml
    /// </summary>
    public partial class Gespeichertselect : Window
    {
        public Gespeichertselect()
        {
            InitializeComponent();
        }

        private void Button_Fittnesplan(object sender, RoutedEventArgs e)
        {
            AufrufenFitnessplan aufrufen = new AufrufenFitnessplan();
            aufrufen.Show();
        }

        private void Button_ErnährungsPlan(object sender, RoutedEventArgs e)
        {
            AufrufenEssensplan essensplan = new AufrufenEssensplan();
            essensplan.Show();
        }

        private void Button_Zueruck(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
