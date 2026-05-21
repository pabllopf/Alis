

using System;

namespace Alis.Extension.Graphic.Glfw
{
    /// <summary>
    ///     Arguments supplied with file drag-drop events.
    /// </summary>
    /// <seealso cref="EventArgs" />
    public class FileDropEventArgs : EventArgs
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="FileDropEventArgs" /> class.
        /// </summary>
        /// <param name="filenames">The dropped filenames.</param>
        public FileDropEventArgs(string[] filenames) => Filenames = filenames;


        /// <summary>
        ///     Gets the filenames of the dropped files.
        /// </summary>
        /// <value>
        ///     The filenames.
        /// </value>
        public string[] Filenames { get; }
    }
}