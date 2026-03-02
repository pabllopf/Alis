using System.Linq;
using System.Reflection;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    /// Provides API-surface coverage for methods contributed by ImGuiP4 wrappers.
    /// </summary>
    public class ImGuiP4Test
    {
        /// <summary>
        /// Verifies table setup APIs expose overloads.
        /// </summary>
        [Fact]
        public void TableSetupColumn_ShouldExposeExpectedOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "TableSetupColumn").ToArray();

            Assert.True(methods.Length >= 3);
            Assert.Contains(methods, method => method.GetParameters().Length == 2);
            Assert.Contains(methods, method => method.GetParameters().Length == 4);
        }

        /// <summary>
        /// Verifies tree-node methods expose pointer and string variants.
        /// </summary>
        [Fact]
        public void TreeNodeMethods_ShouldExposePointerAndStringVariants()
        {
            MethodInfo[] treeNode = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "TreeNode").ToArray();
            MethodInfo[] treeNodeEx = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "TreeNodeEx").ToArray();

            Assert.True(treeNode.Length >= 3);
            Assert.True(treeNodeEx.Length >= 4);
        }
    }
}
