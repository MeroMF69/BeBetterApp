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
            this.Close();
            WindowEinzelneKoerperteileTrainieren windowEinzelneKoerperteileTrainieren = new WindowEinzelneKoerperteileTrainieren();
            windowEinzelneKoerperteileTrainieren.Show();
        }

        private void Button_erstellePlan(object sender, RoutedEventArgs e)
        {
            WindowTrainingsplanerstellung windowTrainingsplanerstellung = new WindowTrainingsplanerstellung();
            windowTrainingsplanerstellung.Show();
        }
    }
}
