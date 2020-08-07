using System;
using Task1.BinaryTree;
using Task1;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var binaryTree = new BinaryTree<Student>();
                                           
            binaryTree.Add(new Student("Pavel", "MMA", "18.02.2020", 12));
            binaryTree.Add(new Student("Pavel", "MMA", "18.02.2020", 2));
            binaryTree.Add(new Student("Pavel", "MMA", "18.02.2020", 3));
            binaryTree.Add(new Student("Pavel", "MMA", "18.02.2020", 5));
            binaryTree.Add(new Student("Pavel", "MMA", "18.02.2020", 8));
            binaryTree.Add(new Student("Pavel", "MMA", "18.02.2020", 5));
            binaryTree.Add(new Student("Pavel", "MMA", "18.02.2020", 34));
            binaryTree.Add(new Student("Pavel", "MMA", "18.02.2020", 1));
            binaryTree.Add(new Student("Pavel", "MMA", "18.02.2020", 0));

            binaryTree.Remove(new Student("Pavel", "MMA", "18.02.2020", 8));

            foreach (var item in binaryTree)
            {
                Console.WriteLine(item);
            }
        }
    }
}
