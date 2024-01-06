using DataStructuresIssues.LinkedLists;

namespace DataStructuresIssues
{
    internal class Helper
    {
        public static readonly string QuitStr = "q";
        public static ListNode? ReadNumberList()
        {
            ListNode head = new ListNode();
            Console.WriteLine("Enter linked list values(numbers) separated by space:");
            var readStr = Console.ReadLine();
            if (readStr == null || readStr == Helper.QuitStr)
            {
                return null;
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
            }
            return head;
        }
    }
}
