

using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    ///     The begin contact delegate test class
    /// </summary>
    public class BeginContactDelegateTest
    {
        /// <summary>
        ///     Tests that begin contact delegate should accept null and handle it
        /// </summary>
        [Fact]
        public void BeginContactDelegate_ShouldAcceptNull()
        {
            BeginContactDelegate callback = contact => contact != null;

            bool result = callback(null);

            Assert.False(result);
        }
    }
}