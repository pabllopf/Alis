// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WindowsFilePicker.cs
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

namespace Alis.Extension.Io.FileDialog
{
    /// <summary>
    ///     FilePicker implementation for Windows using PowerShell.
    /// </summary>
    public class WindowsFilePicker : IFilePicker
    {
        /// <summary>
        ///     Chooses the file
        /// </summary>
        /// <returns>The string</returns>
        public string ChooseFile()
        {
            // Start the process to invoke the PowerShell script that opens the file picker dialog
            // Start the process to invoke the PowerShell script that opens the file picker dialog
            Process process = new Process();
            process.StartInfo = new ProcessStartInfo
            {
                FileName = "powershell",
                Arguments = "-Command \"Add-Type -AssemblyName System.Windows.Forms; [System.Windows.Forms.OpenFileDialog]::new().ShowDialog()\"\n",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            // Start the process and capture its output
            process.Start();
            process.WaitForExit();

            // Check if the user selected a file or cancelled
            if (process.ExitCode == 0)
            {
                // The user selected a file (this can be expanded further to capture the file path)
               Logger.Info("File selected!");
                return "selected_file_path"; // Return the file path if a file is selected (replace with actual capture logic)
            }

            // The user cancelled or closed the dialog
           Logger.Info("The user cancelled or closed the dialog.");
            return null; // Return null if no file was selected
        }
    }
}