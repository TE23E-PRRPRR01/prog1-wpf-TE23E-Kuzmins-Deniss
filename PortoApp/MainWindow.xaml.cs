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

namespace PortoApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    private void RäknaClick(object sender, RoutedEventArgs e)
    {
        // Konvertera texten i textrutan till ett heltal
        if (int.TryParse(txbVikt.Text, out int vikt))
        {
            string resultat = BeraknaPorto(vikt);
            lblResultat.Content = resultat;
        }
        else
        {
            lblResultat.Content = "Ogiltig vikt.";
        }
    }
    private string BeraknaPorto(int vikt)
{
    if (vikt <= 50)
    {
        return "Pris: 22 kr, Antal frimärken: 1";
    }
    else if (vikt <= 100)
    {
        return "Pris: 44 kr, Antal frimärken: 2";
    }
    else if (vikt <= 250)
    {
        return "Pris: 66 kr, Antal frimärken: 3";
    }
    else if (vikt <= 500)
    {
        return "Pris: 88 kr, Antal frimärken: 4";
    }
    else if (vikt <= 1000)
    {
        return "Pris: 132 kr, Antal frimärken: 6";
    }
    else if (vikt <= 2000)
    {
        return "Pris: 154 kr, Antal frimärken: 7";
    }
    else
    {
        return "Vikten överskrider maxgränsen för porto.";
    }
}
}