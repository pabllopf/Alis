namespace Alis.Extension.Io.FileDialog
{
    /// <summary>
    /// FilePicker implementation for Windows.
    /// </summary>
    public class WindowsFilePicker : IFilePicker
    {
        public string ChooseFile()
        {
            return string.Empty; // Return empty if no file was selected
        }
    }
}