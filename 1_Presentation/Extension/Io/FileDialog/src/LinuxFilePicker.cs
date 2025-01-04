

namespace Alis.Extension.Io.FileDialog
{
    /// <summary>
    /// FilePicker implementation for Linux (using GTK).
    /// </summary>
    public class LinuxFilePicker : IFilePicker
    {
        public string ChooseFile()
        {
            return "linux_selected_file_path";
        }
    }
}