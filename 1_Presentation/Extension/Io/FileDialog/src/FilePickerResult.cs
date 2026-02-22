// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FilePickerResult.cs
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

namespace Alis.Extension.Io.FileDialog
{
    /// <summary>
    ///     Represents the result of a file picker dialog operation.
    /// </summary>
    public class FilePickerResult
    {
        /// <summary>
        ///     Gets a value indicating whether the operation was successful.
        /// </summary>
        public bool IsSuccess { get; private set; }

        /// <summary>
        ///     Gets a value indicating whether the user cancelled the dialog.
        /// </summary>
        public bool IsCancelled { get; private set; }

        /// <summary>
        ///     Gets the list of selected file paths.
        /// </summary>
        public List<string> SelectedPaths { get; private set; }

        /// <summary>
        ///     Gets the error message if an error occurred.
        /// </summary>
        public string ErrorMessage { get; private set; }

        /// <summary>
        ///     Gets the first selected path (for single-file dialogs).
        /// </summary>
        public string SelectedPath => SelectedPaths?.FirstOrDefault();

        /// <summary>
        ///     Initializes a new instance of the FilePickerResult class for a successful operation.
        /// </summary>
        /// <param name="selectedPaths">The list of selected paths</param>
        /// <exception cref="ArgumentNullException">Thrown when selectedPaths is null</exception>
        /// <exception cref="ArgumentException">Thrown when selectedPaths is empty</exception>
        public FilePickerResult(List<string> selectedPaths)
        {
            if (selectedPaths == null)
            {
                throw new ArgumentNullException(nameof(selectedPaths), "Selected paths cannot be null.");
            }

            if (selectedPaths.Count == 0)
            {
                throw new ArgumentException("At least one path must be selected.", nameof(selectedPaths));
            }

            IsSuccess = true;
            IsCancelled = false;
            SelectedPaths = new List<string>(selectedPaths);
            ErrorMessage = null;
        }

        /// <summary>
        ///     Initializes a new instance of the FilePickerResult class for a successful operation with a single path.
        /// </summary>
        /// <param name="selectedPath">The single selected path</param>
        /// <exception cref="ArgumentNullException">Thrown when selectedPath is null</exception>
        /// <exception cref="ArgumentException">Thrown when selectedPath is empty</exception>
        public FilePickerResult(string selectedPath)
        {
            if (string.IsNullOrWhiteSpace(selectedPath))
            {
                throw new ArgumentException("Selected path cannot be null or empty.", nameof(selectedPath));
            }

            IsSuccess = true;
            IsCancelled = false;
            SelectedPaths = new List<string> { selectedPath };
            ErrorMessage = null;
        }

        /// <summary>
        ///     Creates a cancelled result.
        /// </summary>
        /// <returns>A cancelled FilePickerResult</returns>
        public static FilePickerResult CreateCancelled()
        {
            return new FilePickerResult
            {
                IsSuccess = false,
                IsCancelled = true,
                SelectedPaths = new List<string>(),
                ErrorMessage = "User cancelled the dialog."
            };
        }

        /// <summary>
        ///     Creates an error result.
        /// </summary>
        /// <param name="errorMessage">The error message</param>
        /// <returns>An error FilePickerResult</returns>
        /// <exception cref="ArgumentNullException">Thrown when errorMessage is null</exception>
        /// <exception cref="ArgumentException">Thrown when errorMessage is empty</exception>
        public static FilePickerResult CreateError(string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(errorMessage))
            {
                throw new ArgumentException("Error message cannot be null or empty.", nameof(errorMessage));
            }

            return new FilePickerResult
            {
                IsSuccess = false,
                IsCancelled = false,
                SelectedPaths = new List<string>(),
                ErrorMessage = errorMessage
            };
        }

        /// <summary>
        ///     Private constructor for factory methods.
        /// </summary>
        private FilePickerResult()
        {
            SelectedPaths = new List<string>();
        }
    }
}

