namespace Alis.Core.Graphic.Backends.SDL2
{
    /// <summary>
    /// The modifier keys enum
    /// </summary>
    [System.Flags]
    public enum ModifierKeys
    {
        /// <summary>
        /// The none modifier keys
        /// </summary>
        None = 0,
        /// <summary>
        /// The alt modifier keys
        /// </summary>
        Alt = 1,
        /// <summary>
        /// The control modifier keys
        /// </summary>
        Control = 2,
        /// <summary>
        /// The shift modifier keys
        /// </summary>
        Shift = 4,
        /// <summary>
        /// The gui modifier keys
        /// </summary>
        Gui = 8,
    }
}
