namespace HedgeCalculator.Domain.Models
{
    public sealed class ProtectionCalculationResult
    {
        public decimal TotalBankroll { get; init; }
        public decimal MainOdd { get; init; }
        public decimal SecondaryOdd { get; init; }

        public decimal MainStake { get; init; }
        public decimal SecondaryStake { get; init; }

        public decimal ReturnIfMainWins { get; init; }
        public decimal ReturnIfSecondaryWins { get; init; }

        public decimal ProfitIfMainWins { get; init; }
        public decimal ProfitIfSecondaryWins { get; init; }

        public decimal MinimumSecondaryOddForMainProfit { get; init; }
        public bool SecondaryCoversEntireBankroll { get; init; }
    }
}