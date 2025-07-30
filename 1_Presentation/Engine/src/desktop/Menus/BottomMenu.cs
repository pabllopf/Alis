using System;
using Alis.App.Engine.Desktop.Core;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Ui;
using Alis.Extension.Graphic.Ui.Fonts;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace Alis.App.Engine.Desktop.Menus
{
    /// <summary>
    /// The bottom menu class
    /// </summary>
    /// <seealso cref="IRenderable"/>
    /// <seealso cref="IHasSpaceWork"/>
    public class BottomMenu : IRenderable, IHasSpaceWork
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BottomMenu"/> class
        /// </summary>
        /// <param name="spaceWork">The space work</param>
        public BottomMenu(SpaceWork spaceWork) => SpaceWork = spaceWork;
        /// <summary>
        /// Gets the value of the space work
        /// </summary>
        public SpaceWork SpaceWork { get; }

        // Static process queue accessible from anywhere
        /// <summary>
        /// The process queue
        /// </summary>
        public static readonly ConcurrentQueue<ProcessInfo> ProcessQueue = new();
        /// <summary>
        /// Gets the value of the total processes
        /// </summary>
        public static int TotalProcesses => _totalProcesses;
        /// <summary>
        /// The total processes
        /// </summary>
        private static int _totalProcesses = 0;
        /// <summary>
        /// The completed processes
        /// </summary>
        private static int _completedProcesses = 0;
        /// <summary>
        /// The current process
        /// </summary>
        private static string _currentProcess = "Idle";
        /// <summary>
        /// The lock
        /// </summary>
        private static readonly object _lock = new();
        /// <summary>
        /// The show process popup
        /// </summary>
        private bool _showProcessPopup = false;
        /// <summary>
        /// The process start time
        /// </summary>
        private DateTime? _processStartTime = null;
        /// <summary>
        /// The current process duration
        /// </summary>
        private int _currentProcessDuration = 0;

        /// <summary>
        /// Initializes this instance
        /// </summary>
        public void Initialize() 
        { 
#if DEBUG
            // Add 10 demo processes with different durations and names for debug/testing
            EnqueueProcess("Loading assets", 2000);
            EnqueueProcess("Connecting to server", 1000);
            EnqueueProcess("Initializing UI", 500);
            EnqueueProcess("Syncing data", 3000);
            EnqueueProcess("Compiling shaders", 1500);
            EnqueueProcess("Checking updates", 700);
            EnqueueProcess("Loading user profile", 1200);
            EnqueueProcess("Preparing workspace", 2500);
            EnqueueProcess("Verifying license", 800);
            EnqueueProcess("Finalizing startup", 1100);
#endif
        }
        
        /// <summary>
        /// Starts this instance
        /// </summary>
        public void Start() { }

        /// <summary>
        /// Renders this instance
        /// </summary>
        public void Render()
        {
            ApplyMenuStyles();
            var (dockSize, menuSize, posY, sizeMenu, bottomMenuHeight) = CalculateMenuLayout();
            SetMenuWindowPositionAndSize(dockSize, menuSize, sizeMenu, bottomMenuHeight);

            if (ImGui.Begin("Bottom Menu", ImGuiWindowFlags.NoTitleBar | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoScrollbar))
            {
                RenderMenuColumns();
                ImGui.End();
            }

            RemoveMenuStyles();
            
            UpdateProcessStatus();
        }

        /// <summary>
        /// Applies the menu styles
        /// </summary>
        private void ApplyMenuStyles()
        {
            ImGui.PushStyleColor(ImGuiCol.Button, new Vector4F(0.13f, 0.14f, 0.15f, 1.0f));
            ImGui.PushStyleColor(ImGuiCol.FrameBg, new Vector4F(0.13f, 0.14f, 0.15f, 1.0f));
            ImGui.PushStyleVar(ImGuiStyleVar.FrameBorderSize, 0.0f);
            ImGui.PushStyleVar(ImGuiStyleVar.FramePadding, new Vector2F(4, 3));
        }

        /// <summary>
        /// Removes the menu styles
        /// </summary>
        private void RemoveMenuStyles()
        {
            ImGui.PopStyleVar(2);
            ImGui.PopStyleColor(2);
        }

        /// <summary>
        /// Calculates the menu layout
        /// </summary>
        /// <returns>The vector dock size vector menu size int pos int size menu float bottom menu height</returns>
        private (Vector2F dockSize, Vector2F menuSize, int posY, int sizeMenu, float bottomMenuHeight) CalculateMenuLayout()
        {
#if OSX
            int posY = 72;
            int sizeMenu = 30;
            float bottomMenuHeight = 30;
#else
            int posY = 170;
            int sizeMenu = 31;
            float bottomMenuHeight = 60;
#endif
            Vector2F dockSize = SpaceWork.ImGuiController.Viewport.Size - new Vector2F(5, posY);
            Vector2F menuSize = new Vector2F(SpaceWork.ImGuiController.Viewport.Size.X, bottomMenuHeight);
            return (dockSize, menuSize, posY, sizeMenu, bottomMenuHeight);
        }

        /// <summary>
        /// Sets the menu window position and size using the specified dock size
        /// </summary>
        /// <param name="dockSize">The dock size</param>
        /// <param name="menuSize">The menu size</param>
        /// <param name="sizeMenu">The size menu</param>
        /// <param name="bottomMenuHeight">The bottom menu height</param>
        private void SetMenuWindowPositionAndSize(Vector2F dockSize, Vector2F menuSize, int sizeMenu, float bottomMenuHeight)
        {
            ImGui.SetNextWindowPos(new Vector2F(
                SpaceWork.ImGuiController.Viewport.WorkPos.X,
                SpaceWork.ImGuiController.Viewport.WorkPos.Y + dockSize.Y + sizeMenu + bottomMenuHeight / 2));
            ImGui.SetNextWindowSize(menuSize);
        }

        /// <summary>
        /// Renders the menu columns
        /// </summary>
        private void RenderMenuColumns()
        {
            ImGui.Columns(6, "MenuColumns", false);
            RenderNotificationButton();
            ImGui.SameLine();
            RenderBranchSelector();
            ImGui.NextColumn();
            ImGui.NextColumn();
            ImGui.NextColumn();
            ImGui.NextColumn();
            ImGui.NextColumn();
            RenderProgressBar();
        }

        /// <summary>
        /// Renders the notification button
        /// </summary>
        private void RenderNotificationButton()
        {
            if (ImGui.Button($"{FontAwesome5.Bell}##notifications"))
            {
                Logger.Info("Opening notifications...");
            }
        }

        
        /// <summary>
        ///     Renders the branch selector dropdown
        /// </summary>
        private void RenderBranchSelector()
        {
            ImGui.SetNextItemWidth(180);
            if (ImGui.BeginCombo("##branchSelector", $"{FontAwesome5.CodeBranch}Master", ImGuiComboFlags.HeightLarge))
            {
                if (ImGui.Selectable("master"))
                {
                    Logger.Info("Switching to branch master...");
                }
                if (ImGui.Selectable("develop"))
                {
                    Logger.Info("Switching to branch develop...");
                }
                if (ImGui.Selectable("feature/new-feature"))
                {
                    Logger.Info("Switching to branch feature/new-feature...");
                }
                ImGui.EndCombo();
            }

            ImGui.SameLine();
        }

        

        /// <summary>
        /// Renders the progress bar
        /// </summary>
        private void RenderProgressBar()
        {
            // Si no hay procesos, no mostrar la barra
            if (TotalProcesses == 0 || _completedProcesses >= TotalProcesses)
            {
                return;
            }

            float progress = (float)_completedProcesses / TotalProcesses;

            // Calcular el tiempo total transcurrido desde el inicio del primer proceso
            double totalTime = 0;
            lock (_lock)
            {
                foreach (var process in ProcessQueue)
                {
                    if (process.StartTime.HasValue)
                    {
                        totalTime += (DateTime.UtcNow - process.StartTime.Value).TotalSeconds;
                    }
                }
            }

            string processLabel = _currentProcess;
            int maxLabelLength = 15; // Puedes ajustar este valor según el espacio disponible
            if (!string.IsNullOrEmpty(processLabel) && processLabel.Length > maxLabelLength)
            {
                processLabel = processLabel.Substring(0, maxLabelLength) + "...";
            }
            string label = $"{_completedProcesses}/{TotalProcesses} {processLabel} ({totalTime:0.0}s)";

            ImGui.SetCursorPosX(ImGui.GetContentRegionMax().X - 200);
            ImGui.ProgressBar(progress, new Vector2F(200, ImGui.GetContentRegionMax().Y - 10), label);
            if (ImGui.IsItemHovered() && ImGui.IsMouseClicked(0))
            {
                _showProcessPopup = true;
            }
            if (_showProcessPopup)
            {
                ImGui.OpenPopup("ProcessQueuePopup");
            }
            if (ImGui.BeginPopup("ProcessQueuePopup"))
            {
                int displayedProcesses = 0;
                foreach (var process in ProcessQueue)
                {
                    string extra = process.Status == ProcessStatus.Running && process.StartTime.HasValue
                        ? $" ({(DateTime.UtcNow - process.StartTime.Value).TotalSeconds:0.0}s)"
                        : process.Status == ProcessStatus.Completed ? " (Completed)" : "";
                    float processProgress = process.Status == ProcessStatus.Running && process.StartTime.HasValue
                        ? (float)(DateTime.UtcNow - process.StartTime.Value).TotalMilliseconds / process.DurationMs
                        : process.Status == ProcessStatus.Completed ? 1.0f : 0.0f;
                    ImGui.ProgressBar(processProgress, new Vector2F(190, 17), $"{process.Name}{extra}");
                    displayedProcesses++;
                }
                // Rellenar con huecos vacíos si hay menos de 10 procesos
                for (int i = displayedProcesses; i < 10; i++)
                {
                    ImGui.NewLine();
                }
                ImGui.EndPopup();
            }

            // if i click outside the popup, close it
            if (ImGui.IsMouseClicked(0) && ImGui.IsPopupOpen("ProcessQueuePopup"))
            {
                _showProcessPopup = false;
                ImGui.CloseCurrentPopup();
            }
        }

        // Call this in Update or a background thread to update process status
        /// <summary>
        /// Updates the process status
        /// </summary>
        public void UpdateProcessStatus()
        {
            lock (_lock)
            {
                if (ProcessQueue.TryPeek(out var process))
                {
                    if (process.Status == ProcessStatus.Pending)
                    {
                        process.Status = ProcessStatus.Running;
                        _currentProcess = process.Name;
                        _processStartTime = DateTime.UtcNow;
                        _currentProcessDuration = process.DurationMs;
                        process.StartTime = _processStartTime;
                    }
                    else if (process.Status == ProcessStatus.Running)
                    {
                        if (_processStartTime.HasValue && (DateTime.UtcNow - _processStartTime.Value).TotalMilliseconds >= _currentProcessDuration)
                        {
                            process.Status = ProcessStatus.Completed;
                            ProcessQueue.TryDequeue(out _);
                            CompleteProcess();
                            _currentProcess = ProcessQueue.TryPeek(out var next) ? next.Name : "Idle";
                            _processStartTime = null;
                            _currentProcessDuration = 0;
                        }
                    }
                }
                else
                {
                    _currentProcess = "Idle";
                    _processStartTime = null;
                    _currentProcessDuration = 0;
                }
            }
        }

        // Method to add a process from anywhere
        /// <summary>
        /// Enqueues the process using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="durationMs">The duration ms</param>
        public static void EnqueueProcess(string name, int durationMs)
        {
            ProcessQueue.Enqueue(new ProcessInfo { Name = name, Status = ProcessStatus.Pending, DurationMs = durationMs });
            Interlocked.Increment(ref _totalProcesses);
        }

        // Call this to mark a process as completed
        /// <summary>
        /// Completes the process
        /// </summary>
        public static void CompleteProcess()
        {
            Interlocked.Increment(ref _completedProcesses);
        }
    }

    /// <summary>
    /// The process info class
    /// </summary>
    public class ProcessInfo
    {
        /// <summary>
        /// Gets or sets the value of the name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the value of the status
        /// </summary>
        public ProcessStatus Status { get; set; }
        /// <summary>
        /// Gets or sets the value of the duration ms
        /// </summary>
        public int DurationMs { get; set; } // Duration in milliseconds
        /// <summary>
        /// Gets or sets the value of the start time
        /// </summary>
        public DateTime? StartTime { get; set; }
    }

    /// <summary>
    /// The process status enum
    /// </summary>
    public enum ProcessStatus
    {
        /// <summary>
        /// The pending process status
        /// </summary>
        Pending,
        /// <summary>
        /// The running process status
        /// </summary>
        Running,
        /// <summary>
        /// The completed process status
        /// </summary>
        Completed
    }
}
