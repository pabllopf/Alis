using Alis.Core.Aspect.Math.Vector;
using Xunit;
using Alis.Extension.Graphic.Sfml.Audios;

namespace Alis.Extension.Graphic.Sfml.Test.Audios
{
    /// <summary>
    /// The listener tests class
    /// </summary>
    public class ListenerTests
    {
        /// <summary>
        /// Tests that set global volume does not throw
        /// </summary>
        [Fact(Skip = "Cannot test Listener without native SFML dependencies.")]
        public void SetGlobalVolume_DoesNotThrow()
        {
            Listener.GlobalVolume = 50f;
            Assert.Equal(50f, Listener.GlobalVolume);
        }

        /// <summary>
        /// Tests that set position does not throw
        /// </summary>
        [Fact(Skip = "Cannot test Listener without native SFML dependencies.")]
        public void SetPosition_DoesNotThrow()
        {
            Listener.Position = new Alis.Core.Aspect.Math.Vector.Vector3F(1, 2, 3);
            Vector3F pos = Listener.Position;
            Assert.Equal(1, pos.X);
            Assert.Equal(2, pos.Y);
            Assert.Equal(3, pos.Z);
        }
    }
}

