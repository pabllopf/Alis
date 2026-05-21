

using System;
using Alis.Core.Aspect.Fluent.Components;

namespace Alis.Core.Ecs.Sample.Components
{
    /// <summary>
    ///     The console text
    /// </summary>
    internal struct ConsoleText(ConsoleColor Color) : IOnUpdate<string>
    {
        /// <summary>
        ///     Updates the str
        /// </summary>
        /// <param name="str">The str</param>
        public void Update(IGameObject self, ref string str)
        {
            ConsoleColor previousColor = Console.ForegroundColor;
            Console.ForegroundColor = Color;
            Console.WriteLine(str);
            Console.ForegroundColor = previousColor;
        }
    }
}