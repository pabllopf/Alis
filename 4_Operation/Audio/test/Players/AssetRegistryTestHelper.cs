using System;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using Alis.Core.Aspect.Memory;

namespace Alis.Core.Audio.Test.Players
{
    /// <summary>
    /// The asset registry test helper class
    /// </summary>
    internal static class AssetRegistryTestHelper
    {
        /// <summary>
        /// The static
        /// </summary>
        private static readonly FieldInfo ActiveNameField = typeof(AssetRegistry).GetField(
            "<ActiveAssemblyName>k__BackingField",
            BindingFlags.NonPublic | BindingFlags.Static);

        /// <summary>
        /// The get value
        /// </summary>
        private static readonly object GlobalLock =
            typeof(AssetRegistry).GetField("_globalLock", BindingFlags.NonPublic | BindingFlags.Static)?.GetValue(null);

        /// <summary>
        /// Saves the and set active using the specified assembly name
        /// </summary>
        /// <param name="assemblyName">The assembly name</param>
        /// <returns>The previous</returns>
        public static string SaveAndSetActive(string assemblyName)
        {
            string previous = (string)ActiveNameField?.GetValue(null);
            ActiveNameField?.SetValue(null, assemblyName);
            return previous;
        }

        /// <summary>
        /// Restores the active using the specified previous name
        /// </summary>
        /// <param name="previousName">The previous name</param>
        public static void RestoreActive(string previousName)
        {
            ActiveNameField?.SetValue(null, previousName);
        }

        /// <summary>
        /// Registers the new assembly using the specified entry name
        /// </summary>
        /// <param name="entryName">The entry name</param>
        /// <param name="content">The content</param>
        /// <returns>The name</returns>
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
