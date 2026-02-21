// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MacFilePicker.cs
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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alis.Core.Aspect.Logging;

namespace Alis.Extension.Io.FileDialog
{
    /// <summary>
    ///     FilePicker implementation for macOS.
    /// </summary>
    public class MacFilePicker : IFilePicker
    {

        /// <summary>
        ///     Opens a file picker dialog with advanced options to select a single file.
        /// </summary>
        /// <param name="options">The dialog options</param>
        /// <returns>The result containing selected file path or error information</returns>
        public FilePickerResult PickFile(FilePickerOptions options)
        {
            Logger.Trace($"PickFile() called with options - Title: {options?.Title}");

            try
            {
                FilePickerValidator.ValidateOptions(options);
                options.AllowMultiple = false;

                string script = BuildOpenFileScript(options, false);
                string result = ExecuteAppleScript(script);

                return ParseResult(result, options, false);
            }
            catch (Exception ex)
            {
                Logger.Error($"Error in PickFile(): {ex.Message}");
                return FilePickerResult.CreateError($"Error picking file: {ex.Message}");
            }
        }

        /// <summary>
        ///     Opens a file picker dialog allowing multiple file selection.
        /// </summary>
        /// <param name="options">The dialog options</param>
        /// <returns>The result containing selected file paths or error information</returns>
        public FilePickerResult PickFiles(FilePickerOptions options)
        {
            Logger.Trace($"PickFiles() called with options - Title: {options?.Title}");

            try
            {
                FilePickerValidator.ValidateOptions(options);
                options.AllowMultiple = true;

                string script = BuildOpenFileScript(options, true);
                string result = ExecuteAppleScript(script);

                return ParseResult(result, options, true);
            }
            catch (Exception ex)
            {
                Logger.Error($"Error in PickFiles(): {ex.Message}");
                return FilePickerResult.CreateError($"Error picking files: {ex.Message}");
            }
        }

        /// <summary>
        ///     Opens a folder picker dialog.
        /// </summary>
        /// <param name="options">The dialog options</param>
        /// <returns>The result containing the selected folder path or error information</returns>
        public FilePickerResult PickFolder(FilePickerOptions options)
        {
            Logger.Trace($"PickFolder() called with options - Title: {options?.Title}");

            try
            {
                FilePickerValidator.ValidateOptions(options);

                string script = BuildFolderSelectScript(options);
                string result = ExecuteAppleScript(script);

                return ParseResult(result, options, false);
            }
            catch (Exception ex)
            {
                Logger.Error($"Error in PickFolder(): {ex.Message}");
                return FilePickerResult.CreateError($"Error picking folder: {ex.Message}");
            }
        }

        /// <summary>
        ///     Builds an AppleScript for opening files.
        /// </summary>
        private string BuildOpenFileScript(FilePickerOptions options, bool allowMultiple)
        {
            Logger.Trace($"Building OpenFile AppleScript (allowMultiple: {allowMultiple}).");

            StringBuilder script = new StringBuilder();
            script.AppendLine("on run");

            // Build the choose file command with proper syntax
            StringBuilder chooseCmd = new StringBuilder("choose file");
            
            // Add prompt if title is provided
            if (!string.IsNullOrEmpty(options.Title))
            {
                chooseCmd.Append($" with prompt \"{EscapeAppleScript(options.Title)}\"");
            }

            // Add default location if provided
            if (!string.IsNullOrEmpty(options.DefaultPath))
            {
                chooseCmd.Append($" default location POSIX file \"{EscapeAppleScript(options.DefaultPath)}\"");
            }

            // Add multiple selections if needed
            if (allowMultiple)
            {
                chooseCmd.Append(" multiple selections allowed true");
            }

            script.AppendLine($"  set selectedItems to {chooseCmd}");
            script.AppendLine("  set output to \"\"");
            script.AppendLine("  repeat with selectedItem in selectedItems");
            script.AppendLine("    if output is \"\" then");
            script.AppendLine("      set output to POSIX path of selectedItem");
            script.AppendLine("    else");
            script.AppendLine("      set output to output & linefeed & POSIX path of selectedItem");
            script.AppendLine("    end if");
            script.AppendLine("  end repeat");
            script.AppendLine("  output");
            script.AppendLine("end run");

            return script.ToString();
        }

        /// <summary>
        ///     Builds an AppleScript for selecting a folder.
        /// </summary>
        private string BuildFolderSelectScript(FilePickerOptions options)
        {
            Logger.Trace("Building FolderSelect AppleScript.");

            StringBuilder script = new StringBuilder();
            script.AppendLine("on run");

            // Build the choose folder command with proper syntax
            StringBuilder chooseCmd = new StringBuilder("choose folder");
            
            // Add prompt if title is provided
            if (!string.IsNullOrEmpty(options.Title))
            {
                chooseCmd.Append($" with prompt \"{EscapeAppleScript(options.Title)}\"");
            }

            // Add default location if provided
            if (!string.IsNullOrEmpty(options.DefaultPath))
            {
                chooseCmd.Append($" default location POSIX file \"{EscapeAppleScript(options.DefaultPath)}\"");
            }

            script.AppendLine($"  set selectedFolder to {chooseCmd}");
            script.AppendLine("  POSIX path of selectedFolder");
            script.AppendLine("end run");

            return script.ToString();
        }

        /// <summary>
        ///     Executes an AppleScript using osascript.
        /// </summary>
        private string ExecuteAppleScript(string script)
        {
            Logger.Trace("Executing AppleScript via osascript.");

            try
            {
                // Create temporary file for the script securely
                string tmpFile = System.IO.Path.Combine(
                    System.IO.Path.GetTempPath(),
                    System.IO.Path.GetRandomFileName() + ".applescript");
                
                System.IO.File.WriteAllText(tmpFile, script);

                try
                {
                    string result = FilePickerExecutor.ExecuteCommand("osascript", tmpFile, 30000);
                    return result;
                }
                finally
                {
                    try
                    {
                        System.IO.File.Delete(tmpFile);
                    }
                    catch
                    {
                        // Ignore cleanup errors
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Warning($"Error executing AppleScript: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        ///     Parses the dialog result.
        /// </summary>
        private FilePickerResult ParseResult(string output, FilePickerOptions options, bool allowMultiple)
        {
            Logger.Trace($"Parsing result from AppleScript output: {output ?? "(null)"}");

            if (string.IsNullOrWhiteSpace(output))
            {
                Logger.Info("Dialog was cancelled by user.");
                return FilePickerResult.CreateCancelled();
            }

            try
            {
                var paths = FilePickerPathConverter.SplitMultiplePaths(output)
                    .Where(p => !string.IsNullOrEmpty(p))
                    .ToArray();

                if (paths.Length == 0)
                {
                    Logger.Info("No paths selected.");
                    return FilePickerResult.CreateCancelled();
                }

                Logger.Info($"Successfully selected {paths.Length} path(s).");
                return new FilePickerResult(paths.ToList());
            }
            catch (Exception ex)
            {
                Logger.Error($"Error parsing AppleScript result: {ex.Message}");
                return FilePickerResult.CreateError($"Error parsing result: {ex.Message}");
            }
        }

        /// <summary>
        ///     Escapes special characters in AppleScript strings.
        /// </summary>
        private string EscapeAppleScript(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            // Escape backslashes first, then quotes
            return input.Replace("\\", "\\\\").Replace("\"", "\\\"");
        }
    }
}