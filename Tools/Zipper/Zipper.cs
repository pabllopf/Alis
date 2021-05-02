//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Zipper.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Tools
{
    using System.IO;
    using Ionic.Zip;

    /// <summary>Manage zip files. </summary>
    public class Zipper
    {
        /// <summary>Zips the specified directory.</summary>
        /// <param name="directory">The directory.</param>
        public static void Zip(string directory) 
        {
            if (!Directory.Exists(directory)) 
            {
                Directory.CreateDirectory(directory);
            }

            string[] directories = directory.Split(new[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar });
            string dirName = directories[directories.Length - 1].Equals(string.Empty) ? directories[directories.Length - 2] : directories[directories.Length - 1];
            string zipName = dirName + ".zip";
            string[] files = Directory.GetFiles(directory, "*", SearchOption.AllDirectories);
            string finalDir = string.Empty;

            foreach (string dir in directories) 
            {
                if (dir.Equals(string.Empty)) 
                {
                    break;
                }

                if (dir.Equals(dirName))
                {
                    break;
                }

                finalDir += dir + "/";   
            }
            
            using (ZipFile zip = new ZipFile())
            {
                foreach (string file in files)
                {
                    zip.AddFile(file, string.Empty);
                }

                Logger.Log(finalDir + zipName);
                zip.Save(finalDir + zipName);
            }
        }

        /// <summary>Zips the specified directory.</summary>
        /// <param name="directory">The directory.</param>
        /// <param name="zipName">Name of the zip.</param>
        public static void Zip(string directory, string zipName)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string[] directories = directory.Split(new[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar });
            string dirName = directories[directories.Length - 1].Equals(string.Empty) ? directories[directories.Length - 2] : directories[directories.Length - 1];
            string[] files = Directory.GetFiles(directory, "*", SearchOption.AllDirectories);
            string finalDir = string.Empty;

            foreach (string dir in directories)
            {
                if (dir.Equals(string.Empty))
                {
                    break;
                }

                if (dir.Equals(dirName))
                {
                    break;
                }

                finalDir += dir + "/";
            }

            using (ZipFile zip = new ZipFile())
            {
                foreach (string file in files)
                {
                    zip.AddFile(file, string.Empty);
                }

                zip.Save(finalDir + zipName);
            }
        }

        /// <summary>Unzips the specified zip file path.</summary>
        /// <param name="zipFile">The zip file path.</param>
        public static void UnZip(string zipFile)
        {
            if (!File.Exists(zipFile))
            {
                throw new FileNotFoundException(zipFile);
            }

            string outPutDir = Path.GetDirectoryName(zipFile);
            using (ZipFile zip = ZipFile.Read(zipFile))
            {
                zip.ExtractAll(outPutDir, ExtractExistingFileAction.OverwriteSilently);
            }
        }

        /// <summary>Unzips the specified zip file path.</summary>
        /// <param name="zipFile">The zip file path.</param>
        /// <param name="outPutDir">output directory</param>
        public static void UnZip(string zipFile, string outPutDir)
        {
            if (!File.Exists(zipFile))
            {
                throw new FileNotFoundException(zipFile);
            }

            if (!Directory.Exists(outPutDir)) 
            {
                Directory.CreateDirectory(outPutDir);
            }

            using (ZipFile zip = ZipFile.Read(zipFile))
            {
                zip.ExtractAll(outPutDir, ExtractExistingFileAction.OverwriteSilently);
            }
        }

        /// <summary>Zips the specified zip file name.</summary>
        /// <param name="zipFile">Name of the zip file.</param>
        /// <param name="files">The files.</param>
        public static void Zip(string zipFile, params string[] files)
        {
            string path = Path.GetDirectoryName(zipFile);
            Directory.CreateDirectory(path);

            using (ZipFile zip = new ZipFile())
            {
                foreach (string file in files)
                {
                    zip.AddFile(file, string.Empty);
                }

                zip.Save(zipFile);
            }
        }
    }
}