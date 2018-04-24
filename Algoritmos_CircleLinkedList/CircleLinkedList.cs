using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Algoritmos_CircleLinkedList
{
    unsafe struct BoolNode
    {
        public bool Value;
        public BoolNode* Next;
        public BoolNode* Previous;
    }
    class CircleLinkedList
    {
        Int32 nodeCount = 0;
        private unsafe BoolNode* head = null;
        public void Add(bool value)
        {
            unsafe
            {
                var node = (BoolNode*)(Marshal.AllocHGlobal(sizeof(BoolNode)));
                node->Value = value;
                node->Next = null;
                node->Previous = null;

                if (head == null)
                {
                    head = node;
                    head->Next = head;
                    head->Previous = head;
                }
                else
                {
                    var current = head;
                    while (current != head)
                    {

                        current = current->Next;
                        
                    }
                    current->Next = node;
                    node->Previous = current;
                    node->Next = head;
                    nodeCount += 1; 

                }
            }
        }
        public unsafe void Write()
        {
            //TODO:---------------------------------
            Int32 x = 0;
            var actual = head;
            if (actual == head)
            {
                Console.Out.Write($"{head->Value} | ");
                if (actual->Next == null && actual->Previous == null)
                {
                    Console.Out.WriteLine();
                }
            else
            {
                while (x < nodeCount)
                {
                    Console.Out.Write($"{actual->Value} | ");
                    actual = actual->Next;
                    x += 1;
                }
                Console.Out.WriteLine();

            }


            }
        }
        public unsafe void Remove(bool value)
        {
            //TODO: make it work...
            BoolNode* Previous = head, actual = head->Next;               
            while (actual != head)   
            {
                if (actual->Value == value)
                {
                    if (Previous == head->Previous)
                    {
                        head->Previous = actual->Next;
                    }
                    else
                {
                    Previous->Next = actual->Next;
                }
                    Marshal.FreeHGlobal((IntPtr)actual);
                    actual = Previous == head->Previous ? head : Previous->Next;
                }
                else
                {
                    Previous = actual;
                    actual = actual->Next;
                }
            }
        }
    }
}
