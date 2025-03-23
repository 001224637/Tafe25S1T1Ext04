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
// modified on 19/03/2025
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238
namespace MortgageCalculator
{
    public sealed partial class MortgageCalculatorPage : Page
    {
        public MortgageCalculatorPage()
        {
            this.InitializeComponent(); // Ensure the XAML elements are recognized
        }

        private async void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get user input
                double principal = double.Parse(PrincipalAmountTextBox.Text);
                int years = int.Parse(YearsTextBox.Text);
                int months = int.Parse(MonthsTextBox.Text);
                double annualInterestRate = double.Parse(InterestRateTextBox.Text) / 100; // Convert to decimal

                // Calculate the monthly interest rate
                double monthlyInterestRate = annualInterestRate / 12;
                MonthlyInterestRateTextBox.Text = monthlyInterestRate.ToString("P5");

                // Calculate the total number of payments
                int totalMonths = (years * 12) + months;

                // Compute the monthly repayment using the formula
                double monthlyRepayment = CalculateMonthlyRepayment(principal, monthlyInterestRate, totalMonths);
                MonthlyRepaymentTextBox.Text = monthlyRepayment.ToString("C2");
            }
            catch (Exception ex)
            {
                await ShowErrorDialog("Error: " + ex.Message);
            }
        }

        private double CalculateMonthlyRepayment(double P, double i, int n)
        {
            if (i == 0)
                return P / n; // A Simple division if interest rate is 0

            double numerator = i * Math.Pow(1 + i, n);
            double denominator = Math.Pow(1 + i, n) - 1;
            return P * (numerator / denominator);
        }

		private void ExitButton_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(Calculator.MainMenu));
		}



		private async System.Threading.Tasks.Task ShowErrorDialog(string message)
        {
            ContentDialog errorDialog = new ContentDialog()
            {
                Title = "Input Error",
                Content = message,
                CloseButtonText = "OK"
            };

            await errorDialog.ShowAsync();
        }
    }
}
