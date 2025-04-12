using Microsoft.VisualStudio.TestTools.UnitTesting;
using Matrix2dLib;
using System;

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


    }
}