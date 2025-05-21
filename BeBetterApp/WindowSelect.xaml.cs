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
        private static readonly string apiKey = "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";
        private static readonly string endpoint = "https://api.openai.com/v1/chat/completions";

        string Texttest = "shallo";
        public WindowSelect()
        {

            InitializeComponent();
            Textblock_Text.Text = Texttest;
 
        }


        private async void Button_Click_Erstell_ein_Fitnessplan(object sender, RoutedEventArgs e)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

            var requestBody = new
            {
                model = "gpt-3.5-turbo", // GPT-4 gegen GPT-3.5 ersetzt
                messages = new[]
                {
            new { role = "user", content = "Erstelle mir einen Fitnessplan bitte" }
        }
            };

            var json = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, Encoding.UTF8 , "application/json");

            try
            {
                var response = await client.PostAsync(endpoint, content);
                var responseString = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    Textblock_Text.Text = $"Fehler: {response.StatusCode} - {response.ReasonPhrase}\n{responseString}";
                    return;
                }

                using JsonDocument doc = JsonDocument.Parse(responseString);

                if (doc.RootElement.TryGetProperty("choices", out JsonElement choices))
                {
                    string reply = choices[0]
                        .GetProperty("message")
                        .GetProperty("content")
                        .GetString();

                    if (!string.IsNullOrWhiteSpace(reply))
                    {
                        // Speicherort: Desktop
                        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Fitnessplan.csv");

                        File.WriteAllText(path, reply);
                        Textblock_Text.Text = $"Fitnessplan gespeichert auf dem Desktop:\n{path}";
                    }
                    else
                    {
                        Textblock_Text.Text = "Antwort ist leer – nichts gespeichert.";
                    }
                }
                else if (doc.RootElement.TryGetProperty("error", out JsonElement error))
                {
                    string errorMessage = error.GetProperty("message").GetString();
                    Textblock_Text.Text = $"API-Fehler: {errorMessage}";
                }
                else
                {
                    Textblock_Text.Text = "Unbekannte Antwortstruktur:\n" + responseString;
                }
            }
            catch (Exception ex)
            {
                Textblock_Text.Text = "Fehler beim Speichern:\n" + ex.ToString();
            }
        }


    }
}
