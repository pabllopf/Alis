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
using System.Collections.Generic;
using System.Linq;
using Alis.Core.Aspect.Logging;

namespace Alis.Extension.Io.FileDialog
{
    /// <summary>
    ///     FilePicker implementation for Linux using zenity/kdialog.
    /// </summary>
    public class LinuxFilePicker : IFilePicker
    {
        /// <summary>
        /// The default dialog tool
        /// </summary>
        private const string DefaultDialogTool = "zenity";
        /// <summary>
        /// The fallback dialog tool
        /// </summary>
        private const string FallbackDialogTool = "kdialog";


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

                string result = ExecuteFileDialog(options, false);
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

                string result = ExecuteFileDialog(options, true);
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

                string result = ExecuteFolderDialog(options);
                return ParseResult(result, options, false);
            }
            catch (Exception ex)
            {
                Logger.Error($"Error in PickFolder(): {ex.Message}");
                return FilePickerResult.CreateError($"Error picking folder: {ex.Message}");
            }
        }

        /// <summary>
        ///     Executes the file dialog using zenity or kdialog.
        /// </summary>
        private string ExecuteFileDialog(FilePickerOptions options, bool allowMultiple)
        {
            Logger.Trace($"Executing file dialog (allowMultiple: {allowMultiple}).");

            string tool = GetAvailableDialogTool();
            if (string.IsNullOrEmpty(tool))
            {
                throw new InvalidOperationException("Neither zenity nor kdialog is available on this system.");
            }

            Logger.Info($"Using {tool} for file dialog.");

            string arguments = BuildFileDialogArguments(tool, options, allowMultiple);
            return FilePickerExecutor.ExecuteCommand(tool, arguments, 30000);
        }

        /// <summary>
        ///     Executes the folder dialog using zenity or kdialog.
        /// </summary>
        private string ExecuteFolderDialog(FilePickerOptions options)
        {
            Logger.Trace("Executing folder dialog.");

            string tool = GetAvailableDialogTool();
            if (string.IsNullOrEmpty(tool))
            {
                throw new InvalidOperationException("Neither zenity nor kdialog is available on this system.");
            }

            Logger.Info($"Using {tool} for folder dialog.");

            string arguments = BuildFolderDialogArguments(tool, options);
            return FilePickerExecutor.ExecuteCommand(tool, arguments, 30000);
        }

        /// <summary>
        ///     Gets the available dialog tool (zenity or kdialog).
        /// </summary>
        private string GetAvailableDialogTool()
        {
            Logger.Trace("Checking for available dialog tools...");

            if (FilePickerExecutor.CommandExists(DefaultDialogTool))
            {
                Logger.Info("Found zenity.");
                return DefaultDialogTool;
            }

            if (FilePickerExecutor.CommandExists(FallbackDialogTool))
            {
                Logger.Info("Found kdialog (zenity not available).");
                return FallbackDialogTool;
            }

            Logger.Warning("Neither zenity nor kdialog found.");
            return null;
        }

        /// <summary>
        ///     Builds the arguments for the file dialog command.
        /// </summary>
        private string BuildFileDialogArguments(string tool, FilePickerOptions options, bool allowMultiple)
        {
            Logger.Trace($"Building file dialog arguments for {tool}.");

            var args = new List<string>();

            if (tool == DefaultDialogTool) // zenity
            {
                args.Add("--file-selection");

                if (!string.IsNullOrEmpty(options.Title))
                {
                    args.Add($"--title=\"{EscapeShellString(options.Title)}\"");
                }

                if (!string.IsNullOrEmpty(options.DefaultPath))
                {
                    args.Add($"--filename=\"{EscapeShellString(options.DefaultPath)}\"");
                }

                if (allowMultiple)
                {
                    args.Add("--multiple");
                    args.Add("--separator=|");
                }

                if (options.Filters != null && options.Filters.Count > 0)
                {
                    foreach (var filter in options.Filters)
                    {
                        args.Add($"--file-filter=\"{EscapeShellString(filter.DisplayName)} | {filter.GetFormattedExtensions()}\"");
                    }
                    args.Add("--file-filter=\"All files | *\"");
                }
            }
            else if (tool == FallbackDialogTool) // kdialog
            {
                if (allowMultiple)
                {
                    args.Add("--getopenfilenames");
                }
                else
                {
                    args.Add("--getopenfilename");
                }

                if (!string.IsNullOrEmpty(options.DefaultPath))
                {
                    args.Add(EscapeShellString(options.DefaultPath));
                }
                else
                {
                    args.Add("~/");
                }

                if (options.Filters != null && options.Filters.Count > 0)
                {
                    var filterStr = string.Join(" ", options.Filters.Select(f => $"{f.DisplayName} ({f.GetFormattedExtensions()})"));
                    args.Add($"\"{EscapeShellString(filterStr)}\"");
                }

                if (!string.IsNullOrEmpty(options.Title))
                {
                    args.Add($"--title \"{EscapeShellString(options.Title)}\"");
                }
            }

            return string.Join(" ", args);
        }

        /// <summary>
        ///     Builds the arguments for the folder dialog command.
        /// </summary>
        private string BuildFolderDialogArguments(string tool, FilePickerOptions options)
        {
            Logger.Trace($"Building folder dialog arguments for {tool}.");

            var args = new List<string>();

            if (tool == DefaultDialogTool) // zenity
            {
                args.Add("--file-selection");
                args.Add("--directory");

                if (!string.IsNullOrEmpty(options.Title))
                {
                    args.Add($"--title=\"{EscapeShellString(options.Title)}\"");
                }

                if (!string.IsNullOrEmpty(options.DefaultPath))
                {
                    args.Add($"--filename=\"{EscapeShellString(options.DefaultPath)}\"");
                }
            }
            else if (tool == FallbackDialogTool) // kdialog
            {
                args.Add("--getexistingdirectory");

                if (!string.IsNullOrEmpty(options.DefaultPath))
                {
                    args.Add(EscapeShellString(options.DefaultPath));
                }
                else
                {
                    args.Add("~/");
                }

                if (!string.IsNullOrEmpty(options.Title))
                {
                    args.Add($"--title \"{EscapeShellString(options.Title)}\"");
                }
            }

            return string.Join(" ", args);
        }

        /// <summary>
        ///     Parses the dialog result.
        /// </summary>
        private FilePickerResult ParseResult(string output, FilePickerOptions options, bool allowMultiple)
        {
            Logger.Trace($"Parsing result from dialog output: {output ?? "(null)"}");

            if (string.IsNullOrWhiteSpace(output))
            {
                Logger.Info("Dialog was cancelled by user.");
                return FilePickerResult.CreateCancelled();
            }

            try
            {
                string[] paths;

                if (allowMultiple)
                {
                    // For zenity, multiple paths are separated by |
                    paths = output.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(p => FilePickerPathConverter.NormalizePath(p))
                        .Where(p => !string.IsNullOrEmpty(p))
                        .ToArray();
                }
                else
                {
                    paths = new[] { FilePickerPathConverter.NormalizePath(output) };
                }

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
                Logger.Error($"Error parsing dialog result: {ex.Message}");
                return FilePickerResult.CreateError($"Error parsing result: {ex.Message}");
            }
        }

        /// <summary>
        ///     Escapes special characters in shell strings.
        /// </summary>
        private string EscapeShellString(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Replace("\"", "\\\"").Replace("'", "\\'").Replace("$", "\\$");
        }
    }
}