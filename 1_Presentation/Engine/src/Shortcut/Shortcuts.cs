// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Shortcuts.cs
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

namespace Alis.App.Engine.Shortcut
{
    public static class Shortcuts
    {
        public static string NewScene { get; private set; }
        public static string OpenScene { get; private set; }
        public static string Save { get; private set; }
        public static string SaveAs { get; private set; }
        public static string Undo { get; private set; }
        public static string Redo { get; private set; }
        public static string Play { get; private set; }
        public static string Pause { get; private set; }
        public static string Cut { get; private set; }
        public static string Copy { get; private set; }
        public static string Paste { get; private set; }
        public static string Duplicate { get; private set; }
        public static string Delete { get; private set; }
        public static string Search { get; private set; }
        
        public static string AboutAlis { get; private set; }
        public static string Preferences { get; private set; }
        public static string QuitAlis { get; private set; }
        
        static Shortcuts()
        {
            if (OperatingSystem.IsMacOS())
            {
                NewScene = "Cmd+N";
                OpenScene = "Cmd+O";
                Save = "Cmd+S";
                SaveAs = "Cmd+Shift+S";
                Undo = "Cmd+Z";
                Redo = "Cmd+Shift+Z";
                Play = "Cmd+P";
                Pause = "Cmd+Shift+P";
                Cut = "Cmd+X";
                Copy = "Cmd+C";
                Paste = "Cmd+V";
                Duplicate = "Cmd+D";
                Delete = "Cmd+Backspace";
                Search = "Cmd+F";
                AboutAlis = "Cmd+I";
                Preferences = "Cmd+,";
                QuitAlis = "Cmd+Q";
            }
            else if (OperatingSystem.IsLinux() || OperatingSystem.IsWindows())
            {
                NewScene = "Ctrl+N";
                OpenScene = "Ctrl+O";
                Save = "Ctrl+S";
                SaveAs = "Ctrl+Shift+S";
                Undo = "Ctrl+Z";
                Redo = "Ctrl+Shift+Z";
                Play = "Ctrl+P";
                Pause = "Ctrl+Shift+P";
                Cut = "Ctrl+X";
                Copy = "Ctrl+C";
                Paste = "Ctrl+V";
                Duplicate = "Ctrl+D";
                Delete = "Del";
                Search = "Ctrl+F";
                AboutAlis = "Ctrl+I";
                Preferences = "Ctrl+,";
                QuitAlis = "Ctrl+Q";
            }
        }
    }
}