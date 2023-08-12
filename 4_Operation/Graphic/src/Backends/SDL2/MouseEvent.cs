namespace Alis.Core.Graphic.Backends.SDL2
{
    /// <summary>
    /// The mouse event
    /// </summary>
    public struct MouseEvent
    {
        /// <summary>
        /// Gets the value of the mouse button
        /// </summary>
        public MouseButton MouseButton { get; }
        /// <summary>
        /// Gets the value of the down
        /// </summary>
        public bool Down { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MouseEvent"/> class
        /// </summary>
        /// <param name="button">The button</param>
        /// <param name="down">The down</param>
        public MouseEvent(MouseButton button, bool down)
        {
            MouseButton = button;
            Down = down;
        }
    }

    /// <summary>
    /// The mouse button enum
    /// </summary>
    public enum MouseButton
    {
        //
        // Summary:
        //     The left mouse button.
        /// <summary>
        /// The left mouse button
        /// </summary>
        Left = 0,
        //
        // Summary:
        //     The middle mouse button.
        /// <summary>
        /// The middle mouse button
        /// </summary>
        Middle = 1,
        //
        // Summary:
        //     The right mouse button.
        /// <summary>
        /// The right mouse button
        /// </summary>
        Right = 2,
        //
        // Summary:
        //     The first extra mouse button.
        /// <summary>
        /// The button mouse button
        /// </summary>
        Button1 = 3,
        //
        // Summary:
        //     The second extra mouse button.
        /// <summary>
        /// The button mouse button
        /// </summary>
        Button2 = 4,
        //
        // Summary:
        //     The third extra mouse button.
        /// <summary>
        /// The button mouse button
        /// </summary>
        Button3 = 5,
        //
        // Summary:
        //     The fourth extra mouse button.
        /// <summary>
        /// The button mouse button
        /// </summary>
        Button4 = 6,
        //
        // Summary:
        //     The fifth extra mouse button.
        /// <summary>
        /// The button mouse button
        /// </summary>
        Button5 = 7,
        //
        // Summary:
        //     The sixth extra mouse button.
        /// <summary>
        /// The button mouse button
        /// </summary>
        Button6 = 8,
        //
        // Summary:
        //     The seventh extra mouse button.
        /// <summary>
        /// The button mouse button
        /// </summary>
        Button7 = 9,
        //
        // Summary:
        //     The eigth extra mouse button.
        /// <summary>
        /// The button mouse button
        /// </summary>
        Button8 = 10,
        //
        // Summary:
        //     The ninth extra mouse button.
        /// <summary>
        /// The button mouse button
        /// </summary>
        Button9 = 11,
        //
        // Summary:
        //     Indicates the last available mouse button.
        /// <summary>
        /// The last button mouse button
        /// </summary>
        LastButton = 12
    }
}