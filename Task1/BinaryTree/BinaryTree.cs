using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Task1.BinaryTree
{
    public class BinaryTree<T> : IEnumerable<T> where T : IComparable
    {
        public TreeNode<T> Head { get; set; }

        public int Count { get; private set; }

        public void Add(T value)
        {   
            if (Head == null)
            {
                Head = new TreeNode<T>(value, null, this);
            }
            else
            {
                AddTo(Head, value);
            }

            Count++;
        }

        private void AddTo(TreeNode<T> node, T value)
        {
            if (value.CompareTo(node.Value) < 0)
            {
                if (node.Left == null)
                {
                    node.Left = new TreeNode<T>(value, node, this);
                }
                else
                {
                    AddTo(node.Left as TreeNode<T>, value);
                }
            }
            else
            {      
                if (node.Right == null)
                {
                    node.Right = new TreeNode<T>(value, node, this);
                }
                else
                {         
                    AddTo(node.Right as TreeNode<T>, value);
                }
            }
        }

        public bool IsContains(T value) => Find(value) != null;

        private TreeNode<T> Find(T value)
        {
            TreeNode<T> treeNode = Head; 

            while (treeNode != null)
            {
                int result = treeNode.CompareTo(value);

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

        public bool Remove(T value)
        {
            TreeNode<T> treeNode;
            treeNode = Find(value);

            if (treeNode == null)
            {
                return false;
            }

            TreeNode<T> treeToBalance = treeNode.Parent as TreeNode<T>;

            Count--;

            if (treeNode.Right == null)
            {
                if (treeNode.Parent == null)
                {
                    Head = treeNode.Left as TreeNode<T>;

                    if (Head != null)
                    {
                        Head.Parent = null;
                    }
                }
                else
                {
                    int result = treeNode.Parent.CompareTo(treeNode.Value);

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
                    Head = treeNode.Right as TreeNode<T>;

                    if (Head != null)
                    {
                        Head.Parent = null;
                    }
                }
                else
                {
                    int result = treeNode.Parent.CompareTo(treeNode.Value);
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
                    Head = leftmost;

                    if (Head != null)
                    {
                        Head.Parent = null;
                    }
                }
                else
                {
                    int result = treeNode.Parent.CompareTo(treeNode.Value);

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
                if (Head != null)
                {
                    Head.Balance();
                }
            }

            return true;
        }

        public void Clear()
        {
            Head = null;
            Count = 0;
        }

        public IEnumerator<T> InOrderTraversal()
        {
            if (Head != null)
            {
                Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();
                TreeNode<T> treeNode = Head;

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

                    yield return treeNode.Value;

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

        public IEnumerator<T> GetEnumerator() => InOrderTraversal();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
