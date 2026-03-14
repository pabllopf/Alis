// --------------------------------------------------------------------------
//
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
//
//  --------------------------------------------------------------------------
//  File:UpdateTypeAttributeTest.cs
//
//  --------------------------------------------------------------------------

using System;
using Alis.Core.Ecs.Updating;
using Xunit;

namespace Alis.Core.Ecs.Test.Updating
{
    /// <summary>
    /// Tests for UpdateTypeAttribute.
    /// </summary>
    public class UpdateTypeAttributeTest
    {
        /// <summary>
        /// Tests that update type attribute is abstract and inherits attribute
        /// </summary>
        [Fact]
        public void UpdateTypeAttribute_IsAbstractAndInheritsAttribute()
        {
            Assert.True(typeof(UpdateTypeAttribute).IsAbstract);
            Assert.True(typeof(Attribute).IsAssignableFrom(typeof(UpdateTypeAttribute)));
        }

        /// <summary>
        /// Tests that update type attribute declares method target usage
        /// </summary>
        [Fact]
        public void UpdateTypeAttribute_DeclaresMethodTargetUsage()
        {
            AttributeUsageAttribute usage = (AttributeUsageAttribute)Attribute.GetCustomAttribute(
                typeof(UpdateTypeAttribute),
                typeof(AttributeUsageAttribute)
            );

            Assert.NotNull(usage);
            Assert.Equal(AttributeTargets.Method, usage.ValidOn);
        }

        /// <summary>
        /// Tests that update type attribute can be extended and applied to method
        /// </summary>
        [Fact]
        public void UpdateTypeAttribute_CanBeExtendedAndAppliedToMethod()
        {
            DummyUpdateTypeAttribute[] attrs =
                (DummyUpdateTypeAttribute[])typeof(TargetMethodHolder).GetMethod(nameof(TargetMethodHolder.Tick))
                    .GetCustomAttributes(typeof(DummyUpdateTypeAttribute), false);

            Assert.Single(attrs);
        }

        /// <summary>
        /// The dummy update type attribute class
        /// </summary>
        /// <seealso cref="UpdateTypeAttribute"/>
        private sealed class DummyUpdateTypeAttribute : UpdateTypeAttribute
        {
        }

        /// <summary>
        /// The target method holder class
        /// </summary>
        private sealed class TargetMethodHolder
        {
            /// <summary>
            /// Ticks this instance
            /// </summary>
            [DummyUpdateType]
            public void Tick()
            {
            }
        }
    }
}

