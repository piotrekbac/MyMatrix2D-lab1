//pamiętaj aby ustawić zależności projeków od siebie, prawym na Matrix2dConsoleLab zależności -> dodaj odwołanie do projektu -> Matrix2d.cs

using Matrix2dLib;

var m = new Matrix2d();
Console.WriteLine(m);

var m1 = new Matrix2d(1,2,3,4);
Console.WriteLine(m1);

//od kroku 8 

var m2 = Matrix2d.Transpoze(m1);

var m3 = (int[,])m2;

