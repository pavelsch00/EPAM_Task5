using System;
using System.Collections.Generic;

namespace Task1.BinaryTree.Interfaces
{
    public interface IBinaryTree<T> : IEnumerable<T> where T : IComparable
    {
        public IEnumerator<T> TreeTraversal();

        public bool IsContains(T collection);

        public void Add(T collection);

        public bool Remove(T collection);

        public void Clear();

        public void SaveToXmlFile(string path);

        public void GetFromXmlFile(string path);
    }
}
