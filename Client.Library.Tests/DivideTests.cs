using Client.Library;

namespace CalculatorTests;

public class DivideTests
{
    private readonly Calculator _calculator;

    public DivideTests()
    {
        _calculator = new Calculator();
    }

    [Fact]
    public void Divide_SingleValue_ReturnsSameValue()
    {
        float result = _calculator.Divide(10f);
        Assert.Equal(10f, result);
    }

    [Fact]
    public void Divide_TwoNumbers_ReturnsCorrectQuotient()
    {
        float result = _calculator.Divide(10f, 2f);
        Assert.Equal(5f, result);
    }

    [Fact]
    public void Divide_MultipleNumbers_ReturnsCorrectQuotient()
    {
        float result = _calculator.Divide(100f, 2f, 5f);
        Assert.Equal(10f, result);
    }

    [Fact]
    public void Divide_ByOne_ReturnsSameValue()
    {
        float result = _calculator.Divide(7f, 1f);
        Assert.Equal(7f, result);
    }

    [Fact]
    public void Divide_ByNegativeNumber_ReturnsCorrectQuotient()
    {
        float result = _calculator.Divide(10f, -2f);
        Assert.Equal(-5f, result);
    }

    [Fact]
    public void Divide_PositiveAndNegativeNumbers_ReturnsCorrectQuotient()
    {
        float result = _calculator.Divide(-20f, -2f, 5f);
        Assert.Equal(2f, result);
    }

    [Fact]
    public void Divide_DecimalValues_ReturnsCorrectQuotient()
    {
        float result = _calculator.Divide(10.5f, 2.1f);
        Assert.Equal(5f, result, 2);
    }

    [Fact]
    public void Divide_LargeValues_ReturnsCorrectQuotient()
    {
        float result = _calculator.Divide(1000000f, 2f);
        Assert.Equal(500000f, result);
    }

    [Fact]
    public void Divide_ThrowsException_WhenDividingByZero()
    {
        Assert.Throws<DivideByZeroException>(() => _calculator.Divide(10f, 0f));
        Assert.Throws<DivideByZeroException>(() => _calculator.Divide(10f, 2f, 0f));
    }

    [Fact]
    public void Divide_ThrowsException_WhenInvalidInput()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.Divide(float.NaN));
        Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.Divide(float.PositiveInfinity));
        Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.Divide(float.NegativeInfinity));
    }
}
