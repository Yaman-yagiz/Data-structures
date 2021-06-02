using System;

namespace Tree
{
    class Program
    {
        static int[] btree = new int[15];
        static void print(int[] btree,int indis)
        {
            if (indis >= 15) return;
            
            if (indis * 2 + 1 <= 14) print(btree, indis*2+1);
            if (indis * 2 + 2 <= 14) print(btree, indis*2+2);
            Console.WriteLine(btree[indis]);
        }
        static void Main(string[] args)
        {
            for (int i = 0; i < 15; i++)
            {
                btree[i] = i;
            }
            print(btree, 0);
            
        }
    }
}
