

using Alis.Core.Ecs.Systems.Execution;
using Alis.Core.Ecs.Systems.Scope;

namespace Alis.Core.Ecs.Systems.Manager
{
    /// <summary>
    ///     Defines the contract for all managers in the Alis ECS framework.
    ///     Extends <see cref="IRuntime" /> to ensure managers participate in the game loop lifecycle.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         <see cref="IManager" /> is the interface that all system managers (Audio, Graphic, Input,
    ///         Network, Physic, Scene, Time, etc.) implement. It inherits from <see cref="IRuntime" />
    ///         to guarantee that managers expose the full lifecycle callbacks required by the
    ///         <see cref="ContextHandler" />.
    ///     </para>
    ///     <para>
    ///         Concrete implementations should derive from <see cref="AManager" />, which provides
    ///         default no-op implementations for all lifecycle methods and standard properties
    ///         (Id, Name, Tag, Context).
    ///     </para>
    /// </remarks>
    public interface IManager : IRuntime
    {
    }
}