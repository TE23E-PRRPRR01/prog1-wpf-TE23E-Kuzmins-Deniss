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

namespace SlumpaApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    private void KlickSlumpa(object sender, RoutedEventArgs e)
    {
        if(int.TryParse(MaxVärdettxb.Text, out int MaxVärde) && MaxVärde > 0)
        {
                int slumptal = new Random().Next(1, MaxVärde+1); // Skapar ett slumpmässigt tal
        Resultattxb.Text = slumptal.ToString();   // Uppdaterar TextBox med rätt namn

        
        } else{
            Resultattxb.Text ="False!";
        }
    }
}