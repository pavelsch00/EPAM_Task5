using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Task1
{
    public static class XmlFileExtension<T>
    {
        public static void SaveToFile(string path, List<T> collection)
        {
            try
            {
                using var fs = new FileStream(path, FileMode.Create);
                var formatter = new XmlSerializer(typeof(List<T>));
                formatter.Serialize(fs, collection);
            }
            catch (Exception)
            {
                throw new ArgumentException("Failed to serialize collection");
            }
        }

        public static List<T> GetFromFile(string path )
        {
            using FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
            var formatter = new XmlSerializer(typeof(List<T>));
            return (List<T>)formatter.Deserialize(fs);
        }
    }
}
