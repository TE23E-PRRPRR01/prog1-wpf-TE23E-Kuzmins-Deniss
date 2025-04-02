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
using System.Net.Http.Json;
using System.Net.Http;

namespace AiApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    // Redskap för att kommunicera över http
    HttpClient klient = new HttpClient();
    // Adresse till Ollama-AI servern
    string url = "http://10.151.168.5:11434/api/generate";

    public MainWindow()
    {
        InitializeComponent();
    }

    private void btnSkicka_Click(object sender, RoutedEventArgs e)
    {
        // Läsa av prompttexten i rutan
        string prompt = txbPrompt.Text;

        // Skapa ett JSON-objekt
        object data = new
        {
            model = "phi4:latest",
            prompt = prompt,
            max_tokens = 500
        };

        // Skicka till Ollama-AI servern
        SkickaTillOllama(data);
    }

    public void SkickaTillOllama(object data)
    {
        try
        {
            // Skicka data till servern
            HttpResponseMessage svar = klient.PostAsJsonAsync(url, data).Result;

            // Kontrollera att "requesten" gick bra
            svar.EnsureSuccessStatusCode();

            // Läs innehållet i svaret
            string råText = svar.Content.ReadAsStringAsync().Result;

            // Dela upp råtexten i ra
            string[] rader = råText.Split("\n");

            //Gå igenom alla rader
            foreach (string rad in rader)
            {
                // Finns response i raden?
                if (rad.Contains("response"))
                {
                    txbSvar.Text += PlockaUtToken(rad);
                }
            }

        }
        catch (HttpRequestException e)
        {
            // Skriv ut felmeddelande
            txbSvar.Text = $"Fel: {e.Message}";
        }
    }

    public string PlockaUtToken(string rad)
    {
        int start = rad.IndexOf("response") + 11;
        int slut = rad.IndexOf("\"", start);

        //Plocka ut token
        return rad.Substring(start, slut -start);
    }
}