using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
// added mainmenu
namespace Calculator
{
    public sealed partial class MainMenu : Page
    {
        // Singleton instance if needed
        public static MainMenu Instance { get; private set; }
        public MainMenu()
        {
            InitializeComponent();
            Instance = this;
        }

        private void MathCalculator_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            // Initialization logic here (if needed)
        }

    }
}

