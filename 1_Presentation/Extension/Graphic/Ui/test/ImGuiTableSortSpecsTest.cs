

using System;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im gui table sort specs test class
    /// </summary>
    public class ImGuiTableSortSpecsTest
    {
        /// <summary>
        ///     Tests that specs should set and get correctly
        /// </summary>
        [Fact]
        public void Specs_Should_SetAndGetCorrectly()
        {
            ImGuiTableSortSpecs tableSortSpecs = new ImGuiTableSortSpecs();
            IntPtr specs = new IntPtr(789);
            tableSortSpecs.Specs = specs;
            Assert.Equal(specs, tableSortSpecs.Specs);
        }

        /// <summary>
        ///     Tests that specs count should set and get correctly
        /// </summary>
        [Fact]
        public void SpecsCount_Should_SetAndGetCorrectly()
        {
            ImGuiTableSortSpecs tableSortSpecs = new ImGuiTableSortSpecs();
            tableSortSpecs.SpecsCount = 3;
            Assert.Equal(3, tableSortSpecs.SpecsCount);
        }

        /// <summary>
        ///     Tests that specs dirty should set and get correctly
        /// </summary>
        [Fact]
        public void SpecsDirty_Should_SetAndGetCorrectly()
        {
            ImGuiTableSortSpecs tableSortSpecs = new ImGuiTableSortSpecs();
            tableSortSpecs.SpecsDirty = 1;
            Assert.Equal(1, tableSortSpecs.SpecsDirty);
        }
    }
}