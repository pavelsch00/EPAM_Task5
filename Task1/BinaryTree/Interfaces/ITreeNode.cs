using System;

namespace Task1.BinaryTree.Interfaces
{
    public interface ITreeNode<T> : IComparable<T> where T : IComparable
    {
        public BinaryTree<T> Tree { get; set; }

        public void Balance();

        public bool IsBalance();
    }
}
