using Alis.Core.Ecs.Systems.Execution;
using Xunit;

namespace Alis.Test.Core.Ecs.Systems.Execution
{
    /// <summary>
    /// The runtime compliance test class
    /// </summary>
    public class IRuntimeComplianceTest
    {
        /// <summary>
        /// Tests that interface can be implemented
        /// </summary>
        [Fact]
        public void Interface_CanBeImplemented()
        {
            var runtime = new TestRuntime();
            Assert.IsAssignableFrom<IRuntime>(runtime);
        }

        /// <summary>
        /// Tests that all lifecycle methods can be called
        /// </summary>
        [Fact]
        public void AllLifecycleMethods_CanBeCalled()
        {
            var runtime = new TestRuntime();
            runtime.OnEnable();
            runtime.OnInit();
            runtime.OnAwake();
            runtime.OnStart();
            runtime.OnPhysicUpdate();
            runtime.OnBeforeUpdate();
            runtime.OnUpdate();
            runtime.OnAfterUpdate();
            runtime.OnProcessPendingChanges();
            runtime.OnBeforeFixedUpdate();
            runtime.OnFixedUpdate();
            runtime.OnAfterFixedUpdate();
            runtime.OnDispatchEvents();
            runtime.OnCalculate();
            runtime.OnBeforeDraw();
            runtime.OnDraw();
            runtime.OnAfterDraw();
            runtime.OnGui();
            runtime.OnRenderPresent();
            runtime.OnDisable();
            runtime.OnReset();
            runtime.OnStop();
            runtime.OnExit();
            runtime.OnDestroy();
            runtime.OnSave();
            runtime.OnLoad();
            runtime.OnSave("test");
            runtime.OnLoad("test");
            Assert.True(runtime.AllCalled);
        }

        /// <summary>
        /// The test runtime class
        /// </summary>
        /// <seealso cref="IRuntime"/>
        internal sealed class TestRuntime : IRuntime
        {
            /// <summary>
            /// The call count
            /// </summary>
            private int _callCount;
            /// <summary>
            /// The expected calls
            /// </summary>
            private const int ExpectedCalls = 28;

            /// <summary>
            /// Ons the enable
            /// </summary>
            public void OnEnable() { _callCount++; }
            /// <summary>
            /// Ons the init
            /// </summary>
            public void OnInit() { _callCount++; }
            /// <summary>
            /// Ons the awake
            /// </summary>
            public void OnAwake() { _callCount++; }
            /// <summary>
            /// Ons the start
            /// </summary>
            public void OnStart() { _callCount++; }
            /// <summary>
            /// Ons the physic update
            /// </summary>
            public void OnPhysicUpdate() { _callCount++; }
            /// <summary>
            /// Ons the before update
            /// </summary>
            public void OnBeforeUpdate() { _callCount++; }
            /// <summary>
            /// Ons the update
            /// </summary>
            public void OnUpdate() { _callCount++; }
            /// <summary>
            /// Ons the after update
            /// </summary>
            public void OnAfterUpdate() { _callCount++; }
            /// <summary>
            /// Ons the process pending changes
            /// </summary>
            public void OnProcessPendingChanges() { _callCount++; }
            /// <summary>
            /// Ons the before fixed update
            /// </summary>
            public void OnBeforeFixedUpdate() { _callCount++; }
            /// <summary>
            /// Ons the fixed update
            /// </summary>
            public void OnFixedUpdate() { _callCount++; }
            /// <summary>
            /// Ons the after fixed update
            /// </summary>
            public void OnAfterFixedUpdate() { _callCount++; }
            /// <summary>
            /// Ons the dispatch events
            /// </summary>
            public void OnDispatchEvents() { _callCount++; }
            /// <summary>
            /// Ons the calculate
            /// </summary>
            public void OnCalculate() { _callCount++; }
            /// <summary>
            /// Ons the before draw
            /// </summary>
            public void OnBeforeDraw() { _callCount++; }
            /// <summary>
            /// Ons the draw
            /// </summary>
            public void OnDraw() { _callCount++; }
            /// <summary>
            /// Ons the after draw
            /// </summary>
            public void OnAfterDraw() { _callCount++; }
            /// <summary>
            /// Ons the gui
            /// </summary>
            public void OnGui() { _callCount++; }
            /// <summary>
            /// Ons the render present
            /// </summary>
            public void OnRenderPresent() { _callCount++; }
            /// <summary>
            /// Ons the disable
            /// </summary>
            public void OnDisable() { _callCount++; }
            /// <summary>
            /// Ons the reset
            /// </summary>
            public void OnReset() { _callCount++; }
            /// <summary>
            /// Ons the stop
            /// </summary>
            public void OnStop() { _callCount++; }
            /// <summary>
            /// Ons the exit
            /// </summary>
            public void OnExit() { _callCount++; }
            /// <summary>
            /// Ons the destroy
            /// </summary>
            public void OnDestroy() { _callCount++; }
            /// <summary>
            /// Ons the save
            /// </summary>
            public void OnSave() { _callCount++; }
            /// <summary>
            /// Ons the load
            /// </summary>
            public void OnLoad() { _callCount++; }
            /// <summary>
            /// Ons the save using the specified path
            /// </summary>
            /// <param name="path">The path</param>
            public void OnSave(string path) { _callCount++; }
            /// <summary>
            /// Ons the load using the specified path
            /// </summary>
            /// <param name="path">The path</param>
            public void OnLoad(string path) { _callCount++; }
            /// <summary>
            /// Gets the value of the all called
            /// </summary>
            public bool AllCalled => _callCount == ExpectedCalls;
        }
    }
}
