using DataStructuresIssues.LinkedLists;

namespace DataStructuresIssues.Solutions
{
    /// <summary>
    /// Remove Dups: Write code to remove duplicates from an unsorted linked list
    /// LeetCode 1836
    /// </summary>
    internal class RemoveDups : ISolveIssue
    {
        /// <summary>
        /// Rotate Matrix: Given an image represented by an NxN matrix, where each pixel in the image is 4
        /// bytes, write a method to rotate the image by 90 degrees.Can you do this in place?
        /// LeetCode 48 Rotate image
        /// </summary>
        public void Solve()
        {
            while (true)
            {
                ListNode head = new ListNode();
                Console.WriteLine("Enter linked list values separated by space:");
                var readStr = Console.ReadLine();
                if (readStr == null || readStr == Helper.QuitStr)
                {
                    return;
                }
                ListNode currentNode = head;
                var values = readStr.Split(' ');
                if (values.Length > 0)
                {
                    currentNode.val = int.Parse(values[0]);
                    for (int i = 1; i < values.Length; i++)
                    {
                        ListNode nextNode = new ListNode(int.Parse(values[i]));
                        currentNode.next = nextNode;
                        currentNode = nextNode;
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
