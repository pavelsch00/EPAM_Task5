using System;

namespace Task1.BinaryTree
{
    public class Node<T> : IComparable<T> where T : IComparable
    {
        Node<T> _left;
        Node<T> _right;

        public Node(T value, Node<T> parent)
        {
            Value = value;
            Parent = parent;
        }

        public T Value { get; private set; }

        public Node<T> Parent { get; set; }

        public Node<T> Left
        {
            get => _left;

            set
            {
                _left = value;

                if (_left != null)
                {
                    _left.Parent = this;
                }
            }
        }

        public Node<T> Right
        {
            get => _right;

            set
            {
                _right = value;

                if (_right != null)
                {
                    _right.Parent = this;
                }
            }
        }

        public int LeftHeight { get => MaxChildHeight(Right); }

        public int RightHeight { get => MaxChildHeight(Right); }

        public int MaxChildHeight(Node<T> node)
        {
            if (node != null)
            {
                return 1 + Math.Max(MaxChildHeight(node.Left), MaxChildHeight(node.Right));
            }

            return 0;
        }

        public int CompareTo(T other) => Value.CompareTo(other);
    }
}
