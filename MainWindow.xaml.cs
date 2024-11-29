using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Game4Kids {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            AssignRandomCross();
        }

        private Button buttonWithCross;
        private List<Button> buttonList = new List<Button>();

        private void AssignRandomCross() {
            buttonList.Add(FirstButton);
            buttonList.Add(SecondButton);
            buttonList.Add(ThirdButton);
            buttonList.Add(FourthButton);

            foreach (Button button in buttonList) {
                button.Content = string.Empty;
            }

            Random rand = new Random();
            int randomIndex = rand.Next(buttonList.Count);
            buttonWithCross = buttonList[randomIndex];
            buttonWithCross.Content = "X";
        }

        private Color GetRandomColor() {
            Random rand = new Random();
            return Color.FromRgb((byte)rand.Next(256), (byte)rand.Next(256), (byte)rand.Next(256));
        }

        private void Grid_ButtonClick(object sender, RoutedEventArgs e) {
            if (e.OriginalSource is Button clickedButton) {
                clickedButton.Background = new SolidColorBrush(GetRandomColor());
                e.Handled = true;

                PlayBeepSound();
                if (clickedButton.Content.ToString() == "X") {
                    AssignRandomCross();
                }
            }
        }
        private void PlayBeepSound() {
            Console.Beep(1000, 500);
        }
    }
}
