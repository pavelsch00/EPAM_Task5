using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Linq;

namespace Task2.FileExtensions
{
    public static class FileExtension<T>
    {
        public static void SaveToXmlFile(string path, ICollection<T> collection)
        {
            try
            {
                using var fileStream = new FileStream(path, FileMode.OpenOrCreate);
                var formatter = new XmlSerializer(typeof(List<T>));
                formatter.Serialize(fileStream, collection);
            }
            catch (Exception)
            {
                throw new ArgumentException("Failed to serialize collection.");
            }
        }

        public static ICollection<T> GetCollectionFromXmlFile(string path)
        {
            try
            {
                using FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate);
                var formatter = new XmlSerializer(typeof(List<T>));
                return (ICollection<T>)formatter.Deserialize(fileStream);
            }
            catch (Exception)
            {
                throw new ArgumentException("Failed to deserialize collection.");
            }
        }

        public static void SaveToJsonFile(string path, ICollection<T> collection)
        {
            try
            {
                using StreamWriter streamWriter = new StreamWriter(path);
                streamWriter.Write(JsonConvert.SerializeObject(collection, Formatting.Indented));
            }
            catch (Exception)
            {
                throw new ArgumentException("Failed to serialize collection.");
            }
        }

        public static ICollection<T> GetCollectionFromJsonFile(string path)
        {
            try
            {
                using var streamReader = new StreamReader(path);
                return JsonConvert.DeserializeObject<ICollection<T>>(streamReader.ReadToEnd());
            }
            catch (Exception)
            {
                throw new ArgumentException("Failed to deserialize collection.");
            }
        }

        public static void SaveToBinaryFile(string path, ICollection<T> collection)
        {
            try
            {
                var binaryFormatter = new BinaryFormatter();
                using var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Write);
                binaryFormatter.Serialize(fileStream, collection);
            }
            catch (Exception)
            {
                throw new ArgumentException("Failed to serialize collection.");
            }
        }

        public static ICollection<T> GetCollectionFromBinaryFile(string path)
        {
            try
            {
                var binaryFormatter = new BinaryFormatter();
                using var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                return (ICollection<T>)binaryFormatter.Deserialize(fileStream);
            }
            catch (Exception)
            {
                throw new ArgumentException("Failed to serialize collection.");
            }
        }

        public static void SaveToXmlFile(string path, T item)
        {
            try
            {
                using var fileStream = new FileStream(path, FileMode.OpenOrCreate);
                var formatter = new XmlSerializer(typeof(T));
                formatter.Serialize(fileStream, item);
            }
            catch (Exception)
            {
                throw new ArgumentException("Failed to serialize item.");
            }
        }

        public static void SaveToJsonFile(string path, T item)
        {
            try
            {
                using StreamWriter streamWriter = new StreamWriter(path);
                streamWriter.Write(JsonConvert.SerializeObject(item, Formatting.Indented));
            }
            catch (Exception)
            {
                throw new ArgumentException("Failed to serialize item.");
            }
        }

        public static void SaveToBinaryFile(string path, T item)
        {
            try
            {
                var binaryFormatter = new BinaryFormatter();
                using var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Write);
                binaryFormatter.Serialize(fileStream, item);
            }
            catch (Exception)
            {
                throw new ArgumentException("Failed to serialize item.");
            }
        }

        public static T GetFromBinaryFile(string path)
        {
            try
            {
                var binaryFormatter = new BinaryFormatter();
                using var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                return (T)binaryFormatter.Deserialize(fileStream);
            }
            catch (Exception)
            {
                throw new ArgumentException("Failed to deserialize item.");
            }
        }

        public static T GetFromXmlFile(string path)
        {
            try
            {
                using FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate);
                var formatter = new XmlSerializer(typeof(T));
                return (T)formatter.Deserialize(fileStream);
            }
            catch (Exception)
            {
                throw new ArgumentException("Failed to deserialize item.");
            }
        }

        public static T GetFromJsonFile(string path)
        {
            try
            {
                using var streamReader = new StreamReader(path);
                return JsonConvert.DeserializeObject<T>(streamReader.ReadToEnd());
            }
            catch (Exception)
            {
                throw new ArgumentException("Failed to deserialize item.");
            }
        }
    }
}
