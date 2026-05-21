

using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Words;
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Systems.Configuration.Physic;

namespace Alis.Builder.Core.Ecs.System.ConfigurationBuilders.Physic
{
    /// <summary>
    ///     The physic setting builder class
    /// </summary>
    /// <seealso cref="IBuild{PhysicSetting}" />
    public class PhysicSettingBuilder :
        IBuild<PhysicSetting>,
        IGravity<PhysicSettingBuilder, float>
    {
        /// <summary>
        ///     The physic setting
        /// </summary>
        private PhysicSetting physicSetting = new PhysicSetting();

        /// <summary>
        ///     Builds this instance
        /// </summary>
        /// <returns>The physic setting</returns>
        public PhysicSetting Build() => physicSetting;

        /// <summary>
        ///     Gravities the x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The physic setting builder</returns>
        public PhysicSettingBuilder Gravity(float x, float y)
        {
            physicSetting.Gravity = new Vector2F(x, y);
            return this;
        }

        /// <summary>
        ///     Debugs the b
        /// </summary>
        /// <param name="b">The </param>
        /// <returns>The physic setting builder</returns>
        public PhysicSettingBuilder Debug(bool b)
        {
            physicSetting.Debug = b;
            return this;
        }

        /// <summary>
        ///     Debugs the color using the specified color
        /// </summary>
        /// <param name="color">The color</param>
        /// <returns>The physic setting builder</returns>
        public PhysicSettingBuilder DebugColor(Color color)
        {
            physicSetting.DebugColor = color;
            return this;
        }
    }
}