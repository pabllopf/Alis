using Alis.Core.Ecs.Systems.Execution;
using Xunit;
using System.Linq;

namespace Alis.Test.Core.Ecs.Systems.Execution
{
    public class IRuntimeComplianceTest
    {
        [Fact]
        public void Interface_CanBeImplemented()
        {
            var runtime = new TestRuntime();
            Assert.IsAssignableFrom<IRuntime>(runtime);
        }

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

        private sealed class TestRuntime : IRuntime
        {
            private int _callCount;
            private const int ExpectedCalls = 28;

            public void OnEnable() { _callCount++; }
            public void OnInit() { _callCount++; }
            public void OnAwake() { _callCount++; }
            public void OnStart() { _callCount++; }
            public void OnPhysicUpdate() { _callCount++; }
            public void OnBeforeUpdate() { _callCount++; }
            public void OnUpdate() { _callCount++; }
            public void OnAfterUpdate() { _callCount++; }
            public void OnProcessPendingChanges() { _callCount++; }
            public void OnBeforeFixedUpdate() { _callCount++; }
            public void OnFixedUpdate() { _callCount++; }
            public void OnAfterFixedUpdate() { _callCount++; }
            public void OnDispatchEvents() { _callCount++; }
            public void OnCalculate() { _callCount++; }
            public void OnBeforeDraw() { _callCount++; }
            public void OnDraw() { _callCount++; }
            public void OnAfterDraw() { _callCount++; }
            public void OnGui() { _callCount++; }
            public void OnRenderPresent() { _callCount++; }
            public void OnDisable() { _callCount++; }
            public void OnReset() { _callCount++; }
            public void OnStop() { _callCount++; }
            public void OnExit() { _callCount++; }
            public void OnDestroy() { _callCount++; }
            public void OnSave() { _callCount++; }
            public void OnLoad() { _callCount++; }
            public void OnSave(string path) { _callCount++; }
            public void OnLoad(string path) { _callCount++; }
            public bool AllCalled => _callCount == ExpectedCalls;
        }
    }
}
