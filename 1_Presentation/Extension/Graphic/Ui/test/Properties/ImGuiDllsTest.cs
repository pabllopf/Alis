// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiDllsTest.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System.Runtime.InteropServices;
using Alis.Core.Aspect.Data.Dll;
using Alis.Extension.Graphic.Ui.Properties;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Properties
{
    /// <summary>
    ///     The im gui dlls test class
    /// </summary>
    public class ImGuiDllsTest
    {
        /// <summary>
        ///     Tests that im gui dll bytes should contain win x 86
        /// </summary>
        [Fact]
        public void ImGuiDllBytes_ShouldContain_WinX86()
        {
            Assert.True(ImGuiDlls.ImGuiDllBytes.ContainsKey(new PlatformInfo(OSPlatform.Windows, Architecture.X86)));
        }

        /// <summary>
        ///     Tests that im gui dll bytes should contain win x 64
        /// </summary>
        [Fact]
        public void ImGuiDllBytes_ShouldContain_WinX64()
        {
            Assert.True(ImGuiDlls.ImGuiDllBytes.ContainsKey(new PlatformInfo(OSPlatform.Windows, Architecture.X64)));
        }

        /// <summary>
        ///     Tests that im gui dll bytes should contain win arm
        /// </summary>
        [Fact]
        public void ImGuiDllBytes_ShouldContain_WinArm()
        {
            Assert.True(ImGuiDlls.ImGuiDllBytes.ContainsKey(new PlatformInfo(OSPlatform.Windows, Architecture.Arm)));
        }

        /// <summary>
        ///     Tests that im gui dll bytes should contain win arm 64
        /// </summary>
        [Fact]
        public void ImGuiDllBytes_ShouldContain_WinArm64()
        {
            Assert.True(ImGuiDlls.ImGuiDllBytes.ContainsKey(new PlatformInfo(OSPlatform.Windows, Architecture.Arm64)));
        }

        /// <summary>
        ///     Tests that im gui dll bytes should contain linux x 86
        /// </summary>
        [Fact]
        public void ImGuiDllBytes_ShouldContain_LinuxX86()
        {
            Assert.True(ImGuiDlls.ImGuiDllBytes.ContainsKey(new PlatformInfo(OSPlatform.Linux, Architecture.X86)));
        }

        /// <summary>
        ///     Tests that im gui dll bytes should contain linux x 64
        /// </summary>
        [Fact]
        public void ImGuiDllBytes_ShouldContain_LinuxX64()
        {
            Assert.True(ImGuiDlls.ImGuiDllBytes.ContainsKey(new PlatformInfo(OSPlatform.Linux, Architecture.X64)));
        }

        /// <summary>
        ///     Tests that im gui dll bytes should contain linux arm
        /// </summary>
        [Fact]
        public void ImGuiDllBytes_ShouldContain_LinuxArm()
        {
            Assert.True(ImGuiDlls.ImGuiDllBytes.ContainsKey(new PlatformInfo(OSPlatform.Linux, Architecture.Arm)));
        }

        /// <summary>
        ///     Tests that im gui dll bytes should contain linux arm 64
        /// </summary>
        [Fact]
        public void ImGuiDllBytes_ShouldContain_LinuxArm64()
        {
            Assert.True(ImGuiDlls.ImGuiDllBytes.ContainsKey(new PlatformInfo(OSPlatform.Linux, Architecture.Arm64)));
        }

        /// <summary>
        ///     Tests that im gui dll bytes should contain osx x 86
        /// </summary>
        [Fact]
        public void ImGuiDllBytes_ShouldContain_OsxX86()
        {
            Assert.True(ImGuiDlls.ImGuiDllBytes.ContainsKey(new PlatformInfo(OSPlatform.OSX, Architecture.X86)));
        }

        /// <summary>
        ///     Tests that im gui dll bytes should contain osx x 64
        /// </summary>
        [Fact]
        public void ImGuiDllBytes_ShouldContain_OsxX64()
        {
            Assert.True(ImGuiDlls.ImGuiDllBytes.ContainsKey(new PlatformInfo(OSPlatform.OSX, Architecture.X64)));
        }

        /// <summary>
        ///     Tests that im gui dll bytes should contain osx arm
        /// </summary>
        [Fact]
        public void ImGuiDllBytes_ShouldContain_OsxArm()
        {
            Assert.True(ImGuiDlls.ImGuiDllBytes.ContainsKey(new PlatformInfo(OSPlatform.OSX, Architecture.Arm)));
        }

        /// <summary>
        ///     Tests that im gui dll bytes should contain osx arm 64
        /// </summary>
        [Fact]
        public void ImGuiDllBytes_ShouldContain_OsxArm64()
        {
            Assert.True(ImGuiDlls.ImGuiDllBytes.ContainsKey(new PlatformInfo(OSPlatform.OSX, Architecture.Arm64)));
        }

        /// <summary>
        ///     Tests that im gui dll bytes win x 86 should have correct path
        /// </summary>
        [Fact]
        public void ImGuiDllBytes_WinX86_ShouldHaveCorrectPath()
        {
            string expectedPath = "Alis.Extension.Graphic.ImGui.resources.win_x86.win-x86_cimgui.zip";
            Assert.Equal(expectedPath, ImGuiDlls.ImGuiDllBytes[new PlatformInfo(OSPlatform.Windows, Architecture.X86)]);
        }

        /// <summary>
        ///     Tests that im gui dll bytes win x 64 should have correct path
        /// </summary>
        [Fact]
        public void ImGuiDllBytes_WinX64_ShouldHaveCorrectPath()
        {
            string expectedPath = "Alis.Extension.Graphic.ImGui.resources.win_x64.win-x64_cimgui.zip";
            Assert.Equal(expectedPath, ImGuiDlls.ImGuiDllBytes[new PlatformInfo(OSPlatform.Windows, Architecture.X64)]);
        }

        /// <summary>
        ///     Tests that im gui dll bytes win arm should have correct path
        /// </summary>
        [Fact]
        public void ImGuiDllBytes_WinArm_ShouldHaveCorrectPath()
        {
            string expectedPath = "Alis.Extension.Graphic.ImGui.resources.win_arm.win-arm_cimgui.zip";
            Assert.Equal(expectedPath, ImGuiDlls.ImGuiDllBytes[new PlatformInfo(OSPlatform.Windows, Architecture.Arm)]);
        }

        /// <summary>
        ///     Tests that im gui dll bytes win arm 64 should have correct path
        /// </summary>
        [Fact]
        public void ImGuiDllBytes_WinArm64_ShouldHaveCorrectPath()
        {
            string expectedPath = "Alis.Extension.Graphic.ImGui.resources.win_arm64.win-arm64_cimgui.zip";
            Assert.Equal(expectedPath, ImGuiDlls.ImGuiDllBytes[new PlatformInfo(OSPlatform.Windows, Architecture.Arm64)]);
        }

        /// <summary>
        ///     Tests that im gui dll bytes linux x 86 should have correct path
        /// </summary>
        [Fact]
        public void ImGuiDllBytes_LinuxX86_ShouldHaveCorrectPath()
        {
            string expectedPath = "Alis.Extension.Graphic.ImGui.resources.linux_x86.linux-x86_cimgui.zip";
            Assert.Equal(expectedPath, ImGuiDlls.ImGuiDllBytes[new PlatformInfo(OSPlatform.Linux, Architecture.X86)]);
        }

        /// <summary>
        ///     Tests that im gui dll bytes linux x 64 should have correct path
        /// </summary>
        [Fact]
        public void ImGuiDllBytes_LinuxX64_ShouldHaveCorrectPath()
        {
            string expectedPath = "Alis.Extension.Graphic.ImGui.resources.linux_x64.linux-x64_cimgui.zip";
            Assert.Equal(expectedPath, ImGuiDlls.ImGuiDllBytes[new PlatformInfo(OSPlatform.Linux, Architecture.X64)]);
        }

        /// <summary>
        ///     Tests that im gui dll bytes linux arm should have correct path
        /// </summary>
        [Fact]
        public void ImGuiDllBytes_LinuxArm_ShouldHaveCorrectPath()
        {
            string expectedPath = "Alis.Extension.Graphic.ImGui.resources.linux_arm.linux-arm_cimgui.zip";
            Assert.Equal(expectedPath, ImGuiDlls.ImGuiDllBytes[new PlatformInfo(OSPlatform.Linux, Architecture.Arm)]);
        }

        /// <summary>
        ///     Tests that im gui dll bytes linux arm 64 should have correct path
        /// </summary>
        [Fact]
        public void ImGuiDllBytes_LinuxArm64_ShouldHaveCorrectPath()
        {
            string expectedPath = "Alis.Extension.Graphic.ImGui.resources.linux_arm64.linux-arm64_cimgui.zip";
            Assert.Equal(expectedPath, ImGuiDlls.ImGuiDllBytes[new PlatformInfo(OSPlatform.Linux, Architecture.Arm64)]);
        }

        /// <summary>
        ///     Tests that im gui dll bytes osx x 86 should have correct path
        /// </summary>
        [Fact]
        public void ImGuiDllBytes_OsxX86_ShouldHaveCorrectPath()
        {
            string expectedPath = "Alis.Extension.Graphic.ImGui.resources.osx_x86.osx-x86_cimgui.zip";
            Assert.Equal(expectedPath, ImGuiDlls.ImGuiDllBytes[new PlatformInfo(OSPlatform.OSX, Architecture.X86)]);
        }

        /// <summary>
        ///     Tests that im gui dll bytes osx x 64 should have correct path
        /// </summary>
        [Fact]
        public void ImGuiDllBytes_OsxX64_ShouldHaveCorrectPath()
        {
            string expectedPath = "Alis.Extension.Graphic.ImGui.resources.osx_x64.osx-x64_cimgui.zip";
            Assert.Equal(expectedPath, ImGuiDlls.ImGuiDllBytes[new PlatformInfo(OSPlatform.OSX, Architecture.X64)]);
        }

        /// <summary>
        ///     Tests that im gui dll bytes osx arm should have correct path
        /// </summary>
        [Fact]
        public void ImGuiDllBytes_OsxArm_ShouldHaveCorrectPath()
        {
            string expectedPath = "Alis.Extension.Graphic.ImGui.resources.osx_arm.osx-arm_cimgui.zip";
            Assert.Equal(expectedPath, ImGuiDlls.ImGuiDllBytes[new PlatformInfo(OSPlatform.OSX, Architecture.Arm)]);
        }

        /// <summary>
        ///     Tests that im gui dll bytes osx arm 64 should have correct path
        /// </summary>
        [Fact]
        public void ImGuiDllBytes_OsxArm64_ShouldHaveCorrectPath()
        {
            string expectedPath = "Alis.Extension.Graphic.ImGui.resources.osx_arm64.osx-arm64_cimgui.zip";
            Assert.Equal(expectedPath, ImGuiDlls.ImGuiDllBytes[new PlatformInfo(OSPlatform.OSX, Architecture.Arm64)]);
        }
    }
}