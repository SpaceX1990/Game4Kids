using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Game4Kids {
    public partial class MainWindow : Window {
        private Button buttonWithSymbol;
        private List<Button> buttonList = new List<Button>();
        private readonly Random rand = new Random();
        private const string Symbol = "★";

        public MainWindow() {
            InitializeComponent();

            buttonList.Add(FirstButton);
            buttonList.Add(SecondButton);
            buttonList.Add(ThirdButton);
            buttonList.Add(FourthButton);

            AssignRandomSymbol(null);
        }

        private void AssignRandomSymbol(Button excludeButton) {
            foreach (Button button in buttonList) {
                button.Content = string.Empty;
                button.FontSize = 48;
            }

            Button newButtonWithSymbol;
            do {
                int randomIndex = rand.Next(buttonList.Count);
                newButtonWithSymbol = buttonList[randomIndex];
            } while (newButtonWithSymbol == excludeButton);

            buttonWithSymbol = newButtonWithSymbol;
            buttonWithSymbol.Content = Symbol;
        }

        private Color GetRandomColor() {
            return Color.FromRgb((byte)rand.Next(256), (byte)rand.Next(256), (byte)rand.Next(256));
        }

        private void Grid_ButtonClick(object sender, RoutedEventArgs e) {
            if (e.OriginalSource is Button clickedButton) {
                clickedButton.Background = new SolidColorBrush(GetRandomColor());

                PlayBeepSound();

                if (clickedButton.Content == Symbol) {
                    AssignRandomSymbol(clickedButton);
                }
            }
        }

        private void PlayBeepSound() {
            Task.Run(() => Console.Beep(1000, 500));
        }
    }
}
