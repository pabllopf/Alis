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
        /// <summary>The files</summary>
        [AllowNull]
        private static Dictionary<string, string> files;

        /// <summary>The work path</summary>
        [AllowNull]
        private static string workPath;

        /// <summary>Gets or sets the work path.</summary>
        /// <value>The work path.</value>
        public static string WorkPath { get => workPath; set => workPath = value; }

        /// <summary>Loads the specified name.</summary>
        /// <param name="file">The name.</param>
        /// <returns>Return the path of assset</returns>
        [return: MaybeNull]
        public static string Load(string file)
        {
            if (workPath == null) 
            {
                workPath = Environment.CurrentDirectory;
            }

            if (files == null) 
            {
                files = new Dictionary<string, string>();
            }

            if (files.ContainsKey(file))
            {
                return files[file];
            }

            if (Directory.Exists(workPath))
            {
                foreach (string path in Directory.GetFiles(workPath, "*", SearchOption.AllDirectories))
                {
                    if (Path.GetFileName(path).Equals(file))
                    {
                        if (!files.ContainsKey(file)) 
                        {
                            files.Add(file, path.Replace("\\", "/"));
                        }

                        return path.Replace("\\", "/");
                    }
                }
            }

            return null;
        }
    }
}
