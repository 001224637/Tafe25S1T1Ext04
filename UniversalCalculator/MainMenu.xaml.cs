using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;

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
		// triggers the math calculator
        private void MathCalculator_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
		// triggers the mortgage calculator
		private void MortgageCalculator_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(MortgageCalculator.MortgageCalculatorPage));
		}
		// trigers the currency converter
		private void CurrencyConverter_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(Calculator.CurrencyConverterPage));
		}
		// triggers the exit
		private void ExitButton_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Exit();
		}

		private void PageLoaded(object sender, RoutedEventArgs e)
        {
            // Initialization logic here (if needed)
        }
		
		// Here we added a message that Trip calculator C# code will be developed later!
		
		private void TripCalculator_Click(object sender, RoutedEventArgs e)
		{
			// Trip calculator C# code will be developed later
		}
    }
}

