using System;
using System.Collections.Generic;

namespace PolynomialLibrary
{
    public partial class Polynomial : IPolynomial, IEquatable<Polynomial>
    {
        private int degree;
        private double[] coefficients;

        int IPolynomial.Degree => degree;

        double IPolynomial.this[int power]
        {
            get
            {
                if (power < 0 || power > degree) return 0;
                return coefficients[power];
            }
            set
            {
                if (power < 0)
                    throw new ArgumentOutOfRangeException(nameof(power));

                if (power > degree)
                {
                    Array.Resize(ref coefficients, power + 1);
                    degree = power;
                }

                coefficients[power] = value;
                while (degree > 0 && coefficients[degree] == 0)
                    degree--;
            }
        }

        double IPolynomial.this[double x]
        {
            get
            {
                double sum = 0;
                for (int i = 0; i <= degree; i++)
                    sum += coefficients[i] * Math.Pow(x, i);
                return sum;
            }
        }

        public Polynomial()
        {
            degree = 0;
            coefficients = new double[1] { 0 };
        }

        public Polynomial(int degree)
        {
            if (degree < 0) throw new ArgumentException("Degree cannot be negative");
            this.degree = degree;
            coefficients = new double[degree + 1];
        }

        public Polynomial(double[] arr)
        {
            if (arr == null || arr.Length == 0)
                throw new ArgumentException("Array is empty");

            coefficients = new double[arr.Length];
            Array.Copy(arr, coefficients, arr.Length);

            degree = arr.Length - 1;
            while (degree > 0 && coefficients[degree] == 0)
                degree--;
        }

        public Polynomial(Polynomial p)
        {
            degree = p.degree;
            coefficients = new double[p.coefficients.Length];
            Array.Copy(p.coefficients, coefficients, p.coefficients.Length);
        }

        Polynomial IPolynomial.Add(Polynomial other)
        {
            int maxDeg = Math.Max(degree, other.degree);
            double[] result = new double[maxDeg + 1];

            for (int i = 0; i <= maxDeg; i++)
            {
                double a = (i <= degree) ? coefficients[i] : 0;
                double b = (i <= other.degree) ? other.coefficients[i] : 0;
                result[i] = a + b;
            }

            return new Polynomial(result);
        }

        Polynomial IPolynomial.Sub(Polynomial other)
        {
            int maxDeg = Math.Max(degree, other.degree);
            double[] result = new double[maxDeg + 1];

            for (int i = 0; i <= maxDeg; i++)
            {
                double a = (i <= degree) ? coefficients[i] : 0;
                double b = (i <= other.degree) ? other.coefficients[i] : 0;
                result[i] = a - b;
            }

            return new Polynomial(result);
        }

        Polynomial IPolynomial.Add(double number)
        {
            double[] result = new double[coefficients.Length];
            Array.Copy(coefficients, result, coefficients.Length);
            result[0] += number;
            return new Polynomial(result);
        }

        Polynomial IPolynomial.Multiply(double number)
        {
            double[] result = new double[degree + 1];
            for (int i = 0; i <= degree; i++)
                result[i] = coefficients[i] * number;

            return new Polynomial(result);
        }

        double[] IPolynomial.ToArray()
        {
            double[] result = new double[coefficients.Length];
            Array.Copy(coefficients, result, coefficients.Length);
            return result;
        }

        string IPolynomial.ToString() => ToString();

        public static Polynomial operator +(Polynomial a, Polynomial b)
            => ((IPolynomial)a).Add(b);

        public static Polynomial operator -(Polynomial a, Polynomial b)
            => ((IPolynomial)a).Sub(b);

        public static Polynomial operator +(Polynomial p, double number)
            => ((IPolynomial)p).Add(number);

        public static Polynomial operator *(Polynomial p, double number)
            => ((IPolynomial)p).Multiply(number);

        public static Polynomial operator *(double number, Polynomial p)
            => ((IPolynomial)p).Multiply(number);

        public static bool operator ==(Polynomial a, Polynomial b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (a is null || b is null) return false;
            return a.Equals(b);
        }

        public static bool operator !=(Polynomial a, Polynomial b)
            => !(a == b);

        public static bool operator true(Polynomial p)
            => !(p.degree == 0 && p.coefficients[0] == 0);

        public static bool operator false(Polynomial p)
            => (p.degree == 0 && p.coefficients[0] == 0);

        public static implicit operator Polynomial(double number)
            => new Polynomial(new double[] { number });

        public static explicit operator double[](Polynomial p)
        {
            double[] result = new double[p.coefficients.Length];
            Array.Copy(p.coefficients, result, p.coefficients.Length);
            return result;
        }

        public override string ToString()
        {
            List<string> parts = new List<string>();
            for (int i = degree; i >= 0; i--)
            {
                if (coefficients[i] == 0) continue;
                string part = coefficients[i].ToString();
                if (i == 1) part += "x";
                else if (i > 1) part += $"x^{i}";
                parts.Add(part);
            }

            if (parts.Count == 0) return "0";
            return string.Join(" + ", parts);
        }

        public override bool Equals(object obj)
        {
            if (obj is Polynomial other)
                return Equals(other);

            return false;
        }

        bool IEquatable<Polynomial>.Equals(Polynomial other)
        {
            return Equals(other);
        }

        public bool Equals(Polynomial other)
        {
            if (other is null) return false;
            if (degree != other.degree) return false;

            for (int i = 0; i <= degree; i++)
            {
                if (coefficients[i] != other.coefficients[i])
                    return false;
            }

            return true;
        }
        public override int GetHashCode()
        {
            int hashCode = 2113002308;
            hashCode = hashCode * -1521134295 + degree.GetHashCode();
            foreach (double coef in coefficients)
            {
                hashCode = hashCode * -1521134295 + coef.GetHashCode();
            }
            return hashCode;
        }
    }
}
