using System;
using Xunit;
using Alis.Extension.Graphic.Sfml.Systems;

namespace Alis.Extension.Graphic.Sfml.Test.Systems
{
    public class CSFMLTests
    {
        [Fact]
        public void Constants_AreCorrect()
        {
            Assert.Equal("csfml-audio", Csfml.Audio);
            Assert.Equal("csfml-graphics", Csfml.Graphics);
            Assert.Equal("csfml-system", Csfml.System);
            Assert.Equal("csfml-window", Csfml.Window);
        }
    }
}

