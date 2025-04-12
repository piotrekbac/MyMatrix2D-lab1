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

var idMatrix = Matrix2d.Id;
var zeroMatrix = Matrix2d.Zero;

Console.WriteLine("Identity Matrix:");
Console.WriteLine(idMatrix);

Console.WriteLine("Zero Matrix:");
Console.WriteLine(zeroMatrix);

var m1 = new Matrix2d(1, 2, 3, 4);
var m2 = new Matrix2d(2, 0, 1, 2);

Console.WriteLine("Matrix m1:");
Console.WriteLine(m1);

Console.WriteLine("Matrix m2:");
Console.WriteLine(m2);

var sum = m1 + m2;
Console.WriteLine("Sum of m1 and m2:");
Console.WriteLine(sum);

var product = m1 * m2;
Console.WriteLine("Product of m1 and m2:");
Console.WriteLine(product);

var transposed = Matrix2d.Transpoze(m1);
Console.WriteLine("Transposed m1:");
Console.WriteLine(transposed);

var determinant = m1.Det();
Console.WriteLine($"Determinant of m1: {determinant}");

var parsedMatrix = Matrix2d.Parse("[[1,2] , [3,4]]");
Console.WriteLine("Parsed Matrix:");
Console.WriteLine(parsedMatrix);

Console.WriteLine();
Console.WriteLine("------------------------------------------------------------------------------");