using System;

namespace Task2.SerializationCollections.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class VersionAttribute : Attribute
    {
        public readonly Version classVersion;

        public VersionAttribute(int major, int minor, int build, int revisionNumbers)
        {
            classVersion = new Version(major, minor, build, revisionNumbers);
        }

        public VersionAttribute(int major, int minor, int build)
        {
            classVersion = new Version(major, minor, build);
        }

        public VersionAttribute(int major, int minor)
        {
            classVersion = new Version(major, minor);
        }

        public VersionAttribute(string version)
        {
            classVersion = new Version(version);
        }
    }
}
