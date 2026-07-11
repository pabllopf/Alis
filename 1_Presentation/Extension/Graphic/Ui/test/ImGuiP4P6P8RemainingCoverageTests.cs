using System;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    public class ImGuiP4P6P8RemainingCoverageTests : IDisposable
    {
        internal readonly IntPtr _ctx;

        public ImGuiP4P6P8RemainingCoverageTests()
        {
            _ctx = ImGui.CreateContext();
            ImGui.SetCurrentContext(_ctx);
            var io = ImGui.GetIo();
            io.DisplaySize = new Vector2F(1920f, 1080f);
            io.Fonts.Build();
        }

        public void Dispose()
        {
            ImGuiNative.igDestroyContext(_ctx);
        }

        [Fact]
        public void CalcTextSize_ShouldExecute()
        {
            Vector2F r1 = ImGui.CalcTextSize("Hello");
            Vector2F r2 = ImGui.CalcTextSize("Hello", 0);
            Vector2F r3 = ImGui.CalcTextSize("Hello", true);
            Vector2F r4 = ImGui.CalcTextSize("Hello", 0f);
            Vector2F r5 = ImGui.CalcTextSize("Hello", 0, 5);
            Vector2F r6 = ImGui.CalcTextSize("Hello", true, 200f);
            Vector2F r7 = ImGui.CalcTextSize("Hello", 0, 5, true);
            Vector2F r8 = ImGui.CalcTextSize("Hello", 0, 5, 200f);
            Vector2F r9 = ImGui.CalcTextSize("Hello", 0, 5, true, 200f);
            _ = r1; _ = r2; _ = r3; _ = r4; _ = r5; _ = r6; _ = r7; _ = r8; _ = r9;
        }

        [Fact]
        public void TableSetupScrollFreeze_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            if (ImGui.BeginTable("tbl", 3))
            {
                ImGui.TableSetupScrollFreeze(1, 1);
                ImGui.EndTable();
            }
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void ShowUserGuide_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.ShowUserGuide();
            ImGui.Render();
        }
    }
}
