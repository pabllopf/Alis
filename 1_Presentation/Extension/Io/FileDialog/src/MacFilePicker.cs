using System;
using System.Diagnostics;

namespace Alis.Extension.Io.FileDialog
{
    /// <summary>
    /// FilePicker implementation for macOS.
    /// </summary>
    public class MacFilePicker : IFilePicker
    {
        public string ChooseFile()
        {
            // Start the process to run the AppleScript that invokes the file picker dialog
            Process process = new Process();
            process.StartInfo = new ProcessStartInfo
            {
                FileName = "osascript",
                Arguments = "-e \"set selectedFile to choose file with prompt \\\"Select a file:\\\"\" -e \"POSIX path of selectedFile\"",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            // Start the process and read its output
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            // Check if the user selected a file or cancelled/closed the dialog
            if (string.IsNullOrEmpty(output))
            {
                Console.WriteLine("The user cancelled or closed the dialog.");
                return null; // Return null if the dialog was closed or cancelled
            }

            // Output is now the POSIX file path of the selected file
            Console.WriteLine($"File selected: {output}");
            return output; // Return the selected file path
        }
    }
}