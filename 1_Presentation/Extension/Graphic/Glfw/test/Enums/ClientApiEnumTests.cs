

using System;
using Alis.Extension.Graphic.Glfw.Enums;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test.Enums
{
    /// <summary>
    ///     Tests for ClientApi enum
    /// </summary>
    public class ClientApiEnumTests
    {
        /// <summary>
        ///     Tests that client api open gl is defined
        /// </summary>
        [Fact]
        public void ClientApi_OpenGl_IsDefined()
        {
            bool isDefined = Enum.IsDefined(typeof(ClientApi), ClientApi.OpenGl);

            Assert.True(isDefined);
        }

        /// <summary>
        ///     Tests that client api open gl es is defined
        /// </summary>
        [Fact]
        public void ClientApi_OpenGlEs_IsDefined()
        {
            bool isDefined = Enum.IsDefined(typeof(ClientApi), ClientApi.OpenGles);

            Assert.True(isDefined);
        }

        /// <summary>
        ///     Tests that client api none is defined
        /// </summary>
        [Fact]
        public void ClientApi_None_IsDefined()
        {
            bool isDefined = Enum.IsDefined(typeof(ClientApi), ClientApi.None);

            Assert.True(isDefined);
        }

        /// <summary>
        ///     Tests that client api can be cast to int
        /// </summary>
        [Fact]
        public void ClientApi_CanBeCastToInt()
        {
            ClientApi api = ClientApi.OpenGl;

            int value = (int) api;

            Assert.True(value != 0);
        }

        /// <summary>
        ///     Tests that client api all apis are different
        /// </summary>
        [Fact]
        public void ClientApi_AllApis_AreDifferent()
        {
            Assert.NotEqual(ClientApi.OpenGl, ClientApi.OpenGles);
            Assert.NotEqual(ClientApi.OpenGl, ClientApi.None);
            Assert.NotEqual(ClientApi.OpenGles, ClientApi.None);
        }
    }
}