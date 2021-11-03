using System.Text.Json.Serialization;
using Alis.FluentApi.Validations;

namespace Alis.Core.Settings.Configurations
{
    /// <summary>
    /// The scene class
    /// </summary>
    public class Scene
    {
        #region Reset()

        /// <summary>
        /// Resets this instance
        /// </summary>
        public void Reset()
        {
            MaxScenesOfGame = 16;
            MaxGameObjectByScene = 1024;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Scene"/> class
        /// </summary>
        public Scene()
        {
            MaxScenesOfGame = 16;
            MaxGameObjectByScene = 1024;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Scene"/> class
        /// </summary>
        /// <param name="maxScenesOfGame">The max scenes of game</param>
        /// <param name="maxGameObjectByScene">The max game object by scene</param>
        [JsonConstructor]
        public Scene(NotNull<int> maxScenesOfGame, NotNull<int> maxGameObjectByScene)
        {
            MaxScenesOfGame = maxScenesOfGame.Value;
            MaxGameObjectByScene = maxGameObjectByScene.Value;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the value of the max scenes of game
        /// </summary>
        [JsonPropertyName("_MaxScenesOfGame")] public int MaxScenesOfGame { get; set; } = 16;

        /// <summary>
        /// Gets or sets the value of the max game object by scene
        /// </summary>
        [JsonPropertyName("_MaxGameObjectByScene")]
        public int MaxGameObjectByScene { get; set; } = 1024;

        #endregion
    }
}