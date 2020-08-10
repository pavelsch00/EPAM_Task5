using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Task2.FileExtensions;
using Task2.Interfaces;

namespace Task2
{
    public class SerializationCollection<T> : ISerializationCollection, IEnumerable<T> where T : ISerializable
    {
        public SerializationCollection(List<T> collection)
        {
            Collection = collection;
        }

        public SerializationCollection()
        {
        }

        /// <summary>
        /// The property describes the content of the SerializationCollection.
        /// </summary>
        public List<T> Collection { get; set; }

        public void GetFromBinaryFileFile(string path)
        {
        }

        public void GetFromJsonFile(string path)
        {
        }

        public void SaveToXmlFile(string path) => FileExtension<T>.SaveToFile(path, Collection);

        public void GetFromXmlFile(string path) => Collection = FileExtension<T>.GetFromFile(path);

        public void SaveToBinaryFilelFile(string path)
        {}

        public void SaveToJsonile(string path)
        {}

        public IEnumerator<T> GetEnumerator()
        {
            return Collection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)Collection).GetEnumerator();
        }
    }
}
