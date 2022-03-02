using TestConsoleApps.Models;

namespace TestConsoleApps.Apps
{
    public class BinarySearchApp : IApp
    {
        List<Node> binaryNodes = new List<Node>();
        int nodeIndex = 1;
        private int count = 10;
        private string res;
        public void Start()
        {
            Node node = AddNode("root");
            Console.WriteLine("Following is the binary tree");
            print2D(node);


            do
            {
                Console.WriteLine("Enter the number to traverse the tree");
                Console.WriteLine("1 For PreOrder");
                Console.WriteLine("2 For InOrder");
                Console.WriteLine("3 For PostOrder");
                var ans = Convert.ToInt16(Console.ReadLine());
                if (ans == 1)
                {
                    Console.WriteLine("PreOrder Traverse(Value,Left,Right) is as follows:");
                    TraversePreOrder(node);
                }
                else if (ans == 2)
                {
                    Console.WriteLine("InOrder Traverse(Left,Value,Right) is as follows:");
                    TraverseInOrder(node);
                }
                else if (ans == 3)
                {
                    Console.WriteLine("PostOrder Traverse(Left,Right,Value) is as follows:");
                    TraversePostOrder(node);
                }
                else
                {
                    Console.WriteLine("Invalalid option");
                }
                Console.Write("Do u want to continue (Y/N):");
                res = Console.ReadLine();
            } while (res.Equals("Y", StringComparison.CurrentCultureIgnoreCase));
        }

        private void TraversePreOrder(Node rootNode)
        {

            if (rootNode != null)
            {
                Console.Write($"{rootNode.Value}  ");
                TraversePreOrder(rootNode.Left);
                TraversePreOrder(rootNode.Right);
            }

        }

        private void TraverseInOrder(Node rootNode)
        {

            if (rootNode != null)
            {
                TraversePreOrder(rootNode.Left);
                Console.Write($"{rootNode.Value}  ");
                TraversePreOrder(rootNode.Right);
            }

        }

        private void TraversePostOrder(Node rootNode)
        {

            if (rootNode != null)
            {
                TraversePreOrder(rootNode.Left);
                TraversePreOrder(rootNode.Right);
                Console.Write($"{rootNode.Value}  ");
            }

        }

        private Node AddNode(string nodeDirection)
        {
            Node node = new Node();
            Console.Write($"Enter Node at {nodeDirection}, ");
            Console.WriteLine($"Enter (Any number) :");
            var num = Console.ReadLine();
            node.Value = Convert.ToInt32(num);
            Console.WriteLine("Press N to terminate further addition or press C to continue");
            var ans = Console.ReadLine();
            if (ans.Equals("C", StringComparison.CurrentCultureIgnoreCase))
            {
                nodeIndex++;
                node.Left = AddNode($"Left to {num}");
                node.Right = AddNode($"Right {num}");
            }

            return node;

        }

        // Function to print binary tree in 2D
        // It does reverse inorder traversal
        void print2DUtil(Node root, int space)
        {
            // Base case
            if (root == null)
                return;

            // Increase distance between levels
            space += count;

            // Process right child first
            print2DUtil(root.Right, space);

            // Print current node after space
            // count
            Console.Write("\n");
            for (int i = count; i < space; i++)
                Console.Write(" ");
            Console.Write(root.Value + "\n");

            // Process left child
            print2DUtil(root.Left, space);
        }

        // Wrapper over print2DUtil()
        void print2D(Node root)
        {
            // Pass initial space count as 0
            print2DUtil(root, 0);
        }
    }
}