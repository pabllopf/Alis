//----------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Console.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//----------------------------------------------------------------------------------------------------
namespace Alis.Editor.UI.Widgets
{
    using Alis.Editor.Utils;
    using ImGuiNET;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>Console widget </summary>
    public class Console : Widget
    {
        /// <summary>The current</summary>
        private static Console current; 

        /// <summary>The filter PTR</summary>
        private ImGuiTextFilterPtr filter;

        /// <summary>The is open</summary>
        private bool isOpen;

        /// <summary>The log</summary>
        private List<string> log = new List<string>();

        /// <summary>The event handler</summary>
        private EventHandler<EventType> eventHandler;

        /// <summary>The item space</summary>
        private System.Numerics.Vector2 itemSpace = new System.Numerics.Vector2(2.0f, 3.0f);

        [NotNull]
        private bool focus = false;

        #region StateFilters

        /// <summary>The filter messages</summary>
        private bool filterLogs = false;
        
        /// <summary>The filter errors</summary>
        private bool filterErrors = false;

        /// <summary>The filter warnings</summary>
        private bool filterWarnings = false;

        #endregion

        #region Colors

        /// <summary>The default color</summary>
        private System.Numerics.Vector4 defaultColor;
        
        /// <summary>The button default</summary>
        private System.Numerics.Vector4 buttonDefault;
        
        /// <summary>The button pressed</summary>
        private System.Numerics.Vector4 buttonPressed = new System.Numerics.Vector4(0.078f, 0.095f, 0.108f, 1.000f);
        
        /// <summary>The red color</summary>
        private System.Numerics.Vector4 redColor = new System.Numerics.Vector4(0.654f, 0.070f, 0.070f, 1.000f);
        
        /// <summary>The yellow color</summary>
        private System.Numerics.Vector4 yellowColor = new System.Numerics.Vector4(0.852f, 0.812f, 0.207f, 1.000f);

        /// <summary>Gets or sets the current.</summary>
        /// <value>The current.</value>
        public static Console Current { get => current; set => current = value; }

        #endregion

        /// <summary>Initializes a new instance of the <see cref="Console" /> class.</summary>
        /// <param name="eventHandler">The event handler.</param>
        public Console()
        {
            isOpen = true;

            unsafe
            {
                ImGuiTextFilter* filterPtr = ImGuiNative.ImGuiTextFilter_ImGuiTextFilter(null);
                filter = new ImGuiTextFilterPtr(filterPtr);
            }

            current = this;
        }

        /// <summary>Clears this instance.</summary>
        public void Clear()
        {
            log.Clear();
        }

        /// <summary>Warnings the specified message.</summary>
        /// <param name="message">The message.</param>
        public static void Warning(string message)
        {
            current?.log?.Add("[" + DateTime.Today + "]" + "  Warning: " + message + "");
            current?.Focus();
        }

        /// <summary>Errors the specified message.</summary>
        /// <param name="message">The message.</param>
        public static void Error(string message)
        {
            current?.log?.Add("[" + DateTime.Today + "]" + "  Error: " + message + "");
            current?.Focus();
        }

        /// <summary>Logs the specified message.</summary>
        /// <param name="message">The message.</param>
        public static void Log(string message)
        {
            current?.log?.Add("[" + DateTime.Today + "]" + "  Log: " + message + "");
            current?.Focus();
        }

        /// <summary>Logs the specified message.</summary>
        /// <param name="message">The message.</param>
        /// <param name="date">if set to <c>true</c> [date].</param>
        public static void Log(string message, bool date)
        {
            if (date)
            {
                current?.log?.Add("[" + DateTime.Today + "]" + "  Log: " + message + "");
            }
            else 
            {
                current?.log?.Add("Log: " + message + "");
            }

            current?.Focus();
        }

        /// <summary>Focuses this instance.</summary>
        private void Focus()
        {
            focus = true;
        }

