

namespace Alis.Core.Ecs.Systems.Execution
{
    /// <summary>
    ///     The runtime interface
    /// </summary>
    public interface IRuntime
    {
        /// <summary>
        ///     Ons the enable
        /// </summary>
        void OnEnable();

        /// <summary>
        ///     Inits this instance
        /// </summary>
        void OnInit();

        /// <summary>
        ///     Awakes this instance
        /// </summary>
        void OnAwake();

        /// <summary>
        ///     Starts this instance
        /// </summary>
        void OnStart();

        /// <summary>
        ///     Ons the physic update
        /// </summary>
        void OnPhysicUpdate();

        /// <summary>
        ///     Before run the update
        /// </summary>
        void OnBeforeUpdate();

        /// <summary>
        ///     Updates this instance
        /// </summary>
        void OnUpdate();

        /// <summary>
        ///     Afters the update
        /// </summary>
        void OnAfterUpdate();

        /// <summary>
        ///     Ons the process pending changes
        /// </summary>
        void OnProcessPendingChanges();

        /// <summary>
        ///     Ons the before fixed update
        /// </summary>
        void OnBeforeFixedUpdate();

        /// <summary>
        ///     Update every frame.
        /// </summary>
        void OnFixedUpdate();

        /// <summary>
        ///     Ons the after fixed update
        /// </summary>
        void OnAfterFixedUpdate();

        /// <summary>
        ///     Dispatches the events
        /// </summary>
        void OnDispatchEvents();

        /// <summary>
        ///     Ons the calculate
        /// </summary>
        void OnCalculate();

        /// <summary>
        ///     Ons the before draw
        /// </summary>
        void OnBeforeDraw();

        /// <summary>
        ///     Draws this instance
        /// </summary>
        void OnDraw();

        /// <summary>
        ///     Ons the after draw
        /// </summary>
        void OnAfterDraw();

        /// <summary>
        ///     Ons the gui
        /// </summary>
        void OnGui();

        /// <summary>
        ///     Ons the render present
        /// </summary>
        void OnRenderPresent();

        /// <summary>
        ///     Ons the disable
        /// </summary>
        void OnDisable();

        /// <summary>
        ///     Resets this instance
        /// </summary>
        void OnReset();

        /// <summary>
        ///     Stops this instance
        /// </summary>
        void OnStop();

        /// <summary>
        ///     Exits this instance
        /// </summary>
        void OnExit();

        /// <summary>
        ///     Ons the destroy
        /// </summary>
        void OnDestroy();

        /// <summary>
        ///     Ons the save
        /// </summary>
        void OnSave();

        /// <summary>
        ///     Ons the load
        /// </summary>
        void OnLoad();

        /// <summary>
        ///     Ons the save using the specified path
        /// </summary>
        /// <param name="path">The path</param>
        void OnSave(string path);

        /// <summary>
        ///     Ons the load using the specified path
        /// </summary>
        /// <param name="path">The path</param>
        void OnLoad(string path);
    }
}