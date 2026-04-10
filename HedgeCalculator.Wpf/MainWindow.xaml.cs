using HedgeCalculator.Domain.Models;
using HedgeCalculator.Domain.Services;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace HedgeCalculator.Wpf
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ClearResultTexts();
        }

        private void BtnCalculateMinimumSecondaryOdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                decimal mainOdd = ParseDecimal(txtMainOdd.Text);

                decimal minimumSecondaryOdd =
                    ProtectionCalculatorService.CalculateMinimumSecondaryOddForMainProfit(mainOdd);

                txtSecondaryOdd.Text = minimumSecondaryOdd.ToString("N2", CultureInfo.InvariantCulture);

                txtMinimumSecondaryOdd.Text =
                    $"Minimum secondary odd for main profit: {minimumSecondaryOdd:N2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Calculation error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }

        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                decimal totalBankroll = ParseDecimal(txtTotalBankroll.Text);
                decimal mainOdd = ParseDecimal(txtMainOdd.Text);
                decimal secondaryOdd = ParseDecimal(txtSecondaryOdd.Text);

                ProtectionCalculationResult result =
                    ProtectionCalculatorService.Calculate(totalBankroll, mainOdd, secondaryOdd);

                txtMinimumSecondaryOdd.Text =
                    $"Minimum secondary odd for main profit: {result.MinimumSecondaryOddForMainProfit:N2}";

                txtMainStake.Text =
                    $"Main stake: {result.MainStake:N2}";

                txtSecondaryStake.Text =
                    $"Secondary stake: {result.SecondaryStake:N2}";

                txtReturnIfMainWins.Text =
                    $"Return if main wins: {result.ReturnIfMainWins:N2}";

                txtReturnIfSecondaryWins.Text =
                    $"Return if secondary wins: {result.ReturnIfSecondaryWins:N2}";

                txtProfitIfMainWins.Text =
                    $"Profit if main wins: {result.ProfitIfMainWins:N2}";

                txtProfitIfSecondaryWins.Text =
                    $"Profit if secondary wins: {result.ProfitIfSecondaryWins:N2}";

                txtCoversEntireBankroll.Text =
                    $"Secondary covers entire bankroll: {(result.SecondaryCoversEntireBankroll ? "Yes" : "No")}";

                txtProfitIfMainWins.Foreground =
                    result.ProfitIfMainWins >= 0 ? Brushes.Green : Brushes.Red;

                txtProfitIfSecondaryWins.Foreground =
                    result.ProfitIfSecondaryWins >= 0 ? Brushes.Green : Brushes.Red;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Calculation error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            txtTotalBankroll.Clear();
            txtMainOdd.Clear();
            txtSecondaryOdd.Clear();
            ClearResultTexts();
        }

        private static decimal ParseDecimal(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Enter a value.");

            string normalizedValue = value.Trim().Replace(',', '.');

            if (decimal.TryParse(
                normalizedValue,
                NumberStyles.Any,
                CultureInfo.InvariantCulture,
                out decimal result))
            {
                return result;
            }

            throw new ArgumentException("Enter a valid numeric value.");
        }

        private void ClearResultTexts()
        {
            txtMinimumSecondaryOdd.Text = "Minimum secondary odd for main profit:";
            txtMainStake.Text = "Main stake:";
            txtSecondaryStake.Text = "Secondary stake:";
            txtReturnIfMainWins.Text = "Return if main wins:";
            txtReturnIfSecondaryWins.Text = "Return if secondary wins:";
            txtProfitIfMainWins.Text = "Profit if main wins:";
            txtProfitIfSecondaryWins.Text = "Profit if secondary wins:";
            txtCoversEntireBankroll.Text = "Secondary covers entire bankroll:";

            txtProfitIfMainWins.Foreground = Brushes.Black;
            txtProfitIfSecondaryWins.Foreground = Brushes.Black;
        }
    }
}