        /// <summary>Prints this instance.</summary>
        public void Print(string message)
        {
            if (filterErrors && message.Contains("Error"))
            {
                ImGui.TextColored(redColor, message.Replace("Error: ", ""));
                return;
            }

            if (filterWarnings && message.Contains("Warning"))
            {
                ImGui.TextColored(yellowColor, message.Replace("Warning: ", ""));
                return;
            }

            if (filterLogs && message.Contains("Log"))
            {
                ImGui.Text(message.Replace("Log: ", ""));
                return;
            }

            if (!filterLogs && !filterWarnings && !filterErrors) 
            {
                if (message.Contains("Warning") || message.Contains("Error")) 
                {
                    ImGui.TextColored(
                        message.Contains("Warning") ? yellowColor : redColor,
                        message.Contains("Warning") ? message.Replace("Warning: ", "") :
                        message.Replace("Error: ", "")
                        );
                }

                if (message.Contains("Log")) 
                {
                    ImGui.Text(message.Replace("Log: ", ""));
                }
            }
        }

        /// <summary>Draws this instance.</summary>
        public override void Draw()
        {
            if (!isOpen)
            {
                WidgetManager.Delete(this);
                return;
            }

            if (focus)
            {
                ImGui.SetNextWindowFocus();
                focus = false;
            }

            if (ImGui.Begin("Console", ref isOpen))
            {
                if (ImGui.Button(Icon.TRASH + " Clean"))
                {
                    Clear();
                    return;
                }

                ImGui.SameLine();

                filter.Draw(Icon.SEARCH + "", -100.0f);

                ImGui.SameLine();

                ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, itemSpace);

                ImGui.PushStyleColor(ImGuiCol.Button, filterLogs ? buttonPressed : buttonDefault);
                if (ImGui.Button(Icon.COMMENT + ""))
                {
                    filterLogs = !filterLogs;
                }

                ImGui.PopStyleColor(1);

                ImGui.SameLine();

                ImGui.PushStyleColor(ImGuiCol.Button, filterWarnings ? buttonPressed : buttonDefault);

                if (log.Find(i => i.Contains("Warning")) != null) 
                {
                    ImGui.PushStyleColor(ImGuiCol.Text, yellowColor);
                }

                if (ImGui.Button(Icon.EXCLAMATIONCIRCLE + ""))
                {
                    filterWarnings = !filterWarnings;
                }
                ImGui.PopStyleColor();
                if (log.Find(i => i.Contains("Warning")) != null)
                {
                    ImGui.PopStyleColor();
                }

                ImGui.SameLine();

                ImGui.PushStyleColor(ImGuiCol.Button, filterErrors ? buttonPressed : buttonDefault);
                
                if (log.Find(i => i.Contains("Error")) != null)
                {
                    ImGui.PushStyleColor(ImGuiCol.Text, redColor);
                }

                if (ImGui.Button(Icon.EXCLAMATIONTRIANGLE + ""))
                {
                    filterErrors = !filterErrors;
                }
                
                ImGui.PopStyleColor();
                if (log.Find(i => i.Contains("Error")) != null)
                {
                    ImGui.PopStyleColor();
                }

                ImGui.PopStyleVar(1);

                ImGui.Separator();

                if (ImGui.BeginChild("scrolling", new System.Numerics.Vector2(0, 0), false, ImGuiWindowFlags.HorizontalScrollbar))
                {
                    ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, new System.Numerics.Vector2(0, 0));

                    for (int i = 0; i < log.Count; i++)
                    {
                        if (filter.IsActive())
                        {
                            if (filter.PassFilter(log[i]))
                            {
                                Print(log[i]);
                            }
                        }
                        else 
                        {
                            Print(log[i]);
                        }
                    }

                    ImGui.PopStyleVar();

                    if (ImGui.GetScrollY() >= ImGui.GetScrollMaxY())
                    {
                        ImGui.SetScrollHereY(1.0f);
                    }
                }

                ImGui.EndChild();
            }

            ImGui.End();
        }
    }
}