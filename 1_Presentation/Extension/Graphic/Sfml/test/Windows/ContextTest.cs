// license header
using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    /// <summary>
    /// The context test class
    /// </summary>
    public class ContextTest
    {
        /// <summary>
        /// Tests that context is assignable from critical finalizer object
        /// </summary>
        [Fact]
        public void Context_IsAssignableFromCriticalFinalizerObject()
        {
            Assert.True(typeof(System.Runtime.ConstrainedExecution.CriticalFinalizerObject).IsAssignableFrom(typeof(Context)));
        }

        /// <summary>
        /// Tests that settings property exists
        /// </summary>
        [Fact]
        public void Settings_Property_Exists()
        {
            Assert.NotNull(typeof(Context).GetProperty("Settings"));
        }

        /// <summary>
        /// Tests that global property exists
        /// </summary>
        [Fact]
        public void Global_Property_Exists()
        {
            var prop = typeof(Context).GetProperty("Global");
            Assert.NotNull(prop);
            Assert.True(prop.GetMethod.IsStatic);
        }

        /// <summary>
        /// Tests that global returns instance
        /// </summary>
        [Fact]
        public void Global_ReturnsInstance()
        {
            var global = Context.Global;
            Assert.NotNull(global);
        }

        /// <summary>
        /// Tests that global returns same instance
        /// </summary>
        [Fact]
        public void Global_ReturnsSameInstance()
        {
            var g1 = Context.Global;
            var g2 = Context.Global;
            Assert.Same(g1, g2);
        }

        /// <summary>
        /// Tests that set active method exists
        /// </summary>
        [Fact]
        public void SetActive_Method_Exists()
        {
            Assert.NotNull(typeof(Context).GetMethod("SetActive"));
        }
    }
}
