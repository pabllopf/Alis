using System.Collections.Generic;
using System.Numerics;

namespace Alis.Core.Graphic.Backends.SDL2
{
    /// <summary>
    /// The input snapshot interface
    /// </summary>
    public interface InputSnapshot
    {
        /// <summary>
        /// Gets the value of the key events
        /// </summary>
        IReadOnlyList<KeyEvent> KeyEvents { get; }
        /// <summary>
        /// Gets the value of the mouse events
        /// </summary>
        IReadOnlyList<MouseEvent> MouseEvents { get; }
        /// <summary>
        /// Gets the value of the key char presses
        /// </summary>
        IReadOnlyList<char> KeyCharPresses { get; }
        /// <summary>
        /// Describes whether this instance is mouse down
        /// </summary>
        /// <param name="button">The button</param>
        /// <returns>The bool</returns>
        bool IsMouseDown(MouseButton button);
        /// <summary>
        /// Gets the value of the mouse position
        /// </summary>
        Vector2 MousePosition { get; }
        /// <summary>
        /// Gets the value of the wheel delta
        /// </summary>
        float WheelDelta { get; }
    }
}