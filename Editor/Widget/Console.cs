//------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Console.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//------------------------------------------------------------------------------------------
namespace Alis.Editor
{
    using System;
    using System.Collections.Generic;
    using ImGuiNET;
   
    /// <summary>Console widget </summary>
    public class Console : Widget
    {
        private string name = "Console";

        /// <summary>The filter PTR</summary>
        private ImGuiTextFilterPtr filterPtr;

        /// <summary>The is open</summary>
        private bool isOpen;

        /// <summary>The log</summary>
        private List<string> log = new List<string>();

        private EventHandler<EventType> eventHandler;

        public Console(EventHandler<EventType> eventHandler) 
        {
            this.eventHandler = eventHandler;
            isOpen = true;

            unsafe
            {
                ImGuiTextFilter* filterPtr = ImGuiNative.ImGuiTextFilter_ImGuiTextFilter(null);
                filterPtr = new ImGuiTextFilterPtr(filterPtr);
            }
        }

        /// <summary>Initializes a new instance of the <see cref="Console" /> class.</summary>
        public Console(bool isOpen) 
        {
            this.isOpen = isOpen;

            unsafe 
            {
                ImGuiTextFilter* filterPtr = ImGuiNative.ImGuiTextFilter_ImGuiTextFilter(null);
                filterPtr = new ImGuiTextFilterPtr(filterPtr);
            }
        }


        /// <summary>Clears this instance.</summary>
        public void Clear() 
        {
            log.Clear();
        }

        public override string GetName()
        {
            return name;
        }

        public override void Open()
        {
            isOpen = true;
        }

        public override void Close()
        {
            isOpen = false;
        }

        public override void OnLoad()
        {
        }

        /// <summary>Draws this instance.</summary>
        public override void Draw()
        {
            if (!isOpen) 
            {
                eventHandler?.Invoke(this, EventType.CloseConsole);
                return;
            }

            if (ImGui.Begin("Console", ref isOpen))
            {
                if (ImGui.Button(Icon.ICON_FA_TRASH + " Clean"))
                {
                    Clear();
                    return;
                }
            }

            ImGui.End();
        }

        
    }
}

/*
    using ImGuiNET;
    using System;
    using System.Collections.Generic;
    public class Console
    {
        private ImGuiTextFilterPtr filter;

        private bool filterMessages = false;
        private bool filterErrors = false;
        private bool filterWarnings = false;

        private List<String> consoleLog = new List<string>();

        private System.Numerics.Vector2 itemSpacing;

        private System.Numerics.Vector4 defaultColor;
        private System.Numerics.Vector4 buttonDefault;
        private System.Numerics.Vector4 buttonPressed = new System.Numerics.Vector4(0.078f, 0.095f, 0.108f, 1.000f);
        private System.Numerics.Vector4 redColor = new System.Numerics.Vector4(0.879f, 0.205f, 0.205f, 1.000f);
        private System.Numerics.Vector4 yellowColor = new System.Numerics.Vector4(0.933f, 0.875f, 0.238f, 1.000f);


        public unsafe Console()
        {
            ImGuiStylePtr style = ImGui.GetStyle();
            defaultColor = style.Colors[(int)ImGuiCol.Text];
            buttonDefault = style.Colors[(int)ImGuiCol.Button];
            itemSpacing = style.ItemSpacing;

            ImGuiTextFilter* filterPtr = ImGuiNative.ImGuiTextFilter_ImGuiTextFilter(null);
            filter = new ImGuiTextFilterPtr(filterPtr);

            Message("ejemplo");
            Error("Error: ejemplo");
            Warning("Warning: ejemplo");
        }

        public void Clear()
        {
            consoleLog.Clear();
        }

        public void Warning(string message)
        {
            consoleLog.Add(message);
        }

        public void Error(string message)
        {
            consoleLog.Add(message);
        }

        public void Message(string message)
        {
            consoleLog.Add(message);
        }

        private void Print(string message)
        {
            if (filterErrors == true && message.Contains("Error"))
            {
                ImGui.TextColored(redColor, message);
                return;
            }

            if (filterWarnings == true && message.Contains("Warning"))
            {
                ImGui.TextColored(yellowColor, message);
                return;
            }

            if (filterMessages == true && !message.Contains("Error") && !message.Contains("Warning"))
            {
                ImGui.TextColored(defaultColor, message);
                return;
            }

            if (filterErrors == true && filterWarnings == true && (message.Contains("Error") || message.Contains("Warning")))
            {
                ImGui.TextColored(
                    message.Contains("Error") ? redColor : yellowColor,
                    message);
                return;
            }

            if (filterErrors == true && filterMessages == true && (message.Contains("Error") || message.Contains("Warning")))
            {
                ImGui.TextColored(
                    message.Contains("Error") ? redColor : defaultColor,
                    message);
                return;
            }

            if (filterWarnings == true && filterMessages == true && (message.Contains("Error") || message.Contains("Warning")))
            {
                ImGui.TextColored(
                    message.Contains("Warning") ? yellowColor : defaultColor,
                    message);
                return;
            }

            if (filterErrors == false && filterWarnings == false && filterMessages == false)
            {
                ImGui.TextColored(
                    message.Contains("Error") ? redColor :
                    message.Contains("Warning") ? yellowColor :
                    defaultColor,
                    message);
                return;
            }
        }

        public void Draw()
        {
            bool isOpen = true;
            if (ImGui.Begin("Console", ref isOpen)) 
            {
                if (ImGui.Button(Icon.ICON_FA_TRASH + " Clean"))
                {
                    Clear();
                    return;
                }

                ImGui.SameLine();

                filter.Draw(Icon.ICON_FA_SEARCH + "", -100.0f);

                ImGui.SameLine();

                ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, new System.Numerics.Vector2(2.0f, 3.0f));

                ImGui.PushStyleColor(ImGuiCol.Button, filterMessages ? buttonPressed : buttonDefault);
                if (ImGui.Button(Icon.ICON_FA_COMMENT + ""))
                {
                    filterMessages = !filterMessages;
                }

                ImGui.PopStyleColor(1);

                ImGui.SameLine();

                ImGui.PushStyleColor(ImGuiCol.Button, filterWarnings ? buttonPressed : buttonDefault);
                if (ImGui.Button(Icon.ICON_FA_EXCLAMATION_CIRCLE + ""))
                {
                    filterWarnings = !filterWarnings;
                }
                ImGui.PopStyleColor(1);

                ImGui.SameLine();

                ImGui.PushStyleColor(ImGuiCol.Button, filterErrors ? buttonPressed : buttonDefault);
                if (ImGui.Button(Icon.ICON_FA_EXCLAMATION_TRIANGLE + ""))
                {
                    filterErrors = filterErrors ? false : true;
                }
                ImGui.PopStyleColor(1);
                ImGui.PopStyleVar(1);

                ImGui.Separator();

                if (ImGui.BeginChild("scrolling", new System.Numerics.Vector2(0, 0), false, ImGuiWindowFlags.HorizontalScrollbar)) 
                {
                    ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, new System.Numerics.Vector2(0, 0));

                    if (filter.IsActive())
                    {
                        foreach (string message in consoleLog) 
                        {
                            if (filter.PassFilter(message)) 
                            {
                                Print(message);
                            }
                        }
                    }
                    else
                    {
                        foreach (string message in consoleLog)
                        {
                            Print(message);
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
*/