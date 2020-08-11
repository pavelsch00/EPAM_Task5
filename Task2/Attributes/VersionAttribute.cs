using System;

namespace Task2.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class VersionAttribute : Attribute
    {
        public VersionAttribute(int major, int minor, int build, int revisionNumbers)
        {
            ClassVersion = new Version(major, minor, build, revisionNumbers);
        }

        public VersionAttribute(int major, int minor, int build)
        {
            ClassVersion = new Version(major, minor, build);
        }

        public VersionAttribute(int major, int minor)
        {
            ClassVersion = new Version(major, minor);
        }

        public VersionAttribute(string version)
        {
            ClassVersion = new Version(version);
        }

        public Version ClassVersion { get; set; }
    }
}
