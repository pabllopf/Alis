// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:UpdateTypeAttributeTest.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using Alis.Core.Ecs.Updating;
using Xunit;

namespace Alis.Core.Ecs.Test.Updating
{
    /// <summary>
    ///     Tests for UpdateTypeAttribute.
    /// </summary>
    public class UpdateTypeAttributeTest
    {
        /// <summary>
        ///     Tests that update type attribute is abstract and inherits attribute
        /// </summary>
        [Fact]
        public void UpdateTypeAttribute_IsAbstractAndInheritsAttribute()
        {
            Assert.True(typeof(UpdateTypeAttribute).IsAbstract);
            Assert.True(typeof(Attribute).IsAssignableFrom(typeof(UpdateTypeAttribute)));
        }

        /// <summary>
        ///     Tests that update type attribute declares method target usage
        /// </summary>
        [Fact]
        public void UpdateTypeAttribute_DeclaresMethodTargetUsage()
        {
            AttributeUsageAttribute usage = (AttributeUsageAttribute) Attribute.GetCustomAttribute(
                typeof(UpdateTypeAttribute),
                typeof(AttributeUsageAttribute)
            );

            Assert.NotNull(usage);
            Assert.Equal(AttributeTargets.Method, usage.ValidOn);
        }

        /// <summary>
        ///     Tests that update type attribute can be extended and applied to method
        /// </summary>
        [Fact]
        public void UpdateTypeAttribute_CanBeExtendedAndAppliedToMethod()
        {
            DummyUpdateTypeAttribute[] attrs =
                (DummyUpdateTypeAttribute[]) typeof(TargetMethodHolder).GetMethod(nameof(TargetMethodHolder.Tick))
                    .GetCustomAttributes(typeof(DummyUpdateTypeAttribute), false);

            Assert.Single(attrs);
        }

        /// <summary>
        ///     The dummy update type attribute class
        /// </summary>
        /// <seealso cref="UpdateTypeAttribute" />
        private sealed class DummyUpdateTypeAttribute : UpdateTypeAttribute
        {
        }

        /// <summary>
        ///     The target method holder class
        /// </summary>
        private sealed class TargetMethodHolder
        {
            /// <summary>
            ///     Ticks this instance
            /// </summary>
            [DummyUpdateType]
            public void Tick()
            {
            }
        }
    }
}