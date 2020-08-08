using System;
using System.Collections.Generic;
using System.Collections;
using Task1.BinaryTree.Interfaces;

namespace Task1.BinaryTree
{
    public class BinaryTree<T> : IBinaryTree<T>, IEnumerable<T> where T : IComparable
    {
        public TreeNode<T> Root { private get; set; }

        public int CountElements { get; private set; }

        private void RecursiveAddition(TreeNode<T> node, T collection)
        {
            if (collection.CompareTo(node.Content) < 0)
            {
                if (node.Left == null)
                {
                    node.Left = new TreeNode<T>(collection, node, this);
                }
                else
                {
                    RecursiveAddition(node.Left as TreeNode<T>, collection);
                }
            }
            else
            {      
                if (node.Right == null)
                {
                    node.Right = new TreeNode<T>(collection, node, this);
                }
                else
                {         
                    RecursiveAddition(node.Right as TreeNode<T>, collection);
                }
            }
        }

        private TreeNode<T> Find(T collection)
        {
            TreeNode<T> treeNode = Root; 

            while (treeNode != null)
            {
                int result = treeNode.CompareTo(collection);

                if (result > 0)
                {
                    treeNode = treeNode.Left as TreeNode<T>;
                }
                else if (result < 0)
                {          
                    treeNode = treeNode.Right as TreeNode<T>;
                }
                else
                {  
                    break;
                }
            }

            return treeNode;
        }

        public IEnumerator<T> TreeTraversal()
        {
            if (Root != null)
            {
                Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();
                TreeNode<T> treeNode = Root;

                bool goLeftNext = true;

                stack.Push(treeNode);

                while (stack.Count > 0)
                {
                    if (goLeftNext)
                    {
                        while (treeNode.Left != null)
                        {
                            stack.Push(treeNode);
                            treeNode = treeNode.Left as TreeNode<T>;
                        }
                    }

                    yield return treeNode.Content;

                    if (treeNode.Right != null)
                    {
                        treeNode = treeNode.Right as TreeNode<T>;

                        goLeftNext = true;
                    }
                    else
                    {
                        treeNode = stack.Pop();
                        goLeftNext = false;
                    }
                }
            }
        }

        public bool IsContains(T collection) => Find(collection) != null;

        public void Add(T collection)
        {
            if (Root == null)
            {
                Root = new TreeNode<T>(collection, null, this);
            }
            else
            {
                RecursiveAddition(Root, collection);
            }

            CountElements++;
        }

        public bool Remove(T collection)
        {
            TreeNode<T> treeNode;
            treeNode = Find(collection);

            if (treeNode == null)
            {
                return false;
            }

            TreeNode<T> treeToBalance = treeNode.Parent as TreeNode<T>;

            CountElements--;

            if (treeNode.Right == null)
            {
                if (treeNode.Parent == null)
                {
                    Root = treeNode.Left as TreeNode<T>;

                    if (Root != null)
                    {
                        Root.Parent = null;
                    }
                }
                else
                {
                    int result = treeNode.Parent.CompareTo(treeNode.Content);

                    if (result > 0)
                    {
                        treeNode.Parent.Left = treeNode.Left;
                    }
                    else if (result < 0)
                    {
                        treeNode.Parent.Right = treeNode.Left;
                    }
                }
            }
            else if (treeNode.Right.Left == null)
            {
                treeNode.Right.Left = treeNode.Left;

                if (treeNode.Parent == null)
                {
                    Root = treeNode.Right as TreeNode<T>;

                    if (Root != null)
                    {
                        Root.Parent = null;
                    }
                }
                else
                {
                    int result = treeNode.Parent.CompareTo(treeNode.Content);
                    if (result > 0)
                    {
                        treeNode.Parent.Left = treeNode.Right;
                    }

                    else if (result < 0)
                    {
                        treeNode.Parent.Right = treeNode.Right;
                    }
                }
            }  
            else
            {
                TreeNode<T> leftmost = treeNode.Right.Left as TreeNode<T>;

                while (leftmost.Left != null)
                {
                    leftmost = leftmost.Left as TreeNode<T>;
                }

                leftmost.Parent.Left = leftmost.Right;
      
                leftmost.Left = treeNode.Left;
                leftmost.Right = treeNode.Right;

                if (treeNode.Parent == null)
                {
                    Root = leftmost;

                    if (Root != null)
                    {
                        Root.Parent = null;
                    }
                }
                else
                {
                    int result = treeNode.Parent.CompareTo(treeNode.Content);

                    if (result > 0)
                    {
                        treeNode.Parent.Left = leftmost;
                    }
                    else if (result < 0)
                    {
                        treeNode.Parent.Right = leftmost;
                    }
                }
            }

            if (treeToBalance != null)
            {
                treeToBalance.Balance();
            }
            else
            {
                if (Root != null)
                {
                    Root.Balance();
                }
            }

            return true;
        }

        public void Clear()
        {
            Root = null;
            CountElements = 0;
        }

        public void SaveToXmlFile(string path)
        {
            var collection = new List<T>();
            IEnumerator item = Root.Tree.GetEnumerator();

            while (item.MoveNext())
            {
                collection.Add((T)item.Current);
            }

            XmlFileExtension<T>.SaveToFile(path, collection);
        }

        public void GetFromXmlFile(string path)
        {
            try
            {
                foreach (var item in XmlFileExtension<T>.GetFromFile(path))
                {
                    Add(item);
                }
            }
            catch (Exception)
            {
                throw new ArgumentException("The argument does not match the T collection");
            }
        }

        public IEnumerator<T> GetEnumerator() => TreeTraversal();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
