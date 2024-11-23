// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AppDelegate.cs
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
using MonoMac.AppKit;
using MonoMac.Foundation;

namespace Alis.App.Engine
{
    internal class AppDelegate : NSApplicationDelegate
    {
        public override void DidFinishLaunching(NSNotification notification)
        {
            // Crear un nuevo menú principal
            NSMenu mainMenu = new NSMenu();

            // Crear un ítem de menú para la aplicación (generalmente "App")
            NSMenuItem appMenuItem = new NSMenuItem("App");
            NSMenu appMenu = new NSMenu();

            // Crear el ítem de menú "Acerca de"
            NSMenuItem aboutItem = new NSMenuItem("About MyApp", AboutApp);
            appMenu.AddItem(aboutItem);

            // Crear el ítem de menú "Salir"
            NSMenuItem quitItem = new NSMenuItem("Quit", QuitApp);
            appMenu.AddItem(quitItem);

            // Asignar el menú "App" al menú principal
            appMenuItem.Submenu = appMenu;
            mainMenu.AddItem(appMenuItem);

            // Asignar el menú principal de la aplicación
            NSApplication.SharedApplication.MainMenu = mainMenu;
        }

        // Acción para el ítem "Acerca de"
        void AboutApp(object sender, EventArgs e)
        {
            NSAlert alert = new NSAlert
            {
                MessageText = "Acerca de la App",
                InformativeText = "Esta es una aplicación de ejemplo usando MonoMac.",
                AlertStyle = NSAlertStyle.Informational
            };
            alert.RunModal();
        }

        // Acción para el ítem "Salir"
        void QuitApp(object sender, EventArgs e)
        {
            NSApplication.SharedApplication.Terminate((NSObject)sender);
        }
    }
}