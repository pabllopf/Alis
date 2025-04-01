// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GeneralSetting.cs
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


namespace Alis.Core.Ecs.System.Configuration.General
{
    
    public class GeneralSetting(
        bool debug = false, 
        string name = "Default Name", 
        string description = "Default Description", 
        string version = "0.0.0", 
        string author = "Pablo Perdomo Falcón", 
        string license = "GPL-3.0 license", 
        string icon = "app.bmp") : IGeneralSetting
    {
        public bool Debug { get; set; } = debug;
        
        public string Name { get; set; } = name;
        
        public string Description { get; set; } = description;
        
        public string Version { get; set; } = version;
        
        public string Author { get; set; } = author;
        
        public string License { get; set; } = license;
        
        public string Icon { get; set; } = icon;
    }
}