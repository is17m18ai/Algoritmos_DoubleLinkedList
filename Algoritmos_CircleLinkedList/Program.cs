using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos_CircleLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO:implement Remove() and Write()
            var j = new CircleLinkedList();
            int x = 0;
            Console.Out.WriteLine("Escreva 10 valores booleanos.");
            bool leitura = bool.Parse(Console.In.ReadLine());
            while (x < 10)
            {
                j.Add(leitura);
                leitura = bool.Parse(Console.In.ReadLine());
                x +=  1;
             }Console.Out.WriteLine();

            j.Write();
            Console.Out.WriteLine();
            j.Remove(true);
            j.Write();
            Console.Out.WriteLine();
        }
    }
}
