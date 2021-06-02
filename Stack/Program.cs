using System;
using System.Collections.Generic;
using System.IO;

namespace Stack
{
    class Program
    {

        // dizi-stack implementi
        static int[] stack = new int[100]; // içine data ekleyip, alacağımız dizi.
        static int sp = -1; // stack pointer. ekleme ve alma işleminde indisi tutan değer. -1 den başlar çünkü data eklerken sp++ ile arttırıp 0.indise datanın eklenmesini sağlarız.

        static void push(int data)
        {
            sp++;
            stack[sp]= data;
        }
        static int pop()
        {       
            int data= stack[sp];
            sp--;
            return data;
        }

        static void Main(string[] args)
        {
            //push(10);
            //push(20);
            //push(30);
            //push(40);
            //Console.WriteLine(pop());
            //Console.WriteLine(pop());
            //Console.WriteLine(pop());

            //for (int i = 0; i < 100; i++)
            //{
            //    push(i);
            //}
            //for (int i = 0; i < 100; i++)
            //{
            //    Console.WriteLine(pop()); // diziyi tersine çevirdi.
            //}


            // palindromik stringi stack kullanarak çöz
            string s = "1234321";
            //int t = 0;
            //// strinlerle çözümü : string s1="";
            //for (int i = 0; i < s.Length; i++)
            //{
            //    push((byte)s[i]);
            //    // strinlerle çözümü : s1=s[i]+s1;
            //}
            //for (int i = 0; i < s.Length; i++)
            //{
            //    if (pop() != (byte)s[i])
            //    {
            //        t = 1;
            //        break;
            //    }
            //}
            //if (t==0) { Console.WriteLine("palindromik"); }
            //// stringlerle çözümü: if(s1==s){ Console.WriteLine("palindromik");}
            //else { Console.WriteLine("palindromik değil"); }


            // palindromik recursive
            // stringi,0'dan stringin uzunluğunun 1 eksiğine kadar olacak şekilde fonksiyona yolluyoruz.
            // eğer stringin tam uzunluğunu yollarsak dizide index 0 dan başladığı için sıkıntıya düşülebilirdi.
            //if (pal(s, 0, s.Length-1) == 1) { Console.WriteLine("palindromik"); }
            //else { Console.WriteLine("palindromik değil"); }


            // bütün parantezler karşılığını bulacak şekilde kapatılmalı, bunun uygun olup olmadığını denetle ve stackle yap.
            string p = "(sdf3(324{dfg{sdf[34345[hty43]34]dfgdf}34534}sdfsdf)1234)";
            string left = "({[";
            string right = ")}]";
            Stack<char> st = new Stack<char>();
            int hata = 0;
            for (int i = 0; i < p.Length; i++)
            {
                //IndexOf( ) metodu, aradığını bulamazsa geriye -1 değerini döndürür. Eğer aradığını bulursa hangi indekste bulmuşsa geriye o indeks değerini döndürür.
                //Arama işlemine kendisini çağıran değişkenin içindeki verinin ilk karakterinden başlayıp son karakterine doğru yapar.
                int index = left.IndexOf(p[i]);
                if (index >= 0) { st.Push(right[index]); continue; }
                index = right.IndexOf(p[i]);
                if (index >= 0)
                {
                    char ch = st.Pop();
                    if (ch != right[index]) { hata = 1; break; }
                }
            }
            if (hata == 1) Console.WriteLine("değil");
            else Console.WriteLine("uygun");


            //kendi harddiskimizdeki bir dizinin tüm alt dizinlerini ekrana yazdır.
            string directoryName = @"c:\Games";
            Stack<string> stak = new Stack<string>();
            stak.Push(directoryName);
            DirectoryInfo di ; // dizin ile ilgili class
            while (stak.Count > 0) // stack içerisindeki veri 0 dan büyükse
            {
                directoryName = stak.Pop();
                di = new DirectoryInfo(directoryName);
                Console.WriteLine(directoryName);
                foreach(DirectoryInfo dinf in di.GetDirectories())
                {
                    stak.Push(dinf.FullName);
                }
            }

        }

        // palindromik recursive
        static int pal(string s,int a,int b)
        {
            if (a >= b) return 1;
            if (s[a] == s[b]) {
                // a,en soldaki ve b en sağdaki karakterleri kontrol ede ede ortada buluşacaklar. Bu durumda a, b ye eşit ya da büyük olduğunda kontrol sağlanmış olacaktır.
                return pal(s, a + 1, b - 1);
            }
            else return 0;
        }
    }
}
