

namespace Alis.App.Installer
{
    /// <summary>
    ///     The program class
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     Entry point for the installer application. Initializes and runs the installer with the provided command-line arguments.
        /// </summary>
        /// <param name="args">Command-line arguments passed to the application.</param>
        public static void Main(string[] args)
        {
            new Installer().Run(args);
        }
    }
}