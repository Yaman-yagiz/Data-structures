using System;

namespace ConsoleApp2
{
    class ciftli
    {
        public int data;
        public ciftli next;
        public ciftli prev;
    }
    class Program
    {
        static void Main(string[] args)
        {
            // 100 elemanlı çiftli linked list oluşturma
            ciftli head = null;
            ciftli last = null;
            for (int i = 0; i < 100; i++)
            {
                ciftli c = new ciftli();
                c.data = i;
                if (head == null) { head = c; last = c; }
                else
                {                   
                    last.next = c;
                    c.prev = last;
                    last = c;
                }
            }
            // 0-99 yazdırma
            ciftli temp = head;
            //while (temp != null)
            //{
            //    Console.WriteLine(temp.data);
            //    temp = temp.next;
            //}
            temp = head;
            //Console.WriteLine("********************************************");
            ////99-0 yazdırma
            //temp = last;
            //while (temp != null)
            //{              
            //    Console.WriteLine(temp.data);
            //    temp = temp.prev;
            //}

            // data değeri 7 olan elemandan sonra yeni eleman ekleme
            while (temp.next!= null)
            {
                if (temp.data == 7)
                {
                    ciftli q = new ciftli(); q.data = 7;
                    q.prev = temp;
                    q.next = temp.next;
                    temp.next = q;
                    temp.next.prev = q;
                    // eğer 7 den sonra tekrar 7 eklersek sonsuz döngüye girebilir bunu engellemek için break ya da temp=temp.next kullanılabilir.
                    temp = temp.next;
                }
                 temp = temp.next; 
            }
            temp = head;
            yazdir(temp);


            // en başta oluşturduğumuz listeyi tersten yeni bir ciftli linked liste aktar.
            // 1.YOL
            //ciftli t = null;
            //last = null;

            //temp = head;
            //while (temp.next != null) { temp = temp.next; } // şuan burada temp son elemanı tutmakta.

            //while (temp != null)
            //{
            //    ciftli c = new ciftli();
            //    c.data = temp.data;
            //    if (t == null) { t = c; last = c; }
            //    else
            //    {
            //        last.next = c;
            //        c.prev = last;
            //        last = c;
            //    }
            //    temp = temp.prev; // geriye doğru gitmek için.
            //}
            //temp = t;
            //yazdir(temp);

            ////2.YOL
            //ciftli t2 = null;
            //last = null;

            //temp = head;
            //while (temp != null)
            //{

            //    ciftli c = new ciftli();
            //    c.data = temp.data;

            //    c.next = t2;
            //    if (t2 != null) t2.prev = c;
            //    t2 = c;

            //    temp = temp.next;
            //}
            //temp = t2;
            //yazdir(temp);

            // data değeri 7 olan blokları delete edelim.
            while (temp.next != null)
            {
                if (temp.data == 7)
                {
                    temp.prev.next = temp.next;
                    temp.next.prev = temp.prev;
                    // data değeri 7 olan değerlerin sadece 1 tanesini silmek istersek: temp = temp.next yazabiliriz.
                }
                temp = temp.next;
            }
            temp = head;
            yazdir(temp);

        }
        static public void yazdir(ciftli c)
        {
            if (c != null)
            {
                Console.WriteLine(c.data);
                yazdir(c.next);
            }
            
        }
    }
}
