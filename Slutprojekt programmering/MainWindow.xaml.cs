using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace ChessAnalyzer
{
    public partial class MainWindow : Window
    {
        private List<string> moves = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddMove_Click(object sender, RoutedEventArgs e)
        {
            string move = MoveInput.Text.Trim();
            if (!string.IsNullOrEmpty(move))
            {
                moves.Add(move);
                UpdateMoveList();
                MoveInput.Clear();
            }
        }

        private void Analyze_Click(object sender, RoutedEventArgs e)
        {
            // Här kommer du senare anropa Stockfish med draglistan
            string fakeResult = $"Analys för: {string.Join(" ", moves)}\n(Fake-output än så länge)";
            OutputText.Text = fakeResult;
        }

        private void LoadPGN_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "PGN-filer (*.pgn)|*.pgn"
            };

            if (dialog.ShowDialog() == true)
            {
                string content = File.ReadAllText(dialog.FileName);
                // För nu bara visa filens innehåll
                OutputText.Text = content;
            }
        }

        private void UpdateMoveList()
        {
            MoveList.Text = "Drag: " + string.Join(", ", moves);
        }
    }
}
