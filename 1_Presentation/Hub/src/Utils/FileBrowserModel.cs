using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Alis.App.Hub.Utils
{
    /// <summary>
    /// Modelo encargado de manejar la lógica del navegador de archivos.
    /// </summary>
    public class FileBrowserModel
    {
        /// <summary>
        /// Gets or sets the value of the current path
        /// </summary>
        public string CurrentPath { get; private set; }
        /// <summary>
        /// Gets or sets the value of the directory contents
        /// </summary>
        public List<string> DirectoryContents { get; private set; } = new List<string>();
        /// <summary>
        /// Gets or sets the value of the show hidden files
        /// </summary>
        public bool ShowHiddenFiles { get; set; } = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileBrowserModel"/> class
        /// </summary>
        /// <param name="initialPath">The initial path</param>
        public FileBrowserModel(string initialPath)
        {
            CurrentPath = initialPath ?? Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            UpdateDirectoryContents();
        }

        /// <summary>
        /// Navigates the to using the specified path
        /// </summary>
        /// <param name="path">The path</param>
        public void NavigateTo(string path)
        {
            if (Directory.Exists(path))
            {
                CurrentPath = path;
                UpdateDirectoryContents();
            }
        }

        /// <summary>
        /// Updates the directory contents
        /// </summary>
        public void UpdateDirectoryContents()
        {
            DirectoryContents.Clear();
            try
            {
                DirectoryContents.AddRange(Directory.GetDirectories(CurrentPath));
                DirectoryContents.AddRange(Directory.GetFiles(CurrentPath).Where(f =>
                    ShowHiddenFiles || !Path.GetFileName(f).StartsWith(".")));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating directory contents: {ex.Message}");
            }
        }
    }
}
