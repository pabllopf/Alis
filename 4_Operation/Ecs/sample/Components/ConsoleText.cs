using System;

using Alis.Core.Ecs.Components;

namespace Alis.Core.Ecs.Sample.Components
{
    struct ConsoleText(ConsoleColor Color) : IComponent<string>
    {
        public void Update(ref string str)
        {
            Console.ForegroundColor = Color;
            Console.WriteLine(str);
        }
    }
}