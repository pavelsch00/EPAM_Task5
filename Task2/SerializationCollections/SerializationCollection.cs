using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using Task2.SerializationCollections.FileExtensions;
using Task2.SerializationCollections.Interfaces;
using Task2.SerializationCollections.Attributes;

namespace Task2.SerializationCollections
{
    public class SerializationCollection<T> : FileExtension<T>, ISerializationCollection<T> where T : ISerializable
    {
        private readonly string versionClass;

        public SerializationCollection()
        {
            try
            {
                versionClass = GetClassVersion();
            }
            catch (Exception)
            {
                throw new Exception("Class version don't be find! Instal class version using VersionAttribute.");
            }
        }

        private static string GetClassVersion() => Attribute.GetCustomAttributes(typeof(T))
        .Where(item => item is VersionAttribute)
        .Select(item => item as VersionAttribute)
        .Select(item => item.classVersion).FirstOrDefault().ToString();

        public ICollection<T> GetCollectionFromBinaryFile(string path) => GetCollectionFromBinaryFile(path, versionClass);

        public void SaveToBinaryFile(string path, ICollection<T> collection) => SaveToBinaryFile(path, collection, versionClass);

        public ICollection<T> GetCollectionFromJsonFile(string path) => GetCollectionFromJsonFile(path, versionClass);

        public void SaveToJsonFile(string path, ICollection<T> collection) => SaveToJsonFile(path, collection, versionClass);

        public ICollection<T> GetCollectionFromXmlFile(string path) => GetCollectionFromXmlFile(path, versionClass);

        public void SaveToXmlFile(string path, ICollection<T> collection) => SaveToXmlFile(path, collection, versionClass);

        public T GetFromBinaryFile(string path) => GetFromBinaryFile(path, versionClass);

        public void SaveToBinaryFile(string path, T collection) => SaveToBinaryFile(path, collection, versionClass);

        public T GetFromJsonFile(string path) => GetFromJsonFile(path, versionClass);

        public void SaveToXmlFile(string path, T collection) => SaveToXmlFile(path, collection, versionClass);

        public void SaveToJsonFile(string path, T collection) => SaveToJsonFile(path, collection, versionClass);

        public T GetFromXmlFile(string path) => GetFromXmlFile(path, versionClass);
    }
}
