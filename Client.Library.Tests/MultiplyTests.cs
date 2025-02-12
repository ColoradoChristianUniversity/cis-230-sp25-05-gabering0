namespace CalculatorTests;

public class MultiplyTests
{
    private readonly Calculator _calculator;

    public MultiplyTests()
    {
        _calculator = new Calculator();
    }

    [Fact]
    public void Multiply_SingleValue_ReturnsSameValue()
    {
        float result = _calculator.Multiply(5f);
        Assert.Equal(5f, result);
    }

    [Fact]
    public void Multiply_TwoNumbers_ReturnsCorrectProduct()
    {
        float result = _calculator.Multiply(10f, 3f);
        Assert.Equal(30f, result);
    }

    [Fact]
    public void Multiply_MultipleNumbers_ReturnsCorrectProduct()
    {
        float result = _calculator.Multiply(2f, 3f, 4f, 5f);
        Assert.Equal(120f, result);
    }

    [Fact]
    public void Multiply_WithZero_ReturnsZero()
    {
        float result = _calculator.Multiply(7f, 0f);
        Assert.Equal(0f, result);
    }

    [Fact]
    public void Multiply_NegativeNumbers_ReturnsCorrectProduct()
    {
        float result = _calculator.Multiply(-5f, -3f, -2f);
        Assert.Equal(-30f, result);
    }

    [Fact]
    public void Multiply_PositiveAndNegativeNumbers_ReturnsCorrectProduct()
    {
        float result = _calculator.Multiply(10f, -3f, 4f);
        Assert.Equal(-120f, result);
    }

    [Fact]
    public void Multiply_DecimalValues_ReturnsCorrectProduct()
    {
        float result = _calculator.Multiply(1.5f, 2.0f, 3.0f);
        Assert.Equal(9.0f, result, 2);
    }

    [Fact]
    public void Multiply_LargeValues_ReturnsCorrectProduct()
    {
        float result = _calculator.Multiply(1000000f, 2f);
        Assert.Equal(2000000f, result);
    }

    [Fact]
    public void Multiply_ThrowsException_WhenInvalidInput()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.Multiply(float.NaN));
        Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.Multiply(float.PositiveInfinity));
        Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.Multiply(float.NegativeInfinity));
    }
}