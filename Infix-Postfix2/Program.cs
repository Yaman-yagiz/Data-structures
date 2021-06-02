using System;
using System.Collections.Generic;

namespace Infix_Postfix2
{
    class Program
    {
        // delegate'ler bir fonksiyonun(metodun) imzasını tutarlar. İmzadan kastımız parametrelerinin tipi ve dönüş tipidir. Metodlara pointerdır.
        public delegate int YeniDelegate(int p, int q); 

        static void calistir(int a,int b,YeniDelegate yd)
        {
            Console.WriteLine(yd(a,b));
        }
        static int topla(int a,int b)
        {
            //Console.WriteLine("TOPLA");
            return a + b;
        }
        static int carp(int a, int b)
        {
            //Console.WriteLine("ÇARP");
            return a * b;
        }
        static int bol(int a, int b)
        {
            //Console.WriteLine("BÖL");
            return a / b;
        }
        static int cikar(int a, int b)
        {
            //Console.WriteLine("ÇIKAR");
            return a - b;
        }

        
        static void Main(string[] args)
        {

            YeniDelegate yd = cikar;
            //Console.WriteLine(yd(5, 7));
            //yd = carp;
            //Console.WriteLine(yd(5, 7));

            //yd += bol;
            //yd += carp;
            //yd += topla;
            //Console.WriteLine(yd(5, 2));
            //yd -= topla;
            //Console.WriteLine(yd(4,2));
            // Bu yukarıdaki deletgate yapısı bir linked list yapısıdır.


            string postfix = "ab*cab*c/d-/-g+";
            // Daha genel bir çözüm string s="abcdefghijklmnoprstuvwxyz"; her değere karşı da value dizisini büyütmeliyiz.
            // * ile işaretli olan satırda ise st.Push(value[s.IndexOf(postfix[i])]) diyerek çözüm yapacağız.
            string op = "+-/*";
            int[] value = { 1, 2, 3,4,5 };
            Stack<int> st = new Stack<int>();

            for (int i = 0; i < postfix.Length; i++)
            {
                int index = op.IndexOf(postfix[i]);
                if (index==-1) {
                    st.Push(value[postfix.IndexOf(postfix[i])]); continue; } //*
                int operand1 = st.Pop();
                int operand2 = st.Pop();
                if (index == 0){ st.Push(topla(operand2,operand1)); continue; }
                if (index == 1){ st.Push(cikar(operand2,operand1)); continue; }
                if (index == 2){ st.Push(bol(operand2,operand1)); continue; }
                if (index == 3){ st.Push(carp(operand2,operand1)); continue; }
            }
            Console.WriteLine(st.Pop());
             
        }
    }
}
