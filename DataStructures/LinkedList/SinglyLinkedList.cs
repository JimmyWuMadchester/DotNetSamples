using System;
using System.Collections;

namespace LinkedList
{
    public class Node{
        public int NodeContent { get; set; }
        public Node Next;

        public Node(int content){
            this.NodeContent = content;
            this.Next = null;
        }
    }

    public class SinglyLinkedList{
        private Node head;
        private Node tail;

        public SinglyLinkedList(){
            head = null;
            tail = null;
        }

        /// <summary>
        /// Return the first element
        /// </summary>
        public Node First(){
            return head;
        }

        /// <summary>
        /// Return the last element
        /// </summary>
        public Node Last(){
            return tail;
        }


        /// <summary>
        /// Adds a new node containing the specified value at the end of the LinkedList
        /// </summary>
        public void AddLast(int content){
            var node = new Node(content);
            // Adding the first node. Make it the head.
            if (head == null){
                head = node;        // Change head to the new node
                head.Next = tail;   // Point head to the tail
                tail = head;        // Tail is also the head
            }
            else{
                // Add it to the current tail.
                tail.Next = node;   // Link current tail to the new node
                tail = tail.Next;   // Change tail to the new node.
            }
        }
        
        /// <summary>
        /// Removes the first occurrence of the specified value from the list
        /// </summary>
        public bool Remove(int content){
            if (head == null){
                return false;
            }

            var current = head;
            // Check head
            if (current.NodeContent == content){
                current = current.Next;
                return true;
            }

            // Check starting from head+1
            while (current.Next != null){       // Loop until the tail-1
                if (current.Next.NodeContent == content){  // Check tail NodeContent
                    current.Next = current.Next.Next;
                    return true;
                }
                current = current.Next;
            }

            return false;
        }

        public void Reverse(){
            var current = head;
            Node newRoot = null;
            Node temp;
            while (current != null){
                temp = current.Next;
                current.Next = newRoot;
                newRoot = current;

                if (current.Next == null){
                    tail = current;
                }
                current = temp;
            }
            
            head = newRoot;
        }
    }

    public static class Helper{
        // Linked Lists Solution 2.1
        // Remove duplicates using hashtable
        public static void DeleteDups(SinglyLinkedList list){
            Hashtable table = new Hashtable();
            var current = list.First();
            if (current != null){
                table.Add(current.NodeContent, true);

                while (current.Next != null){

                    if (table.ContainsKey(current.Next.NodeContent)){
                        current.Next = current.Next.Next;
                    }else{
                        table.Add(current.Next.NodeContent, true);
                        current = current.Next;
                    }
                }
            }
        }

        private static Node temp;
        public static int NthToLast(Node current, int k){
            int n;
            // The tail is the 1st element from the last.
            if (current == null){
                return 0;
            }
            n = NthToLast(current.Next, k) + 1;
            if (n == k){
                temp = current;
            }
            return n;
        }

        public static Node FindNthToLast(SinglyLinkedList l, int k){
            var current = l.First();
            NthToLast(current, k);
            return temp;
        }
    }

    public static class SinglyLinkedListTest{
        public static void Run(){
            Console.WriteLine("Hello, welcome to Linked List example!");

            var l = new SinglyLinkedList();
            l.AddLast(0);
            l.AddLast(1);
            l.AddLast(2);
            l.AddLast(3);
            l.AddLast(4);
            Console.WriteLine($"First item in the list: {l.First().NodeContent}");
            Console.WriteLine($"Last item in the list: {l.Last().NodeContent}");

            l.AddLast(4);
            l.AddLast(2);
            l.AddLast(3);
            l.AddLast(4);
            l.AddLast(3);
            l.AddLast(4);
            
            while(l.Remove(3)){}
            Console.WriteLine($"First item in the list: {l.First().NodeContent}");
            Console.WriteLine($"Last item in the list: {l.Last().NodeContent}");
        }

        public static void DeleteDups_GivenDupsList_ShouldRemoveDups(){
            Console.WriteLine("Hello, welcome to Linked List example of removing duplicates");

            var l = new SinglyLinkedList();
            l.AddLast(0);
            l.AddLast(1);
            l.AddLast(2);
            l.AddLast(3);
            l.AddLast(4);
            l.AddLast(4);
            l.AddLast(2);
            l.AddLast(3);
            l.AddLast(4);
            l.AddLast(3);
            l.AddLast(4);
            
            Node current = null;
            Console.WriteLine("Before removing duplicates:");
            current = l.First();
            while (current != null){
                Console.WriteLine(current.NodeContent);
                current = current.Next;
            }

            Helper.DeleteDups(l);
            Console.WriteLine("After removing duplicates:");
            current = l.First();
            while (current != null){
                Console.WriteLine(current.NodeContent);
                current = current.Next;
            }
        }

        public static void FindNthToLast_Given2AsIndex_ShouldReturn2ndFromLast(){
            Console.WriteLine("Hello, welcome to Linked List example of find the kth to last element");
            var l = new SinglyLinkedList();
            l.AddLast(0);
            l.AddLast(1);
            l.AddLast(2);
            l.AddLast(3);
            l.AddLast(4);
            l.AddLast(4);
            l.AddLast(2);
            l.AddLast(10);
            l.AddLast(4);
            l.AddLast(3);
            l.AddLast(4);
            var k = 4;
            Node result = Helper.FindNthToLast(l, k);
            Console.WriteLine($"The {k}th item from the last is: {result.NodeContent}");
        }

        public static void Reverse_GivenAscList_ShouldReturnDescList(){
            var l = new SinglyLinkedList();
            l.AddLast(0);
            l.AddLast(1);
            l.AddLast(2);
            l.AddLast(3);
            l.AddLast(4);

            l.Reverse();
            var current = l.First();
            while (current != null){
                Console.WriteLine(current.NodeContent);
                current = current.Next;
            }
        }
    }
}