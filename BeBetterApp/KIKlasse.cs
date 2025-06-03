using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;
using OpenAI;
using OpenAI.Chat;

namespace BeBetterApp
{
    class KIKlasse()
    {

        public void Ki(TextBox ausgabe, string aufforderung, string Speicherort)
        {
            
            ausgabe.Text = "Ihr Trainigsplan wird erstellt bitte warten!"; // Dass der Nutzer weiß dass es geladen wird

            ChatClient client = new(model: "gpt-4o", apiKey: Properties.Settings.Default.OPENAI_KEY); 
            // Hier ist mein API Key und welche version von Chat gpt es benutzen soll

            ChatCompletion completion = client.CompleteChat(aufforderung); 
            // Hier wird Chatgpt eine Frage gestellt

            string save = completion.Content[0].Text; // Hier wird die antwort abgespeichert

            using (StreamWriter sw = new StreamWriter(Speicherort))
            {
                sw.WriteLine(save); //Hier wird die Datei abgespeichert dass man auch den gelichen Trainungsplan benutzt

            }

            int zeilenAnzahl = File.ReadLines(Speicherort).Count(); // Anzahl an zeilen

            string inhalt = File.ReadAllText(Speicherort); // File wird gelesen
            ausgabe.Text = inhalt; // File wird ausgegeben


        }

    }




}
