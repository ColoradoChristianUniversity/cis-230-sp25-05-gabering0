namespace CalculatorTests;

public class SquareRootTests
{
    private readonly Calculator _calculator;

    public SquareRootTests()
    {
        _calculator = new Calculator();
    }

    [Fact]
    public void SquareRoot_PositiveNumber_ReturnsCorrectResult()
    {
        float result = _calculator.SquareRoot(16f);
        Assert.Equal(4f, result);
    }

    [Fact]
    public void SquareRoot_Zero_ReturnsZero()
    {
        float result = _calculator.SquareRoot(0f);
        Assert.Equal(0f, result);
    }

    [Fact]
    public void SquareRoot_NonPerfectSquare_ReturnsCorrectResult()
    {
        float result = _calculator.SquareRoot(2f);
        Assert.Equal(1.4142f, result, 4);
    }

    [Fact]
    public void SquareRoot_LargeNumber_ReturnsCorrectResult()
    {
        float result = _calculator.SquareRoot(1000000f);
        Assert.Equal(1000f, result);
    }

    [Fact]
    public void SquareRoot_NegativeNumber_ThrowsException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.SquareRoot(-25f));
    }
}
