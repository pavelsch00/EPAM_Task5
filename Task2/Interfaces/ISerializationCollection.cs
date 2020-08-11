using System.Collections.Generic;

namespace Task2.Interfaces
{
    interface ISerializationCollection<T>
    {
        public ICollection<T> GetCollectionFromBinaryFile(string path);

        public ICollection<T> GetCollectionFromJsonFile(string path);

        public ICollection<T> GetCollectionFromXmlFile(string path);

        public void SaveToXmlFile(string path, ICollection<T> collection);

        public T GetFromXmlFile(string path);

        public void SaveToJsonFile(string path, ICollection<T> collection);

        public T GetFromJsonFile(string path);

        public void SaveToBinaryFile(string path, ICollection<T> collection);

        public T GetFromBinaryFile(string path);
    }
}
