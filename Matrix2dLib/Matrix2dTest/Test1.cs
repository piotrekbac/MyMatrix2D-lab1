using Microsoft.VisualStudio.TestTools.UnitTesting;
using Matrix2dLib;
using System;
using Newtonsoft.Json.Bson;

namespace Matrix2dTests
{
    [TestClass]
    public class Matrix2dTests
    {
        //Testujemy czy macierz jest poprawnie inicjowana 
        [TestMethod]
        public void TestMatrixPoprawnaInicjowanie()
        {
            //Arrrange 
            var matrixId = Matrix2d.Id;

            //Act i Assert
            Assert.AreEqual("[[1,0] , [0,1]]", matrixId.ToString());
        }

        //Testujemy czy macierz zerowa jest poprawnie inicjowana
        [TestMethod]
        public void TestMatrixZeroInicjowanie()
        {
            //Arrange 
            var matrixZero = Matrix2d.Zero;

            //Act i Assert
            Assert.AreEqual("[[0,0] , [0,0]]", matrixZero.ToString());
        }

        //Testujemy czy macierz poprawnie dodaje dwie macierze - operator dodawania
        [TestMethod]
        public void TestMatrixDodanieDwochMacierz()
        {
            //Arrange 
            var m1 = new Matrix2d(1, 2, 3, 4);
            var m2 = new Matrix2d(2, 0, 1, 2);

            //Act
            var MatrixSuma = m1 + m2;

            //Assert
            Assert.AreEqual("[[3,2] , [4,6]]", MatrixSuma.ToString());
        }

        //Testujemy domyślny konstruktor macierzy
        public void TestMatrixDomyslnyKonstruktor()
        {
            //Arrange 
            var domyslnyMatrix = new Matrix2d();

            //Act i Assert
            Assert.AreEqual("[1,0] , [0,1]", domyslnyMatrix.ToString());
        }

        //Testujemy czy macierz poprawnie odejmuje dwie macierze - operator odejmowanie 
        public void TestMatrixOdejmowanie()
        {
            //Arrange 
            var m1 = new Matrix2d(1, 2, 3, 4);
            var m2 = new Matrix2d(2, 0, 1, 2);

            //Act
            var matrixRoznica = m1 - m2;

            //Assert
            Assert.AreEqual("[[-1,-2] , [2,-2]]", matrixRoznica.ToString());
        }

        //Testujemy czy macierz poprawnie mnoży dwie macierze - operator mnożenia
        public void TestMatrixMnozenie()
        {
            //Arrange 
            var m1 = new Matrix2d(1, 2, 3, 4);
            var m2 = new Matrix2d(2, 0, 1, 2);

            //Act
            var matrixMnozenie = m1 * m2; 

            //Assert
            Assert.AreEqual("[[4,4] , [10,8]]", matrixMnozenie.ToString());
        }


    }
}