using System.Collections.Generic;
using System.Runtime.Serialization;
using Task2.FileExtensions;
using Task2.Interfaces;
using Task2.Attributes;
using System;
using System.Linq;

namespace Task2
{
    public class SerializationCollection<T> : ISerializationCollection<T> where T : ISerializable
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
        .Select(item => item.ClassVersion).FirstOrDefault().ToString();

        public ICollection<T> GetCollectionFromBinaryFile(string path) => FileExtension<T>.GetCollectionFromBinaryFile(path, versionClass);

        public void SaveToBinaryFile(string path, ICollection<T> collection) => FileExtension<T>.SaveToBinaryFile(path, collection, versionClass);

        public ICollection<T> GetCollectionFromJsonFile(string path) => FileExtension<T>.GetCollectionFromJsonFile(path, versionClass);

        public void SaveToJsonFile(string path, ICollection<T> collection) => FileExtension<T>.SaveToJsonFile(path, collection, versionClass);

        public ICollection<T> GetCollectionFromXmlFile(string path) => FileExtension<T>.GetCollectionFromXmlFile(path, versionClass);

        public void SaveToXmlFile(string path, ICollection<T> collection) => FileExtension<T>.SaveToXmlFile(path, collection, versionClass);

        public T GetFromBinaryFile(string path) => FileExtension<T>.GetFromBinaryFile(path, versionClass);

        public void SaveToBinaryFile(string path, T collection) => FileExtension<T>.SaveToBinaryFile(path, collection, versionClass);

        public T GetFromJsonFile(string path) => FileExtension<T>.GetFromJsonFile(path, versionClass);

        public void SaveToXmlFile(string path, T collection) => FileExtension<T>.SaveToXmlFile(path, collection, versionClass);

        public void SaveToJsonFile(string path, T collection) => FileExtension<T>.SaveToJsonFile(path, collection, versionClass);

        public T GetFromXmlFile(string path) => FileExtension<T>.GetFromXmlFile(path, versionClass);
    }
}
