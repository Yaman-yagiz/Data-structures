using System;

namespace Btree_LinkedList
{
    class BTREE
    {
        public int data;
        public BTREE left, right;
    }
    class Program
    {

        // ÖDEV:0 dan btree oluştur. sıralı şekilde.

        static int[] btree = new int[15];
        static BTREE bt = new BTREE();
        static void treecopy(int[] btree, BTREE btp, int indis)
        {
            if (indis >= 15) return;
            btp.data = btree[indis];
            if (indis * 2 + 1 <= 14)
            {
                btp.left = new BTREE();
                treecopy(btree,btp.left, indis * 2 + 1);
            }
            if (indis * 2 + 2 <= 14)
            {
                btp.right = new BTREE();
                treecopy(btree,btp.right, indis * 2 + 2);
            }
        }
        static void TreeLinkedListPrint(BTREE btp)
        {
            if (btp == null) return;
            Console.WriteLine(btp.data);
            TreeLinkedListPrint(btp.left);
            TreeLinkedListPrint(btp.right);
        }     
        static void Main(string[] args)
        {
            for (int i = 0; i < 15; i++)
            {
                btree[i] = i;
            }
            treecopy(btree, bt, 0);
            TreeLinkedListPrint(bt);
            

        }
    }
}
