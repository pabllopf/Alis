using System.Reflection;
using Alis.Core.Aspect.Data.Dll;
using Alis.Extension.Graphic.Ui.Properties;

namespace Alis.Extension.Graphic.Ui.Fonts
{
    /// <summary>
    /// The jet brains class
    /// </summary>
    public static class JetBrains
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JetBrains"/> class
        /// </summary>
        static JetBrains()
        {
            EmbeddedDllClass.ExtractEmbeddedDlls("jetbrains", DllType.File, FontResources.FontsJetBrainDllBytes, Assembly.GetExecutingAssembly(), "Assets");
        }

        /// <summary>
        /// The font icon file name far
        /// </summary>
        public static readonly string NameRegular = "JetBrainsMonoNL-Regular.ttf";

        /// <summary>
        /// The font icon file name far
        /// </summary>
        public static readonly string NameSolid = "JetBrainsMono-Bold.ttf";

        /// <summary>
        /// The font icon file name far
        /// </summary>
        public static readonly string NameLight = "JetBrainsMonoNL-Regular.ttf";
    }
}