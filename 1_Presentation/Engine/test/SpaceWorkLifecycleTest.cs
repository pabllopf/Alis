// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SpaceWorkLifecycleTest.cs
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

using System;
using System.IO;
using Alis.App.Engine.Core;
using Alis.App.Engine.Entity;
using Alis.Core.Aspect.Data.Json;
using Xunit;

namespace Alis.App.Engine.Test
{
    /// <summary>
    ///     Tests the real lifecycle of <see cref="SpaceWork" /> including
    ///     project configuration persistence through the temp folder.
    /// </summary>
    public class SpaceWorkLifecycleTest
    {
        /// <summary>
        ///     The config file path used by the SpaceWork constructor
        /// </summary>
        private static readonly string ConfigFilePath = Path.Combine(Path.GetTempPath(), "projectConfig.json");

        /// <summary>
        ///     Deletes the shared temporary configuration file
        /// </summary>
        private static void DeleteConfigFile()
        {
            if (File.Exists(ConfigFilePath))
            {
                File.Delete(ConfigFilePath);
            }
        }

        /// <summary>
        ///     Tests that constructor when no config file exists creates default project and writes config
        /// </summary>
        [Fact]
        public void Constructor_WhenNoConfigFileExists_CreatesDefaultProjectAndWritesConfig()
        {
            DeleteConfigFile();

            try
            {
                SpaceWork spaceWork = new SpaceWork();

                Assert.NotNull(spaceWork.Project);
                Assert.Equal("MacOS Project (latest)", spaceWork.Project.Name);
                Assert.True(File.Exists(ConfigFilePath));
            }
            finally
            {
                DeleteConfigFile();
            }
        }

        /// <summary>
        ///     Tests that constructor when config file exists loads project from json file
        /// </summary>
        [Fact]
        public void Constructor_WhenConfigFileExists_LoadsProjectFromJsonFile()
        {
            Project customProject = new Project("Custom Test Project", "/custom/path", "SYNCED", "2 hours ago", "v1.2.0");
            File.WriteAllText(ConfigFilePath, JsonNativeAot.Serialize(customProject));

            try
            {
                SpaceWork spaceWork = new SpaceWork();

                Assert.Equal("Custom Test Project", spaceWork.Project.Name);
                Assert.Equal("/custom/path", spaceWork.Project.Path);
                Assert.Equal("SYNCED", spaceWork.Project.CloudStatus);
                Assert.Equal("2 hours ago", spaceWork.Project.ModifiedDate);
            }
            finally
            {
                DeleteConfigFile();
            }
        }

        /// <summary>
        ///     Tests that constructor sets initial lifecycle state properly
        /// </summary>
        [Fact]
        public void Constructor_WhenCreated_SetsInitialLifecycleState()
        {
            DeleteConfigFile();

            try
            {
                SpaceWork spaceWork = new SpaceWork();

                Assert.Equal(60, spaceWork.Fps);
                Assert.True(spaceWork.IsRunning);
                Assert.NotNull(spaceWork.IconDemo);
                Assert.NotNull(spaceWork.ImGuiDemo);
                Assert.NotNull(spaceWork.ImGuizmoDemo);
                Assert.NotNull(spaceWork.ImNodeDemo);
                Assert.NotNull(spaceWork.ImPlotDemo);
            }
            finally
            {
                DeleteConfigFile();
            }
        }

        /// <summary>
        ///     Tests that on init when project window not implemented throws not implemented exception
        /// </summary>
        [Fact]
        public void OnInit_WhenProjectWindowNotImplemented_ThrowsNotImplementedException()
        {
            SpaceWork spaceWork = new SpaceWork();

            Exception exception = Record.Exception(() => spaceWork.OnInit());

            Assert.IsType<NotImplementedException>(exception);
        }

        /// <summary>
        ///     Tests that on start when project window not implemented throws not implemented exception
        /// </summary>
        [Fact]
        public void OnStart_WhenProjectWindowNotImplemented_ThrowsNotImplementedException()
        {
            SpaceWork spaceWork = new SpaceWork();

            Exception exception = Record.Exception(() => spaceWork.OnStart());

            Assert.IsType<NotImplementedException>(exception);
        }
    }
}
