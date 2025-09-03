// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Program.cs
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
using Alis.Core.Aspect.Logging;
using Alis.Core.Ecs.Systems.Configuration;

namespace Alis.Sample.Desktop
{
    /// <summary>
    ///     The program class
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     Main the args
        /// </summary>
        /// <param name="args">The args</param>
        public static void Main(string[] args)
        {
            //var game = VideoGame.Create().Build();
            //game.Save();

            Setting setting = new Setting();
            setting.General = setting.General with {Debug = true};
            setting.General = setting.General with {Name = "en-US"};
            setting.OnSave();
            
            Logger.Info("Setting saved successfully.");
            Logger.Info($"Debug: {setting.General.Debug}");
            Logger.Info($"Name: {setting.General.Name}");
            Logger.Info($"Description: {setting.General.Description}");
            Logger.Info($"Version: {setting.General.Version}");
            Logger.Info($"Author: {setting.General.Author}");
            Logger.Info($"License: {setting.General.License}");
            Logger.Info($"Icon: {setting.General.Icon}");
            
            
            
            setting.OnLoad();
            
            Logger.Info("General Setting:");
            Logger.Info($"Debug: {setting.General.Debug}");
            Logger.Info($"Name: {setting.General.Name}");
            Logger.Info($"Description: {setting.General.Description}");
            Logger.Info($"Version: {setting.General.Version}");
            Logger.Info($"Author: {setting.General.Author}");
            Logger.Info($"License: {setting.General.License}");
            Logger.Info($"Icon: {setting.General.Icon}");
            //game.Run();
        }
    }
}