namespace CalculatorTests;

public class PowerTests
{
    private readonly Calculator _calculator;

    public PowerTests()
    {
        _calculator = new Calculator();
    }

    [Fact]
    public void Power_TwoNumbers_ReturnsCorrectResult()
    {
        float result = _calculator.Power(2f, 3f);
        Assert.Equal(8f, result);
    }

    [Fact]
    public void Power_ZeroExponent_ReturnsOne()
    {
        float result = _calculator.Power(5f, 0f);
        Assert.Equal(1f, result);
    }

    [Fact]
    public void Power_ExponentOne_ReturnsBase()
    {
        float result = _calculator.Power(7f, 1f);
        Assert.Equal(7f, result);
    }

    [Fact]
    public void Power_NegativeExponent_ReturnsFractionalResult()
    {
        float result = _calculator.Power(2f, -2f);
        Assert.Equal(0.25f, result, 2);
    }

    [Fact]
    public void Power_NegativeBaseEvenExponent_ReturnsPositive()
    {
        float result = _calculator.Power(-3f, 2f);
        Assert.Equal(9f, result);
    }

    [Fact]
    public void Power_NegativeBaseOddExponent_ReturnsNegative()
    {
        float result = _calculator.Power(-3f, 3f);
        Assert.Equal(-27f, result);
    }

    [Fact]
    public void Power_DecimalExponent_ReturnsCorrectResult()
    {
        float result = _calculator.Power(9f, 0.5f);
        Assert.Equal(3f, result, 2);
    }

    [Fact]
    public void Power_LargeExponent_ReturnsCorrectResult()
    {
        float result = _calculator.Power(2f, 10f);
        Assert.Equal(1024f, result);
    }

    [Fact]
    public void Power_ThrowsException_WhenInvalidInput()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.Power(float.NaN, 2f));
        Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.Power(float.PositiveInfinity, 2f));
        Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.Power(float.NegativeInfinity, 2f));
    }
}
