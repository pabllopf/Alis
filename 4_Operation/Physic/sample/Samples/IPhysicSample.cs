
namespace Alis.Core.Physic.Sample.Samples
{
    /// <summary>
    /// The physic sample interface
    /// </summary>
    internal interface IPhysicSample
    {
        /// <summary>
        /// Gets the value of the key
        /// </summary>
        string Key { get; }

        /// <summary>
        /// Gets the value of the title
        /// </summary>
        string Title { get; }

        /// <summary>
        /// Gets the value of the description
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Runs the runtime
        /// </summary>
        /// <param name="runtime">The runtime</param>
        void Run(SampleRuntime runtime);
    }
}

