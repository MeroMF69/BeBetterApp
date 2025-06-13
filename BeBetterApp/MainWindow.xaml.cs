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



            if (File.Exists("Daten.json"))
            {
                string daten = File.ReadAllText("Daten.json");
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


            if (File.Exists("Challenges.json"))
            {
                string Challage_daten = File.ReadLines("Challenges.json").First();

                if (!string.IsNullOrWhiteSpace(Challage_daten))
                {


                    if (Tag == heute)
                    {
                        Textblock_challange.Text = Challage_daten;
                    }
                    else
                    {
                        string challangenow = KICallenges(punkte);
                        Textblock_challange.Text = challangenow;
                        using (StreamWriter sw = new StreamWriter("Challenges.json"))
                        {
                            sw.WriteLine(challangenow);
                        }
                    }


                }
                else
                {
                    string challangenow = KICallenges(punkte);
                    Textblock_challange.Text = challangenow;
                    using (StreamWriter sw = new StreamWriter("Challenges.json"))
                    {
                        sw.WriteLine(challangenow);
                    }
                }
            }
            else
            {
                string challangenow = KICallenges(punkte);
                Textblock_challange.Text = challangenow;
                using (StreamWriter sw = new StreamWriter("Challenges.json"))
                {
                    sw.WriteLine(challangenow);
                }
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
            ChatClient client = new(model: "gpt-3.5-turbo", apiKey: Properties.Settings.Default.OPENAI_KEY);

            ChatCompletion completion = client.CompleteChat($"Gib mir eine Fittnes-Challange kann yoga,push up usw sein, rechne mit Punkten:{Punkte} aus wieviel man braucht nimmm die Punkte und dividiere sie um 7000 die machst du mal bei sachen wie plans machst dann eif 30 sek dazu und bei joggen 2 min dazu ist dir überlassen gib nur aus: Mach (die anzahl oder die Zeit) (lang) (die Challange) schreib nichts dazu nur die sache die ich dir angegeben habe.");

            string save = completion.Content[0].Text; 

            return save;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (done == false)
            {
                streak = streak + 1;
                punkte = punkte + (streak / 100+1)*1000;
                Label_streak.Content = $"STREAK: {streak}";
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
