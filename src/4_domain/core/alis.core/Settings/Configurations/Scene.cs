using System.Text.Json.Serialization;
using Alis.FluentApi.Validations;

namespace Alis.Core.Settings.Configurations
{
    public class Scene
    {
        #region Reset()

        public void Reset()
        {
            MaxScenesOfGame = 16;
            MaxGameObjectByScene = 1024;
        }

        #endregion

        #region Constructor

        public Scene()
        {
            MaxScenesOfGame = 16;
            MaxGameObjectByScene = 1024;
        }

        [JsonConstructor]
        public Scene(NotNull<int> maxScenesOfGame, NotNull<int> maxGameObjectByScene)
        {
            MaxScenesOfGame = maxScenesOfGame.Value;
            MaxGameObjectByScene = maxGameObjectByScene.Value;
        }

        #endregion

        #region Properties

        [JsonPropertyName("_MaxScenesOfGame")] public int MaxScenesOfGame { get; set; } = 16;

        [JsonPropertyName("_MaxGameObjectByScene")]
        public int MaxGameObjectByScene { get; set; } = 1024;

        #endregion
    }
}