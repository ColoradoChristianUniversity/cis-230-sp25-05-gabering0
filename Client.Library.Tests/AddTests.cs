using Client.Library;

namespace CalculatorTests;

public class AddTests
{
    private readonly Calculator _calculator;

    public AddTests()
    {
        _calculator = new Calculator();
    }

    [Fact]
    public void Add_SingleValue_ReturnsSameValue()
    {
        float result = _calculator.Add(5f);
        Assert.Equal(5f, result);
    }

    [Fact]
    public void Add_TwoNumbers_ReturnsCorrectSum()
    {
        float result = _calculator.Add(5f, 3f);
        Assert.Equal(8f, result);
    }

    [Fact]
    public void Add_MultipleNumbers_ReturnsCorrectSum()
    {
        float result = _calculator.Add(2f, 3f, 4f, 5f);
        Assert.Equal(14f, result);
    }

    [Fact]
    public void Add_WithZero_ReturnsSameValue()
    {
        float result = _calculator.Add(7f, 0f);
        Assert.Equal(7f, result);
    }

    [Fact]
    public void Add_NegativeNumbers_ReturnsCorrectSum()
    {
        float result = _calculator.Add(-5f, -3f, -2f);
        Assert.Equal(-10f, result);
    }

    [Fact]
    public void Add_PositiveAndNegativeNumbers_ReturnsCorrectSum()
    {
        float result = _calculator.Add(10f, -3f, -4f);
        Assert.Equal(3f, result);
    }

    [Fact]
    public void Add_DecimalValues_ReturnsCorrectSum()
    {
        float result = _calculator.Add(1.5f, 2.3f, 3.2f);
        Assert.Equal(7.0f, result, 2);
    }

    [Fact]
    public void Add_LargeValues_ReturnsCorrectSum()
    {
        float result = _calculator.Add(1000000f, 2000000f);
        Assert.Equal(3000000f, result);
    }

    [Fact]
    public void Add_ThrowsException_WhenInvalidInput()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.Add(float.NaN));
        Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.Add(float.PositiveInfinity));
        Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.Add(float.NegativeInfinity));
    }
}
