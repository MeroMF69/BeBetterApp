using Serilog;
using System.Windows;

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
            Log.Information("WindowSelect (Fitness) geöffnet");

        }

        private void Button_zuruck(object sender, RoutedEventArgs e)
        {
            Log.Information("Fitness-Select Window geschlossen");
            this.Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void Button_Koerperteile(object sender, RoutedEventArgs e)
        {
            Log.Information("Einzelne-Körperteile-Trainieren Window geöffnet");
            this.Close();
            WindowEinzelneKoerperteileTrainieren windowEinzelneKoerperteileTrainieren = new WindowEinzelneKoerperteileTrainieren();
            windowEinzelneKoerperteileTrainieren.Show();
        }

        private void Button_erstellePlan(object sender, RoutedEventArgs e)
        {
            Log.Information("Fitness-Plan erstellen Window geöffnet");
            WindowTrainingsplanerstellung windowTrainingsplanerstellung = new WindowTrainingsplanerstellung();
            windowTrainingsplanerstellung.Show();
        }
    }
}
