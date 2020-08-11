using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Task2.FileExtensions;
using Task2.Interfaces;

namespace Task2
{
    public class SerializationCollection<T> : ISerializationCollection<T> where T : ISerializable
    {
        public ICollection<T> GetCollectionFromBinaryFile(string path) => FileExtension<T>.GetCollectionFromBinaryFile(path);

        public void SaveToBinaryFile(string path, ICollection<T> collection) => FileExtension<T>.SaveToBinaryFile(path, collection);

        public ICollection<T> GetCollectionFromJsonFile(string path) => FileExtension<T>.GetCollectionFromJsonFile(path);

        public void SaveToJsonFile(string path, ICollection<T> collection) => FileExtension<T>.SaveToJsonFile(path, collection);

        public ICollection<T> GetCollectionFromXmlFile(string path) => FileExtension<T>.GetCollectionFromXmlFile(path);

        public void SaveToXmlFile(string path, ICollection<T> collection) => FileExtension<T>.SaveToXmlFile(path, collection);

        public T GetFromBinaryFile(string path) => FileExtension<T>.GetFromBinaryFile(path);

        public void SaveToBinaryFile(string path, T collection) => FileExtension<T>.SaveToBinaryFile(path, collection);

        public T GetFromJsonFile(string path) => FileExtension<T>.GetFromJsonFile(path);

        public void SaveToXmlFile(string path, T collection) => FileExtension<T>.SaveToXmlFile(path, collection);

        public void SaveToJsonFile(string path, T collection) => FileExtension<T>.SaveToJsonFile(path, collection);

        public T GetFromXmlFile(string path) => FileExtension<T>.GetFromXmlFile(path);
    }
}
