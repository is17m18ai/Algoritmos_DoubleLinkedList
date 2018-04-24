using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Algoritmos_DoubleLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = new DoubleLinkedList();
            Console.Out.WriteLine("Escreva numeros ate introduzir -1");
            float leitura = float.Parse(Console.In.ReadLine());
            while (leitura != (-1))
            {
                n.Add(leitura);
                leitura = float.Parse(Console.In.ReadLine());
            }
            n.Write();
            n.Remove(3.14F);
            n.Write();
            
        }
    }
}
