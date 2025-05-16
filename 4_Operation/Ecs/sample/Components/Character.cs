using System;
using Alis.Core.Ecs.Components;

namespace Alis.Core.Ecs.Sample.Components
{
    struct Character(char c) : IComponent<Position>
    {
        public char Char = c;
        public void Update(ref Position pos)
        {
            Console.SetCursorPosition(pos.X, pos.Y);
            Console.Write(Char);
        }
    }
}