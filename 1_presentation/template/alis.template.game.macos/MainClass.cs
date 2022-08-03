using AppKit;

namespace Alis.Template.Game.MacOs
{
    /// <summary>
    ///     The main class
    /// </summary>
    internal static class MainClass
    {
        /// <summary>
        ///     Main the args
        /// </summary>
        /// <param name="args">The args</param>
        private static void Main(string[] args)
        {
            NSApplication.Init();
            NSApplication.Main(args);
        }
    }
}