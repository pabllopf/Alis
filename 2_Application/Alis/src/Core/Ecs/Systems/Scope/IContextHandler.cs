

namespace Alis.Core.Ecs.Systems.Scope
{
    /// <summary>
    ///     The runner interface
    /// </summary>
    public interface IContextHandler<T>
    {
        /// <summary>
        ///     Gets the value of the context
        /// </summary>
        T Context { get; }

        /// <summary>
        ///     Runs this instance
        /// </summary>
        void Run();

        /// <summary>
        ///     Exits this instance
        /// </summary>
        void Exit();

        /// <summary>
        ///     Saves this instance
        /// </summary>
        void Save();

        /// <summary>
        ///     Loads this instance
        /// </summary>
        void Load();

        /// <summary>
        ///     Loads the and run
        /// </summary>
        void LoadAndRun();

        /// <summary>
        ///     Inits the preview
        /// </summary>
        void InitPreview();

        /// <summary>
        ///     Previews this instance
        /// </summary>
        void Preview();
    }
}