// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GitIntegration.cs
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
using System.IO;

namespace Alis.App.Engine.Windows
{
    /// <summary>
    ///     The git integration class
    /// </summary>
    public class GitIntegration
    {
        /// <summary>
        ///     Checks if Git is installed on the system.
        /// </summary>
        /// <returns>True if Git is installed, otherwise false.</returns>
        public static bool IsGitInstalled()
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "git",
                    Arguments = "--version",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = Process.Start(startInfo))
                {
                    process.WaitForExit();
                    return process.ExitCode == 0;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        ///     Checks if the current directory is a Git repository.
        /// </summary>
        /// <param name="directory">The directory to check.</param>
        /// <returns>True if the directory is a Git repository, otherwise false.</returns>
        public static bool IsGitRepository(string directory)
        {
            try
            {
                string gitFolderPath = Path.Combine(directory, ".git");
                return Directory.Exists(gitFolderPath);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        ///     Executes a Git command and returns the output.
        /// </summary>
        /// <param name="arguments">The Git command arguments.</param>
        /// <param name="workingDirectory">The working directory for the command.</param>
        /// <returns>The output of the Git command.</returns>
        public static string ExecuteGitCommand(string arguments, string workingDirectory)
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "git",
                    Arguments = arguments,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WorkingDirectory = workingDirectory
                };

                using (Process process = Process.Start(startInfo))
                {
                    string output = process.StandardOutput.ReadToEnd();
                    process.WaitForExit();
                    return output;
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
    }
}