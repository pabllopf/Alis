//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="AssetManager.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Tools
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;

    /// <summary>Find any asset of the videogame.</summary>
    public static class Asset
    {
        private static string workPath = string.Empty;

        /// <summary>The assets</summary>
        private static Dictionary<string, string> assets = new Dictionary<string, string>();

        /// <summary>Gets the assets path.</summary>
        /// <value>The assets path.</value>
        public static string AssetsPath => Environment.CurrentDirectory + "/Assets/";

        /// <summary>Gets or sets the work path.</summary>
        /// <value>The work path.</value>
        public static void SetWorkPath(string message) 
        {
            workPath = message;
        }

        /// <summary>Loads the specified name.</summary>
        /// <param name="file">The name.</param>
        /// <returns>Return the path of assset</returns>
        [return: MaybeNull]
        public static string Load(string file)
        {
            if (assets.ContainsKey(file))
            {
                return assets[file];
            }

            string tempPath = !workPath.Equals(string.Empty) ? workPath : AssetsPath;

            if (Directory.Exists(tempPath))
            {
                foreach (string path in Directory.GetFiles(tempPath, "*", SearchOption.AllDirectories))
                {
                    if (Path.GetFileName(path).Equals(file))
                    {
                        if (!assets.ContainsKey(file))
                        {
                            assets.Add(file, path);
                        }

                        return path;
                    }
                }
            }

            return null;
        }
    }
}
