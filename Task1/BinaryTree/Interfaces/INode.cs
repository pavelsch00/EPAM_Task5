using System;

namespace Task1.BinaryTree.Interfaces
{
    public interface INode<T> : IComparable<T> where T : IComparable
    {
        public Node<T> Parent { get; set; }

        public Node<T> Left { get; set; }

        public Node<T> Right { get; set; }

        public int LeftHeight { get; }

        public int RightHeight { get; }
    }
}
