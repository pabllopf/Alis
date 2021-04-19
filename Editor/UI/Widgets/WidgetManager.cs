//----------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="WidgetManager.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//----------------------------------------------------------------------------------------------------
namespace Alis.Editor.UI.Widgets
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using Alis.Tools;
    using ImGuiNET;

    /// <summary>Widget Manager</summary>
    public class WidgetManager
    {
        /// <summary>The current</summary>
        [AllowNull]
        private WidgetManager current;

        /// <summary>The widgets</summary>
        [NotNull]
        private List<Widget> widgets;

        /// <summary>The information</summary>
        [NotNull]
        private Info info;

        /// <summary>Initializes a new instance of the <see cref="WidgetManager" /> class.</summary>
        public WidgetManager(Info info)
        {
            widgets = new List<Widget>
            {
                new DockSpace(),
                new TopMenu(info),
                new BottomMenu(),
                new Inspector(),
                new Console()
            };

            DefaultView();
            Logger.Info();
        }

        /// <summary>Draws this instance.</summary>
        public void Update()
        {
            for (int i = 0; i < widgets.Count; i++)
            {
                if (widgets[i] != null) 
                {
                    widgets[i].Draw();
                }
            }
        }

        public void AddWidget(Widget widget) 
        {
            
        }

        private void DefaultView()
        {
            string file = Environment.CurrentDirectory + "/custom.ini";
            if (File.Exists(file))
            {
                ImGui.LoadIniSettingsFromDisk(file);
            }
            else
            {
                string filetemp = Environment.CurrentDirectory + "/Resources/Default.ini";
                if (File.Exists(filetemp))
                {
                    ImGui.LoadIniSettingsFromDisk(filetemp);
                    ImGui.SaveIniSettingsToDisk(file);
                }
            }
        }
    }
}
