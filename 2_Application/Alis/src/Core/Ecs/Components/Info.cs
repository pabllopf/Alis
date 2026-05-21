

using Alis.Core.Aspect.Fluent.Components;

namespace Alis.Core.Ecs.Components
{
    /// <summary>
    ///     Info component
    /// </summary>
    public record struct Info : IOnInit, IOnUpdate
    {
        /// <summary>
        ///     The id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     The is active
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        ///     The is static
        /// </summary>
        public bool IsStatic { get; set; }

        /// <summary>
        ///     The name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     The tag
        /// </summary>
        public string Tag { get; set; }

        /// <summary>
        ///     Inits the self
        /// </summary>
        /// <param name="self">The self</param>
        public void OnInit(IGameObject self)
        {
        }

        /// <summary>
        ///     Updates the self
        /// </summary>
        /// <param name="self">The self</param>
        public void OnUpdate(IGameObject self)
        {
        }
    }
}