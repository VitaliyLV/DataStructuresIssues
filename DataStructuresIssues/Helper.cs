using DataStructuresIssues.Graphs;
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
        public static List<int>? ReadNumbers()
        {
            Console.WriteLine("Enter numbers separated by space:");
            var readStr = Console.ReadLine();
            if (readStr == null || readStr == Helper.QuitStr)
            {
                return null;
            }
            List<int> numbers = new List<int>();
            var values = readStr.Split(' ');
            if (values.Length > 0)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    numbers.Add(int.Parse(values[i]));
                }
            }
            return numbers;
        }
        public static void PrintNodes(Node? node)
        {
            if (node == null)
                Console.WriteLine();
            Queue<Node> queue = new Queue<Node>();
            node.isVisited = true;
            queue.Enqueue(node);

            while (queue.Count > 0)
            {
                Node node1 = queue.Dequeue();
                Console.WriteLine(node1.val);
                foreach (Node node2 in node1.children)
                {
                    if (node2.isVisited)
                        continue;
                    queue.Enqueue(node2);
                    node2.isVisited = true;
                }
            }
        }

    }
}
