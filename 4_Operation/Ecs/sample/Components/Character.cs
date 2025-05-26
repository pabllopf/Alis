using System;
using Alis.Core.Ecs.Components;

namespace Alis.Core.Ecs.Sample.Components
{
    /// <summary>
    /// The character
    /// </summary>
    struct Character(char c) : IComponent<Position>
    {
        /// <summary>
        /// The 
        /// </summary>
        public char Char = c;
        /// <summary>
        /// Updates the pos
        /// </summary>
        /// <param name="pos">The pos</param>
        public void Update(ref Position pos)
        {
            Console.SetCursorPosition(pos.X, pos.Y);
            Console.Write(Char);
        }
    }
}