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
        throw new NotImplementedException();
    }

    public float Divide(float a, params float[] b)
    {
        throw new NotImplementedException();
    }

    public float Factorial(float a)
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