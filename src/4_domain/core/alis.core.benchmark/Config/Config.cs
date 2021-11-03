//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Config.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using System.Diagnostics.CodeAnalysis;
    using System.Numerics;
    using Newtonsoft.Json;
    
    /// <summary>Define the config of videogame</summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class Config 
    {
        /// <summary>The name</summary>
        [NotNull]      
        private string name;

        /// <summary>The author</summary>
        [NotNull]
        private string author;

        /// <summary>
        /// The debug
        /// </summary>
        [NotNull]
        private bool debug;

        /// <summary>The time manager</summary>
        [NotNull]
        private Time time;

        /// <summary>The window</summary>
        [NotNull]
        private WindowManager window;

        /// <summary>Initializes a new instance of the <see cref="Config" /> class.</summary>
        /// <param name="name">The name.</param>
        public Config([NotNull] string name)
        {
            this.name = name;
            author = "Alis Framework";
            time = new Time(0.01f, 1.00f, 120.0f, false);
            window = new WindowManager(WindowState.Normal, new Vector2(1024, 640));
            Logger.Info();
        }

        /// <summary>Initializes a new instance of the <see cref="Config" /> class.</summary>
        /// <param name="name">The name.</param>
        /// <param name="time">The time.</param>
        public Config([NotNull] string name, [NotNull] Time time)
        {
            this.name = name;
            author = "Alis Framework";
            this.time = time;
            window = new WindowManager(WindowState.Normal, new Vector2(1024, 640));
            Logger.Info();
        }

        /// <summary>Initializes a new instance of the <see cref="Config" /> class.</summary>
        /// <param name="name">The name.</param>
        /// <param name="timeManager">The time manager.</param>
        public Config([NotNull] string name, [NotNull] Time time, [NotNull] WindowManager window)
        {
            this.name = name;
            author = "Alis Framework";
            this.time = time;
            this.window = window;
            Logger.Info();
        }

        /// <summary>Initializes a new instance of the <see cref="Config" /> class.</summary>
        /// <param name="name">The name.</param>
        /// <param name="timeManager">The time manager.</param>
        [JsonConstructor]
        public Config([NotNull] string name, [NotNull] string author, [NotNull] Time time, [NotNull] WindowManager window, bool debug)
        {
            this.author = author;
            this.name = name;
            this.time = time;
            this.window = window;
            this.debug = debug;
            Logger.Info();
        }

        /// <summary>Gets the name.</summary>
        /// <value>The name.</value>
        [NotNull]
        [JsonProperty("_Name")]
        public string Name { get => name; set => name = value; }

        /// <summary>Gets or sets the author.</summary>
        /// <value>The author.</value>
        [NotNull]
        [JsonProperty("_Author")]
        public string Author { get => author; set => author = value; }

        /// <summary>Gets the time manager.</summary>
        /// <value>The time manager.</value>
        [NotNull]
        [JsonProperty("_Time")]
        public Time Time { get => time; set => time = value; }

        /// <summary>Gets or sets the window.</summary>
        /// <value>The window.</value>
        [NotNull]
        [JsonProperty("_Window")]
        public WindowManager Window { get => window; set => window = value; }

        /// <summary>
        /// Gets or sets the value of the debug
        /// </summary>
        [NotNull]
        [JsonProperty("_Debug")]
        public bool Debug { get => debug; set => debug = value; }

        /// <summary>The builder</summary>
        public static ConfigBuilder Builder() => new ConfigBuilder();

        /// <summary> Scene Manager Builder</summary>
        public class ConfigBuilder
        {
            /// <summary>The current</summary>
            [AllowNull]
            private  ConfigBuilder current;

            /// <summary>The author</summary>
            [AllowNull]
            private string author;

            /// <summary>The name</summary>
            [AllowNull]
            private string name;

            /// <summary>
            /// The debug
            /// </summary>
            [AllowNull]
            private bool debug = false;

            /// <summary>The time</summary>
            [AllowNull]
            private Time time;

            /// <summary>The window</summary>
            [AllowNull]
            private WindowManager window;

            /// <summary>Initializes a new instance of the <see cref="VideoGameBuilder" /> class.</summary>
            public ConfigBuilder() => current ??= this;

            /// <summary>Names the specified name.</summary>
            /// <param name="name">The name.</param>
            /// <returns>Return the builder</returns>
            public ConfigBuilder Name(string name)
            {
                current.name = name;
                return current;
            }

            /// <summary>Authors the specified author.</summary>
            /// <param name="author">The author.</param>
            /// <returns>Return the builder</returns>
            public ConfigBuilder Author(string author)
            {
                current.author = author;
                return current;
            }

            /// <summary>Debugs the specified debug.</summary>
            /// <param name="debug">if set to <c>true</c> [debug].</param>
            /// <returns>Return the builder</returns>
            public ConfigBuilder Debug(bool debug)
            {
                current.debug = debug;
                return current;
            }

            /// <summary>Times the specified time.</summary>
            /// <param name="time">The time.</param>
            /// <returns>Return the builder</returns>
            public ConfigBuilder Time(Time time)
            {
                current.time = time;
                return current;
            }

            /// <summary>Windows the specified window.</summary>
            /// <param name="window">The window.</param>
            /// <returns>Return the builder</returns>
            public ConfigBuilder Window(WindowManager window)
            {
                current.window = window;
                return current;
            }

            /// <summary>Builds this instance.</summary>
            /// <returns>Build the scene manager</returns>
            public Config Build()
            {
                current.author ??= "Alis Framework";
                current.time ??= new Time(0.01f, 1.00f, 60.0f, false);
                current.name ??= "Default";
                current.window ??= new WindowManager(WindowState.Normal, new Vector2(1024, 640));

                return new Config(current.name, current.author, current.time, current.window, current.debug);
            }
        }
    }
}