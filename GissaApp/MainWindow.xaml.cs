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

namespace GissaApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    //Slumpa fram ett tal 1-1000
    int slumptal = Random.Shared.Next(1, 1001);
    List<int> listaGissningar = [];

    private void KlickGissa(object sender, RoutedEventArgs e)
    {
        //Läss av riúta gissning
        string input = tbxGissning.Text;
        //Konvertera till ett heltal
        bool lyckades = int.TryParse(input, out int gissning);

        //Lyckades konvertera?
        if (lyckades)
        {
            //Lagra i lista
            listaGissningar.Add(gissning);


            //Jämföra gissning med slumptal
            if (gissning == slumptal)
            {
                tbxResultat.Text = $"Din gissning var rätt ({gissning})!";
            }
            else if (gissning < slumptal)
            {
                tbxResultat.Text = $"Din gissning ({gissning}) var för låg!";
            }
            else if (gissning > slumptal)
            {
                tbxResultat.Text = $"Din gissning ({gissning}) var för hög!";
            }
        }
        else
        {
            tbxResultat.Text = "Ogiltig inmattning!";
            return;
        }

    }
    private void KlickVisaFacit(object sender, RoutedEventArgs e)
    {
        tbxResultat.Text = $"Rätt svar är {slumptal}";
    }
    private void KlickVisaGissningar(object sender, RoutedEventArgs e)
    {
        //Skriv ut alla gissningar som finns i lista
        tbxGissningar.Text = ""; //Rensa rutan innan vi skriver ut nya gissningar
        //I stora rutan txbGissningar
        foreach (var tal in listaGissningar)
        {
            tbxGissningar.Text += $"{tal}\n"; // Lägg till varje gissning på en ny rad
        }

    }
    private void KlickSpelaIgen(object sender, RoutedEventArgs e)
    {
        slumptal = Random.Shared.Next(1, 1001); //Nytt slumptal

        listaGissningar = [];
        //Ränsa gränssnittet
        tbxGissningar.Text = ""; //Rensa rutan innan vi skriver ut nya gissningar
        tbxResultat.Text = ""; //Rensa rutan innan vi skriver ut nya gissningar
        tbxGissning.Text = ""; //Rensa rutan innan vi skriver ut nya gissningar
    }
}