using System.Windows;

namespace MelloApp
{
    public partial class MainWindow : Window
    {
        // Variabler för att räkna röster
        private int antalRöd = 0;
        private int antalBlå = 0;
        private int antalGrön = 0;
        private int antalYellow = 0;
        private int antalPurple = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        // Metod som anropas när en röstknapp klickas
        private void KlickRösta(object sender, RoutedEventArgs e)
        {
            // Kollar vilken knapp som tryckts och ökar motsvarande röstantal
            if (sender == röd)
            {
                antalRöd++;
            }
            else if (sender == blå)
            {
                antalBlå++;
            }
            else if (sender == grön)
            {
                antalGrön++;
            }
            else if (sender == gul)
            {
                antalYellow++;
            }
            else if (sender == lila)
            {
                antalPurple++;
            }

            // Uppdaterar resultatet i textfältet
            txbResultat.Text = $"Röd: {antalRöd}, Blå: {antalBlå}, Grön: {antalGrön}, Gul: {antalYellow}, Lila: {antalPurple}";
        }

        // Återställ röster
        private void KlickReset(object sender, RoutedEventArgs e)
        {
            antalRöd = antalBlå = antalGrön = antalYellow = antalPurple = 0;
            txbResultat.Text = "Röd: 0, Blå: 0, Grön: 0, Gul: 0, Lila: 0";
        }
    }
}
