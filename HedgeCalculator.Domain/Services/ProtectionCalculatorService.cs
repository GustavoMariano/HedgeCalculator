using HedgeCalculator.Domain.Models;
using System;

namespace HedgeCalculator.Domain.Services
{
    public static class ProtectionCalculatorService
    {
        public static decimal CalculateMinimumSecondaryOddForMainProfit(decimal mainOdd)
        {
            ValidateOdd(mainOdd, nameof(mainOdd));

            return mainOdd / (mainOdd - 1m);
        }

        public static ProtectionCalculationResult Calculate(decimal totalBankroll, decimal mainOdd, decimal secondaryOdd)
        {
            ValidateBankroll(totalBankroll);
            ValidateOdd(mainOdd, nameof(mainOdd));
            ValidateOdd(secondaryOdd, nameof(secondaryOdd));

            decimal secondaryStake = totalBankroll / secondaryOdd;
            decimal mainStake = totalBankroll - secondaryStake;

            decimal returnIfSecondaryWins = secondaryStake * secondaryOdd;
            decimal returnIfMainWins = mainStake * mainOdd;

            decimal profitIfSecondaryWins = returnIfSecondaryWins - totalBankroll;
            decimal profitIfMainWins = returnIfMainWins - totalBankroll;

            return new ProtectionCalculationResult
            {
                TotalBankroll = totalBankroll,
                MainOdd = mainOdd,
                SecondaryOdd = secondaryOdd,

                MainStake = mainStake,
                SecondaryStake = secondaryStake,

                ReturnIfMainWins = returnIfMainWins,
                ReturnIfSecondaryWins = returnIfSecondaryWins,

                ProfitIfMainWins = profitIfMainWins,
                ProfitIfSecondaryWins = profitIfSecondaryWins,

                MinimumSecondaryOddForMainProfit = CalculateMinimumSecondaryOddForMainProfit(mainOdd),
                SecondaryCoversEntireBankroll = returnIfSecondaryWins >= totalBankroll
            };
        }

        private static void ValidateBankroll(decimal totalBankroll)
        {
            if (totalBankroll <= 0m)
                throw new ArgumentException("The total bankroll must be greater than zero.", nameof(totalBankroll));
        }

        private static void ValidateOdd(decimal odd, string paramName)
        {
            if (odd <= 1m)
                throw new ArgumentException("The odd must be greater than 1.", paramName);
        }
    }
}