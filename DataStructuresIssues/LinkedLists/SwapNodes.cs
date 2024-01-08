using DataStructuresIssues.LinkedLists;

namespace DataStructuresIssues.Solutions
{
    internal class SwapNodes : ISolveIssue
    {
        /// <summary>
        /// Given a linked list, swap every two adjacent nodes and return its head. 
        /// You must solve the problem without modifying the values in the list's nodes (i.e., only nodes themselves may be changed.)
        /// LeetCode 24
        /// </summary>
        public void Solve()
        {
            while (true)
            {
                ListNode? head = Helper.ReadNumberList();
                if (head == null)
                {
                    return;
                }

                head = SwapPairs(head);
                Console.WriteLine("Result:");
                while (head != null)
                {
                    Console.Write($"{head.val} ");
                    head = head.next;
                }
                Console.WriteLine();
            }
        }

        public ListNode? SwapPairs(ListNode? head)
        {
            if (head != null && head.next != null)
            {
                ListNode first = head;
                ListNode? third = head.next.next;
                head = head.next;
                head.next = first;
                head.next.next = SwapPairs(third);
            }
            return head;

        }

    }   
}
