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
using Alis.Builder.Core.Ecs.Entity;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs;
using Alis.Core.Ecs.Components.Render;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Systems.Configuration;
using Alis.Core.Ecs.Systems.Configuration.General;
using Alis.Core.Physic.Common;

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
            
            Console.WriteLine("Setting saved successfully.");
            Console.WriteLine($"Debug: {setting.General.Debug}");
            Console.WriteLine($"Name: {setting.General.Name}");
            Console.WriteLine($"Description: {setting.General.Description}");
            Console.WriteLine($"Version: {setting.General.Version}");
            Console.WriteLine($"Author: {setting.General.Author}");
            Console.WriteLine($"License: {setting.General.License}");
            Console.WriteLine($"Icon: {setting.General.Icon}");
            
            
            
            setting.OnLoad();
            
            Console.WriteLine("General Setting:");
            Console.WriteLine($"Debug: {setting.General.Debug}");
            Console.WriteLine($"Name: {setting.General.Name}");
            Console.WriteLine($"Description: {setting.General.Description}");
            Console.WriteLine($"Version: {setting.General.Version}");
            Console.WriteLine($"Author: {setting.General.Author}");
            Console.WriteLine($"License: {setting.General.License}");
            Console.WriteLine($"Icon: {setting.General.Icon}");
            //game.Run();
        }
    }
}