

namespace Alis.Extension.Io.FileDialog
{
    /// <summary>
    ///     Enumeration representing different types of file dialogs.
    /// </summary>
    public enum FileDialogType
    {
        /// <summary>
        ///     Dialog for opening/selecting an existing file
        /// </summary>
        OpenFile = 0,

        /// <summary>
        ///     Dialog for saving a file with a new name
        /// </summary>
        SaveFile = 1,

        /// <summary>
        ///     Dialog for selecting a folder/directory
        /// </summary>
        SelectFolder = 2
    }
}