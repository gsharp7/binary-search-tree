using System;

namespace Trees
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BST bst = new BST();
            bst.insert(10);
            bst.insert(100);
            bst.insert(2);
            bst.insert(0);
            bst.insert(8);
            bst.insert(21);
            
            //bst.print();
            Console.WriteLine("Search: " + bst.search(21));
            bst.delete(0);
            Console.WriteLine("Minimum: " + bst.minimum());
            Console.WriteLine("Maximum: " + bst.maximum());
        }

        public class BST{
        public int size;
        public Node root;

        public BST(){
            size = 0;
            root = null;
        }

        public void insert(int x){
            Node current = root;
            Node n = new Node(x);
            if(current == null)
                root = n;
            else{
                Node target = null;
                while(current != null){
                    target = current;
                    if(x < current.item)
                        current = current.left;
                    else
                        current = current.right;
                }
                if(x < target.item)
                    target.left = n;
                else
                    target.right = n;
            }
            size++;
        }

        public void delete(int x){
            Node current = root;
            while(current.item != x){
                if(x < current.item){
                    if(current.left == null)
                        break;
                    current = current.left;
                }
                else{
                    if(current.right == null)
                        break;
                    current = current.right;
                }
            }
            
        }

        public bool search(int x){
            return searchTree(x, root);
        }

        bool searchTree(int x, Node n){
            if(n == null)
                return false;
            if(x == n.item)
                return true;
            if(x < n.item)
                return searchTree(x, n.left);
            else
                return searchTree(x, n.right);
        }

        public int minimum(){
            Node current = root;
            while(true){
                if(current.left == null)
                    return current.item;
                else
                    current = current.left;
            }
        }

        public int maximum(){
            Node current = root;
            while(true){
                if(current.right == null)
                    return current.item;
                else
                    current = current.right;
            }
        }

        public void print(){
            printTree(root, 0, "RT");
        }

        void printTree(Node n, int depth, string side){
            if(n == null)
                return;
            int nextDepth = depth + 1;
            for(int d = 0; d < depth; d++)
                Console.Write("   ");
            Console.WriteLine(side + ": " + n.item);
            printTree(n.left, nextDepth, "L");
            printTree(n.right, nextDepth, "R");
        }


    }

    public class Node{
        public int item;
        public Node left;
        public Node right;

        public Node(){
            item = 0;
            left = null;
            right = null;
        }

        public Node(int x){
            item = x;
            left = null;
            right = null;
        }
    }
    }

}
