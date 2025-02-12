namespace CalculatorTests;

public class FactorialTests
{
    private readonly Calculator _calculator;

    public FactorialTests()
    {
        _calculator = new Calculator();
    }

    [Fact]
    public void Factorial_Zero_ReturnsOne()
    {
        float result = _calculator.Factorial(0f);
        Assert.Equal(1f, result);
    }

    [Fact]
    public void Factorial_One_ReturnsOne()
    {
        float result = _calculator.Factorial(1f);
        Assert.Equal(1f, result);
    }

    [Fact]
    public void Factorial_PositiveInteger_ReturnsCorrectResult()
    {
        float result = _calculator.Factorial(5f);
        Assert.Equal(120f, result);
    }

    [Fact]
    public void Factorial_LargeNumber_ReturnsCorrectResult()
    {
        float result = _calculator.Factorial(10f);
        Assert.Equal(3628800f, result);
    }

    [Fact]
    public void Factorial_NegativeNumber_ThrowsException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.Factorial(-5f));
    }

    [Fact]
    public void Factorial_NonInteger_ThrowsException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.Factorial(4.5f));
    }
}