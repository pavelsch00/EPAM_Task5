using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Task2.FileExtensions
{
    public static class FileExtension<T>
    {
        public static void SaveToXmlFile(string path, IEnumerable<T> collection)
        {
            try
            {
                using var fs = new FileStream(path, FileMode.OpenOrCreate);
                var formatter = new XmlSerializer(typeof(List<T>));
                formatter.Serialize(fs, collection);
            }
            catch (Exception)
            {
                throw new ArgumentException("Failed to serialize collection.");
            }
        }

        public static IEnumerable<T> GetFromXmlFile(string path )
        {
            using FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
            var formatter = new XmlSerializer(typeof(List<T>));
            return (IEnumerable<T>)formatter.Deserialize(fs);
        }

        public static void SaveToJsonFile(string path, IEnumerable<T> collection)
        {
            using StreamWriter streamWriter = new StreamWriter(path);
            streamWriter.Write(JsonConvert.SerializeObject(collection, Formatting.Indented));
        }


        public static IEnumerable<T> GetFromJsonFile(string path)
        {
            using var streamReader = new StreamReader(path);
            return JsonConvert.DeserializeObject<List<T>>(streamReader.ReadToEnd());
        }

        public static void SaveToBinaryFile(string path, IEnumerable<T> collection)
        {
            var binaryFormatter = new BinaryFormatter();
            using var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Write);
            binaryFormatter.Serialize(fileStream, collection);
        }

        public static IEnumerable<T> GetFromBinaryFile(string path)
        {
            var binaryFormatter = new BinaryFormatter();
            using var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            return (ICollection<T>)binaryFormatter.Deserialize(fileStream);
        }
    }
}
