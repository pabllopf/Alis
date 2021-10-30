namespace Alis.Core
{
    using Core.Systems;

    public class SceneManager : SceneSystem
    {
        [global::System.Text.Json.Serialization.JsonConstructorAttribute]
        public SceneManager() : base()
        {
            Scenes = new Scene[100];
            ActiveScene = Scenes[0];
        }

        [global::System.Text.Json.Serialization.JsonPropertyNameAttribute("_Scenes")]
        public Scene[] Scenes { get; private set; }

        [global::System.Text.Json.Serialization.JsonPropertyNameAttribute("_ActiveScene")]
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