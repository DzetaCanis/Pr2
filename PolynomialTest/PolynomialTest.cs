using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolynomialLibrary;
using System;

namespace PolynomialTests
{
    [TestClass]
    public class PolynomialTest
    {
        
        [TestMethod]
        public void Constructor_DefaultConstructor_CreatesZeroPolynomial()
        {
            // Arrange

            // Act
            Polynomial p = new Polynomial();

            // Assert
            Assert.AreEqual(0.0, ((IPolynomial)p)[0]);
            Assert.AreEqual(0, ((IPolynomial)p).Degree);
        }
        
        
        [TestMethod]
        public void Constructor_DegreeConstructor_CreatesPolynomialWithZeros()
        {
            // Arrange
            int expectedDegree = 4;

            // Act
            Polynomial p = new Polynomial(expectedDegree);

            // Assert
            Assert.AreEqual(expectedDegree, ((IPolynomial)p).Degree);
            Assert.AreEqual(0, ((IPolynomial)p)[2]);
        }
        
        
        [TestMethod]
        public void Constructor_NegativeDegree_ThrowsArgumentException()
        {
            // Arrange

            // Act

            // Assert
            Assert.ThrowsException<ArgumentException>(() => new Polynomial(-5));
        }
        
        
        [TestMethod]
        public void Constructor_ArrayConstructor_CorrectDegreeSet()
        {
            // Arrange
            double[] arr = { 1, 2, 3 };

            // Act
            Polynomial p = new Polynomial(arr);

            // Assert
            Assert.AreEqual(2, ((IPolynomial)p).Degree);
        }
        
        
        [TestMethod]
        public void Constructor_ArrayWithLeadingZeros_CorrectDegreeReduced()
        {
            // Arrange
            double[] arr = { 1, 2, 0, 0 };

            // Act
            Polynomial p = new Polynomial(arr);

            // Assert
            Assert.AreEqual(1, ((IPolynomial)p).Degree);
        }
        
        [TestMethod]
        public void Constructor_CopyConstructor_CreatesExactCopy()
        {
            // Arrange
            Polynomial p1 = new Polynomial(new double[] { 2, 5, 3 });

            // Act
            Polynomial p2 = new Polynomial(p1);

            // Assert
            Assert.AreEqual(((IPolynomial)p1)[2], ((IPolynomial)p2)[2]);
            Assert.AreEqual(((IPolynomial)p1).Degree, ((IPolynomial)p2).Degree);
        }

        
        [TestMethod]
        public void Indexer_GetCoefficient_ReturnsCorrectValue()
        {
            // Arrange
            Polynomial p = new Polynomial(new double[] { 1, 4, 9 });

            // Act
            double value = ((IPolynomial)p)[2];

            // Assert
            Assert.AreEqual(9, value);
        }
        
        
        [TestMethod]
        public void Indexer_SetCoefficientOutOfRange_ExpandsDegree()
        {
            // Arrange
            Polynomial p = new Polynomial(new double[] { 1 });

            // Act
            ((IPolynomial)p)[3] = 5;

            // Assert
            Assert.AreEqual(5, ((IPolynomial)p)[3]);
            Assert.AreEqual(3, ((IPolynomial)p).Degree);
        }

        
        [TestMethod]
        public void Indexer_SetNegativePower_ThrowsArgumentOutOfRange()
        {
            // Arrange
            Polynomial p = new Polynomial();

            // Act

            // Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => ((IPolynomial)p)[-1] = 10);
        }

        
        [TestMethod]
        public void Indexer_EvaluateAtPoint_ReturnsCorrectValue()
        {
            // Arrange
            Polynomial p = new Polynomial(new double[] { 1, 2, 3 });

            // Act
            double result = ((IPolynomial)p)[2];

            // Assert
            Assert.AreEqual(3, result);
        }
        
        
        [TestMethod]
        public void Add_AddTwoPolynomials_ReturnsCorrectSum()
        {
            // Arrange
            Polynomial a = new Polynomial(new double[] { 1, 2 });
            Polynomial b = new Polynomial(new double[] { 3, 4 });

            // Act
            Polynomial result = ((IPolynomial)a).Add(b);

            // Assert
            Assert.AreEqual(4, ((IPolynomial)result)[0]);
            Assert.AreEqual(6, ((IPolynomial)result)[1]);
        }


