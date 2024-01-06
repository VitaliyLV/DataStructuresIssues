using DataStructuresIssues.LinkedLists;

namespace DataStructuresIssues.Solutions
{
    internal class RemoveDups : ISolveIssue
    {
        /// <summary>
        /// Remove Dups: Write code to remove duplicates from an unsorted linked list
        /// LeetCode 1836
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

                Remove(head);
                Console.WriteLine("Result:");
                while (head != null)
                {
                    Console.Write($"{head.val} ");
                    head = head.next;
                }
                Console.WriteLine();
            }
        }

        private void Remove(ListNode head)
        {
            ListNode currentNode = head;
            List<int> vals = new List<int>
            {
                currentNode.val
            };
            while (currentNode != null && currentNode.next != null)
            {
                if (vals.Contains(currentNode.next.val))
                {
                    currentNode.next = currentNode.next.next;
                }
                else
                {
                    vals.Add(currentNode.next.val);
                    currentNode = currentNode.next;
                }
            }
        }

    }   
}
