using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CurrencyConverterPage : Page
    {
		private Dictionary<string, Dictionary<string, double>> exchangeRates;
		public CurrencyConverterPage()
        {
            this.InitializeComponent();
			LoadExchangeRates();
		}
		private void LoadExchangeRates()
		{
			exchangeRates = new Dictionary<string, Dictionary<string, double>>
			{
				{ "USD", new Dictionary<string, double> { { "EUR", 0.85189982 }, { "GBP", 0.72872436 }, { "INR", 74.257327 } } },
				{ "EUR", new Dictionary<string, double> { { "USD", 1.1739732 }, { "GBP", 0.8556672 }, { "INR", 87.00755 } } },
				{ "GBP", new Dictionary<string, double> { { "USD", 1.371907 }, { "EUR", 1.1686692 }, { "INR", 101.68635 } } },
				{ "INR", new Dictionary<string, double> { { "USD", 0.011492628 }, { "EUR", 0.013492774 }, { "GBP", 0.0098339397 } } }
			};
		}

		private void ConvertButton_Click(object sender, RoutedEventArgs e)
		{
			if (!double.TryParse(AmountTextBox.Text, out double amount) || amount <= 0)
			{
				ConversionResultText.Text = "Invalid amount. Please enter a valid number.";
				return;
			}

			string fromCurrency = GetSelectedCurrency(FromCurrencyComboBox);
			string toCurrency = GetSelectedCurrency(ToCurrencyComboBox);

			if (fromCurrency == toCurrency)
			{
				ConversionResultText.Text = $"Same currency selected. No conversion needed.";
				return;
			}

			double convertedAmount = CalculateConversion(amount, fromCurrency, toCurrency);

			if (convertedAmount >= 0)
			{
				double conversionRate = exchangeRates[fromCurrency][toCurrency];
				ConversionResultText.Text = $"{amount} {fromCurrency} = {convertedAmount:F6} {toCurrency}\n" +
											$"1 {fromCurrency} = {conversionRate:F6} {toCurrency}";
			}
			else
			{
				ConversionResultText.Text = "Conversion rate not available.";
			}
		}

		private double CalculateConversion(double amount, string fromCurrency, string toCurrency)
		{
			if (exchangeRates.ContainsKey(fromCurrency) && exchangeRates[fromCurrency].ContainsKey(toCurrency))
			{
				double conversionRate = exchangeRates[fromCurrency][toCurrency];
				return amount * conversionRate;
			}
			return -1; // Error case
		}

		private string GetSelectedCurrency(ComboBox comboBox)
		{
			ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
			return selectedItem.Content.ToString().Split('-')[0].Trim();
		}

		private void ExitButton_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Exit();
		}
	}
}
