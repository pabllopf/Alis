// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Installer.cs
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
using System.Threading;
using System.Threading.Tasks;
using Alis.App.Installer.Controllers;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Aspect.Time;
using Alis.Extension.Graphic.Ui;
using Alis.Extension.Updater;
using Alis.Extension.Updater.Services.Api;
using Alis.Extension.Updater.Services.Files;

namespace Alis.App.Installer
{
    /// <summary>
    ///     The engine class
    /// </summary>
    public class Installer
    {
        /// <summary>
        ///     The name engine
        /// </summary>
        private const string NameEngine = "Alis Installer by @pabllopf";
        
        /// <summary>
        ///     The height window
        /// </summary>
        private readonly int heightWindow = 70;

        /// <summary>
        ///     The width window
        /// </summary>
        private readonly int widthWindow = 600;
        
        /// <summary>
        ///     The arguments
        /// </summary>
        private string[] arguments;
        
        /// <summary>
        /// The imgui controller
        /// </summary>
        private ImGuiControllerImplementGlfw _imguiController;
        
        /// <summary>
        ///     The is open main
        /// </summary>
        private bool isOpenMain = true;
        
        /// <summary>
        ///     Starts this instance
        /// </summary>
        /// <param name="args"></param>
        /// <returns>The int</returns>
        public void Run(string[] args)
        {
            arguments = args;
            Logger.Info(@$"Starting {NameEngine} with args: {string.Join(", ", arguments)}");

            string versionToInstall = null;

            for (int i = 0; i < args.Length; i++)
            {
                if ((args[i] == "-versionToInstall") && (i + 1 < args.Length))
                {
                    versionToInstall = args[i + 1];
                }
            }

            if (versionToInstall != null)
            {
                Logger.Info(@$"Version to install: {versionToInstall}");
            }
            else
            {
                versionToInstall = "latest";
                Logger.Warning($"Version to install: {versionToInstall}");
            }

            _imguiController = new ImGuiControllerImplementGlfw(NameEngine, widthWindow, heightWindow, 1, false);
            _imguiController.OnInit();
            
            
            string api = "https://api.github.com/repos/pabllopf/alis/releases";
            string dirProject = Path.Combine(Directory.GetParent(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)!.FullName)!.FullName, "Editor", $"{versionToInstall}");
            Logger.Info(@$"API: {api}");
            Logger.Info(@$"DIR: {dirProject}");
            Logger.Info(@"Starting UpdateManager");
            UpdateManager manager = new UpdateManager(new GitHubApiService(api), versionToInstall, new FileService(), dirProject);

            using CancellationTokenSource cts = new CancellationTokenSource();
            Task<bool> task = manager.Start(cts.Token);
            
            
            // Definir la variable de estado fuera del bucle principal
            int animationState = 0;

            // Inicializar la variable de tiempo fuera del bucle principal
            double lastUpdateTime = 0;
            Clock clock = new Clock();
            clock.Start();
            Logger.Info(@$"Starting {NameEngine}");
            
            while (_imguiController.IsRunning)
            {
                _imguiController.OnPollEvents();

                if (_imguiController.IsRunning == false)
                {
                    cts.Cancel();
                    Logger.Info(@$"Closing {NameEngine}");
                    break;
                }

                if (task.IsCompleted)
                {
                    _imguiController.IsRunning = false;
                }

                _imguiController.OnStartFrame();
                _imguiController.OnRenderFrame();
                
                if (clock.ElapsedMilliseconds - lastUpdateTime >= 250) // Si ha pasado al menos 1 segundo
                {
                    // Actualizar el estado de la animación
                    animationState++;
                    if (animationState > 3)
                    {
                        animationState = 0;
                    }

                    // Reiniciar el tiempo de la última actualización
                    lastUpdateTime = clock.ElapsedMilliseconds;
                }

                // Determinar qué símbolo mostrar basado en el estado de la animación
                string animationSymbol = animationState switch
                {
                    0 => "[/]",
                    1 => "[-]",
                    2 => "[\\]",
                    _ => "[/]"
                };

                ImGui.PushFont(_imguiController.FontLoaded16Solid);
                ImGui.SetNextWindowPos(new Vector2F(0, 0));
                Vector2F viewportSize = ImGui.GetMainViewport().Size;
                ImGui.SetNextWindowSize(new Vector2F(viewportSize.X, viewportSize.Y));
                if (ImGui.Begin("MainWindow", ref isOpenMain, ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoTitleBar | ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoScrollWithMouse))
                {
                    ImGui.Separator();
                    ImGui.ProgressBar(manager.Progress, new Vector2F(-1, 30), $"{Math.Round(manager.Progress * 100)}%");
                    ImGui.Separator();
                    ImGui.Text($"{animationSymbol} {manager.Message}");
                    ImGui.Separator();
                }
                ImGui.End();
                ImGui.PopFont();
                
                _imguiController.OnEndFrame();
            }

            if (_imguiController.IsRunning == false && !cts.IsCancellationRequested)
            {
                task.Wait(); 
            }
            
            
            Logger.Info(@$"Closing {NameEngine}");
            
            _imguiController.OnExit();
        }
    }
}