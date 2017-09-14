using System;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, welcome to Linked List example!");

            var l = new SinglyLinkedList();
            l.AddLast(0);
            l.AddLast(1);
            l.AddLast(2);
            l.AddLast(3);
            l.AddLast(4);
            Console.WriteLine($"First item in the list: {l.First().NodeContent}");
            Console.WriteLine($"Last item in the list: {l.Last().NodeContent}");
            Console.WriteLine($"Count items in the list: {l.Count()}");
        }
    }
}
