using System;
using System.Diagnostics;
using System.IO;

namespace Alis.App.Engine.Desktop.Windows
{
    public class GitIntegration
    {
        /// <summary>
        /// Checks if Git is installed on the system.
        /// </summary>
        /// <returns>True if Git is installed, otherwise false.</returns>
        public static bool IsGitInstalled()
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "git",
                    Arguments = "--version",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = Process.Start(startInfo))
                {
                    process.WaitForExit();
                    return process.ExitCode == 0;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Checks if the current directory is a Git repository.
        /// </summary>
        /// <param name="directory">The directory to check.</param>
        /// <returns>True if the directory is a Git repository, otherwise false.</returns>
        public static bool IsGitRepository(string directory)
        {
            try
            {
                string gitFolderPath = Path.Combine(directory, ".git");
                return Directory.Exists(gitFolderPath);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Executes a Git command and returns the output.
        /// </summary>
        /// <param name="arguments">The Git command arguments.</param>
        /// <param name="workingDirectory">The working directory for the command.</param>
        /// <returns>The output of the Git command.</returns>
        public static string ExecuteGitCommand(string arguments, string workingDirectory)
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "git",
                    Arguments = arguments,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WorkingDirectory = workingDirectory
                };

                using (Process process = Process.Start(startInfo))
                {
                    string output = process.StandardOutput.ReadToEnd();
                    process.WaitForExit();
                    return output;
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
    }
}
