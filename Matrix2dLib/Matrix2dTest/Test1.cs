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
        [TestMethod]
        public void TestMatrixDomyslnyKonstruktor()
        {
            //Arrange 
            var domyslnyMatrix = new Matrix2d();

            //Act i Assert
            Assert.AreEqual("[[1,0] , [0,1]]", domyslnyMatrix.ToString());
        }

        //Testujemy czy macierz poprawnie odejmuje dwie macierze - operator odejmowanie 
        [TestMethod]
        public void TestMatrixOdejmowanie()
        {
            //Arrange 
            var m1 = new Matrix2d(1, 2, 3, 4);
            var m2 = new Matrix2d(2, 0, 1, 2);

            //Act
            var matrixRoznica = m1 - m2;

            //Assert
            Assert.AreEqual("[[-1,2] , [2,2]]", matrixRoznica.ToString());
        }

        //Testujemy czy macierz poprawnie mnoży dwie macierze - operator mnożenia
        [TestMethod]
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

        //Testtujemy czy macierz poprawnie mnoży przez skalar (liczbę całkowitą) z LEWEJ strony działania - operator mnożenia
        [TestMethod]
        public void TestMatrixMnozenieSkalarLewo()
        {
            //Arrange
            var matrix = new Matrix2d(1, 2, 3, 4);

            //Act
            var wynik = 2 * matrix;

            //Assert
            Assert.AreEqual("[[2,4] , [6,8]]", wynik.ToString());
        }

        //Testujemy czy macierz poprawnie mnoży przez skalar (liczbę całkowitą) z PRAWEJ strony działania - operator mnożenia
        [TestMethod]
        public void TestMatrixMnozenieSkalarPrawo()
        {
            //Arrange
            var matrix = new Matrix2d(1, 2, 3, 4);

            //Act
            var wynik = matrix * 2;

            //Assert
            Assert.AreEqual("[[2,4] , [6,8]]", wynik.ToString());
        }

        //Testujemy poprawność metody negacji macierzy (zmiana znaków macierzy na przeciwne).
        [TestMethod]
        public void TestMatrixNegacja()
        {
            //Arrange 
            var matrix = new Matrix2d(1, 2, 3, 4);

            //Act
            var negacja = -matrix;

            //Assert
            Assert.AreEqual("[[-1,-2] , [-3,-4]]", negacja.ToString());
        }

        //Testujemy poprawność metody transpozycji macierzy (zamiana wierszy na kolumny i kolumn na wiersze).
        [TestMethod]
        public void TestMatrixTranspozycja()
        {
            //Arrange 
            var matrix = new Matrix2d(1, 2, 3, 4);
            //Act
            var transpozycja = Matrix2d.Transpoze(matrix);
            //Assert
            Assert.AreEqual("[[1,3] , [2,4]]", transpozycja.ToString());
        }

    }
}