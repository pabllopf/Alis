

using System;
using Alis.Core.Aspect.Fluent.Components;

namespace Alis.Core.Ecs.Sample.Components
{
    /// <summary>
    ///     The character
    /// </summary>
    internal struct Character(char c) : IOnUpdate<Position>
    {
        /// <summary>
        ///     The
        /// </summary>
        public char Char = c;

        /// <summary>
        ///     Updates the pos
        /// </summary>
        /// <param name="pos">The pos</param>
        public void Update(IGameObject self, ref Position pos)
        {
            Console.SetCursorPosition(pos.X, pos.Y);
            Console.Write(Char);
        }
    }
}