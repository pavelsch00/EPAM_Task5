using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Task2.FileExtensions;
using Task2.Interfaces;

namespace Task2
{
    public class SerializationCollection<T> : ISerializationCollection, IEnumerable<T> where T : ISerializable
    {
        public SerializationCollection(IEnumerable<T> collection)
        {
            Collection = collection;
        }

        public SerializationCollection()
        {
        }

        /// <summary>
        /// The property describes the content of the SerializationCollection.
        /// </summary>
        public IEnumerable<T> Collection { get; set; }

        public void GetFromBinaryFile(string path) => Collection = FileExtension<T>.GetFromBinaryFile(path);

        public void GetFromJsonFile(string path) => Collection = FileExtension<T>.GetFromJsonFile(path);

        public void SaveToXmlFile(string path) => FileExtension<T>.SaveToXmlFile(path, Collection);

        public void GetFromXmlFile(string path) => Collection = FileExtension<T>.GetFromXmlFile(path);

        public void SaveToBinaryFile(string path) => FileExtension<T>.SaveToBinaryFile(path, Collection);

        public void SaveToJsonFile(string path) => FileExtension<T>.SaveToJsonFile(path, Collection);

        public IEnumerator<T> GetEnumerator()
        {
            return Collection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
