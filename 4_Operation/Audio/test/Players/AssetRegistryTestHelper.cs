using System;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using Alis.Core.Aspect.Memory;

namespace Alis.Core.Audio.Test.Players
{
    internal static class AssetRegistryTestHelper
    {
        private static readonly FieldInfo ActiveNameField = typeof(AssetRegistry).GetField(
            "<ActiveAssemblyName>k__BackingField",
            BindingFlags.NonPublic | BindingFlags.Static);

        private static readonly object GlobalLock =
            typeof(AssetRegistry).GetField("_globalLock", BindingFlags.NonPublic | BindingFlags.Static)?.GetValue(null);

        public static string SaveAndSetActive(string assemblyName)
        {
            string previous = (string)ActiveNameField?.GetValue(null);
            ActiveNameField?.SetValue(null, assemblyName);
            return previous;
        }

        public static void RestoreActive(string previousName)
        {
            ActiveNameField?.SetValue(null, previousName);
        }

        public static string RegisterNewAssembly(string entryName, byte[] content)
        {
            byte[] zipBytes;
            using (MemoryStream zipMs = new MemoryStream())
            {
                using (ZipArchive archive = new ZipArchive(zipMs, ZipArchiveMode.Create, true))
                {
                    ZipArchiveEntry entry = archive.CreateEntry(entryName, CompressionLevel.Optimal);
                    using (Stream entryStream = entry.Open())
                    {
                        entryStream.Write(content, 0, content.Length);
                    }
                }
                zipBytes = zipMs.ToArray();
            }
            string name = "AssetRegistryTest_" + Guid.NewGuid().ToString("N");
            AssetRegistry.RegisterAssembly(name, () => new MemoryStream(zipBytes, false));
            return name;
        }
    }
}
