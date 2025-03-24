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

namespace AritmitikApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnBerakna_Click(object sender, RoutedEventArgs e)
        {
            // Rensa input från mellanslag
            string tal1Text = txtTal1.Text.Trim();
            string tal2Text = txtTal2.Text.Trim();
            string operatorText = txtOperator.Text.Trim();

            // Validera tal 1
            if (!double.TryParse(tal1Text, out double tal1))
            {
                lblResultat.Content = "Fel: Tal 1 är ogiltigt!";
                lblResultat.Foreground = System.Windows.Media.Brushes.Red;
                return;
            }

            // Validera tal 2
            if (!double.TryParse(tal2Text, out double tal2))
            {
                lblResultat.Content = "Fel: Tal 2 är ogiltigt!";
                lblResultat.Foreground = System.Windows.Media.Brushes.Red;
                return;
            }

            // Validera operator
            double resultat;
            switch (operatorText)
            {
                case "+":
                    resultat = tal1 + tal2;
                    break;
                case "-":
                    resultat = tal1 - tal2;
                    break;
                case "*":
                    resultat = tal1 * tal2;
                    break;
                case "/":
                    if (tal2 == 0)
                    {
                        lblResultat.Content = "Fel: Division med noll!";
                        lblResultat.Foreground = System.Windows.Media.Brushes.Red;
                        return;
                    }
                    resultat = tal1 / tal2;
                    break;
                default:
                    lblResultat.Content = "Fel: Ogiltig operator!";
                    lblResultat.Foreground = System.Windows.Media.Brushes.Red;
                    return;
            }

            // Visa resultat
            lblResultat.Content = $"Resultat: {resultat}";
            lblResultat.Foreground = System.Windows.Media.Brushes.Green;
        }
    }
}