// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Program.cs
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
using Alis.Core.Aspect.Logging;

namespace Alis.Extension.Io.FileDialog.Sample
{
    /// <summary>
    ///     Sample program demonstrating FileDialog functionality.
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     Main entry point
        /// </summary>
        /// <param name="args">Command line arguments</param>
        public static void Main(string[] args)
        {
            try
            {
                Logger.Info("=== FileDialog Sample Application ===");
                Logger.Info($"Platform: {FilePickerFactory.GetPlatformName()}");
                Logger.Info($"Platform Supported: {FilePickerFactory.IsPlatformSupported()}");
                Logger.Info("");

                // Get the platform-specific file picker
                IFilePicker filePicker = FilePickerFactory.CreateFilePicker();

                // Example 1: Legacy method (single file selection)
                DemonstrateLegacyMethod(filePicker);

                Logger.Info("");

                // Example 2: Single file selection with options
                DemonstrateSingleFileSelection(filePicker);

                Logger.Info("");

                // Example 3: Multiple file selection
                DemonstrateMultipleFileSelection(filePicker);

                Logger.Info("");

                // Example 4: Folder selection
                DemonstrateFolderSelection(filePicker);

                Logger.Info("");

                // Example 5: File selection with filters
                DemonstrateFileSelectionWithFilters(filePicker);

                Logger.Info("");
                Logger.Info("=== Sample Application Completed ===");
            }
            catch (Exception ex)
            {
                Logger.Error($"An error occurred: {ex.Message}");
                Logger.Error($"Stack Trace: {ex.StackTrace}");
            }
        }

        /// <summary>
        ///     Demonstrates the legacy ChooseFile method.
        /// </summary>
        private static void DemonstrateLegacyMethod(IFilePicker filePicker)
        {
            Logger.Info("--- Example 1: Legacy Method (ChooseFile) ---");
            Logger.Info("Note: This method opens a dialog. Press Cancel or Escape to skip.");

            try
            {
                string selectedFile = filePicker.ChooseFile();

                if (!string.IsNullOrEmpty(selectedFile))
                {
                    Logger.Info($"Selected file: {selectedFile}");
                }
                else
                {
                    Logger.Info("No file selected.");
                }
            }
            catch (Exception ex)
            {
                Logger.Warning($"Legacy method error: {ex.Message}");
            }
        }

        /// <summary>
        ///     Demonstrates single file selection with options.
        /// </summary>
        private static void DemonstrateSingleFileSelection(IFilePicker filePicker)
        {
            Logger.Info("--- Example 2: Single File Selection ---");

            try
            {
                var options = new FilePickerOptions("Select a File", FileDialogType.OpenFile)
                    .WithDefaultPath(System.IO.Path.GetTempPath());

                Logger.Info("Opening file dialog...");
                FilePickerResult result = filePicker.PickFile(options);

                if (result.IsSuccess)
                {
                    Logger.Info($"File selected: {result.SelectedPath}");
                }
                else if (result.IsCancelled)
                {
                    Logger.Info("Dialog was cancelled by user.");
                }
                else
                {
                    Logger.Warning($"Error: {result.ErrorMessage}");
                }
            }
            catch (Exception ex)
            {
                Logger.Warning($"Error in single file selection: {ex.Message}");
            }
        }

        /// <summary>
        ///     Demonstrates multiple file selection.
        /// </summary>
        private static void DemonstrateMultipleFileSelection(IFilePicker filePicker)
        {
            Logger.Info("--- Example 3: Multiple File Selection ---");

            try
            {
                var options = new FilePickerOptions("Select Multiple Files", FileDialogType.OpenFile)
                    .WithDefaultPath(System.IO.Path.GetTempPath())
                    .WithMultipleSelection();

                Logger.Info("Opening multiple file dialog...");
                FilePickerResult result = filePicker.PickFiles(options);

                if (result.IsSuccess)
                {
                    Logger.Info($"Selected {result.SelectedPaths.Count} file(s):");
                    for (int i = 0; i < result.SelectedPaths.Count; i++)
                    {
                        Logger.Info($"  {i + 1}. {result.SelectedPaths[i]}");
                    }
                }
                else if (result.IsCancelled)
                {
                    Logger.Info("Dialog was cancelled by user.");
                }
                else
                {
                    Logger.Warning($"Error: {result.ErrorMessage}");
                }
            }
            catch (Exception ex)
            {
                Logger.Warning($"Error in multiple file selection: {ex.Message}");
            }
        }

        /// <summary>
        ///     Demonstrates folder selection.
        /// </summary>
        private static void DemonstrateFolderSelection(IFilePicker filePicker)
        {
            Logger.Info("--- Example 4: Folder Selection ---");

            try
            {
                var options = new FilePickerOptions("Select a Folder", FileDialogType.SelectFolder)
                    .WithDefaultPath(System.IO.Path.GetTempPath());

                Logger.Info("Opening folder dialog...");
                FilePickerResult result = filePicker.PickFolder(options);

                if (result.IsSuccess)
                {
                    Logger.Info($"Folder selected: {result.SelectedPath}");
                }
                else if (result.IsCancelled)
                {
                    Logger.Info("Dialog was cancelled by user.");
                }
                else
                {
                    Logger.Warning($"Error: {result.ErrorMessage}");
                }
            }
            catch (Exception ex)
            {
                Logger.Warning($"Error in folder selection: {ex.Message}");
            }
        }

        /// <summary>
        ///     Demonstrates file selection with filters.
        /// </summary>
        private static void DemonstrateFileSelectionWithFilters(IFilePicker filePicker)
        {
            Logger.Info("--- Example 5: File Selection with Filters ---");

            try
            {
                var options = new FilePickerOptions("Select a Text or Document File", FileDialogType.OpenFile)
                    .WithDefaultPath(System.IO.Path.GetTempPath())
                    .WithFilter(new FilePickerFilter("Text Files", "txt", "log"))
                    .WithFilter(new FilePickerFilter("Document Files", "doc", "docx", "pdf"))
                    .WithFilter(new FilePickerFilter("All Files", "*"));

                Logger.Info("Opening filtered file dialog...");
                Logger.Info("Filters configured:");
                foreach (var filter in options.Filters)
                {
                    Logger.Info($"  - {filter.DisplayName}: {filter.GetFormattedExtensions()}");
                }

                FilePickerResult result = filePicker.PickFile(options);

                if (result.IsSuccess)
                {
                    Logger.Info($"File selected: {result.SelectedPath}");
                    
                    // Validate the result
                    bool isValid = FilePickerValidator.IsResultValid(result, options);
                    Logger.Info($"Result validation: {(isValid ? "PASSED" : "FAILED")}");
                }
                else if (result.IsCancelled)
                {
                    Logger.Info("Dialog was cancelled by user.");
                }
                else
                {
                    Logger.Warning($"Error: {result.ErrorMessage}");
                }
            }
            catch (Exception ex)
            {
                Logger.Warning($"Error in filtered file selection: {ex.Message}");
            }
        }
    }
}

