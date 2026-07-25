using System;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    /// The im gui p 6 tests class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    public class ImGuiP6Tests : IDisposable
    {
        /// <summary>
        /// The ctx
        /// </summary>
        internal readonly IntPtr _ctx;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImGuiP6Tests"/> class
        /// </summary>
        public ImGuiP6Tests()
        {
            _ctx = ImGui.CreateContext();
            ImGui.SetCurrentContext(_ctx);
            var io = ImGui.GetIo();
            io.DisplaySize = new Vector2F(1920f, 1080f);
            io.Fonts.Build();
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            ImGuiNative.igDestroyContext(_ctx);
        }

        /// <summary>
        /// Inputs the int 3 all overloads should execute
        /// </summary>
        [RequireCImguiSystemFact]
        public void InputInt3_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            int val = 0;
            ImGui.InputInt3("i3a", ref val);
            ImGui.InputInt3("i3b", ref val, ImGuiInputTextFlags.None);
            ImGui.End();
            ImGui.Render();
        }

        /// <summary>
        /// Lists the box all overloads should execute
        /// </summary>
        [RequireCImguiSystemFact]
        public void ListBox_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            int currentItem = 0;
            string[] items = new[] { "One", "Two", "Three" };
            ImGui.ListBox("lb1", ref currentItem, items, items.Length);
            ImGui.ListBox("lb2", ref currentItem, items, items.Length, 3);
            ImGui.End();
            ImGui.Render();
        }

        /// <summary>
        /// Loads the ini settings from disk should execute
        /// </summary>
        [RequireCImguiSystemFact]
        public void LoadIniSettingsFromDisk_ShouldExecute()
        {
            ImGui.LoadIniSettingsFromDisk("");
        }

        /// <summary>
        /// Logs the to file all overloads should execute
        /// </summary>
        [RequireCImguiSystemFact]
        public void LogToFile_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.LogToFile();
            ImGui.LogFinish();
            ImGui.Render();
            ImGui.NewFrame();
            ImGui.LogToFile(-1);
            ImGui.LogFinish();
            ImGui.Render();
            ImGui.NewFrame();
            ImGui.LogToFile(-1, "test.log");
            ImGui.LogFinish();
            ImGui.Render();
        }
    }
}
