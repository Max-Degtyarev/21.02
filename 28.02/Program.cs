//#define EXM1
//#define EXM2
//#define EXM3
#define EXM4
//#define EXM5
//#define EXM6

using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


// синтаксис индексатора

//Type this[typeOfArgument] { get; set }


namespace _28._02
{


#if EXM1
    class CPoint
    {
        public int X { get; set; }

        public int Y { get; set; }



    }

    struct SPoint
    {
        public int X { get; set; }

        public int Y { get; set; }

    } 
#endif




#if EXM2
    class Point
    {

        public int X { get; set; }
        public int Y { get; set; }


        //переопределение делается для того, чтобы ссылочные типы
        //сравнивались по значениям, как и значимые типы

        public override bool Equals(object obj)
        {
            return this.ToString() == obj.ToString();

        }


        // переопределение в паре с Equals, чтобы объекты ссылочных
        // типов имели одинаковый хеш-код после сравнения значений
        // методом Equals
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }


        public static bool operator ==(Point p1, Point p2)
        {

            return p1.Equals(p2);

        }

        public static bool operator !=(Point p1, Point p2)
        {

            return !(p1 == p2);

        }

        public static bool operator >(Point p1, Point p2)
        {

            return Math.Sqrt(p1.X * p1.X + p1.Y * p1.Y) < Math.Sqrt(p2.X * p2.X + p2.Y * p2.Y);

        }


        public static bool operator <(Point p1, Point p2)
        {
            return Math.Sqrt(p1.X * p1.X + p1.Y * p1.Y) > Math.Sqrt(p2.X * p2.X + p2.Y * p2.Y);

        }



    } 
#endif



#if EXM3
    class Point
    {

        public int X { get; set; }
        public int Y { get; set; }


        public static bool operator true(Point p)
        {

            return p.X != 0 || p.Y != 0 ? true : false;

        }

        public static bool operator false(Point p)
        {

            return p.X == 0 && p.Y == 0 ? true : false;

        }


        public static Point operator |(Point p1, Point p2)
        {

            if ((p1.X != 0 || p1.Y != 0) || (p2.X != 0 || p2.Y != 0))
            {
                return p2;

            }
            return new Point();


        }

        public static Point operator &(Point p1, Point p2)
        {

            if ((p1.X != 0 && p1.Y != 0) && (p2.X != 0 && p2.Y != 0))
            {
                return p2;

            }
            return new Point();


        }


        //public override string ToString()
        //{

        //    return ();

        //}





    } 
#endif



#if EXM4
    class Laptop
    {

        public string Brand { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return $"{Brand} {Price}";
        }

    }

    class Shop
    {

        Laptop[] laptopArr;

        public Shop(int size)
        {

            laptopArr = new Laptop[size];

        }

        public int Length
        {

            get { return laptopArr.Length; }

        }

        public Laptop this[int index]
        {

            get
            {

                if (index >= 0 && index < laptopArr.Length)
                {
                    return laptopArr[index];

                }
                throw new IndexOutOfRangeException();

            }

            set
            {

                laptopArr[index] = value;

            }


        }






    } 
#endif


#if EXM5
    class MultiArray
    {

        private int[,] array;
        public int Rows { get; private set; }
        public int Cols { get; private set; }


        public MultiArray(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            array = new int[rows, cols];


        }

        public int this[int r, int c]
        {
            get { return array[r, c]; }
            set { array[r, c] = value; }



        }



    } 
#endif



#if EXM6
    class Laptop
    {

        public string Brand { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return $"{Brand} {Price}";
        }

    }


    enum Brands
    {
        Apple, Asus, Lenovo

    };



    class Shop
    {

        Laptop[] laptopArr;

        public Shop(int size)
        {

            laptopArr = new Laptop[size];

        }

        public int Length
        {

            get { return laptopArr.Length; }

        }

        public Laptop this[int index]
        {

            get
            {

                if (index >= 0 && index < laptopArr.Length)
                {
                    return laptopArr[index];

                }
                throw new IndexOutOfRangeException();

            }

            set
            {

                laptopArr[index] = value;

            }


        }


        public Laptop this[string name]
        {

            get
            {
                if (Enum.IsDefined(typeof(Brands), name))
                {

                    return laptopArr[(int)Enum.Parse(typeof(Brands), name)];

                }
                //else
                //{
                //    return new Laptop();

                //}

                throw new Exception("Неверное имя");


            }
            set
            {
                if (Enum.IsDefined(typeof(Brands), name))
                {
                    laptopArr[(int)Enum.Parse(typeof(Brands), name)] = value;


                }


            }
        }


        public int FindByPrice(double price)
        {

            for (int i = 0; i < laptopArr.Length; i++)
            {

                if (laptopArr[i].Price == price)
                {
                    return i;

                }

            }
            return -1;


        }


        public Laptop this[double price]
        {
            get
            {

                if (FindByPrice(price) >= 0)
                {

                    return this[FindByPrice(price)];

                }
                throw new Exception("Недопустимая стоимость");
            }
            set
            {


                if (FindByPrice(price) >= 0)
                {

                    this[FindByPrice(price)] = value;

                }


            }




        } 





    }

