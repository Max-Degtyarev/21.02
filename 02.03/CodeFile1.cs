using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace InterfacesPW223
{
    class StudentCard
    {
        public int Number { get; set; }
        public string Series { get; set; }
        public override string ToString()
        {
            return $"Студенческий билет: {Series} {Number}\n";
        }
    }

    class Student : IComparable, ICloneable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public StudentCard StudentCard { get; set; }
        public override string ToString()
        {
            return $"Имя: {FirstName}\nФамилия: {LastName}\nДата рождения: {BirthDate.ToShortDateString()}\n" + StudentCard.ToString();
        }

        public int CompareTo(object obj)
        {
            if (obj is Student)
            {
                return LastName.CompareTo((obj as Student).LastName);
            }
            throw new NotImplementedException();
        }

        public object Clone()
        {

            Student temp = (Student)MemberwiseClone();
            temp.StudentCard = new StudentCard
            {
                Series = this.StudentCard.Series,
                Number = this.StudentCard.Number


            };
            return temp;

        }


    }

    class DateComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is Student && y is Student)
            {
                return DateTime.Compare((x as Student).BirthDate, (y as Student).BirthDate);
            }
            throw new NotImplementedException();
        }
    }

    class Auditory : IEnumerable
    {
        Student[] students =
        {
            new Student
            {
                FirstName="John",
                LastName="Connor",
                BirthDate=new DateTime(1983,5,16),
                StudentCard = new StudentCard{Number=123456,Series="JC"}
            },
            new Student
            {
                FirstName="Sahra",
                LastName="Connor",
                BirthDate=new DateTime(1963,4,26),
                StudentCard = new StudentCard{Number=654321,Series="SC"}
            },
            new Student
            {
                FirstName="Arnold",
                LastName="Shwarzenegger",
                BirthDate=new DateTime(1953,10,20),
                StudentCard = new StudentCard{Number=987654,Series="AS"}
            },
            new Student
            {
                FirstName="Robert",
                LastName="Patrick",
                BirthDate=new DateTime(1963,9,06),
                StudentCard = new StudentCard{Number=135791,Series="RP"}
            }
        };

        public void Sort()
        {
            Array.Sort(students);
        }

        public void Sort(IComparer comparer)
        {
            Array.Sort(students, comparer);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return students.GetEnumerator();
        }
    }



    class InterfacesPW223
    {
        static void Main(string[] args)
        {
            Auditory auditory = new Auditory();
            WriteLine("**********Список студентов**********");

            foreach (Student student in auditory)
            {
                WriteLine(student);
            }

            WriteLine("***********Сортировка по фамилии********");

            //стандартная сортировка по фамилии
            auditory.Sort();
            foreach (Student student in auditory)
            {
                WriteLine(student);
            }


            WriteLine("***********Сортировка по дате рождения********");

            //сортировка по ДР
            auditory.Sort(new DateComparer());
            foreach (Student student in auditory)
            {
                WriteLine(student);
            }

            WriteLine("***************Клонирование*************");

            Student student1 = new Student
            {
                FirstName = "Donald",
                LastName = "Duck",
                BirthDate = new DateTime(1989, 10, 15),
                StudentCard = new StudentCard { Number = 8596, Series = "RGH" }


            };

            Student student2 = (Student)student1.Clone();

            WriteLine(student1);
            WriteLine(student2);


            WriteLine("***************Изменение*************");

            student2.StudentCard.Number = 654596;
            student2.StudentCard.Series = "IJGH";


            WriteLine(student1);
            WriteLine(student2);




        }
    }
}

