using System;
using Alis.Core.Ecs.Systems;

namespace Alis.Core.Ecs.Sample.Components
{
    internal struct WriteAction : IAction<int>
    {
        public void Run(ref int x) => Console.Write($"{x++}, ");
    }
}