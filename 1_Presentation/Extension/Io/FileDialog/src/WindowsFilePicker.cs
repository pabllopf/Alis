using System;
using System.Diagnostics;

namespace Alis.Extension.Io.FileDialog
{
    /// <summary>
    /// FilePicker implementation for Windows using PowerShell.
    /// </summary>
    public class WindowsFilePicker : IFilePicker
    {
        public string ChooseFile()
        {
            // Start the process to invoke the PowerShell script that opens the file picker dialog
            // Start the process to invoke the PowerShell script that opens the file picker dialog
            Process process = new Process();
            process.StartInfo = new ProcessStartInfo
            {
                FileName = "powershell",
                Arguments = "-Command \"Add-Type -AssemblyName System.Windows.Forms; [System.Windows.Forms.OpenFileDialog]::new().ShowDialog()\"\n",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };


            // Start the process and capture its output
            process.Start();
            process.WaitForExit();

            // Check if the user selected a file or cancelled
            if (process.ExitCode == 0)
            {
                // The user selected a file (this can be expanded further to capture the file path)
                Console.WriteLine("File selected!");
                return "selected_file_path"; // Return the file path if a file is selected (replace with actual capture logic)
            }
            else
            {
                // The user cancelled or closed the dialog
                Console.WriteLine("The user cancelled or closed the dialog.");
                return null; // Return null if no file was selected
            }
        }
    }
}