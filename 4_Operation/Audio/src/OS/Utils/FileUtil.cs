// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FileUtil.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System.IO;

namespace Alis.Core.Audio.OS.Utils
{
    /// <summary>
    ///     The file util class
    /// </summary>
    internal static class FileUtil
    {
        /// <summary>
        ///     The temp dir name
        /// </summary>
        private const string TempDirName = "temp";

        /// <summary>
        ///     Checks the file to play using the specified original file name
        /// </summary>
        /// <param name="originalFileName">The original file name</param>
        /// <returns>The file name to return</returns>
        public static string CheckFileToPlay(string originalFileName)
        {
            string fileNameToReturn = originalFileName;
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
        ///     Clears the temp files
        /// </summary>
        public static void ClearTempFiles()
        {
            if (Directory.Exists(TempDirName))
            {
                Directory.Delete(TempDirName, true);
            }
        }
    }
}