

using Alis.App.Hub.Core;

namespace Alis.App.Hub.Windows.Sections
{
    /// <summary>
    ///     The section class
    /// </summary>
    /// <seealso cref="IRuntime" />
    public abstract class ASection : IRuntime
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ASection" /> class
        /// </summary>
        /// <param name="spaceWork">The space work</param>
        public ASection(SpaceWork spaceWork) => SpaceWork = spaceWork;

        /// <summary>
        ///     Gets or sets the value of the space work
        /// </summary>
        public SpaceWork SpaceWork { get; set; }

        /// <summary>
        ///     Gets or sets the value of the title
        /// </summary>
        public string Title { get; set; } = "Window";

        /// <summary>
        ///     Gets or sets the value of the is open
        /// </summary>
        public bool IsOpen { get; set; }

        /// <summary>
        ///     Gets or sets the value of the is focused
        /// </summary>
        public bool IsFocused { get; set; }

        /// <summary>
        ///     Ons the init
        /// </summary>
        public abstract void OnInit();

        /// <summary>
        ///     Ons the start
        /// </summary>
        public abstract void OnStart();

        /// <summary>
        ///     Ons the update
        /// </summary>
        public abstract void OnUpdate();

        /// <summary>
        ///     Ons the render
        /// </summary>
        public abstract void OnRender(float scaleFactor);

        /// <summary>
        ///     Ons the destroy
        /// </summary>
        public abstract void OnDestroy();
    }
}