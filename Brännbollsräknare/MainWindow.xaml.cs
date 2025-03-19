using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Brännbollsräknare
{
    public partial class MainWindow : Window
    {
        int poangInne = 0;
        int poangUte = 0;
        List<string> historik = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void UppdateraHistorik(string händelse)
        {
            historik.Add(händelse);
            if (historik.Count > 10)
            {
                historik.RemoveAt(0);
            }
            lstHistorik.ItemsSource = null;
            lstHistorik.ItemsSource = historik;
        }

        private void KlickFrivarv(object sender, RoutedEventArgs e)
        {
            poangInne += 5;
            txbLagInne.Text = poangInne.ToString();
            UppdateraHistorik("Lag inne (+5 poäng)");
        }

        private void KlickBränning(object sender, RoutedEventArgs e)
        {
            poangUte += 2;
            txbLagUtte.Text = poangUte.ToString();
            UppdateraHistorik("Lag utte (+2 poäng)");
        }

        private void KlickLyra(object sender, RoutedEventArgs e)
        {
            poangUte += 3;
            txbLagUtte.Text = poangUte.ToString();
            UppdateraHistorik("Lag utte (+3 poäng)");
        }

        private void KlickVarv(object sender, RoutedEventArgs e)
        {
            poangInne += 1;
            txbLagInne.Text = poangInne.ToString();
            UppdateraHistorik("Lag inne (+1 poäng)");
        }
    }
}