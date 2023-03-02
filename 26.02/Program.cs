//#define EXM1
//#define EXM2
//#define EXM3
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Console;

namespace _26._02
{
    internal class Program
    {

        class Human
        {

            string _firstName;
            string _lastName;
            DateTime _birthDate;


            public Human(string fName, string lName, DateTime date)
            {
                _firstName = fName;
                _lastName = lName;
                _birthDate = date;

            }

            public virtual void Print()
            {

                WriteLine($"\nИмя: {_firstName}\nФамилия: {_lastName}\nДата рождения: {_birthDate.ToShortDateString()}\n");

            }

        }

        class Employee : Human
        {

            double _salary;

            public Employee(string fName, string lName, DateTime date, double salary): base(fName, lName, date)
            {
                _salary = salary;

            }

            public override void Print()
            {
                base.Print();
                WriteLine($"Заработная плата: {_salary} $");
            }

        }

        class Developer : Employee
        {
            string _language;

            public Developer(string fName, string lName, DateTime date, double salary, string language): base(fName, lName, date, salary)
            {
                _language = language;

            }

            public override void Print()
            {
                base.Print();
                WriteLine($"Язык программирования: {_language}\n");
            }


        }

        class Designer : Employee
        {

            string _fiedActivity;

            public Designer(string fName, string lName, DateTime date, double salary, string activity): base(fName, lName, date, salary)
            {
                _fiedActivity = activity;

            }

            public override void Print()
            {
                base.Print();
                WriteLine($"Сфера деятельности: {_fiedActivity}");
            }

        }

        class Specialist : Employee
        {
            string _qualification;

            public Specialist(string fName, string lName, DateTime date, double salary, string qualification): base(fName, lName, date, salary)
            {
                _qualification = qualification;

            }

            public override void Print()
            {
                base.Print();

            }

        }


        //////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////


        public abstract class Human2
        {

            string _firstName;
            string _lastName;
            DateTime _birthDate;


            public Human2(string fName, string lName, DateTime date)
            {
                _firstName = fName;
                _lastName = lName;
                _birthDate = date;

            }

            public abstract void Said();


            public override string ToString()
            {

                return $"\nИмя: {_firstName}\nФамилия: {_lastName}\nДата рождения: {_birthDate.ToShortDateString()}";

            }

        }


        abstract class Learner : Human2
        {

            string _institut;

            public Learner(string fName, string lName, DateTime date, string institut): base(fName, lName, date)
            {
                _institut = institut;

            }

            public abstract void Study();

            public override string ToString()
            {
                return base.ToString() + $"\nУчебное заведение: {_institut}";

            }

        }


        class Student : Learner
        {

            string _groupName;

            public Student(string fName, string lName, DateTime date, string institut, string groupName): base(fName, lName, date, institut)
            {

                _groupName = groupName;

            }

            public override void Said()
            {
                WriteLine("Поставьте мне зачет автоматом");
            }

            public override void Study()
            {
                WriteLine("Я изучаю что-то в институте");

            }

            public override string ToString()
            {
                //base.Print();
                return base.ToString() + $"\nЯ учусь в группе: {_groupName}";
            }


        }

        class SchoolChild : Learner
        {

            string _className;

            public SchoolChild(string fName, string lName, DateTime date, string institut, string className) : base(fName, lName, date, institut)
            {
                _className = className;
            }


            public override void Said()
            {
                WriteLine("Я сегодня получил три пятерки");
            }

            public override void Study()
            {
                WriteLine("Я изучаю все предметы в школе, мне очень интересно");

            }

            public override string ToString()
            {
                return base.ToString() + $"\nЯ учусь в классе: {_className}";
            }

                       

        }


        ////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////


        class Point
        {

            public int X { get; set; }
            public int Y { get; set; }

            public static Point operator++(Point s)
            {
                s.X++;
                s.Y++;
                return s;

            }
            public static Point operator--(Point s)
            {
                s.X--;
                s.Y--;
                return s;

            }

            public static Point operator-(Point s)
            {

                return new Point { X = -s.X, Y = -s.Y };

            }

