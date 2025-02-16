namespace Client.Library;

public class Calculator : ICalculator
{
    public float Add(float a, params float[] b)
    {
        ArgumentOutOfRangeException.ThrowIfEqual(a, float.NaN, "The first number cannot be NaN");
        ArgumentOutOfRangeException.ThrowIfEqual(a, float.PositiveInfinity, "The first number cannot be Positive Infinity");
        ArgumentOutOfRangeException.ThrowIfEqual(a, float.NegativeInfinity, "The first number cannot be Negative Infinity");
        
        foreach (var number in b)
        {
            a += number;
        }
        return a;
    }

    public float Divide(float a, params float[] b)
    {
        ArgumentOutOfRangeException.ThrowIfEqual(a, float.NaN, "The first number cannot be NaN");
        ArgumentOutOfRangeException.ThrowIfEqual(a, float.PositiveInfinity, "The first number cannot be Positive Infinity");
        ArgumentOutOfRangeException.ThrowIfEqual(a, float.NegativeInfinity, "The first number cannot be Negative Infinity");

        foreach (var number in b)
        {
            ArgumentOutOfRangeException.ThrowIfEqual(number, float.NaN, "A number cannot be NaN");
            ArgumentOutOfRangeException.ThrowIfEqual(number, float.PositiveInfinity, "A number cannot be Positive Infinity");
            ArgumentOutOfRangeException.ThrowIfEqual(number, float.NegativeInfinity, "A number cannot be Negative Infinity");

            if (number == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero");
            }

            a /= number;
        }
        return a;
    }


    public float Modulus(float a, float b)
    {
        ArgumentOutOfRangeException.ThrowIfEqual(a, float.NaN, "The first number cannot be NaN");
        ArgumentOutOfRangeException.ThrowIfEqual(a, float.PositiveInfinity, "The first number cannot be Positive Infinity");
        ArgumentOutOfRangeException.ThrowIfEqual(a, float.NegativeInfinity, "The first number cannot be Negative Infinity");
        ArgumentOutOfRangeException.ThrowIfEqual(b, float.NaN, "The second number cannot be NaN");
        ArgumentOutOfRangeException.ThrowIfEqual(b, float.PositiveInfinity, "The second number cannot be Positive Infinity");
        ArgumentOutOfRangeException.ThrowIfEqual(b, float.NegativeInfinity, "The second number cannot be Negative Infinity");

        if (b == 0)
        {
            throw new ArgumentOutOfRangeException(nameof(b), "Cannot divide by zero");
        }

        return a % b;
    }

    public float Multiply(float a, params float[] b)
    {
        ArgumentOutOfRangeException.ThrowIfEqual(a, float.NaN, "The first number cannot be NaN");
        ArgumentOutOfRangeException.ThrowIfEqual(a, float.PositiveInfinity, "The first number cannot be Positive Infinity");
        ArgumentOutOfRangeException.ThrowIfEqual(a, float.NegativeInfinity, "The first number cannot be Negative Infinity");

        foreach (var number in b)
        {
            ArgumentOutOfRangeException.ThrowIfEqual(number, float.NaN, "A number cannot be NaN");
            ArgumentOutOfRangeException.ThrowIfEqual(number, float.PositiveInfinity, "A number cannot be Positive Infinity");
            ArgumentOutOfRangeException.ThrowIfEqual(number, float.NegativeInfinity, "A number cannot be Negative Infinity");

            a *= number;
        }
        return a;
    }


    public float Power(float baseValue, float exponent)
        {
            if (float.IsNaN(baseValue) || float.IsInfinity(baseValue))
            {
                throw new ArgumentOutOfRangeException(nameof(baseValue), "Base value cannot be NaN or Infinity.");
            }

            return (float)Math.Pow(baseValue, exponent);
        }

    public float SquareRoot(float a)
    {
        if (a < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(a), "Cannot calculate the square root of a negative number");
        }

        return (float)Math.Sqrt(a);
    }
    public float Subtract(float a, params float[] b)
    {
        if (b == null || b.Length == 0)
            return a;

        foreach (var number in b)
        {
            if (float.IsNaN(number) || float.IsInfinity(number))
                throw new ArgumentOutOfRangeException(nameof(b), "Invalid number provided.");

            a -= number;
        }
        return a;
    }
}
