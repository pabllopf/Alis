using System;
using System.IO;
using System.Runtime.InteropServices;
using Alis.App.Engine.Desktop.Core;
using Alis.Core.Aspect.Data.Resource;
using Alis.Core.Aspect.Logging;
using Alis.Extension.Graphic.Ui;
using Alis.Extension.Graphic.Ui.Controllers;

namespace Alis.App.Engine.Desktop
{
    /// <summary>
    ///     The engine class
    /// </summary>
    public class Engine
    {
        /// <summary>
        /// The imgui controller
        /// </summary>
        private ImGuiControllerImplementGlfw imguiController;
        
        /// <summary>
        /// The space work
        /// </summary>
        private SpaceWork spaceWork;
        
        /// <summary>
        ///     Starts this instance
        /// </summary>
        /// <returns>The int</returns>
        public void Run()
        {
            
            imguiController = new ImGuiControllerImplementGlfw(
                "Welcome to Alis Engine by @pabllopf",
                1024,
                768,
                0,
#if DEBUG
                true
#else
                    false
#endif
                
                );
            
            spaceWork = new SpaceWork(imguiController);
            
            imguiController.OnInit();
            imguiController.OnStart();
            
            spaceWork.Initialize();
            spaceWork.Start();

            if (!File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "imgui.ini")))
            {
                LayoutDefault();
            }
            
            while (imguiController.IsRunning)
            {
                imguiController.OnPollEvents();

                imguiController.OnStartFrame();
                
                imguiController.OnRenderFrame();
                
                spaceWork.Update();
                
                imguiController.OnEndFrame();
            }
            
            
            imguiController.OnExit();
        }
        
        
        /// <summary>
        /// Layouts the default
        /// </summary>
        private static void LayoutDefault()
        {
            Logger.Info("Layout Default selected");

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                ImGui.LoadIniSettingsFromDisk(AssetManager.Find("LayoutDefaultOsx.ini"));
                return;
            }
            
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                ImGui.LoadIniSettingsFromDisk(AssetManager.Find("LayoutDefaultWin.ini"));
                return;
            }
            
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                ImGui.LoadIniSettingsFromDisk(AssetManager.Find("LayoutDefaultLinux.ini"));
                return;
            }
            
            Logger.Error("Unsupported OS for layout default");
        }
    }
}