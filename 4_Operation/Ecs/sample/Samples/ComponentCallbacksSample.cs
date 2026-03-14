using Alis.Core.Ecs.Sample.Components;

namespace Alis.Core.Ecs.Sample.Samples
{
    /// <summary>
    /// The component callbacks sample class
    /// </summary>
    /// <seealso cref="IEcsSample"/>
    internal sealed class ComponentCallbacksSample : IEcsSample
    {
        /// <summary>
        /// Gets the value of the key
        /// </summary>
        public string Key => "callbacks";

        /// <summary>
        /// Gets the value of the title
        /// </summary>
        public string Title => "Component Callbacks";

        /// <summary>
        /// Gets the value of the description
        /// </summary>
        public string Description => "Shows IOnUpdate callbacks and component dependency checks.";

        /// <summary>
        /// Runs this instance
        /// </summary>
        public void Run()
        {
            using Scene scene = new Scene();

            scene.Create(default(Vel), default(Pos));
            scene.Create(default(Pos));

            scene.Update();
        }
    }
}

