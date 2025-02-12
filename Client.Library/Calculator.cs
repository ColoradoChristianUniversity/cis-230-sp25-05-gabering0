public interface ICalculator
{
    float Add(float a, params float[] b);
    float Subtract(float a, params float[] b);
    float Multiply(float a, params float[] b);
    float Divide(float a, params float[] b);
    float Modulus(float a, float b);
    float Power(float a, float b);
    float Factorial(float a);
    float SquareRoot(float a);
}

public class Calculator : ICalculator
{
    public float Add(float a, params float[] b)
    {
        ArgumentOutOfRangeException.ThrowIfEqual(float.NaN, a, nameof(a));
        ArgumentOutOfRangeException.ThrowIfEqual(float.PositiveInfinity, a, nameof(a));
        ArgumentOutOfRangeException.ThrowIfEqual(float.NegativeInfinity, a, nameof(a));

        foreach (var i in b)
        {
            a += i;
        }
        return a;
    }

    public float Subtract(float a, params float[] b)
    {
        ArgumentOutOfRangeException.ThrowIfEqual(float.NaN, a, nameof(a));
        ArgumentOutOfRangeException.ThrowIfEqual(float.PositiveInfinity, a, nameof(a));
        ArgumentOutOfRangeException.ThrowIfEqual(float.NegativeInfinity, a, nameof(a));

        foreach (var i in b)
        {
            a -= i;
        }
        return a;
    }

    public float Multiply(float a, params float[] b)
    {
        ArgumentOutOfRangeException.ThrowIfEqual(float.NaN, a, nameof(a));
        ArgumentOutOfRangeException.ThrowIfEqual(float.PositiveInfinity, a, nameof(a));
        ArgumentOutOfRangeException.ThrowIfEqual(float.NegativeInfinity, a, nameof(a));

        foreach (var i in b)
        {
            a *= i;
        }
        return a;
    }

    public float Divide(float a, params float[] b)
    {
        ArgumentOutOfRangeException.ThrowIfEqual(float.NaN, a, nameof(a));
        ArgumentOutOfRangeException.ThrowIfEqual(float.PositiveInfinity, a, nameof(a));
        ArgumentOutOfRangeException.ThrowIfEqual(float.NegativeInfinity, a, nameof(a));

        foreach (var i in b)
        {
            ArgumentOutOfRangeException.ThrowIfEqual(i, 0, nameof(b));
            a /= i;
        }
        return a;
    }

    public float Modulus(float a, float b)
    {
        ArgumentOutOfRangeException.ThrowIfEqual(float.NaN, a, nameof(a));
        ArgumentOutOfRangeException.ThrowIfEqual(float.PositiveInfinity, a, nameof(a));
        ArgumentOutOfRangeException.ThrowIfEqual(float.NegativeInfinity, a, nameof(a));

        ArgumentOutOfRangeException.ThrowIfEqual(b, 0, nameof(b));
        return a % b;
    }

    public float Power(float a, float b)
    {
        ArgumentOutOfRangeException.ThrowIfEqual(float.NaN, a, nameof(a));
        ArgumentOutOfRangeException.ThrowIfEqual(float.PositiveInfinity, a, nameof(a));
        ArgumentOutOfRangeException.ThrowIfEqual(float.NegativeInfinity, a, nameof(a));

        return (float)Math.Pow(a, b);
    }

    public float Factorial(float a)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(a, 0, nameof(a));
        ArgumentOutOfRangeException.ThrowIfNotEqual(a % 1, 0, nameof(a));

        if (a == 0 || a == 1)
            return 1;
        return a * Factorial(a - 1);
    }

    public float SquareRoot(float a)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(a, 0, nameof(a));

        return (float)Math.Sqrt(a);
    }
}
