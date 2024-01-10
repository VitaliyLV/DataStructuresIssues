using DataStructuresIssues.Graphs;

namespace DataStructuresIssues.Solutions
{
    public class NodeClone : ISolveIssue
    {
        /// <summary>
        /// Given a reference of a node in a connected undirected graph. Return a deep copy(clone) of the graph.
        /// LeetCode 133
        /// </summary>
        public void Solve()
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

            Console.WriteLine("Existing graph:");
            Helper.PrintNodes(nodes[0]);

            var nodeCopy = CloneGraph(nodes[0]);
            Console.WriteLine("Copied graph:");
            Helper.PrintNodes(nodeCopy);
        }

        public Node? CloneGraph(Node node)
        {
            if (node == null)
                return null;
            Dictionary<int, Node> vals = new Dictionary<int, Node>();
            Node newNode = new Node();
            newNode.val = node.val;
            vals.Add(newNode.val, newNode);
            CloneNeighbors(node, newNode, vals);
            return newNode;

        }
        private void CloneNeighbors(Node from, Node to, Dictionary<int, Node> vals)
        {
            if (from.children != null)
            {
                foreach (Node node in from.children)
                {
                    if(vals.TryGetValue(node.val, out var nd))
                    {
                        to.children.Add(nd);
                    }
                    else
                    {
                        var newNode = new Node(node.val);
                        to.children.Add(newNode);
                        vals.Add(node.val, newNode);
                        CloneNeighbors(node, newNode, vals);
                    }
                }
            }
        }

    }
}
