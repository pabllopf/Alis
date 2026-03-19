using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    /// The query report fixture delegate test class
    /// </summary>
    public class QueryReportFixtureDelegateTest
    {
        /// <summary>
        /// Tests that delegate should return callback value
        /// </summary>
        [Fact]
        public void Delegate_ShouldReturnCallbackValue()
        {
            Fixture capturedFixture = null;
            QueryReportFixtureDelegate callback = fixture =>
            {
                capturedFixture = fixture;
                return fixture != null;
            };

            bool result = callback(null);

            Assert.False(result);
            Assert.Null(capturedFixture);
        }
    }
}

