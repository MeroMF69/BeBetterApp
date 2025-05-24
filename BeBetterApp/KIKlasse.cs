using System;
using System.Data;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Controls;
using OpenAI;
using OpenAI.Chat;

namespace BeBetterApp
{
    class KIKlasse()
    {
        public void Ki(TextBox ausgabe)
        {
            ChatClient client = new(model: "gpt-4o", apiKey: "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");

            ChatCompletion completion = client.CompleteChat("Gib mir ein Trainungsplan für eine woche. Gib nur den Plan nichts dazu schreiben oder so ** hinzufügen ein komplett normaler Text. Danke!");

            ausgabe.Text = completion.Content[0].Text;
        }

    }




}
