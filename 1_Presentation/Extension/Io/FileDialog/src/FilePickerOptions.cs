

using System;
using System.Collections.Generic;

namespace Alis.Extension.Io.FileDialog
{
    /// <summary>
    ///     Represents configuration options for file picker dialogs.
    /// </summary>
    public class FilePickerOptions
    {
        /// <summary>
        ///     Initializes a new instance of the FilePickerOptions class with default values.
        /// </summary>
        public FilePickerOptions()
        {
            Title = "Select a file";
            DefaultPath = null;
            Filters = new List<FilePickerFilter>();
            AllowMultiple = false;
            AllowDirectories = false;
            DialogType = FileDialogType.OpenFile;
        }

        /// <summary>
        ///     Initializes a new instance of the FilePickerOptions class with specified title and dialog type.
        /// </summary>
        /// <param name="title">The title of the dialog</param>
        /// <param name="dialogType">The type of dialog</param>
        /// <exception cref="ArgumentNullException">Thrown when title is null</exception>
        /// <exception cref="ArgumentException">Thrown when title is empty</exception>
        public FilePickerOptions(string title, FileDialogType dialogType = FileDialogType.OpenFile)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title cannot be null or empty.", nameof(title));
            }

            Title = title;
            DefaultPath = null;
            Filters = new List<FilePickerFilter>();
            AllowMultiple = false;
            AllowDirectories = false;
            DialogType = dialogType;
        }

        /// <summary>
        ///     Gets or sets the title of the dialog window.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///     Gets or sets the default path to start browsing.
        /// </summary>
        public string DefaultPath { get; set; }

        /// <summary>
        ///     Gets or sets the file filters available in the dialog.
        /// </summary>
        public List<FilePickerFilter> Filters { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether multiple files can be selected.
        /// </summary>
        public bool AllowMultiple { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether directories can be selected (only for SelectFolder dialog).
        /// </summary>
        public bool AllowDirectories { get; set; }

        /// <summary>
        ///     Gets or sets the type of dialog to display.
        /// </summary>
        public FileDialogType DialogType { get; set; }

        /// <summary>
        ///     Adds a file filter to the options.
        /// </summary>
        /// <param name="filter">The filter to add</param>
        /// <returns>The current options for fluent API</returns>
        /// <exception cref="ArgumentNullException">Thrown when filter is null</exception>
        public FilePickerOptions WithFilter(FilePickerFilter filter)
        {
            if (filter == null)
            {
                throw new ArgumentNullException(nameof(filter), "Filter cannot be null.");
            }

            Filters.Add(filter);
            return this;
        }

        /// <summary>
        ///     Sets the default path.
        /// </summary>
        /// <param name="path">The default path</param>
        /// <returns>The current options for fluent API</returns>
        public FilePickerOptions WithDefaultPath(string path)
        {
            DefaultPath = path;
            return this;
        }

        /// <summary>
        ///     Enables selection of multiple files.
        /// </summary>
        /// <returns>The current options for fluent API</returns>
        public FilePickerOptions WithMultipleSelection()
        {
            AllowMultiple = true;
            return this;
        }

        /// <summary>
        ///     Gets a value indicating whether this dialog allows directory selection.
        /// </summary>
        /// <returns>True if dialog type is SelectFolder, false otherwise</returns>
        public bool IsDirectoryDialog() => DialogType == FileDialogType.SelectFolder;
    }
}