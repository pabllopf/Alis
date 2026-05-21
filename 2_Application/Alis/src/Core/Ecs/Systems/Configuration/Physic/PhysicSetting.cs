

using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Ecs.Systems.Configuration.Physic
{
    /// <summary>
    ///     The physic setting
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PhysicSetting(
        Vector2F gravity,
        bool debug,
        Color debugColor) : IPhysicSetting
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PhysicSetting" /> class with default values.
        /// </summary>
        public PhysicSetting() : this(new Vector2F(0, -9.81f), false, new Color(0, 0, 0, 1))
        {
        }

        /// <summary>
        ///     Gets or sets the value of the gravity
        /// </summary>
        public Vector2F Gravity { get; set; } = gravity;

        /// <summary>
        ///     Gets or sets the value of the debug
        /// </summary>
        public bool Debug { get; set; } = debug;

        /// <summary>
        ///     Gets or sets the value of the debug color
        /// </summary>
        public Color DebugColor { get; set; } = debugColor;
    }
}