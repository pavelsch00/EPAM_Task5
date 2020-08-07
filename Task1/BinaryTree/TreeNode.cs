using System;
using System.Collections.Generic;
using System.Text;
using Task1.Enums;

namespace Task1.BinaryTree
{
    public partial class TreeNode<T> : Node<T>, IComparable<T> where T : IComparable
    {

        public TreeNode(T t, TreeNode<T> parent, BinaryTree<T> tree) : base(t, parent)
        {
            Tree = tree;
        }

        public BinaryTree<T> Tree { get; set; }

        public void Balance()
        {
            if (State == TreeState.RightHeavy)
            {
                if (Right != null && BalanceFactor < 0)
                {
                    LeftRightRotation();
                }
                else
                {
                    LeftRotation();
                }
            }
            else if (State == TreeState.LeftHeavy)
            {
                if (Left != null && BalanceFactor > 0)
                {
                    RightLeftRotation();
                }
                else
                {
                    RightRotation();
                }
            }
        }

        public bool IsBalance() => LeftHeight - RightHeight == 0;

        private TreeState State
        {
            get
            {
                if (LeftHeight - RightHeight > 1)
                {
                    return TreeState.LeftHeavy;
                }

                if (RightHeight - LeftHeight > 1)
                {
                    return TreeState.RightHeavy;
                }

                return TreeState.Balanced;
            }
        }

        private void LeftRotation()
        {
            Node<T> newRoot = Right;
            ReplaceRoot(newRoot);
  
            Right = newRoot.Left;
  
            newRoot.Left = this;
        }

        private void RightRotation()
        {
            Node<T> newRoot = Left;
            ReplaceRoot(newRoot);

            Left = newRoot.Right;
 
            newRoot.Right = this;
        }

        private void LeftRightRotation()
        {
            RightRotation();
            LeftRotation();
        }

        private void RightLeftRotation()
        {
            LeftRotation();
            RightRotation();
        }

        private void ReplaceRoot(Node<T> newRoot)
        {
            if (Parent != null)
            {
                if (Parent.Left == this)
                {
                    Parent.Left = newRoot;
                }
                else if (Parent.Right == this)
                {
                    Parent.Right = newRoot;
                }
            }
            else
            {
                Tree.Head = newRoot
                    as TreeNode<T>;
            }

            newRoot.Parent = Parent;
            Parent = newRoot;
        }
    }
}
