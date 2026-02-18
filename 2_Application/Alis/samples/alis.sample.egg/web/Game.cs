using Alis.Core.Ecs.Systems;

namespace Alis.Sample.Egg.Web
{
    /// <summary>
    /// The game class
    /// </summary>
    public static class Game
    {
        /// <summary>
        /// Creates
        /// </summary>
        /// <returns>The video game</returns>
        public static VideoGame Create()
        {
             return VideoGame.Create().Build();
        }
    }
}
