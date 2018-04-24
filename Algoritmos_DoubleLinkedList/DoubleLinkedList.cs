using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Algoritmos_DoubleLinkedList
{
    unsafe struct FloatNode
    {
        public float Value;
        public FloatNode* Next;
        public FloatNode* Previous;
    }
    class DoubleLinkedList
    {
        private unsafe FloatNode* head = null;

        public void Add(float value)
        {
            unsafe {
                //alocar memoria para o node
                var node = (FloatNode*)(Marshal.AllocHGlobal(sizeof(FloatNode)));
                //locais/valor do node
                node->Value = value;
                node->Next = null;
                node->Previous = null;

                if(head == null)
                {
                    head = node;
                }
                else
                {
                    //verifica se estamos no ultimo elemento da lista
                    var current = head;
                    while (current->Next != null)
                    {

                        current = current->Next;
                    }

                    current->Next = node;
                    node->Previous = current;
                }
            }
        }
        public void AddBackwards(float value)
        {
            unsafe
            {
                var node = (FloatNode*)(Marshal.AllocHGlobal(sizeof(FloatNode)));
                node->Value = value;
                node->Next = null;
                node->Previous = null;

                if (head == null)
                {
                    head = node;
                }
                else
                {
                    
                    var current = head;
                    while (current->Next != null)
                    {

                        current = current->Next;
                    }

                    current->Previous = node;
                    node->Next = current;
                }
            }
        }

        public unsafe void Write()
        {
            var actual = head;
            while (actual != null)
            {
                Console.Write($"{actual->Value} | ");
                actual = actual->Next;

            }Console.WriteLine();
        }
        public unsafe void WriteBackwards()
        {
            var actual = head;
            if(actual == null)
            {
                Console.Error.WriteLine("List is empty.");
            }
            else
            {
                while(actual != null)
                {
                    actual = actual->Next;
                }
                while (actual != null)
                {
                    Console.Write($"{actual->Value}");
                    actual = actual->Previous;

                }
                Console.WriteLine();
            }
        }
        public unsafe void Remove(float value)
        {
            FloatNode* Previous = null, actual = head;
            while(actual != null)
            {
                if (actual->Value == value)
                {
                    if (Previous == null)
                    {
                        head = actual->Next;
                    }
                    else
                    {
                        Previous->Next = actual->Next;
                    }
                    Marshal.FreeHGlobal((IntPtr)actual);
                    actual = Previous == null ? head : Previous->Next;
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
