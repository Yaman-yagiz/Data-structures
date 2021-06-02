using System;

namespace Kuyruk
{
    class Program
    {

        static int[] queue = new int[100];
        static int front = 0;
        static int rear = -1;
        static public int dequeu()
        {
            int data = queue[front];
            front++;
            return data;
        }
        static public void enqueu(int data) 
        {
            if (rear+1 == queue.Length) move(); // dizi tamamen dolu ise move ile alınan değerlerden kalan boş indise elemanları yukarı doğru kaydırıyoruz.
            rear++;
            queue[rear] = data;
        }
        static int count()
        {
            return rear - front + 1;
        }
        static void move()
        {
            for (int i = front; i < queue.Length; i++)
            {
                queue[i-front] = queue[i];
            }
            rear = count()-1;
            front = 0;
        }
        static void Main(string[] args)
        {
            for (int i = 0; i < 100; i++)
            {
                enqueu(i);
            }
            dequeu();
            enqueu(5);
            for (int i = 0; i < queue.Length; i++)
            {
                Console.WriteLine(queue[i]);
            }
            
        }
    }
}
