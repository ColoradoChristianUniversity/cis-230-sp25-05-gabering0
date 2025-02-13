using Client.Library;

namespace CalculatorTests;

public class SubtractTests
{
    private readonly Calculator _calculator;

    public SubtractTests()
    {
        _calculator = new Calculator();
    }

    [Fact]
    public void Subtract_SingleValue_ReturnsSameValue()
    {
        float result = _calculator.Subtract(5f);
        Assert.Equal(5f, result);
    }

    [Fact]
    public void Subtract_TwoNumbers_ReturnsCorrectDifference()
    {
        float result = _calculator.Subtract(10f, 3f);
        Assert.Equal(7f, result);
    }

    [Fact]
    public void Subtract_MultipleNumbers_ReturnsCorrectDifference()
    {
        float result = _calculator.Subtract(20f, 3f, 4f, 5f);
        Assert.Equal(8f, result);
    }

    [Fact]
    public void Subtract_WithZero_ReturnsSameValue()
    {
        float result = _calculator.Subtract(7f, 0f);
        Assert.Equal(7f, result);
    }

    [Fact]
    public void Subtract_NegativeNumbers_ReturnsCorrectDifference()
    {
        float result = _calculator.Subtract(-5f, -3f, -2f);
        Assert.Equal(0f, result);
    }

    [Fact]
    public void Subtract_PositiveAndNegativeNumbers_ReturnsCorrectDifference()
    {
        float result = _calculator.Subtract(10f, -3f, -4f);
        Assert.Equal(17f, result);
    }

    [Fact]
    public void Subtract_DecimalValues_ReturnsCorrectDifference()
    {
        float result = _calculator.Subtract(10.5f, 2.3f, 3.2f);
        Assert.Equal(5.0f, result, 2);
    }

    [Fact]
    public void Subtract_LargeValues_ReturnsCorrectDifference()
    {
        float result = _calculator.Subtract(1000000f, 200000f);
        Assert.Equal(800000f, result);
    }

    [Fact]
    public void Subtract_ThrowsException_WhenInvalidInput()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.Subtract(float.NaN));
        Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.Subtract(float.PositiveInfinity));
        Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.Subtract(float.NegativeInfinity));
    }
}
