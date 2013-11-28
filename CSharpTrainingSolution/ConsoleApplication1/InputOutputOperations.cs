using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    // учат се методи Write, WriteLine, Read, ReadLine, int.Parse, double.Parse and etc.
    class InputOutputOperations
    {
        static void Main(string[] args)
        {
            // Зад. 1

            //double a = 15.5;
            //int b = 14;
            //Console.WriteLine("{0} + {1} = {2}", a, b, a + b);
            //// resault 15,5 + 15 = 29,5

            ////Зад. 2 Отпечатване на int

            //string str = Console.ReadLine();
            //int i = int.Parse(str);  
            //Console.WriteLine(str);
            ////resault = числото което сме въвели за i

            //Зад. 3 

            //string str = Console.ReadLine();
            //int number;
            //if (int.TryParse(str, out number))
            //{
            //    Console.WriteLine("Validno Chislo: {0} ", number);
            //}
            //else
            //    Console.WriteLine("Nevalidno chislo: {0}", str);

            //Зад. 4  Проба за Replace в стринг :) 

            //string rado = Console.ReadLine();
            //rado = rado.Replace("-", "---");
            //Console.WriteLine(rado);

            //зад. 4 Сметки лице на триъгълник и правоъгълник

            Console.WriteLine("This program calcultes " + "the area of rectangle or a triangle");
            Console.Write("Enter a and b for (rectangle): " + "or a and h (for triangle): ");
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            Console.Write("Enter 1 for a rectangle or" + "for 2 triangle: ");
            int choice = int.Parse(Console.ReadLine());
            double area = (double) (a*b) / choice; //Tip: Всъщност делин на choice когато потребителя реши 1 или 2 да избере :)  
            Console.WriteLine("The area of your rectangle" + "is {0}", area);


        }
    }
}
