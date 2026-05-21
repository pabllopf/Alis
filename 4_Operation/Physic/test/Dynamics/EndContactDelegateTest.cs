

using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    ///     The end contact delegate test class
    /// </summary>
    public class EndContactDelegateTest
    {
        /// <summary>
        ///     Tests that end contact delegate should accept null contact
        /// </summary>
        [Fact]
        public void EndContactDelegate_ShouldAcceptNullContact()
        {
            bool invoked = false;
            EndContactDelegate callback = contact => { invoked = true; };

            callback(null);

            Assert.True(invoked);
        }
    }
}