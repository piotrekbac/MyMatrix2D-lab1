namespace Matrix2dLib
{
#nullable disable //to jest dyrektywa kompilatora, która wyłącza ostrzeżenia o nullach

    //immutable class - klasa niezmienna - nie można zmienić wartości pól tej klasy
    public class Matrix2d : IEquatable<Matrix2d>  //implementujemy interfejs IEquatable<Matrix2d> - to jest interfejs generyczny
    {
        private readonly int a, b, c, d;         //private fields - prywatne pola 

        /* 
              ---------
              |  a b  |
              |  c d  |
              ---------
         */

        //Teraz będziemy budować konstruktor - wprowadzenie danych do tych macierzy

        public Matrix2d(int a, int b, int c, int d)
        {
            this.a = a;                 //używamy this.a bo mamy konflikt nazw - a i a - jedno to pole klasy a drugie to argument konstruktora 
            this.b = b;
            this.c = c;
            this.d = d;
        } 

        //Teraz piszemy drugi konstruktor który tworzy Matrix2d bez argumentów - domyślny konstruktor

        //public Matrix2d()
        //{
        //    a = 1;
        //    b = 0;
        //    c = 0;
        //    d = 1;
        //}

        //Można napisać też prościej: 
        public Matrix2d() : this(1, 0, 0, 1) { }

        //public const Matrix2d Id = new Matrix2d(1, 0, 0, 1); - nie jesteśmy w stanie przypisać wartości do pola const w ten sposób

        public static  Matrix2d Id => new Matrix2d(1, 0, 0, 1);     //to jest właściwość - property typu get, to nie jest stała, property typu obliczeniowego

        public static  Matrix2d Zero => new Matrix2d(0, 0, 0, 0);   //to jest właściwość - property typu get, to nie jest stała, property typu obliczeniowego

        //Matrix2d jest niezminniczą zmienną - immutable - nie można zmienić wartości pól tej klasy

        //Implementujemy przesunięcie metody ToString()

        public override string ToString() => $"[[{a},{b}] , [{c},{d}]]";

        //Teraz będziemy definiować Equals, żeby to zrobić musimy na początku zaimplementować w klasie Matrix2d interfejs IEquatable<Matrix2d> - to jest interfejs generyczny

        //jakby dopisać pytajnik przed typem Matrix2d to wtedy można by było zwrócić null - to jest tzw. nullability - to jest nowa funkcjonalność w C# 8.0
        //ta derektywa #nullable disable wyłącza ostrzeżenia o nullach 
        public bool Equals(Matrix2d other)
        {
            if (other is null) return false; //jeżeli other jest nullem to zwracamy false
            return a == other.a && 
                   b == other.b && 
                   c == other.c && 
                   d == other.d; 

            //jeżeli a jest równe other.a i b jest równe other.b i c jest równe other.c i d jest równe other.d to zwracamy true
        }

        //Przysłąniecie metody Equals(object)
        public override bool Equals(object obj)
            => obj is Matrix2d m && Equals(m);

        //Metoda GetHashCode() - zgodna z implementacją równości Equals, opiera się na krotce (Tuple) -> (a, b, c, d)
        public override int GetHashCode()
            => (a, b, c, d).GetHashCode();


        //Teraz będziemy definiować operator ==
        public static bool operator ==(Matrix2d left, Matrix2d right) => left.Equals(right);
        //Definując operator == musimy zdefiniować operator != bo w innym wypadku nie będzie działać
        public static bool operator !=(Matrix2d left, Matrix2d right) => !left.Equals(right);

        //Teraz będziemy definiwoać operator dodawania macierzy + 
        public static Matrix2d operator +(Matrix2d left, Matrix2d right) 
            => new Matrix2d(left.a + right.a, left.b + right.b, 
                            left.c + right.c, left.d + right.d);

        public static Matrix2d operator -(Matrix2d left, Matrix2d right)
            => new Matrix2d(left.a - right.a, left.b - right.b,
                            left.c - right.c, left.d - right.d);

        //NA ZAJĘCIACH - Odpuszczamy sobie definiowanie operatora GetHashCode() - nie jest to konieczne w tym przypadku, bo nie będziemy korzystać z Dictornary ani HashSet

        //Teraz będziemy definiować operator mnożenia macierzy *
        public static Matrix2d operator *(Matrix2d left, Matrix2d right)
            => new Matrix2d(left.a * right.a + left.b * right.c, 
                            left.a * right.b + left.b * right.d,
                            left.c * right.a + left.d * right.c, 
                            left.c * right.b + left.d * right.d);

        //to się nazywa przeciązaniem operatora - operator * jest przeciążony, zatem napiszemy teraz mnożenie macierzy przez liczbę 

        //Teraz będziemy definiować operator mnożenia macierzy przez liczbę * - w jedną stronę - prawostronnie
        public static Matrix2d operator *(int k, Matrix2d macierz)
            => new Matrix2d(k * macierz.a, k * macierz.b, 
                            k * macierz.c, k * macierz.d);
        //dzięki temu, że mamy różne argumenty w operatorze * to możemy przeciążyć ten operator, w jednym przypadku mnożymy macierz przez macierz, a w drugim przez liczbę (oznaczoną jako k)

        //Teraz będziemy definiować operator mnożenia macierzy przez liczbę * - w drugą stronę - lewostronnie
        public static Matrix2d operator *(Matrix2d macierz, int k)
            => k * macierz; //to jest wywołanie operatora * zdefiniowanego wyżej

        public static Matrix2d operator -(Matrix2d macierz)
            => -1 * macierz;

        //Teraz będziemy implementować transpozycję macierzy - Transpose(A) - zamieniamy wiersze na kolumny i kolumny na wiersze
        public static Matrix2d Transpoze(Matrix2d m) //static - oznacza że jest to metoda zdefiniowana na potrzeby klasy 
            => new Matrix2d(m.a, m.c, m.b, m.d);

        //Pomijamy krok 9 - funkcje obliczające wyznacznik macierzy 

        //Metoda obliczająca wyznacznik macierzy 
        public static int Determinant(Matrix2d m)
            => m.a * m.d - m.b * m.c;

        //Wyznacznik macierzy - a konkretniej jego instancja
        public int Det() => Determinant(this);

        //Implementacja rzutowania macierzy na tablicę regularną - int[2,2] 
        public static explicit operator int[,](Matrix2d m) 
            => new int[2, 2] { { m.a, m.b }, { m.c, m.d } };

        //powyżej konwerter, tworzy tablicę 2x2 i przypisuje wartości z macierzy m

        //Metoda Parse, która zgłosi wyjątek FormatException jeżeli nie będzie można sparsować stringa na macierz 2x2
        public static Matrix2d Parse(string s)
        {
            try
            {
                var parts = s.Replace("[", "").Replace("]", "").Split(',');
                if (parts.Length != 4)
                    throw new FormatException("Element musi zawierać dokładnie 4 elementy!");

                if (int.TryParse(parts[0], out int a) ||
                    int.TryParse(parts[1], out int b) ||
                    int.TryParse(parts[2], out int c) ||
                    int.TryParse(parts[3], out int d))
                {
                    throw new FormatException("Pierwszy element nie jest liczbą całkowitą!");
                }              
                return new Matrix2d(a, b, c, d);
            }

            catch
            {
                throw new FormatException("Niewłaściwy format. Właściwym formatem jest: [[a,b] , [c,d]].");
            }        
        }
    }
}
