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
        throw new NotImplementedException();
    }

    public float Modulus(float a, float b)
    {
        throw new NotImplementedException();
    }

    public float Multiply(float a, params float[] b)
    {
        throw new NotImplementedException();
    }

    public float Power(float a, float b)
    {
        throw new NotImplementedException();
    }

    public float SquareRoot(float a)
    {
        throw new NotImplementedException();
    }

    public float Subtract(float a, params float[] b)
    {
        throw new NotImplementedException();
    }
}