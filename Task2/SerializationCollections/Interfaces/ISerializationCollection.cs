using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Task2.SerializationCollections.Interfaces
{
    interface ISerializationCollection<T> where T : ISerializable
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