        [TestMethod]
        public void Sub_SubtractTwoPolynomials_ReturnsCorrectDifference()
        {
            // Arrange
            Polynomial a = new Polynomial(new double[] { 5, 5 });
            Polynomial b = new Polynomial(new double[] { 2, 3 });

            // Act
            Polynomial result = ((IPolynomial)a).Sub(b);

            // Assert
            Assert.AreEqual(3, ((IPolynomial)result)[0]);
            Assert.AreEqual(2, ((IPolynomial)result)[1]);
        }

        
        [TestMethod]
        public void Add_AddNumber_AddsToConstantTerm()
        {
            // Arrange
            Polynomial p = new Polynomial(new double[] { 2, 4 });

            // Act
            Polynomial result = ((IPolynomial)p).Add(3);

            // Assert
            Assert.AreEqual(5, ((IPolynomial)result)[0]);
            Assert.AreEqual(4, ((IPolynomial)result)[1]);
        }
        
        
        [TestMethod]
        public void Multiply_MultiplyByNumber_ReturnsScaledPolynomial()
        {
            // Arrange
            Polynomial p = new Polynomial(new double[] { 1, 2, 3 });

            // Act
            Polynomial result = ((IPolynomial)p).Multiply(2);

            // Assert
            Assert.AreEqual(2, ((IPolynomial)result)[0]);
            Assert.AreEqual(4, ((IPolynomial)result)[1]);
            Assert.AreEqual(6, ((IPolynomial)result)[2]);
        }

        
        [TestMethod]
        public void ToArray_ReturnsIndependentCopy()
        {
            // Arrange
            Polynomial p = new Polynomial(new double[] { 1, 2 });

            // Act
            double[] arr = ((IPolynomial)p).ToArray();
            arr[0] = 99;

            // Assert
            Assert.AreEqual(1, ((IPolynomial)p)[0]);
        }

        
        [TestMethod]
        public void OperatorPlus_AddsPolynomialsCorrectly()
        {
            // Arrange
            Polynomial a = new Polynomial(new double[] { 1, 1 });
            Polynomial b = new Polynomial(new double[] { 2, 3 });

            // Act
            Polynomial c = a + b;

            // Assert
            Assert.AreEqual(3, ((IPolynomial)c)[0]);
            Assert.AreEqual(4, ((IPolynomial)c)[1]);
        }
        
        
        [TestMethod]
        public void OperatorMinus_SubtractsPolynomialsCorrectly()
        {
            // Arrange
            Polynomial a = new Polynomial(new double[] { 5, 4 });
            Polynomial b = new Polynomial(new double[] { 1, 1 });

            // Act
            Polynomial c = a - b;

            // Assert
            Assert.AreEqual(4, ((IPolynomial)c)[0]);
            Assert.AreEqual(3, ((IPolynomial)c)[1]);
        }
        
        
        [TestMethod]
        public void OperatorMultiply_MultipliesPolynomialByNumber()
        {
            // Arrange
            Polynomial p = new Polynomial(new double[] { 3, 3 });

            // Act
            Polynomial r = p * 2;

            // Assert
            Assert.AreEqual(6, ((IPolynomial)r)[0]);
            Assert.AreEqual(6, ((IPolynomial)r)[1]);
        }
        
        
        [TestMethod]
        public void OperatorImplicit_ConvertsNumberToPolynomial()
        {
            // Arrange
            double number = 7;

            // Act
            Polynomial p = number;

            // Assert
            Assert.AreEqual(7, ((IPolynomial)p)[0]);
            Assert.AreEqual(0, ((IPolynomial)p).Degree);
        }
        
        
        [TestMethod]
        public void OperatorExplicit_ConvertsPolynomialToArray()
        {
            // Arrange
            Polynomial p = new Polynomial(new double[] { 4, 5 });

            // Act
            double[] arr = (double[])p;

            // Assert
            Assert.AreEqual(4, arr[0]);
            Assert.AreEqual(5, arr[1]);
        }
        
        
        [TestMethod]
        public void Equals_TwoIdenticalPolynomials_ReturnsTrue()
        {
            // Arrange
            Polynomial a = new Polynomial(new double[] { 1, 2 });
            Polynomial b = new Polynomial(new double[] { 1, 2 });

            // Act
            bool equals = a == b;

            // Assert
            Assert.IsTrue(equals);
        }


        [TestMethod]
        public void OperatorTrueFalse_ZeroPolynomial_ReturnsFalse()
        {
            // Arrange
            Polynomial p = new Polynomial();

            // Act
            bool result = p ? true : false;

            // Assert
            Assert.IsFalse(result);
        }
    }
}
