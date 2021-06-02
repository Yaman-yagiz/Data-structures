using System;

namespace kuyruk_linkedList
{
    class ciftli
    {
        public int data = 0;
        public ciftli next;
        public ciftli prev;
    }
    class Program
    {
        // 100 elemanlı çiftli linked list oluşturma ve dizilerdeki gibi rear front kullanarak implement et
        //static ciftli kuyruk = new ciftli();
        //static ciftli head = null;
        //static ciftli last = null;

        static int[] queue = new int[100];
        static ciftli front = null;
        static ciftli rear = null;
        static public int dequeu()
        {
            int data = front.data;
            front = front.next;
            return data;
        }
        static public void enqueu(int data)
        {
            ciftli c = new ciftli(); c.data = data;
            c.prev = rear;
            if (rear == null) { 
                rear = c; 
                front = c; }
            else { 
                rear.next = c;  
                rear = c; }
            
        }
        //static int count()
        //{
        //    return rear - front + 1;
        //}
        static void Main(string[] args)
        {
            for (int i = 0; i < 6; i++)
            {
                enqueu(i);
            }
            while (front != null) { Console.WriteLine(front.data); front = front.next; }

            //// 100 elemanlı çiftli linked list oluşturma
            //for (int i = 0; i < 100; i++)
            //{
            //    ciftli c = new ciftli();
            //    c.data = i;

            //    if (head == null) { head = c; last = c; kuyruk = head; }
            //    else
            //    {
            //        last.next = c;
            //        c.prev = last;
            //        last = c;
            //    }
            //}

            //while (kuyruk != null) { Console.WriteLine(kuyruk.data); kuyruk = kuyruk.next; }
        }
    }
}
