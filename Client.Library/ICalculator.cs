namespace Client.Library;

public interface ICalculator
{
    float Add(float a, params float[] b);
    float Subtract(float a, params float[] b);
    float Multiply(float a, params float[] b);
    float Divide(float a, params float[] b);
    float Modulus(float a, float b);
    float Power(float a, float b);
    float SquareRoot(float a);
}
