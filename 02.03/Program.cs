//#define EXM1
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static System.Console;


//Синтаксис интерфеса

//[модификатор доступа] interface имя_интерфейса
//{
//
//    тело интерфеса
//
//}



namespace _02._03
{

#if EXM1
    //public interface IResearcher
    //{
    //    void Investigate();

    //    void Invent();

    //}



    public interface IWorker
    {
        bool IsWorking { get; }
        string Work();


    }

    public interface IManager
    {

        List<IWorker> ListOfWorkers { get; set; }

        void Organize();

        void MakeBudget();

        void Control();

    }



    abstract class Human
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public override string ToString()
        {
            return $"Имя: {FirstName}\nФамилия: {LastName}\nДата рождения: {BirthDate.ToShortDateString()}\n";
        }


    }



    abstract class Employee : Human
    {

        public string Position { get; set; }

        public double Salary { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"Должность: {Position}\nЗарплата: {Salary}";
        }



    }

    class Director : Employee, IManager
    {
        public List<IWorker> ListOfWorkers { get; set; }

        public void Organize()
        {
            WriteLine("Организую работу");
        }

        public void MakeBudget()
        {
            WriteLine("Формирую бюджет");
        }

        public void Control()
        {
            WriteLine("Контролирую работу");
        }


    }


    class Seller : Employee, IWorker
    {
        bool isWorking = true;

        public bool IsWorking
        {

            get { return isWorking; }

        }

        public string Work()
        {
            return "Продаю товар";

        }
    }


    class Cashier : Employee, IWorker
    {
        public bool IsWorking => true;

        public string Work()
        {
            return "Принимаю оплату за товар";
        }
    }

    class Storekeeper : Employee, IWorker
    {
        public bool IsWorking => true;

        public string Work()
        {
            return "Принимаю товар на склад";
        }
    } 
#endif


    class Child : ICloneable
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"Имя: {Name}, Возраст: {Age}";
        }

        public object Clone()
        {
            return this.MemberwiseClone();

        }


    }




    internal class Program
    {


        static void Main(string[] args)
        {



#if EXM1
            Director director = new Director
            {
                FirstName = "Bill",
                LastName = "Gates",
                BirthDate = new DateTime(1956, 12, 07),
                Position = "Директор",
                Salary = 12000

            };


            IWorker seller = new Seller
            {
                FirstName = "Jim",
                LastName = "Beam",
                BirthDate = new DateTime(1989, 04, 24),
                Position = "Продавец",
                Salary = 15000

            };

            if (seller is Employee)
            {

                WriteLine($"Заработная плата продавца: {(seller as Employee).Salary}");


            }

            director.ListOfWorkers = new List<IWorker>
            {

                seller,
                new Cashier
                {
                    FirstName = "Jack",
                    LastName = "Daniels",
                    BirthDate = new DateTime(1990, 07, 08),
                    Position = "Кассир",
                    Salary = 1000


                },

                new Storekeeper
                {
                    FirstName = "Ray",
                    LastName = "Ban",
                    BirthDate = new DateTime(1985, 11, 15),
                    Position = "Хранитель склада",
                    Salary = 23000

                }

            };

            WriteLine(director);
            if (director is IManager)
            {

                director.Control();

            }
            WriteLine();

            foreach (IWorker item in director.ListOfWorkers)
            {
                WriteLine(item);
                if (item.IsWorking)
                {
                    WriteLine(item.Work());

                }
                WriteLine();

            } 
#endif


            Child child1 = new Child
            {
                Name = "Вовка",
                Age = 5
            };

            WriteLine("Начальные значения: ");
            Child child2 = (Child)child1.Clone();
            WriteLine($"Ребенок №1: {child1}");
            WriteLine($"Ребенок №2: {child2}");

            child2.Age = 10;
            WriteLine("\nЗначения после изменения возраста: \n");
            WriteLine($"Ребенок №1: {child1}");
            WriteLine($"Ребенок №2: {child2}");





        }
    }
}
