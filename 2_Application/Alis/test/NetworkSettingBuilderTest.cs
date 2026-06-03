// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NetworkSettingBuilderTest.cs
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

using Alis.Builder.Core.Ecs.System.ConfigurationBuilders.Network;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Ecs.Systems.Configuration.Network;
using Xunit;

namespace Alis.Test
{
    /// <summary>
    ///     Contains unit tests for the <see cref="NetworkSettingBuilder" /> class.
    /// </summary>
    public class NetworkSettingBuilderTest
    {
        /// <summary>
        ///     Tests that the default constructor creates a builder.
        /// </summary>
        [Fact]
        public void DefaultConstructor_CreatesBuilder()
        {
            NetworkSettingBuilder builder = new NetworkSettingBuilder();

            Assert.NotNull(builder);
        }

        /// <summary>
        ///     Tests that the Build method returns a NetworkSetting instance.
        /// </summary>
        [Fact]
        public void Build_ReturnsNetworkSettingInstance()
        {
            NetworkSettingBuilder builder = new NetworkSettingBuilder();
            NetworkSetting setting = builder.Build();

            Assert.IsType<NetworkSetting>(setting);
        }

        /// <summary>
        ///     Tests that the Build method returns a non-null NetworkSetting.
        /// </summary>
        [Fact]
        public void Build_ReturnsNonNullNetworkSetting()
        {
            NetworkSettingBuilder builder = new NetworkSettingBuilder();
            NetworkSetting setting = builder.Build();

            Assert.NotNull(setting);
        }

        /// <summary>
        ///     Tests that the builder implements expected interfaces.
        /// </summary>
        [Fact]
        public void BuilderImplementsExpectedInterfaces()
        {
            NetworkSettingBuilder builder = new NetworkSettingBuilder();

            Assert.IsAssignableFrom<IBuild<NetworkSetting>>(builder);
        }

        /// <summary>
        ///     Tests that the default Build returns default NetworkSetting values.
        /// </summary>
        [Fact]
        public void DefaultBuildReturnsDefaultValues()
        {
            NetworkSettingBuilder builder = new NetworkSettingBuilder();
            NetworkSetting setting = builder.Build();

            Assert.Equal(8080, setting.Port);
            Assert.Equal("127.0.0.1", setting.Ip);
            Assert.Equal("localhost", setting.Host);
            Assert.Equal("http", setting.Protocol);
        }

        /// <summary>
        ///     Tests that the Ip method returns the same builder instance for chaining.
        /// </summary>
        [Fact]
        public void IpReturnsBuilderForChaining()
        {
            NetworkSettingBuilder builder = new NetworkSettingBuilder();

            NetworkSettingBuilder result = builder.Ip("192.168.1.1");

            Assert.Same(builder, result);
        }

        /// <summary>
        ///     Tests that calling Build multiple times returns the same instance (reference).
        /// </summary>
        [Fact]
        public void BuildReturnsSameInstanceEachCall()
        {
            NetworkSettingBuilder builder = new NetworkSettingBuilder();

            NetworkSetting first = builder.Build();
            NetworkSetting second = builder.Build();

            Assert.Equal(first.Port, second.Port);
            Assert.Equal(first.Ip, second.Ip);
            Assert.Equal(first.Host, second.Host);
            Assert.Equal(first.Protocol, second.Protocol);
        }

        /// <summary>
        ///     Tests that Ip method can be called with null value.
        /// </summary>
        [Fact]
        public void IpCanBeCalledWithNull()
        {
            NetworkSettingBuilder builder = new NetworkSettingBuilder();

            NetworkSettingBuilder result = builder.Ip(null);

            Assert.Same(builder, result);
        }

        /// <summary>
        ///     Tests that Ip method can be called with empty string.
        /// </summary>
        [Fact]
        public void IpCanBeCalledWithEmptyString()
        {
            NetworkSettingBuilder builder = new NetworkSettingBuilder();

            NetworkSettingBuilder result = builder.Ip(string.Empty);

            Assert.Same(builder, result);
        }
    }
}
