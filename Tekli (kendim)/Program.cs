using System;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;

namespace ConsoleApp1
{
    class Program
    {
        class node
        {
            public int data; 
            public node next;
        }
       
        static void yazdir(node temp)
        {
            if (temp != null) { Console.Write("{0} => ",temp.data); yazdir(temp.next); }
            else { Console.WriteLine(); return; }   
        }
        // linked list oluşturmak recursive
        static void ekle(node temp,int i)
        {
            if (i >= 6) { return ; }
            temp.next = new node();
            temp = temp.next;
            temp.data = i;
            ekle(temp, i + 1);
        }
        // recursive listenin en sonuna eleman ekleme.
        static void SonaEkle(node temp, int a)
        {
            if (temp.next == null)
            {
                temp.next = new node();
                temp.next.data = a;
            }
            else { SonaEkle(temp.next, a); }
            return;
        }
        static node BasaEkle(node temp, int a)
        {
            if (temp == null) { return temp; }
            node eklencek = new node(); eklencek.data = a;
            eklencek.next = temp;
            temp = eklencek;
            return temp;
        }
        // recursive listenin belirtilen elemandan sonraki bloğa eleman ekleme.
        static void arayaEkle(node temp,int listEleman,int eklenecek)
        {
            if (temp == null) { return; Console.WriteLine("asd"); } 
            if(temp.data == listEleman) 
            {
                node t = new node(); t.data = eklenecek;
                t.next = temp.next;
                temp.next = t;
            }
            arayaEkle(temp.next, listEleman, eklenecek);
        }
        static void Main(string[] args)
        {           
            node head = new node();
            head.data = 0; // ilk değer
            node temp = head; // temp üzerindeki değişiklikler head'e ekleniyor.           
            Console.Write("İlk değer: ");
            yazdir(head);
            Console.Write("Eleman eklenmiş hali: ");
            ekle(head,1);
            yazdir(head);// eklenilen değerler.

            ////2 ten sonra 100 elemanını ekleme
            //while (temp.next != null)
            //{
            //    if (temp.next.data == 3) { node t = new node(); t.data = 100; t.next = temp.next; temp.next = t; break; }
            //    else { temp = temp.next; }
            //}
            //Console.Write("Araya 100 elemanı eklendi: ");
            //yazdir(head);
            //node q = head;
            // linked listi dairesel yapmak
            //while (temp.next!= null) { temp = temp.next; }
            //temp.next = q;
            //yazdir(head);

            // linked listin sonuna eleman ekleme
            //while (temp.next != null) { temp = temp.next; }
            //temp.next = new node();
            //temp.next.data = 61;
            Console.Write("Sona eleman eklendi: ");
            SonaEkle(head, 61);
            yazdir(head);
            Console.Write("Sona eleman eklendi: ");
            SonaEkle(head, 17);
            yazdir(head);
            Console.Write("Sona eleman eklendi: ");
            SonaEkle(head, 23);
            yazdir(head);
            Console.Write("Araya eleman eklendi: ");
            arayaEkle(head, 5, 50); // 5 ten sonra 50 yi ekle demektir.
            yazdir(head);
            Console.Write("Başa Eleman ekleme: ");
            head = BasaEkle(head, 67);
            yazdir(head);
            Console.Write("Başa Eleman ekleme: ");
            head = BasaEkle(head, 19);
            yazdir(head);
            Console.Write("Araya eleman eklendi: ");
            arayaEkle(head, 17, 81); 
            yazdir(head);
        }
    }
}
