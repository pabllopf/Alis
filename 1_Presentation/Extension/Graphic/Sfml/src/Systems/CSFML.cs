using System.Reflection;
using Alis.Core.Aspect.Data.Dll;

namespace Alis.Extension.Graphic.Sfml.Systems
{
    /// <summary>
    /// The csfml class
    /// </summary>
    public static class Csfml
    {
        static Csfml() 
        {
            EmbeddedDllClass.ExtractEmbeddedDlls("sfml", DllType.File, Properties.SfmlDlls.SfmlDllBytes, Assembly.GetAssembly(typeof(Properties.SfmlDlls)));
        }
        
        /// <summary>
        /// The audio
        /// </summary>
        public const string Audio = "csfml-audio";
        /// <summary>
        /// The graphics
        /// </summary>
        public const string Graphics = "csfml-graphics";
        /// <summary>
        /// The system
        /// </summary>
        public const string System = "csfml-system";
        /// <summary>
        /// The window
        /// </summary>
        public const string Window = "csfml-window";

    }
}
