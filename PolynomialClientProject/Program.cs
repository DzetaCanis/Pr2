using PolynomialLibrary;
using System;

namespace PolynomialClientProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            // Створення поліномів
            Polynomial p1 = new Polynomial(new double[] { 1, 2, 3 }); // 3x^2 + 2x + 1
            Polynomial p2 = new Polynomial(new double[] { 0, 1, 1 }); // x^2 + x

            Console.WriteLine("Вхідні поліноми:");
            Console.WriteLine("p1: " + p1);
            Console.WriteLine("p2: " + p2);
            Console.WriteLine();

            // Додавання поліномів
            Polynomial sum = p1 + p2;
            Console.WriteLine("Додавання поліномів (p1 + p2): " + sum);

            // Віднімання поліномів
            Polynomial diff = p1 - p2;
            Console.WriteLine("Віднімання поліномів (p1 - p2): " + diff);

            // Множення полінома на число
            Polynomial prod1 = p1 * 2;
            Polynomial prod2 = 3 * p2;
            Console.WriteLine("Множення полінома на число (p1 * 2): " + prod1);
            Console.WriteLine("Множення числа на поліном (3 * p2): " + prod2);

            // Додавання числа до полінома
            Polynomial addNumber = p1 + 5;
            Console.WriteLine("Додавання числа до полінома (p1 + 5): " + addNumber);

            // Доступ до коефіцієнтів через індексатор
            double coeffX2 = ((IPolynomial)p1)[2];
            Console.WriteLine("Доступ до коефіцієнта при x^2 у p1: " + coeffX2);

            // Обчислення значення полінома у точці
            double valueAt2 = ((IPolynomial)p1)[2.0]; // Значення p1 при x=2
            Console.WriteLine("Обчислення значення полінома p1(x=2): " + valueAt2);

            // Неявне приведення числа до полінома
            Polynomial pFromDouble = 7; // implicit operator
            Console.WriteLine("Неявне приведення числа 7 до полінома: " + pFromDouble);

            // Явне приведення полінома до масиву коефіцієнтів
            double[] coeffs = (double[])p1;
            Console.WriteLine("Явне приведення p1 до масиву коефіцієнтів: [" + string.Join(", ", coeffs) + "]");

            // Перевірка рівності поліномів
            Polynomial p3 = new Polynomial(new double[] { 1, 2, 3 });
            Console.WriteLine("Перевірка рівності поліномів:");
            Console.WriteLine("p1 == p3: " + (p1 == p3));
            Console.WriteLine("p1 != p2: " + (p1 != p2));

            // Перевірка оператора true/false
            Polynomial zeroPoly = new Polynomial();
            Console.WriteLine("Перевірка, чи є поліноми ненульовими:");
            if (p1)
                Console.WriteLine("p1 є ненульовим поліномом");

            if (zeroPoly)
                Console.WriteLine("zeroPoly  є ненульовим поліномом");
            else
                Console.WriteLine("zeroPoly  є нульовим поліномом");

            Console.ReadLine();
        }
    }
}
