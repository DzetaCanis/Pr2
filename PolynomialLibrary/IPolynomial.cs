using System;

namespace PolynomialLibrary
{

    public interface IPolynomial
    {
        int Degree { get; }

        double this[int power] { get; set; }

        double this[double x] { get; }

        Polynomial Add(Polynomial other);

        Polynomial Sub(Polynomial other);

        Polynomial Add(double number);

        Polynomial Multiply(double number);

        double[] ToArray();

        string ToString();
    }
}
