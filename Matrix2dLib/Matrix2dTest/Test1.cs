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

        //Testujemy poprawność metody obliczania wyznacznika (determinanty w skrócie DET)
        [TestMethod]
        public void TestMatrixDeterminanta()
        {
            //Arrange 
            var matrix = new Matrix2d(1, 2, 3, 4);

            //Act i Assert
            Assert.AreEqual(-2, matrix.Det());
        }

        //Testujemy poprawność metody macierzy na tablicę 2x2 (dwuwymiarową)
        [TestMethod]
        public void TestRzutowanieMacierzyNaTabliceDwuwymiarowa()
        {
            //Arrange
            var matrix = new Matrix2d(1, 2, 3, 4);
            var tablica = (int[,])matrix;

            //Act i Assert
            Assert.AreEqual(1, tablica[0, 0]);
            Assert.AreEqual(2, tablica[0, 1]);
            Assert.AreEqual(3, tablica[1, 0]);
            Assert.AreEqual(4, tablica[1, 1]);
        }

        //Testujemy poprawność metody Parse, która zamienia stringa na macierz 2x2
        [TestMethod]
        public void TestMatrixMetodaParse()
        {
            //Arrange 
            var matrixSparsowany = Matrix2d.Parse("[[1,2] , [3,4]]");

            //Act i Assert
            Assert.AreEqual("[[1,2] , [3,4]]", matrixSparsowany.ToString());
        }

        //Testujemy czy metoda Parse zgłasza wyjątek FormatException, gdy ciąg wejściowy ma zbyt mało elementów
        [TestMethod]
        public void TestMatrixMetodaParse_ZbytMaloElementow()
        {
           //Assert
           Assert.ThrowsException<FormatException>(() => Matrix2d.Parse("[[1,2] , [3]]"));
        }

        //Testujemy czy metoda Parse zgłasza wyjątek FormatException, gdy ciąg wejściowy ma zbyt dużo elementów
        [TestMethod]
        public void TestMatrixMetodaParse_ZbytDuzoElementow()
        {
           //Assert
           Assert.ThrowsException<FormatException>(() => Matrix2d.Parse("[[1,2] , [3,4,5]]"));
        }

        [TestMethod]
        public void TestMatrixMetodaParse_ElementKtoryNieJestLiczba()
        {
            //Assert
            Assert.ThrowsException<FormatException>(() => Matrix2d.Parse("[[1,2] , [3,x]]"));
        }

        [TestMethod]
        public void TestMatrixMetodaParase_PustePoleDanychWejsciowych()
        {
            //Assert
            Assert.ThrowsException<FormatException>(() => Matrix2d.Parse(""));
        }

        

        //Testujemy czy macierz jest poprawnie porównywana z inną macierzą (w tym przypadku wypełnioną nullami) - testowanie metody Equals
        [TestMethod]
        public void TestMatrixRownoscNullom()
        {
            //Arrange 
            var matrix = new Matrix2d(1, 2, 3, 4);

            //Act
            Matrix2d matrixDruga = null;

            //Assert    
            Assert.IsFalse(matrix.Equals(matrixDruga));
        }

        //Testujemy czy metoda Equals poprawnie rozpoznaje dwie macierze takie same, jako równe sobie
        [TestMethod]
        public void TestMatrixRownoscWzgledemMacierzy()
        {
            //Arrange
           var matrix1 = new Matrix2d(1, 2, 3, 4);
           var matrix2 = new Matrix2d(1, 2, 3, 4);

            //Act i Assert
            Assert.IsTrue(matrix1.Equals(matrix2));

        }

        //Testowanie metody Equals czy poprawnie rozpoznaje ona, że diwe różne macierze są sobie nierówne
        [TestMethod]
        public void TestMatrixNierownoscWzgledemMacierzy()
        {
            //Arrange
            var matrix1 = new Matrix2d(1, 2, 3, 4);
            var matrix2 = new Matrix2d(1, 2, 3, 5);

            //Act i Assert
            Assert.IsFalse(matrix1.Equals(matrix2));
        }

        //Testujemy czy metoda Equals() działa poprawnie, gdy porównujemy macierze rzutowane jako obiekt
        [TestMethod]
        public void TestMatrixRzutowanieMacierzyJakoObiekt()
        {
            //Arrange 
            var matrix = new Matrix2d(1, 2, 3, 4);
            object matrix2 = new Matrix2d(2, 0, 1, 2);

            //Act i Assert 
            Assert.IsFalse(matrix.Equals(matrix2));
        }

        //Testujemy czy metoda Equals() zwraca false, gdy porównujemy macierz z obiektem innego typu 
        [TestMethod]
        public void TestMatrixMetodaEqualsZRoznymiTypami()
        {
            //Arrange 
            var matrix = new Matrix2d(1, 2, 3, 4);
            object objekt = "To nie jest obiekt Matrix2d";

            //Act i Assert
            Assert.IsFalse(matrix.Equals(objekt));
        }

        //Testujemy czy metoda GetHashCode() zwraca ten sam kod haszujący dla tej samej macierzy
        [TestMethod]
        public void TestMatrixGetHashCode()
        {
            //Arrange
            var matrix = new Matrix2d(1, 2, 3, 4);

            //Act
            var hashCode = matrix.GetHashCode();

            //Assert
            Assert.AreEqual(hashCode, matrix.GetHashCode());

        }

        //Testujemy czy metoda GetHashCode() zgłasza wyjątek FormatException, gdy nie można sparsować stringa na macierz 2x2 ze względu na niepoprawny format danych wejściowych
        [TestMethod]
        public void TestMatrixGetHashCodeZRoznymiTypami()
        {
            //Arrange 
            var matrix = new Matrix2d(1, 2, 3, 4);
            object objekt = "To nie jest obiekt Matrix2d";
            //Act i Assert
            Assert.IsFalse(matrix.GetHashCode().Equals(objekt.GetHashCode()));
        }

        //Testujemy operator porównania macierzy (==)
        [TestMethod]
        public void TestMatrixOperatorRownosci()
        {
            //Arrange 
            var matrix1 = new Matrix2d(1, 2, 3, 4);
            var matrix2 = new Matrix2d(1, 2, 3, 4);
            //Act i Assert
            Assert.IsTrue(matrix1 == matrix2);
        }

        //Testujemy operator nierówności macierzy (!=)
        [TestMethod]
        public void TestMatrixOperatorNierownosci()
        {
            //Arrange 
            var matrix1 = new Matrix2d(1, 2, 3, 4);
            var matrix2 = new Matrix2d(1, 2, 3, 5);
            //Act i Assert
            Assert.IsTrue(matrix1 != matrix2);
        }

    }
}