            public override string ToString()
            {
                return $"Point: X = {X}, Y = {Y}";  
            }



        }



        class Point2
        {

            public int X { get; set; }
            public int Y { get; set; }



        }

        class Vector
        {


            public int X { get; set; }
            public int Y { get; set; }

            public Vector() { }
            public Vector(Point2 begin, Point2 end)
            {
                X = end.X - begin.X;
                Y = end.Y - begin.Y;


            }


            public static Vector operator +(Vector v1, Vector v2)
            {

                return new Vector { X = v1.X + v2.X, Y = v1.Y + v2.Y };


            }

            public static Vector operator -(Vector v1, Vector v2)
            {

                return new Vector { X = v1.X - v2.X, Y = v1.Y - v2.Y };


            }

            public static Vector operator*(Vector v, int n)
            {

                v.X *= n;
                v.Y *= n;
                return v;

            }


            public override string ToString()
            {
                return $"Vector: X = {X}, Y = {Y}";
            }


        }





        static void Main(string[] args)
        {

#if EXM1
            //Human employee = new Employee("John", "Connor", DateTime.Now, 1200);
            //employee.Print();


            //Human developer = new Developer("Mark", "Zukerberg", new DateTime(1983, 2, 13), 123000, "Python");
            //developer.Print();


            Human[] people =
            {

                new Developer("Bill", "Gates", new DateTime(1956, 6, 15), 34500, "C#"),
                new Designer("Andy", "Warholl", new DateTime(1943, 3, 27), 56000, "Art"),
                new Specialist("Arkadij", "Ukupnik", new DateTime (1956, 4, 12), 12000, "MSQL - Admin")


            };


            foreach (Human item in people)
            {

                item.Print();

            } 
#endif


#if EXM2
            Learner[] learners =
            {

                new Student("Аристарх", "Пирогов", new DateTime(1963, 5, 26), "MGU Moscow", "ITPRST112"),
                new SchoolChild("Вовка", "Коневский", new DateTime(1586, 7, 30), "Saint Peterbourg Middle School", "6-PW")


            };

            foreach (Learner item in learners)
            {

                WriteLine(item);
                item.Study();
                item.Said();

            }


            Student student = new Student("Артем", "Кирпичный", new DateTime(1986, 12, 25), "Harward", "23RPO");
            WriteLine(student.ToString());
            WriteLine($"Полное имя типа - {student.GetType().FullName}");
            WriteLine($"Имя текущего элемента - {student.GetType().Name}");
            WriteLine($"Базовый класс текущего элемента - {student.GetType().BaseType}");
            WriteLine($"Является ли текущий элемент абстрактным объектом - {student.GetType().IsAbstract}");
            WriteLine($"Является ли объект классом - {student.GetType().IsClass}");
            WriteLine($"Можно ли получить доступ к объекту из кода за пределами сборки - {student.GetType().IsVisible}");

#endif


#if EXM3
            Point point = new Point { X = 10, Y = 10 };
            WriteLine($"Исходная точка: {point}");
            WriteLine("Префиксная и постфиксная форма инкремента выполняются одинаково");
            WriteLine(++point);
            WriteLine(point++);
            WriteLine($"Префиксная форма декремента {--point}");
            WriteLine($"Выполнение оператора - {-point} не изменило исходную ");

#endif



            Point2 p1 = new Point2 { X = 2, Y = 3 };
            Point2 p2 = new Point2 { X = 5, Y = 6 };

            Vector v1 = new Vector(p1, p2);
            Vector v2 = new Vector { X = 2, Y = 3 };

            WriteLine($"Векторы\n{v1}\n{v2}\n");
            WriteLine($"Сложение векторов\n{v1 + v2}\n");
            WriteLine($"Разность векторов\n{v1 - v2}\n");
            Write("Введите целое число: ");
            int n = int.Parse(ReadLine());
            v1 *= n;
            WriteLine($"\nУмножение вектора на целое чиcло\n{n}\n{v1}");









        }
    }
}
