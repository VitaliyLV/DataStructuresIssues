using DataStructuresIssues.Graphs;

namespace DataStructuresIssues.Solutions
{
    internal class RouteBetweenNodes : ISolveIssue
    {
        const string trueResponse = "TRUE. There is a route.";
        const string falseResponse = "FALSE. No Route exists.";

        /// <summary>
        /// Route Between Nodes: Given a directed graph, design an algorithm to find out whether there is a
        /// route between two nodes.
        /// </summary>

        public void Solve()
        {
            while (true)
            {
                List<Node> nodes = new List<Node>();
                for (int i = 0; i < 6; i++)
                {
                    nodes.Add(new Node(i));
                }
                nodes[0].children = new List<Node> { nodes[1], nodes[4], nodes[5] };
                nodes[2].children.Add(nodes[1]);
                nodes[3].children.Add(nodes[2]);
                nodes[3].children.Add(nodes[4]);
                nodes[1].children.Add(nodes[3]);
                nodes[1].children.Add(nodes[4]);

                Console.WriteLine("Select 2 nodes:");
                var nums = Helper.ReadNumbers();
                if (nums == null || nums.Count != 2)
                    return;

                Console.WriteLine("Result: " + (RouteExists(nodes[nums[0]], nodes[nums[1]]) ? trueResponse : falseResponse));
            }
        }

        private bool RouteExists(Node start, Node end)
        {
            Queue<Node> queue = new Queue<Node>();
            start.isVisited = true;
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                Node node1 = queue.Dequeue();
                if(node1 == end)
                    return true;
                foreach(Node node2 in node1.children)
                {
                    if (node2.isVisited)
                        continue;
                    queue.Enqueue(node2);
                    node2.isVisited = true;
                }
            }
            return false;
        }
    }
}
