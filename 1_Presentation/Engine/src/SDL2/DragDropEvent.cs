namespace Veldrid.Sdl2
{
    /// <summary>
    /// The drag drop event
    /// </summary>
    public struct DragDropEvent
    {
        /// <summary>
        /// Gets the value of the file
        /// </summary>
        public string File { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DragDropEvent"/> class
        /// </summary>
        /// <param name="file">The file</param>
        public DragDropEvent(string file)
        {
            File = file;
        }
    }
}