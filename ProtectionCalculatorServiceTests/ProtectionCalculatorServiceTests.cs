using HedgeCalculator.Domain.Services;
using Xunit;

namespace ProtectionCalculatorServiceTests;

public sealed class ProtectionCalculatorServiceTests
{
    [Fact]
    public void Calculate_ShouldCoverEntireBankroll_WhenSecondaryWins()
    {
        var result = ProtectionCalculatorService.Calculate(100m, 1.30m, 5.00m);

        Assert.Equal(20m, result.SecondaryStake);
        Assert.Equal(80m, result.MainStake);
        Assert.Equal(100m, result.ReturnIfSecondaryWins);
        Assert.Equal(0m, result.ProfitIfSecondaryWins);
        Assert.True(result.SecondaryCoversEntireBankroll);
    }

    [Fact]
    public void Calculate_ShouldGenerateProfitOnMain_WhenSecondaryOddIsHighEnough()
    {
        var result = ProtectionCalculatorService.Calculate(100m, 1.30m, 5.00m);

        Assert.Equal(104m, result.ReturnIfMainWins);
        Assert.Equal(4m, result.ProfitIfMainWins);
    }

    [Fact]
    public void CalculateMinimumSecondaryOddForMainProfit_ShouldReturnExpectedValue()
    {
        var result = ProtectionCalculatorService.CalculateMinimumSecondaryOddForMainProfit(1.30m);

        Assert.Equal(4.3333333333333333333333333333m, result);
    }

    [Fact]
    public void Calculate_ShouldHaveNoMainProfit_WhenSecondaryOddIsBreakEvenThreshold()
    {
        decimal minOdd = ProtectionCalculatorService.CalculateMinimumSecondaryOddForMainProfit(1.30m);

        var result = ProtectionCalculatorService.Calculate(100m, 1.30m, minOdd);

        Assert.True(result.ProfitIfMainWins <= 0.000001m);
    }

    [Fact]
    public void Calculate_ShouldThrow_WhenBankrollIsInvalid()
    {
        Assert.Throws<System.ArgumentException>(() =>
            ProtectionCalculatorService.Calculate(0m, 1.30m, 5.00m));
    }

    [Fact]
    public void Calculate_ShouldThrow_WhenMainOddIsInvalid()
    {
        Assert.Throws<System.ArgumentException>(() =>
            ProtectionCalculatorService.Calculate(100m, 1.00m, 5.00m));
    }

    [Fact]
    public void Calculate_ShouldThrow_WhenSecondaryOddIsInvalid()
    {
        Assert.Throws<System.ArgumentException>(() =>
            ProtectionCalculatorService.Calculate(100m, 1.30m, 1.00m));
    }
}
