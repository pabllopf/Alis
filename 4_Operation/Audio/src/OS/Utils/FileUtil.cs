using System.IO;

namespace Alis.Core.Audio.OS.Utils
{
    /// <summary>
    /// The file util class
    /// </summary>
    internal static class FileUtil
    {
        /// <summary>
        /// The temp dir name
        /// </summary>
        private const string TempDirName = "temp";

        /// <summary>
        /// Checks the file to play using the specified original file name
        /// </summary>
        /// <param name="originalFileName">The original file name</param>
        /// <returns>The file name to return</returns>
        public static string CheckFileToPlay(string originalFileName)
        {
            var fileNameToReturn = originalFileName;
            if (originalFileName.Contains(" "))
            {
                Directory.CreateDirectory(TempDirName);
                fileNameToReturn = TempDirName + Path.DirectorySeparatorChar + 
                    Path.GetFileName(originalFileName).Replace(" ", "");
                File.Copy(originalFileName, fileNameToReturn);
            }

            return fileNameToReturn;
        }

        /// <summary>
        /// Clears the temp files
        /// </summary>
        public static void ClearTempFiles()
        {
            if (Directory.Exists(TempDirName))
                Directory.Delete(TempDirName, true);
        }
    }
}
