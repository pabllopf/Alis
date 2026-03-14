using System;
using Alis.Core.Ecs.Kernel.Events;

namespace Alis.Core.Ecs.Sample.Samples
{
    internal sealed class RuntimeComponentEnumerationSample : IEcsSample
    {
        public string Key => "enumerate-components-runtime";

        public string Title => "Runtime Component Enumeration";

        public string Description => "Enumerates all components on an entity without knowing generic types at compile time.";

        public void Run()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(3, "runtime", 1.25f);

            Console.WriteLine("Enumerating component values:");
            entity.EnumerateComponents(default(PrintComponentAction));
        }

        private struct PrintComponentAction : IGenericAction
        {
            public void Invoke<T>(ref T type)
            {
                Console.WriteLine($"- {nameof(type)}: {type}");
            }
        }
    }
}

