using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Game4Kids {
    public partial class MainWindow : Window {
        private Button buttonWithCross;
        private List<Button> buttonList = new List<Button>();
        private readonly Random rand = new Random();

        public MainWindow() {
            InitializeComponent();

            buttonList.Add(FirstButton);
            buttonList.Add(SecondButton);
            buttonList.Add(ThirdButton);
            buttonList.Add(FourthButton);

            AssignRandomCross(null);
        }

        private void AssignRandomCross(Button excludeButton) {
            foreach (Button button in buttonList) {
                button.Content = string.Empty;
                button.FontSize = 48;
            }

            Button newButtonWithCross;
            do {
                int randomIndex = rand.Next(buttonList.Count);
                newButtonWithCross = buttonList[randomIndex];
            } while (newButtonWithCross == excludeButton);

            buttonWithCross = newButtonWithCross;
            buttonWithCross.Content = "X";
        }

        private Color GetRandomColor() {
            return Color.FromRgb((byte)rand.Next(256), (byte)rand.Next(256), (byte)rand.Next(256));
        }

        private void Grid_ButtonClick(object sender, RoutedEventArgs e) {
            if (e.OriginalSource is Button clickedButton) {
                clickedButton.Background = new SolidColorBrush(GetRandomColor());

                PlayBeepSound();

                if (clickedButton.Content.ToString() == "X") {
                    AssignRandomCross(clickedButton);
                }
            }
        }

        private void PlayBeepSound() {
            Task.Run(() => Console.Beep(1000, 500));
        }
    }
}
