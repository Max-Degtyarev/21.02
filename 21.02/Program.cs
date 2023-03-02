//#define EXM1
//#define EXM2
//#define EXM3

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace _21._02
{
    internal class Program
    {
#if EXM1

        class Student
        {
            string firstName;
            string lastName;

            public Student(string firstName, string lastName)
            {

                this.firstName = firstName;
                this.lastName = lastName;

            }

        }


        class ClassA
        {

            public void MethodA(ClassB obj)
            {
                obj.MethodB(this);
            }

        }

        class ClassB
        {
            public void MethodB(ClassA obj)
            {
                WriteLine("Работа с классом " + obj.GetType().Name);
            }

        }




        class Car
        {


            private string _driverName;
            private int _currSpeed;


            public Car() : this("Нет водителя", 0) { }

            public Car(string driverName) : this(driverName, 0) { }

            public Car(string driverName, int speed)
            {

                _driverName = driverName;
                _currSpeed = speed;

            }

            public void SetDriver(string driverName)
            {
                _driverName = driverName;

            }

            public void PrintState()
            {

                WriteLine($"{_driverName} едет со скоростью {_currSpeed} км/ч");


            }

            public void SpeedUp(int delta)
            {
                _currSpeed += delta;

            }


        } 
#endif


#if EXM2
        class Student
        {
            static string _academyName = "Топ";
            string _firstName = "Анатолий";

            public void ShowName()
            {
                WriteLine(_firstName);
            }

            public static void ShowAcademy()
            {
                WriteLine(_academyName);
            }



        }


        static void MyFunction(int[] MyArr, int i)
        {
            MyArr[0] = 100;
            i = 100;

        }


        class Mathematic
        {

            public static int Sum(int a, int b)
            {

                return a + b;
            }

            public static int Sum(int a, int b, int c)
            {

                return a + b + c;
            }


            public static double Sum(double a, double b)
            {
                return a + b;
            }

        } 
#endif


#if EXM3
        private static void MyFunction(ref int i, ref int[] myArr)
        {
            WriteLine("Внутри функции MyFunction до изменения i = " + i);
            Write("MyArr { ");
            foreach (int val in myArr)
            {
                Write(val + " ");
            }
            WriteLine("}");

            i = 100;
            myArr = new int[] { 3, 2, 1 };
            WriteLine("Внутри функции MyFunction после изменения i = " + i);
            Write("MyArr { ");
            foreach (int val in myArr)
            {
                Write(val + " ");
            }
            WriteLine("}");

        }


        private static void GetDigit(out int digit)
        {

            digit = new Random().Next(10);
        }

#endif


        private static int Sum(params int[] arr)
        {

            int res = 0;
            foreach(int i in arr)
            {
                res += i;
            }
            return res;

        }


        partial class MyClass
        {

            public static void Method1()
            {
                WriteLine("Hello");

            }


        }





        static void Main(string[] args)
        {


#if EXM1
            ClassA a = new ClassA();
            ClassB b = new ClassB();
            a.MethodA(b);

            Car myCar = new Car("Вася");
            for (int i = 0; i < 10; i++)
            {
                myCar.SpeedUp(15);
                myCar.PrintState();
            }

#endif


#if EXM2
            Student student1 = new Student();
            student1.ShowName();
            Student.ShowAcademy();

            int i = 0;
            int[] MyArr = { 0, 1, 2, 3, 4 };
            WriteLine("i = " + i);
            WriteLine("MyArr[0] = " + MyArr[0]);
            WriteLine("Вызов MyFunction");
            MyFunction(MyArr, i);
            WriteLine("i = " + i);
            WriteLine("MyArr[0] = " + MyArr[0]);

            int a = 10, b = 20, c = 30;
            double da = 3.3, db = 6.7;

            WriteLine($"{a} + {b} = {Mathematic.Sum(a, b)}");
            WriteLine($"{a} + {b} + {c} = {Mathematic.Sum(a, b, c)}");
            WriteLine($"{da} + {db} = {Mathematic.Sum(da, db)}"); 
#endif


#if EXM3
            int i = 10;
            int[] myArr = { 1, 2, 3 };
            WriteLine("Внутри метода Main до передачи в метод MyFunction  i = " + i);
            Write("MyArr { ");
            foreach (int val in myArr)
            {
                Write(val + " ");
            }
            WriteLine("}");


            MyFunction(ref i, ref myArr);


            WriteLine("Внутри метода Main после передачи в метод MyFunction  i = " + i);
            Write("MyArr { ");
            foreach (int val in myArr)
            {
                Write(val + " ");
            }
            WriteLine("}");


            WriteLine();
            WriteLine();

            int a;
            GetDigit(out a);
            WriteLine("a = " + a); 
#endif


            WriteLine("Сумма = " + Sum(new int[] { 1, 2, 3, 4, 5 } ));
            WriteLine("Сумма = " + Sum( 10, 20, 30, 40, 50 ));






        }




    }
}
