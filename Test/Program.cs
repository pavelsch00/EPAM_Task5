using System;
using Task1.BinaryTree;
using Task1;
using System.Linq;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var binaryTree = new BinaryTree<Student>();
                                           
            binaryTree.Add(new Student("Pavel", "MMA", "18.02.2020", 10));
            binaryTree.Add(new Student("Maxim", "TViMS", "18.02.2020", 2));
            binaryTree.Add(new Student("Rita", "MMA", "18.02.2020", 3));
            binaryTree.Add(new Student("Sasha", "TViMS", "18.02.2020", 5));
            binaryTree.Add(new Student("Tolik", "MMA", "18.02.2020", 8));
            binaryTree.Add(new Student("Michail", "TViMS", "18.02.2020", 5));
            binaryTree.Add(new Student("Stephan", "MMA", "18.02.2020", 4));
            binaryTree.Add(new Student("Taras", "TViMS", "18.02.2020", 1));
            binaryTree.Add(new Student("Daniil", "MMA", "18.02.2020", 0));

            binaryTree.Remove(new Student("Michail", "TViMS", "18.02.2020", 7));

            foreach (var item in binaryTree)
            {
                Console.WriteLine(item);
            }
        }
    }
}
