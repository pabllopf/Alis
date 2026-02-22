// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FilePickerExecutor.cs
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
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Logging;

namespace Alis.Extension.Io.FileDialog
{
    /// <summary>
    ///     Provides methods for executing system commands related to file dialogs.
    /// </summary>
    public static class FilePickerExecutor
    {
        /// <summary>
        ///     Executes a system command and returns its output.
        /// </summary>
        /// <param name="fileName">The name of the executable to run</param>
        /// <param name="arguments">The command arguments</param>
        /// <param name="timeoutMs">The maximum time to wait for the process (in milliseconds)</param>
        /// <returns>The command output</returns>
        /// <exception cref="ArgumentNullException">Thrown when fileName is null</exception>
        /// <exception cref="ArgumentException">Thrown when fileName is empty</exception>
        public static string ExecuteCommand(string fileName, string arguments, int timeoutMs = 30000)
        {
            Logger.Trace($"Executing command: {fileName} with arguments: {arguments}");

            if (string.IsNullOrWhiteSpace(fileName))
            {
                Logger.Error("File name cannot be null or empty.");
                throw new ArgumentException("File name cannot be null or empty.", nameof(fileName));
            }

            Process process = null;

            try
            {
                process = new Process();
                process.StartInfo = new ProcessStartInfo
                {
                    FileName = fileName,
                    Arguments = arguments ?? string.Empty,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                Logger.Trace($"Starting process: {fileName}");
                process.Start();

                bool exited = process.WaitForExit(timeoutMs);
                if (!exited)
                {
                    Logger.Warning($"Process {fileName} did not exit within {timeoutMs}ms, killing it.");
                    process.Kill();
                    return null;
                }

                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();

                Logger.Trace($"Process {fileName} exited with code: {process.ExitCode}");

                if (process.ExitCode != 0 && !string.IsNullOrEmpty(error))
                {
                    Logger.Warning($"Command error: {error}");
                }

                return output;
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                Logger.Warning($"File not found or cannot execute: {fileName} - {ex.Message}");
                throw new InvalidOperationException($"Cannot execute {fileName}: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                Logger.Error($"Error executing command {fileName}: {ex.Message}");
                throw;
            }
            finally
            {
                process?.Dispose();
            }
        }

        /// <summary>
        ///     Checks if a command exists on the system.
        /// </summary>
        /// <param name="command">The command name to check</param>
        /// <returns>True if the command exists, false otherwise</returns>
        public static bool CommandExists(string command)
        {
            Logger.Trace($"Checking if command exists: {command}");

            if (string.IsNullOrWhiteSpace(command))
            {
                Logger.Warning("Command name cannot be null or empty.");
                return false;
            }

            try
            {
                string checkCommand = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                    ? $"where {command}"
                    : $"which {command}";

                string fileName = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "cmd" : "sh";
                string arguments = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                    ? $"/c {checkCommand}"
                    : $"-c {checkCommand}";

                string output = ExecuteCommand(fileName, arguments, 5000);
                bool exists = !string.IsNullOrEmpty(output);

                Logger.Trace($"Command '{command}' exists: {exists}");
                return exists;
            }
            catch (Exception ex)
            {
                Logger.Warning($"Error checking if command exists: {ex.Message}");
                return false;
            }
        }
    }
}


