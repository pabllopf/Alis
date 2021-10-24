namespace Alis.Core
{
    public class SceneManager : SceneSystem
    {
        [System.Text.Json.Serialization.JsonConstructor]
        public SceneManager(Configuration configuration) : base(configuration)
        {
            Scenes = new Scene[100];
            ActiveScene = Scenes[0];
        }

        [System.Text.Json.Serialization.JsonPropertyName("_Scenes")]
        public Scene[] Scenes { get; private set; }

        [System.Text.Json.Serialization.JsonPropertyName("_ActiveScene")]
        public Scene ActiveScene { get; private set; }

        public override void Start() => ActiveScene?.Start();

        public override void Update() => ActiveScene?.Update();

        public void Add(Scene scene) 
        {
            Scenes[0] = scene;
            ActiveScene = Scenes[0];
        }

        public void ChangeScene(int index) => ActiveScene = Scenes[index];
    }
}