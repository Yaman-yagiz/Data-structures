using System;

namespace Stack2__Stack_LinkedList_İmplementi_
{
    class Program
    {
        class ciftli
        {
            public int data;
            public ciftli next;
            public ciftli prev;
        }
        static ciftli sp = null;
        static void push(int data)
        {
            ciftli c = new ciftli();
            c.data = data;
            c.prev = sp;
            if (sp != null) sp.next = c; 
            sp = c; 
        }
        static int pop()
        {
            int data = sp.data;
            sp = sp.prev;
            return data;       
        }

        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                push(i);
            }
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(pop());
            }
        }
    }
}
