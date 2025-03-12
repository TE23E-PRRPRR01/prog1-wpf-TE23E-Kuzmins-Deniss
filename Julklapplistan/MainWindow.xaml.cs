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

        stpInmatning.IsEnabled= false;
        stpListan.IsEnabled= false;

        lsbJulklappar.ItemsSource = listaJulklappar;

    }

    private void KlickAnge(object sender, RoutedEventArgs e)
    {
        string antal = txbAntal.Text;

     //kontroll
     if (antal == "")
     {
        txbStatus.Text = "Vg ange ett antal";
     }
     else
     {
        bool lyckas = int.TryParse(antal, out int talet);
        if (lyckas)
        {
            maxJulklappar = talet;
            txbStatus.Text = $"Max julklappar är {maxJulklappar}";


            //låser upp
            stpMax.IsEnabled= false;
        stpInmatning.IsEnabled= true;
        stpListan.IsEnabled= true;
        }
        else
        {
            txbStatus.Text = "Vg ange ett antal";
        }

     }

    }
    private void KlickLäggtill(object sender, RoutedEventArgs e)
    {
        //läs av text rutorna
        string julklapp = txbJulklapp.Text;
        string mottagare = txbMottagare.Text;

        listaJulklappar.Add($"{julklapp} till {mottagare}");
        lsbjulklappar.Items.Refresh();

    }
    private void KlickBytut(object sender, RoutedEventArgs e)
    {
        
    }
}