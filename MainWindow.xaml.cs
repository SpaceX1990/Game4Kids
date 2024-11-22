using System.Windows;
using System.Windows.Media;

namespace Game4Kids {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private readonly Dictionary<int, Color> dictionary = new Dictionary<int, Color> {
            { 1, Colors.Red },
            { 2, Colors.DarkGoldenrod },
            { 3, Colors.LawnGreen },
            { 4, Colors.LightBlue },
            { 5, Colors.Salmon },
            { 6, Colors.LightPink },
            { 7, Colors.YellowGreen },
            { 8, Colors.Firebrick },
            { 9, Colors.Crimson },
            { 10, Colors.Chocolate },
            { 11, Colors.BlanchedAlmond },
            { 12, Colors.Honeydew },
            { 13, Colors.Tomato },
            { 14, Colors.MistyRose },
            { 15, Colors.Peru }
        };

        public MainWindow() {
            InitializeComponent();
            RandomizeButtonsColor();
        }

        private void RandomizeButtonsColor() {
            Color randomColor = GetRandomColor();

            FirstButton.Background = new SolidColorBrush(GetRandomColor());
            SecondButton.Background = new SolidColorBrush(GetRandomColor());
            ThirdButton.Background = new SolidColorBrush(GetRandomColor());
            FourthButton.Background = new SolidColorBrush(GetRandomColor());
        }

        private Color GetRandomColor() {
            Random random = new Random();
            int randomKey = random.Next(1, dictionary.Count + 1);
            Color randomColor = dictionary[randomKey];
            return randomColor;
        }
    }
}