#endif





    internal class Program
    {

        static void Main(string[] args)
        {

#if EXM1
            CPoint cp = new CPoint { X = 10, Y = 10 };
            CPoint cp1 = new CPoint { X = 10, Y = 10 };
            CPoint cp2 = cp1;

            // Здесь будет false, так как разные адреса памяти
            WriteLine($"ReferenceEquals(cp, cp1) = {ReferenceEquals(cp, cp1)}");

            // Здесь будет true, так как адрес одинаковый
            WriteLine($"ReferenceEquals(cp1, cp2) = {ReferenceEquals(cp1, cp2)}");

            SPoint sp = new SPoint { X = 10, Y = 10 };
            SPoint sp1 = new SPoint { X = 10, Y = 10 };


            // Для значимых типов создаются ссылки м результат всегда будет false
            WriteLine($"ReferenceEquals(sp, sp1) = {ReferenceEquals(sp, sp1)}");

            // Для ссылочных типов сравниваются адреса
            WriteLine($"Equals(cp, cp1) = {Equals(cp, cp1)}");

            // Для значимых типов сравниваются значения полей
            WriteLine($"Equals(sp, sp1) = {Equals(sp, sp1)}"); 
#endif

#if EXM2
            Point p1 = new Point { X = 10, Y = 10 };
            Point p2 = new Point { X = 20, Y = 20 };


            WriteLine($"Point 1: {p1}");
            WriteLine($"Point 2: {p2}");

            WriteLine($"Point 1 == Point 2: {p1 == p2}");
            WriteLine($"Point 1 != Point 2: {p1 != p2}");
            WriteLine($"Point 1 > Point 2: {p1 > p2}");
            WriteLine($"Point 1 < Point 2: {p1 < p2}"); 
#endif



#if EXM3
            Point p1 = new Point { X = 10, Y = 10 };
            Point p2 = new Point { X = 0, Y = 0 };


            WriteLine($"Point 1: {p1}");
            WriteLine($"Point 2: {p2}");


            WriteLine("Point 1 && Point 2: ");

            if (p1 && p2)
            {
                WriteLine("true");

            }
            else
            {

                WriteLine("false");
            }

            WriteLine("Point 1 || Point 2: ");

            if (p1 || p2)
            {
                WriteLine("true");

            }
            else
            {

                WriteLine("false");
            } 
#endif


#if EXM4
            Shop laptops = new Shop(3);
            laptops[0] = new Laptop { Brand = "Apple", Price = 50000 };
            laptops[1] = new Laptop { Brand = "Asus", Price = 70000 };
            laptops[2] = new Laptop { Brand = "Lenovo", Price = 40000 };

            try
            {
                for (int i = 0; i < laptops.Length; i++)
                {

                    WriteLine(laptops[i]);

                }

            }
            catch (Exception ex)
            {

                WriteLine(ex.Message);

            } 
#endif

#if EXM5
            MultiArray multi = new MultiArray(2, 3);
            for (int i = 0; i < multi.Rows; i++)
            {

                for (int j = 0; j < multi.Cols; j++)
                {

                    multi[i, j] = i + j;
                    Write($"{multi[i, j]} ");

                }
                WriteLine();

            } 
#endif



#if EXM6
        Shop laptops = new Shop(3);
        laptops[0] = new Laptop { Brand = "Apple", Price = 50000 };
        laptops[1] = new Laptop { Brand = "Asus", Price = 70000 };
        laptops[2] = new Laptop { Brand = "Lenovo", Price = 40000 };

        try
        {
            for (int i = 0; i < laptops.Length; i++)
            {

                WriteLine(laptops[i]);

            }
            WriteLine();
            WriteLine($"Производитель Apple: {laptops["Apple"]}");
            WriteLine($"Производитель Asus: {laptops["Asus"]}");
            WriteLine($"Производитель Lenovo: {laptops["Lenovo"]}");

            WriteLine($"Стоимость 50000: {laptops[50000.00]}");
            WriteLine($"Стоимость 70000: {laptops[70000.00]}");
            WriteLine($"Стоимость 40000: {laptops[40000.00]}");



        }
        catch (Exception ex)
        {

            WriteLine(ex.Message);

        } 
#endif




        }

    }
    
}
