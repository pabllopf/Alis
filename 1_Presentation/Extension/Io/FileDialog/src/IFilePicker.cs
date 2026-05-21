

namespace Alis.Extension.Io.FileDialog
{
    /// <summary>
    ///     Interface for file picker strategy pattern implementations across different operating systems.
    /// </summary>
    public interface IFilePicker
    {
        /// <summary>
        ///     Opens a file picker dialog with advanced options.
        /// </summary>
        /// <param name="options">The dialog options</param>
        /// <returns>The result containing selected file path(s) or error information</returns>
        FilePickerResult PickFile(FilePickerOptions options);

        /// <summary>
        ///     Opens a file picker dialog allowing multiple file selection.
        /// </summary>
        /// <param name="options">The dialog options</param>
        /// <returns>The result containing selected file paths or error information</returns>
        FilePickerResult PickFiles(FilePickerOptions options);

        /// <summary>
        ///     Opens a folder picker dialog.
        /// </summary>
        /// <param name="options">The dialog options</param>
        /// <returns>The result containing the selected folder path or error information</returns>
        FilePickerResult PickFolder(FilePickerOptions options);
    }
}