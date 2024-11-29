using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Game4Kids {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private Color GetRandomColor() {
            Random rand = new Random();
            return Color.FromRgb((byte)rand.Next(256), (byte)rand.Next(256), (byte)rand.Next(256));
        }

        private void Grid_ButtonClick(object sender, RoutedEventArgs e) {
            if (e.OriginalSource is Button clickedButton) {
                clickedButton.Background = new SolidColorBrush(GetRandomColor());
                e.Handled = true;
            }
        }
    }
}
