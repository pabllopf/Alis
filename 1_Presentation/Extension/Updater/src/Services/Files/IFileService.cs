// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IFileService.cs
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

using System.Threading.Tasks;

namespace Alis.Extension.Updater.Services.Files
{
    /// <summary>
    ///     The file service interface
    /// </summary>
    public interface IFileService
    {
        /// <summary>
        ///     Downloads the file using the specified url
        /// </summary>
        /// <param name="url">The url</param>
        /// <param name="directory">The directory</param>
        /// <returns>A task containing the string</returns>
        Task<string> DownloadFileAsync(string url, string directory);

        /// <summary>
        ///     Extracts the and replace using the specified zip path
        /// </summary>
        /// <param name="zipPath">The zip path</param>
        /// <param name="directory">The directory</param>
        void ExtractAndReplace(string zipPath, string directory);

        /// <summary>
        ///     Cleans the temp files using the specified directory
        /// </summary>
        /// <param name="directory">The directory</param>
        void CleanTempFiles(string directory);

        /// <summary>
        ///     Backups the directory
        /// </summary>
        /// <param name="directory">The directory</param>
        void Backup(string directory);
    }
}