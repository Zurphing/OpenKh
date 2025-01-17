using OpenKh.Kh2;
using System.Collections.Generic;
using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace OpenKh.Patcher
{
    public class Metadata
    {
        public class Dependency
        {
            public string Name { get; set; }
        }

        public string Title { get; set; }
        public string OriginalAuthor { get; set; }
        public string Description { get; set; }
        public string Game { get; set; }
        public int Specifications { get; set; }
        public List<Dependency> Dependencies { get; set; }
        public List<AssetFile> Assets { get; set; }

        private static readonly IDeserializer deserializer =
            new DeserializerBuilder()
            .IgnoreFields()
            .IgnoreUnmatchedProperties()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .Build();
        private static readonly ISerializer serializer =
            new SerializerBuilder()
            .IgnoreFields()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .Build();

        public static Metadata Read(Stream stream) =>
            deserializer.Deserialize<Metadata>(new StreamReader(stream));
        public void Write(Stream stream) =>
            serializer.Serialize(new StreamWriter(stream), this);
        public override string ToString() =>
        serializer.Serialize(this);
    }

    public class AssetFile
    {
        public string Name { get; set; }
        public string Method { get; set; }
        public string Platform { get; set; }
        public string Package { get; set; }
        public List<Multi> Multi { get; set; }
        public List<AssetFile> Source { get; set; }

        public bool Required { get; set; }
        public string Type { get; set; }
        public Bar.MotionsetType MotionsetType { get; set; }
        public string Language { get; set; }
        public bool IsSwizzled { get; set; }
        public int Index { get; set; }
    }

    public class Multi
    {
        public string Name { get; set; }
    }
}
