using AppKit;

namespace DrawCube
{
    /// <summary>
    /// The main class
    /// </summary>
    static class MainClass
    {
        /// <summary>
        /// Main the args
        /// </summary>
        /// <param name="args">The args</param>
        static void Main(string[] args)
        {
            NSApplication.Init();
            NSApplication.Main(args);
        }
    }
}
