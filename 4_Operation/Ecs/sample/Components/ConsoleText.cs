using System;

using Alis.Core.Ecs.Components;

namespace Alis.Core.Ecs.Sample.Components
{
    /// <summary>
    /// The console text
    /// </summary>
    struct ConsoleText(ConsoleColor Color) : IComponent<string>
    {
        /// <summary>
        /// Updates the str
        /// </summary>
        /// <param name="str">The str</param>
        public void Update(ref string str)
        {
            Console.ForegroundColor = Color;
            Console.WriteLine(str);
        }
    }
}