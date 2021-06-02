using System;
namespace ConsoleApp1
{
    class tekli
    {
        public int data;
        public tekli next;
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] x = { 5, 11, -3, 6, 3, 8 };
            // bu diziyi tekli linked list yapısına aktarınız.
            tekli head = null;
            tekli last = null;
            for (int i = 0; i < x.Length; i++)
            {
                tekli t = new tekli();
                t.data = x[i];
                if (head == null) { head = t; last = t; }
                else
                {
                    last.next = t;
                    last = t;
                }
            }
            tekli temp = head;
            while (temp != null)
            {
                Console.WriteLine(temp.data);
                temp = temp.next;
            }

            Console.WriteLine("---------------------------");
            // bu linked listi sıralayarak düzenleyiniz. yani = {-3,3,5,6,8,11} olacak şekilde.
            tekli sirali = null;
            tekli q = head;
            while (q!=null)
            {
                tekli sonraki = q.next;
                if (sirali == null || sirali.data >= q.data)
                {
                    q.next = sirali;
                    sirali = q;
                }
                else
                {
                    tekli q1 = sirali;
                    while (q1.next!=null && q1.next.data < q.data)
                    {
                        q1 = q1.next;
                    }
                    q.next = q1.next;
                    q1.next = q;

                }
                q = sonraki;
            }
            head = sirali;
            printlist(head);


        }
       static void printlist(tekli head)
        {
            while (head != null)
            {
                Console.Write(head.data + " ");
                head = head.next;
            }
            Console.WriteLine();
        }




    }
}
