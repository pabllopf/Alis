using Alis.Core.Ecs.Sample.Components;

namespace Alis.Core.Ecs.Sample.Samples
{
    /// <summary>
    /// The init lifecycle sample class
    /// </summary>
    /// <seealso cref="IEcsSample"/>
    internal sealed class InitLifecycleSample : IEcsSample
    {
        /// <summary>
        /// Gets the value of the key
        /// </summary>
        public string Key => "init-lifecycle";

        /// <summary>
        /// Gets the value of the title
        /// </summary>
        public string Title => "Init Lifecycle";

        /// <summary>
        /// Gets the value of the description
        /// </summary>
        public string Description => "Demonstrates IOnInit + IOnUpdate behavior for initialized components.";

        /// <summary>
        /// Runs this instance
        /// </summary>
        public void Run()
        {
            using Scene scene = new Scene();

            scene.Create(default(Pos2));
            scene.Create(default(Pos2), default(Vel2));

            scene.Update();
        }
    }
}

