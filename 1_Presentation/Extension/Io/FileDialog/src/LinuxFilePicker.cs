// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:LinuxFilePicker.cs
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

using System;
using System.Diagnostics;
using Alis.Core.Aspect.Logging;

namespace Alis.Extension.Io.FileDialog
{
    /// <summary>
    ///     FilePicker implementation for Linux.
    /// </summary>
    public class LinuxFilePicker : IFilePicker
    {
        /// <summary>
        ///     Chooses the file
        /// </summary>
        /// <returns>The output</returns>
        public string ChooseFile()
        {
            // Start the process to run the zenity command that invokes the file picker dialog
            Process process = new Process();
            process.StartInfo = new ProcessStartInfo
            {
                FileName = "zenity",
                Arguments = "--file-selection --title=\"Select a file\"",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            // Start the process and read its output
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            // Check if the user selected a file or cancelled/closed the dialog
            if (string.IsNullOrEmpty(output))
            {
               Logger.Info("The user cancelled or closed the dialog.");
                return null; // Return null if the dialog was closed or cancelled
            }

            // Output is now the file path of the selected file
           Logger.Info($"File selected: {output}");
            return output; // Return the selected file path
        }
    }
}