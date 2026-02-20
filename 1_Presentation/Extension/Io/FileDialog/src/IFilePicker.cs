// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IFilePicker.cs
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

namespace Alis.Extension.Io.FileDialog
{
    /// <summary>
    ///     Interface for file picker strategy pattern implementations across different operating systems.
    /// </summary>
    public interface IFilePicker
    {

        /// <summary>
        ///     Opens a file picker dialog with advanced options.
        /// </summary>
        /// <param name="options">The dialog options</param>
        /// <returns>The result containing selected file path(s) or error information</returns>
        FilePickerResult PickFile(FilePickerOptions options);

        /// <summary>
        ///     Opens a file picker dialog allowing multiple file selection.
        /// </summary>
        /// <param name="options">The dialog options</param>
        /// <returns>The result containing selected file paths or error information</returns>
        FilePickerResult PickFiles(FilePickerOptions options);

        /// <summary>
        ///     Opens a folder picker dialog.
        /// </summary>
        /// <param name="options">The dialog options</param>
        /// <returns>The result containing the selected folder path or error information</returns>
        FilePickerResult PickFolder(FilePickerOptions options);
    }
}