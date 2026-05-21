

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder terminal interface that executes the configured
    ///     entity pipeline or action chain.
    /// </summary>
    /// <remarks>
    ///     Calling <c>Run()</c> finalizes the fluent chain — it validates the configuration,
    ///     creates the entity (if applicable), and triggers any registered behaviors.
    ///     After <c>Run()</c>, the builder state is typically consumed and cannot be reused.
    /// </remarks>
    public interface IRun
    {
        /// <summary>
        ///     Executes the configured builder pipeline and creates or modifies the target entity.
        ///     This is the terminal operation in a fluent chain.
        /// </summary>
        void Run();
    }
}