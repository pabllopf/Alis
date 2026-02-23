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
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Alis.Core.Aspect.Logging;

namespace Alis.Extension.Io.FileDialog
{
    /// <summary>
    ///     FilePicker implementation for Windows using PowerShell.
    /// </summary>
    public class WindowsFilePicker : IFilePicker
    {
        /// <summary>
        /// The file open script
        /// </summary>
        private const string FileOpenScript = @"
Add-Type -AssemblyName System.Windows.Forms
$dialog = New-Object System.Windows.Forms.OpenFileDialog
$dialog.Title = '{0}'
{1}
{2}
if ($dialog.ShowDialog() -eq 'OK') {{
    $dialog.FileName
}}
";

        /// <summary>
        /// The file save script
        /// </summary>
        private const string FileSaveScript = @"
Add-Type -AssemblyName System.Windows.Forms
$dialog = New-Object System.Windows.Forms.SaveFileDialog
$dialog.Title = '{0}'
{1}
{2}
if ($dialog.ShowDialog() -eq 'OK') {{
    $dialog.FileName
}}
";

        /// <summary>
        /// The folder select script
        /// </summary>
        private const string FolderSelectScript = @"
Add-Type -AssemblyName System.Windows.Forms
$dialog = New-Object System.Windows.Forms.FolderBrowserDialog
$dialog.Description = '{0}'
{1}
if ($dialog.ShowDialog() -eq 'OK') {{
    $dialog.SelectedPath
}}
";


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
                if (options == null) throw new ArgumentNullException(nameof(options));
                options.AllowMultiple = false;

                string script = BuildOpenFileScript(options);
                string result = ExecuteScript(script);

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
                if (options == null) throw new ArgumentNullException(nameof(options));
                options.AllowMultiple = true;

                string script = BuildOpenFileScript(options);
                string result = ExecuteScript(script);

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
                if (options == null) throw new ArgumentNullException(nameof(options));

                string script = BuildFolderSelectScript(options);
                string result = ExecuteScript(script);

                return ParseResult(result, options, false);
            }
            catch (Exception ex)
            {
                Logger.Error($"Error in PickFolder(): {ex.Message}");
                return FilePickerResult.CreateError($"Error picking folder: {ex.Message}");
            }
        }

        /// <summary>
        ///     Builds the PowerShell script for opening a file.
        /// </summary>
        private string BuildOpenFileScript(FilePickerOptions options)
        {
            Logger.Trace("Building OpenFile PowerShell script.");

            StringBuilder script = new StringBuilder(FileOpenScript);
            script.Replace("{0}", EscapeScriptString(options.Title ?? "Select a file"));

            // Add default path
            string pathConfig = string.Empty;
            if (!string.IsNullOrEmpty(options.DefaultPath))
            {
                pathConfig = $"$dialog.InitialDirectory = '{FilePickerPathConverter.ConvertPathSeparators(options.DefaultPath)}'";
            }

            script.Replace("{1}", pathConfig);

            // Add filters and multiselect
            StringBuilder optionsConfig = new StringBuilder();
            if (options.Filters != null && options.Filters.Count > 0)
            {
                optionsConfig.AppendLine("$dialog.Filter = '" + BuildFilterString(options.Filters) + "'");
            }

            if (options.AllowMultiple)
            {
                optionsConfig.AppendLine("$dialog.Multiselect = $true");
            }

            script.Replace("{2}", optionsConfig.ToString());

            return script.ToString();
        }

        /// <summary>
        ///     Builds the PowerShell script for selecting a folder.
        /// </summary>
        private string BuildFolderSelectScript(FilePickerOptions options)
        {
            Logger.Trace("Building FolderSelect PowerShell script.");

            StringBuilder script = new StringBuilder(FolderSelectScript);
            script.Replace("{0}", EscapeScriptString(options.Title ?? "Select a folder"));

            string pathConfig = string.Empty;
            if (!string.IsNullOrEmpty(options.DefaultPath))
            {
                pathConfig = $"$dialog.SelectedPath = '{FilePickerPathConverter.ConvertPathSeparators(options.DefaultPath)}'";
            }

            script.Replace("{1}", pathConfig);

            return script.ToString();
        }

        /// <summary>
        ///     Builds the filter string for Windows file dialogs.
        /// </summary>
        private string BuildFilterString(List<FilePickerFilter> filters)
        {
            Logger.Trace($"Building filter string for {filters.Count} filter(s).");

            if (filters == null || filters.Count == 0)
            {
                return "All files (*.*)|*.*";
            }

            var filterParts = filters.Select(f => $"{f.DisplayName}|{f.GetFormattedExtensions()}");
            string result = string.Join("|", filterParts) + "|All files (*.*)|*.*";

            Logger.Trace($"Filter string: {result}");
            return result;
        }

        /// <summary>
        ///     Executes a PowerShell script and returns the output.
        /// </summary>
        private string ExecuteScript(string script)
        {
            Logger.Trace("Executing PowerShell script.");

            try
            {
                return FilePickerExecutor.ExecuteCommand("powershell", $"-NoProfile -NonInteractive -Command \"{script}\"", 30000);
            }
            catch (Exception ex)
            {
                Logger.Warning($"Error executing PowerShell script: {ex.Message}");
                throw;
            }
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
                var paths = allowMultiple
                    ? FilePickerPathConverter.SplitMultiplePaths(output)
                    : new[] { FilePickerPathConverter.NormalizePath(output) };

                paths = paths.Where(p => !string.IsNullOrEmpty(p)).ToArray();

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
        ///     Escapes special characters in PowerShell strings.
        /// </summary>
        private string EscapeScriptString(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return input
                .Replace("'", "''")
                .Replace("\"", "`\"")
                .Replace("$", "`$");
        }
    }
}