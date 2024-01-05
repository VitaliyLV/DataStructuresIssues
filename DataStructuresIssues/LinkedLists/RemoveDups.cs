﻿using DataStructuresIssues.LinkedLists;

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
                ListNode? head = Helper.ReadList();
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