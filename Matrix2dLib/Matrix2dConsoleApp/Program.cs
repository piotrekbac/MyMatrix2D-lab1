//pamiętaj aby ustawić zależności projeków od siebie, prawym na Matrix2dConsoleLab zależności -> dodaj odwołanie do projektu -> Matrix2d.cs

using Matrix2dLib;

//var m = new Matrix2d();
//Console.WriteLine(m);

//var m1 = new Matrix2d(1,2,3,4);
//Console.WriteLine(m1);

////od kroku 8 

//var m2 = Matrix2d.Transpoze(m1);

//var m3 = (int[,])m2;

//Powyższą część kodu realizowaliśmy na labolatoriach - w ramach przykładu

Console.WriteLine("------------------------------------------------------------------------------");
Console.WriteLine();

var MatrixId = Matrix2d.Id;
var MatrixZero = Matrix2d.Zero;

Console.WriteLine("Id naszego Matrixa:");
Console.WriteLine(MatrixId);

Console.WriteLine("MatrixZero (czyli innymi słowy macierz z zawartością 0):");
Console.WriteLine(MatrixZero);

var macierz1 = new Matrix2d(1, 2, 3, 4);
var macierz2 = new Matrix2d(2, 0, 1, 2);

Console.WriteLine("Oto wartość naszego matrix1:");
Console.WriteLine(macierz1);

Console.WriteLine("Oto wartość naszego matrix2:");
Console.WriteLine(macierz2);

var sumaMacierzy = macierz1 + macierz2;
Console.WriteLine("Suma matrix1 oraz matrix2");
Console.WriteLine(sumaMacierzy);

var wynikMnozenia = macierz1 * macierz2;
Console.WriteLine("WynikMnozenia matrix1 przez matrix2:");
Console.WriteLine(wynikMnozenia);

var poTranspozycji = Matrix2d.Transpoze(macierz1);
Console.WriteLine("Nasza macierz1 po tranposyzji prezentuje się w ten sposób:");
Console.WriteLine(poTranspozycji);

var determinanta = macierz1.Det();
Console.WriteLine($"Detereminantą naszej macierzy matrix1 jest: {determinanta}");

var sparsowanyMatrix = Matrix2d.Parse("[[1,2] , [3,4]]");
Console.WriteLine("Nasza macierz po sparsowaniu, prezentuje się następująco:");
Console.WriteLine(sparsowanyMatrix);

Console.WriteLine();
Console.WriteLine("------------------------------------------------------------------------------");