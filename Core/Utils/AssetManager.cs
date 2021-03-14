//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="AssetManager.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>Find any asset of the videogame.</summary>
    public static class AssetManager
    {
        /// <summary>The assets</summary>
        private static Dictionary<string, string> assets = new Dictionary<string, string>();

        /// <summary>Gets the assets path.</summary>
        /// <value>The assets path.</value>
        public static string AssetsPath => Environment.CurrentDirectory + "/Assets/";

        /// <summary>Loads the specified name.</summary>
        /// <param name="file">The name.</param>
        /// <returns>Return the path of assset</returns>
        public static string Load(string file)
        {
            if(assets.ContainsKey(file))
            {
                return assets[file];
            }

            foreach (string path in Directory.GetFiles(AssetsPath, "*", SearchOption.AllDirectories))
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

            throw new Exception("The asset " + file + " dont exit on the directory " + AssetsPath);
        }
    }
}
