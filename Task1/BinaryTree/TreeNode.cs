using System;
using Task1.Enums;

namespace Task1.BinaryTree
{
    public class TreeNode<T> : Node<T>, IComparable<T> where T : IComparable
    {
        public TreeNode(T t, TreeNode<T> parent, BinaryTree<T> tree) : base(t, parent)
        {
            Tree = tree;
        }

        public BinaryTree<T> Tree { get; set; }

        public void Balance()
        {
            switch (State)
            {
                case BalanceState.LeftHeavy:
                    if (Left != null && (RightHeight - LeftHeight) > 0)
                    {
                        LeftRotation();
                        RightRotation();
                    }
                    else
                    {
                        RightRotation();
                    }
                    break;
                case BalanceState.RightHeavy:
                    if (Right != null && (RightHeight - LeftHeight) < 0)
                    {
                        RightRotation();
                        LeftRotation();
                    }
                    else
                    {
                        LeftRotation();
                    }
                    break;
                case BalanceState.Balanced:
                    break;
                default:
                    break;
            }
        }

        public bool IsBalance() => LeftHeight - RightHeight == 0;

        private BalanceState State
        {
            get
            {
                if (LeftHeight - RightHeight > 1)
                {
                    return BalanceState.LeftHeavy;
                }

                if (RightHeight - LeftHeight > 1)
                {
                    return BalanceState.RightHeavy;
                }

                return BalanceState.Balanced;
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
                Tree.Root = newRoot
                    as TreeNode<T>;
            }

            newRoot.Parent = Parent;
            Parent = newRoot;
        }
    }
}
