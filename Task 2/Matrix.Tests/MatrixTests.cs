using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matrix.Matrices;

namespace Matrix.Tests
{
    [TestFixture]
    public class MatrixTests
    {
        [Test]
        public void SymmetricMatrixInsert_ValidIntFormat_ValidResult()
        {
            int[,] arr = new int[,] {
                { 0, 1, 2 },
                { 1, 3, 4 },
                { 2, 4, 5 } };

            SymmetricMatix<int> sm = new SymmetricMatix<int>(3, arr);
            sm.InsertElement(0, 2, 6);

            Assert.AreEqual(arr[0, 2], 6);
            Assert.AreEqual(arr[2, 0], 6);
        }

        [Test]
        public void SquareMatrixMatrixInsert_ValidIntFormat_ValidResult()
        {
            int[,] arr = new int[,] {
                { 0, 1, 2 },
                { 1, 3, 4 },
                { 2, 4, 5 } };

            SquareMatrix<int> sm = new SquareMatrix<int>(3, arr);
            sm.InsertElement(0, 2, 6);
            sm.InsertElement(1, 1, 68);

            Assert.AreEqual(arr[0, 2], 6);
            Assert.AreEqual(arr[1, 1], 6);
        }

        [Test]
        public void DiagonalMatrixInsert_ValidIntFormat_ValidResult()
        {
            int[,] arr = new int[,] {
                { 0, 0, 0 },
                { 0, 3, 0 },
                { 0, 0, 5 } };

            DiagonalMatrix<int> sm = new DiagonalMatrix<int>(3, arr);
            sm.InsertElement(2, 2, 2);
            sm.InsertElement(1, 1, 9);

            Assert.AreEqual(arr[2, 2], 2);
            Assert.AreEqual(arr[1, 1], 9);
        }

        [Test]
        public void MatrixSummator_ValidIntFormat_ValidResult()
        {
            int[,] arr = new int[,] {
                { 0, 1, 2 },
                { 1, 3, 4 },
                { 2, 4, 5 } };

            int[,] arr2 = new int[,] {
                { 0, 0, 0 },
                { 0, 3, 0 },
                { 0, 0, 5 } };

            SymmetricMatix<int> sm = new SymmetricMatix<int>(3, arr);
            DiagonalMatrix<int> dm = new DiagonalMatrix<int>(3, arr2);           

            var t = MatrixSummator.SumTwoMatrix(dm, sm);

            Assert.AreEqual(t[1, 1], 6);
            Assert.AreEqual(t[1, 2], 4);
        }
    }
}
