using Client.Library;

namespace CalculatorTests;

public class ModulusTests
{
    private readonly Calculator _calculator;

    public ModulusTests()
    {
        _calculator = new Calculator();
    }

    [Fact]
    public void Modulus_TwoNumbers_ReturnsCorrectRemainder()
    {
        float result = _calculator.Modulus(10f, 3f);
        Assert.Equal(1f, result);
    }

    [Fact]
    public void Modulus_DivisibleNumbers_ReturnsZero()
    {
        float result = _calculator.Modulus(20f, 5f);
        Assert.Equal(0f, result);
    }

    [Fact]
    public void Modulus_ByNegativeNumber_ReturnsCorrectRemainder()
    {
        float result = _calculator.Modulus(10f, -3f);
        Assert.Equal(1f, result);
    }

    [Fact]
    public void Modulus_NegativeNumbers_ReturnsCorrectRemainder()
    {
        float result = _calculator.Modulus(-10f, -3f);
        Assert.Equal(-1f, result);
    }

    [Fact]
    public void Modulus_DecimalValues_ReturnsCorrectRemainder()
    {
        float result = _calculator.Modulus(10.5f, 2.1f);
        Assert.Equal(0f, result, 2);
    }

    [Fact]
    public void Modulus_LargeValues_ReturnsCorrectRemainder()
    {
        float result = _calculator.Modulus(1000000f, 250000f);
        Assert.Equal(0f, result);
    }

    [Fact]
    public void Modulus_ThrowsException_WhenDividingByZero()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.Modulus(10f, 0f));
    }

    [Fact]
    public void Modulus_ThrowsException_WhenInvalidInput()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.Modulus(float.NaN, 2f));
        Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.Modulus(float.PositiveInfinity, 2f));
        Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.Modulus(float.NegativeInfinity, 2f));
    }
}
