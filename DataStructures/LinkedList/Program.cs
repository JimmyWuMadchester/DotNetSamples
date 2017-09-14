using System;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            SinglyLinkedListTest.Run();
            SinglyLinkedListTest.DeleteDups_GivenDupsList_ShouldRemoveDups();
            SinglyLinkedListTest.FindNthToLast_Given2AsIndex_ShouldReturn2ndFromLast();
            SinglyLinkedListTest.Reverse_GivenAscList_ShouldReturnDescList();
        }
    }
}
