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
using OpenAI.Chat;
using System.IO;
using HarfBuzzSharp;
using System.Text.Json;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using System.Collections.Generic;
using Serilog;






namespace BeBetterApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Liste für Termine, automatisch UI-aktualisiert


        DateOnly heute = DateOnly.FromDateTime(DateTime.Now); 
        int streak = 0;
        int punkte = 0;
        DateOnly Tag = DateOnly.FromDateTime(DateTime.Now);
        bool done = false;



        public MainWindow()
        {
            InitializeComponent();
            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("BeBetter.log", rollingInterval: RollingInterval.Day)
            .CreateLogger();

            Log.Verbose("Program hat gestartet ...");
            try
            {


                if (File.Exists("Daten.json"))
                {
                    string daten = File.ReadAllText("Daten.json");
                    Log.Information("Daten wurden von Daten.json gelesen");
                    if (!string.IsNullOrWhiteSpace(daten))
                    {
                        string[] dataSplit = daten.Split('#');

                        streak = int.Parse(dataSplit[0]);
                        punkte = int.Parse(dataSplit[1]);
                        Tag = DateOnly.Parse(dataSplit[2]);
                        done = bool.Parse(dataSplit[3]);

                    }
                    else
                    {
                        using (StreamWriter sw = new StreamWriter("Daten.json"))
                        {
                            sw.WriteLine($"0#0#{heute}#false");
                        }
                    }
                }
                else
                {
                    using (StreamWriter sw = new StreamWriter("Daten.json"))
                    {
                        sw.WriteLine($"0#0#{heute}#false");
                    }
                }

                if (done == true)
                {
                    Label_streak.Foreground = Brushes.White;
                    Border_challange.Background = Brushes.Gray;
                }

                if (heute != Tag)
                {
                    done = false;
                    int diff = Tag.DayNumber - heute.DayNumber;
                    if (diff > 1)
                    {
                        streak = 0;
                    }
                    using (StreamWriter sw = new StreamWriter("Daten.json"))
                    {
                        sw.WriteLine($"{streak}#{punkte}#{heute}#{done}");
                    }
                }
            }
            catch
            {
                Log.Error("Daten können nicht gelesen werden.");
            }
            Label_streak.Content = $"STREAK: {streak}";

            if (punkte <=7000)
            {
                Image_rank.Source = new BitmapImage(new Uri("Icons/BronzeRank.png", UriKind.Relative)); 
            }
            else if (punkte > 7000 && punkte <= 31000)
            {
                Image_rank.Source = new BitmapImage(new Uri("Icons/SilberRank.png", UriKind.Relative));
            }
            else
            {
                Image_rank.Source = new BitmapImage(new Uri("Icons/DiaRank.png", UriKind.Relative));
            }

            
            if (File.Exists("Challengesnes.json"))
            {

                string Challage_daten = File.ReadLines("Challengesnes.json").FirstOrDefault();
                            Log.Information("Daten wurden von Challenges.json gelesen");



                if (!string.IsNullOrWhiteSpace(Challage_daten))
                {


                    if (Tag == heute)
                    {
                        if (File.Exists("Aufgabe.json"))
                        {
                            string aufgabe = File.ReadLines("Aufgabe.json").FirstOrDefault();
                               Log.Information("Daten wurden von Aufgabe.json gelesen");

                            if (!string.IsNullOrWhiteSpace(Challage_daten))
                            {
                                Textblock_challange.Text = aufgabe;
                            }
                            else
                            {
                                string challangenow = KICallenges(punkte);
                                Textblock_challange.Text = challangenow;
                                using (StreamWriter sw = new StreamWriter("Aufgabe.json"))
                                {
                                    sw.WriteLine(challangenow);
                                }

                            }
                        }
                        else
                        {
                            string challangenow = KICallenges(punkte);
                            Textblock_challange.Text = challangenow;
                            using (StreamWriter sw = new StreamWriter("Aufgabe.json"))
                            {
                                sw.WriteLine(challangenow);
                            }
                        }
                    }
                    else
                    {
                        string challangenow = KICallenges(punkte);
                        Textblock_challange.Text = challangenow;
                        using (StreamWriter sw = new StreamWriter("Aufgabe.json"))
                        {
                            sw.WriteLine(challangenow);
                        }
                    }


                }
                else
                {
                    Textblock_challange.Text = "Error 104: Kontaktiere bitte den suppport";
                    Log.Error("Die Challanges file ist leer");
                }
            }
            else
            {
                Textblock_challange.Text = "Error 104: Kontaktiere bitte den suppport";
                            Log.Error("Die Challanges file existiert nicht mehr");
            }
            







            // Volbildschirm 
            this.WindowState = WindowState.Maximized;
            this.WindowStyle = WindowStyle.None;
            this.ResizeMode = ResizeMode.NoResize;

        }

        private void Button_Fitness(object sender, RoutedEventArgs e)
        {
            
            WindowSelect window = new WindowSelect();
            window.Show();
            Log.Verbose("in Fitness drinen");
        }

        private void Button_Ernaehrung(object sender, RoutedEventArgs e)
        {
            
            Ernaerungselect ernaerungselect = new Ernaerungselect();
            ernaerungselect.Show();
            Log.Verbose("in Ernährung drinen");
        }

 

        private void Button_Quit(object sender, RoutedEventArgs e)
        {
            Log.Information("App wurde beendet");
            Application.Current.Shutdown(); // ALLE Fenster schließen sich!!!!!
        }

        private void Button_Saved(object sender, RoutedEventArgs e)
        {
            
            Gespeichertselect gespeichertselect = new Gespeichertselect();
            gespeichertselect.Show();
            Log.Verbose("in Gespeicherte drinen");
        }


        private void Button_Organisation(object sender, RoutedEventArgs e)
        {
            // Kalender öffnen
            CalendarWindow kalender = new CalendarWindow();
            kalender.ShowDialog();
            Log.Verbose("in Organisation drinen drinen");

            // Terminliste aktualisieren
            terminListeControl.Aktualisieren();

            // RadioButton ent-checken, damit erneuter Klick möglich ist
            if (sender is RadioButton rb)
            {
                rb.IsChecked = false;
            }
        }

        string speicherPfad = "termine.json"; // Pfad indem meine Termine gespeichert werden 

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GlobalSchedule.SharedSchedule.LoadFromFile(speicherPfad); // Lädt alle Termine aus der Datei und speichert sie in der globalen Terminliste 
            terminListeControl.Aktualisieren(); // Aktulisiert Anzeige in der TErminliste im FEnster 

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            GlobalSchedule.SharedSchedule.SaveToFile(speicherPfad);
        }

        private string KICallenges(int Punkte)
        {
            Random rnd = new Random();
            int zahl = rnd.Next(1, 4);


            string path = "Challengesnes.json"; // Datei im Ausgabeverzeichnis (Debug-Ordner)
            string jsonString = File.ReadAllText(path);

            

            TrainingsData data = JsonSerializer.Deserialize<TrainingsData>(jsonString);


            string[] arrayReps = data.repetitive.ToArray();
            string[] arrayShort = data.shortDuration.ToArray();
            string[] arrayLong = data.longDuration.ToArray();

            if (zahl == 1)
            {
                int länge = arrayReps.Length;

                zahl = rnd.Next(0,länge);

                string aufgabe = arrayReps[zahl];

                int wiederholungen = punkte / 7000 +10;

                string finale = $"{wiederholungen} {aufgabe}";

                return finale;
            }

            else if (zahl == 3)
            {
                int länge = arrayLong.Length;

                zahl = rnd.Next(0, länge);

                string aufgabe = arrayLong[zahl];

                int wiederholungen = punkte / 7000 +10;

                string finale = $"{wiederholungen} {aufgabe}";
                return finale;
            }
            else
            {
                int länge = arrayShort.Length;

                zahl = rnd.Next(0, länge);

                string aufgabe = arrayShort[zahl];

                int wiederholungen = (punkte / 7000)*10 + 30;
                string finale = "";

                if (wiederholungen >= 60)
                {
                    double wiederholungeninmin = wiederholungen / 60;
                    double kommateil = zahl - Math.Truncate(wiederholungeninmin);
                    kommateil = kommateil * 60;
                    finale = $"{Math.Truncate(wiederholungeninmin)}:{kommateil} min {aufgabe}";
                }
                else
                {
                    finale = $"{wiederholungen} sek {aufgabe}";
                }

                return finale;
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (done == false)
            {
                streak = streak + 1;
                
                punkte = punkte + (streak / 100+1)*1000;
                Label_streak.Content = $"STREAK: {streak}";
                Label_streak.Foreground = Brushes.White;
                Border_challange.Background = Brushes.Gray;
                using (StreamWriter sw = new StreamWriter("Daten.json"))
                done = true;
                using (StreamWriter sw = new StreamWriter("Daten.json"))
                {
                    sw.WriteLine($"{streak}#{punkte}#{heute}#{done}");
                }
                Label_rank.Foreground = Brushes.White;
            }

        }

        private void Button_achievement_Click(object sender, RoutedEventArgs e)
        {
            Achievements achievements = new Achievements();
            achievements.Show();
        }
    }
}
