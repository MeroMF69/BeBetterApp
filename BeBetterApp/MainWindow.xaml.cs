using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System;
using System.IO;






namespace BeBetterApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Liste für Termine, automatisch UI-aktualisiert

        

        public MainWindow()
        {
            InitializeComponent();
            

            
            this.WindowState = WindowState.Maximized;
            this.WindowStyle = WindowStyle.None;
            this.ResizeMode = ResizeMode.NoResize;

        }

        private void Button_Fitness(object sender, RoutedEventArgs e)
        {
            
            WindowSelect window = new WindowSelect();
            window.Show();
            
        }

        private void Button_Ernaehrung(object sender, RoutedEventArgs e)
        {
            Ernaerungselect ernaerungselect = new Ernaerungselect();
            ernaerungselect.Show();
        }

 

        private void Button_Quit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); // ALLE Fenster schließen sich!!!!!
        }

        private void Button_Saved(object sender, RoutedEventArgs e)
        {

        }


        private void Button_Organisation(object sender, RoutedEventArgs e)
        {
            // Kalender öffnen
            CalendarWindow kalender = new CalendarWindow();
            kalender.ShowDialog();

            // Terminliste aktualisieren
            terminListeControl.Aktualisieren();

            // RadioButton ent-checken, damit erneuter Klick möglich ist
            if (sender is RadioButton rb)
            {
                rb.IsChecked = false;
            }
        }

        string speicherPfad = "termine.json";

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GlobalSchedule.SharedSchedule.LoadFromFile(speicherPfad);
            terminListeControl.Aktualisieren();

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            GlobalSchedule.SharedSchedule.SaveToFile(speicherPfad);
        }

    }
}
