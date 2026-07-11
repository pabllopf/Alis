// license header
using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    public class ContextTest
    {
        [Fact]
        public void Context_IsAssignableFromCriticalFinalizerObject()
        {
            Assert.True(typeof(System.Runtime.ConstrainedExecution.CriticalFinalizerObject).IsAssignableFrom(typeof(Context)));
        }

        [Fact]
        public void Settings_Property_Exists()
        {
            Assert.NotNull(typeof(Context).GetProperty("Settings"));
        }

        [Fact]
        public void Global_Property_Exists()
        {
            var prop = typeof(Context).GetProperty("Global");
            Assert.NotNull(prop);
            Assert.True(prop.GetMethod.IsStatic);
        }

        [Fact]
        public void Global_ReturnsInstance()
        {
            var global = Context.Global;
            Assert.NotNull(global);
        }

        [Fact]
        public void Global_ReturnsSameInstance()
        {
            var g1 = Context.Global;
            var g2 = Context.Global;
            Assert.Same(g1, g2);
        }

        [Fact]
        public void SetActive_Method_Exists()
        {
            Assert.NotNull(typeof(Context).GetMethod("SetActive"));
        }
    }
}
