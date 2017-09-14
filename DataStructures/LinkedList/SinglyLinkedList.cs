using System;

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
        private int size;

        public SinglyLinkedList(){
            size = 0;
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
        /// Return the size of list
        /// </summary>
        public int Count(){
            return size;
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

            size++;
        }
    }
}