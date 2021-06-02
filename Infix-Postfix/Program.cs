using System;
using System.Collections;
using System.Collections.Generic;

namespace Infix_Postfix
{
    class Program
    {
        static void Main(string[] args)
        {
            // Kurallar
            // operandlar direkt postfixe eklenir.(operand: a,b,c gibi değişkenler)
            // '(' görüldüğünde stağa push edilir.
            // operatorun operator önceliği stacktaki operatörden büyükse stağa push edilir.
            // operatorun operator önceliği stacktaki operatörden küçük ya da eşitse ve durum devam ettiği sürece stacktan operatorler pop edilip postfixe eklenir.
            // ')' görüldüğünde bütün elemanlar postfixe pop edilir.
            // bütün işlemler bitince mevcut operatoru stağa push yap.
            // tüm karakterler(infixteki) biterse, stağı komple postfixe pop yap.

            string infix = "a+b*c-d";
            string postfix = "";
            Stack<char> st = new Stack<char>();
            string op = "+-*/()";
            int[] oncelikler = { 1, 1, 2, 2, 0, 3 };

            for (int i = 0; i < infix.Length; i++)
            {
                int index = op.IndexOf(infix[i]);
                if (index == -1) { postfix += infix[i]; continue; }
                if (index == 4) { st.Push(infix[i]); continue; }
                if (index == 5) 
                {
                    while (st.Peek() != '(') { postfix += st.Pop(); } // Peek() fonksiyonu Pop() fonksiyonuna benzerdir fakat farklı olarak Peek ile stackta bir sonraki öğeye bakarız. Alma işlemi yapılmaz.
                    st.Pop(); // '(' ifadesini stacktan çıkartıyoruz.
                }
                if (st.Count > 0)
                {
                    if (oncelikler[index] > oncelikler[op.IndexOf(st.Peek())] ) 
                    { st.Push(infix[i]); continue; } // continue olduğu için aşağı else yazmaya gerek yok.

                    //else
                    bool kontrol = true;
                    while (kontrol)
                    {
                        postfix += st.Pop();
                        if (st.Count == 0) kontrol = false;
                        else 
                        { 
                            if (oncelikler[index] > oncelikler[op.IndexOf(st.Peek())]) kontrol = false;
                            if (st.Peek() == '(') kontrol = false;
                        }
                    }
                    st.Push(infix[i]);
                }
                else { st.Push(infix[i]); continue; }
            }
            while (st.Count > 0) postfix += st.Pop();
            Console.WriteLine(postfix);
        }
    }
}
