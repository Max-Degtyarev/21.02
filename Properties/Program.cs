using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Properties
{

    class Example
    {

        int _num;

        public int Num
        {
            get { return _num; }
            set { _num = value; }   

        }

    }



    internal class Program
    {
        static void Main(string[] args)
        {

            Example example = new Example();
            Write("Введите целое число: ");
            example.Num = int.Parse(ReadLine());
            Write("Вы ввели: ");
            WriteLine(example.Num);



        }
    }
}
