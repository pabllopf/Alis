

using System;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im gui list clipper test class
    /// </summary>
    public class ImGuiListClipperTest
    {
        /// <summary>
        ///     Tests that display start should set and get correctly
        /// </summary>
        [Fact]
        public void DisplayStart_Should_SetAndGetCorrectly()
        {
            ImGuiListClipper listClipper = new ImGuiListClipper();
            listClipper.DisplayStart = 5;
            Assert.Equal(5, listClipper.DisplayStart);
        }

        /// <summary>
        ///     Tests that display end should set and get correctly
        /// </summary>
        [Fact]
        public void DisplayEnd_Should_SetAndGetCorrectly()
        {
            ImGuiListClipper listClipper = new ImGuiListClipper();
            listClipper.DisplayEnd = 10;
            Assert.Equal(10, listClipper.DisplayEnd);
        }

        /// <summary>
        ///     Tests that items count should set and get correctly
        /// </summary>
        [Fact]
        public void ItemsCount_Should_SetAndGetCorrectly()
        {
            ImGuiListClipper listClipper = new ImGuiListClipper();
            listClipper.ItemsCount = 20;
            Assert.Equal(20, listClipper.ItemsCount);
        }

        /// <summary>
        ///     Tests that items height should set and get correctly
        /// </summary>
        [Fact]
        public void ItemsHeight_Should_SetAndGetCorrectly()
        {
            ImGuiListClipper listClipper = new ImGuiListClipper();
            listClipper.ItemsHeight = 25.5f;
            Assert.Equal(25.5f, listClipper.ItemsHeight);
        }

        /// <summary>
        ///     Tests that start pos y should set and get correctly
        /// </summary>
        [Fact]
        public void StartPosY_Should_SetAndGetCorrectly()
        {
            ImGuiListClipper listClipper = new ImGuiListClipper();
            listClipper.StartPosY = 30.0f;
            Assert.Equal(30.0f, listClipper.StartPosY);
        }

        /// <summary>
        ///     Tests that temp data should set and get correctly
        /// </summary>
        [Fact]
        public void TempData_Should_SetAndGetCorrectly()
        {
            ImGuiListClipper listClipper = new ImGuiListClipper();
            IntPtr tempData = new IntPtr(123);
            listClipper.TempData = tempData;
            Assert.Equal(tempData, listClipper.TempData);
        }
    }
}