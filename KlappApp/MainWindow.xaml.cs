using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Converters;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KlappApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    int maxJulklappar = 0;
    List<string> listaJulklappar = [];
    public MainWindow()
    {
        InitializeComponent();

    }
    private void KlickAnge(object sender, RoutedEventArgs e)
    {
        //Läs av rutan
        string antal = txbAntal.Text;

        //Försök enkel kontroll
        if (antal == "")
        {
            txbStatus.Text = "Vg ange ett heltal";
        }
        else
        {
            bool lyckas = int.TryParse(antal, out int talet);
            if (lyckas)
            {
                maxJulklappar = talet;
                txbStatus.Text = $"Max julklappar är {maxJulklappar}";



                //Koppla list till listbox
                lsbJulklappar.ItemSource = listaJulklappar;

                //Läs gränsnitt
                stpMax.IsEnabled = false;
                stpInmatning.IsEnabled = false;
                stpListan.IsEnabled = true;
            }
            else
            {
                txbStatus.Text = "Vg ange ett heltal";
            }
        }
    }
    private void KlickLäggTill(object sender, RoutedEventArgs e)
    {
// Läs av text ruuttorna
string julklapp = txbJulklapp.Text;
string mottagare = txbMottagare.Text;
lsbJulklappar.Items.Refresh();

listaJulklappar.Add($"{julklapp} till {mottagare}");
    }
    private void KlickBytUt(object sender, RoutedEventArgs e)
    {

    }
}