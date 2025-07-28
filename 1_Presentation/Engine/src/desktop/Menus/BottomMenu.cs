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
        public static readonly ConcurrentQueue<ProcessInfo> ProcessQueue = new();
        public static int TotalProcesses => _totalProcesses;
        private static int _totalProcesses = 0;
        private static int _completedProcesses = 0;
        private static string _currentProcess = "Idle";
        private static readonly object _lock = new();
        private bool _showProcessPopup = false;
        private DateTime? _processStartTime = null;
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

        private void ApplyMenuStyles()
        {
            ImGui.PushStyleColor(ImGuiCol.Button, new Vector4F(0.13f, 0.14f, 0.15f, 1.0f));
            ImGui.PushStyleColor(ImGuiCol.FrameBg, new Vector4F(0.13f, 0.14f, 0.15f, 1.0f));
            ImGui.PushStyleVar(ImGuiStyleVar.FrameBorderSize, 0.0f);
            ImGui.PushStyleVar(ImGuiStyleVar.FramePadding, new Vector2F(4, 3));
        }

        private void RemoveMenuStyles()
        {
            ImGui.PopStyleVar(2);
            ImGui.PopStyleColor(2);
        }

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

        private void SetMenuWindowPositionAndSize(Vector2F dockSize, Vector2F menuSize, int sizeMenu, float bottomMenuHeight)
        {
            ImGui.SetNextWindowPos(new Vector2F(
                SpaceWork.ImGuiController.Viewport.WorkPos.X,
                SpaceWork.ImGuiController.Viewport.WorkPos.Y + dockSize.Y + sizeMenu + bottomMenuHeight / 2));
            ImGui.SetNextWindowSize(menuSize);
        }

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

        private void RenderNotificationButton()
        {
            if (ImGui.Button($"{FontAwesome5.Bell}##notifications"))
            {
                Logger.Info("Opening notifications...");
            }
        }

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
        }

        private void RenderProgressBar()
        {
            // Si no hay procesos, no mostrar la barra
            if (TotalProcesses == 0 || _completedProcesses >= TotalProcesses)
                return;
            float progress = (float)_completedProcesses / TotalProcesses;
            string label = $"{_completedProcesses}/{TotalProcesses} - {_currentProcess}";
            if (_processStartTime.HasValue && _currentProcessDuration > 0)
            {
                double elapsed = (DateTime.UtcNow - _processStartTime.Value).TotalMilliseconds;
                double percent = Math.Min(1.0, elapsed / _currentProcessDuration);
                progress = ((float)_completedProcesses + (float)percent) / TotalProcesses;
                label += $" ({Math.Max(0, (_currentProcessDuration - elapsed) / 1000.0):0.0}s)";
            }
            ImGui.SetCursorPosX(ImGui.GetContentRegionMax().X - 150);
            ImGui.ProgressBar(progress, new Vector2F(150, ImGui.GetContentRegionMax().Y - 10), label);
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
                ImGui.Text("Process Queue:");
                int i = 1;
                foreach (var process in ProcessQueue)
                {
                    string extra = process.Status == ProcessStatus.Running && process.StartTime.HasValue
                        ? $" ({Math.Max(0, (process.DurationMs - (DateTime.UtcNow - process.StartTime.Value).TotalMilliseconds) / 1000.0):0.0}s left)"
                        : "";
                    ImGui.BulletText($"{i++}. {process.Name} - {process.Status}{extra}");
                }
                if (ImGui.Button("Close"))
                {
                    _showProcessPopup = false;
                    ImGui.CloseCurrentPopup();
                }
                ImGui.EndPopup();
            }
        }

        // Call this in Update or a background thread to update process status
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
        public static void EnqueueProcess(string name, int durationMs)
        {
            ProcessQueue.Enqueue(new ProcessInfo { Name = name, Status = ProcessStatus.Pending, DurationMs = durationMs });
            Interlocked.Increment(ref _totalProcesses);
        }

        // Call this to mark a process as completed
        public static void CompleteProcess()
        {
            Interlocked.Increment(ref _completedProcesses);
        }
    }

    public class ProcessInfo
    {
        public string Name { get; set; }
        public ProcessStatus Status { get; set; }
        public int DurationMs { get; set; } // Duration in milliseconds
        public DateTime? StartTime { get; set; }
    }

    public enum ProcessStatus
    {
        Pending,
        Running,
        Completed
    }
}

