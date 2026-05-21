

using Alis.Core.Ecs.Systems.Configuration.Audio;
using Alis.Core.Ecs.Systems.Configuration.General;
using Alis.Core.Ecs.Systems.Configuration.Graphic;
using Alis.Core.Ecs.Systems.Configuration.Input;
using Alis.Core.Ecs.Systems.Configuration.Network;
using Alis.Core.Ecs.Systems.Configuration.Physic;

namespace Alis.Core.Ecs.Systems.Configuration
{
    /// <summary>
    ///     The setting class
    /// </summary>
    /// <seealso cref="ISetting" />
    public class Setting : ISetting
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Setting" /> class
        /// </summary>
        public Setting()
        {
            General = new GeneralSetting();
            Audio = new AudioSetting();
            Graphic = new GraphicSetting();
            Input = new InputSetting();
            Network = new NetworkSetting();
            Physic = new PhysicSetting();
        }

        /// <summary>
        /// </summary>
        /// <param name="general"></param>
        /// <param name="audio"></param>
        /// <param name="graphic"></param>
        /// <param name="input"></param>
        /// <param name="network"></param>
        /// <param name="physic"></param>
        public Setting(GeneralSetting general, AudioSetting audio, GraphicSetting graphic, InputSetting input, NetworkSetting network, PhysicSetting physic)
        {
            General = general;
            Audio = audio;
            Graphic = graphic;
            Input = input;
            Network = network;
            Physic = physic;
        }

        /// <summary>
        ///     Gets or sets the value of the general
        /// </summary>

        public GeneralSetting General { get; set; }

        /// <summary>
        ///     Gets or sets the value of the audio
        /// </summary>

        public AudioSetting Audio { get; set; }

        /// <summary>
        ///     Gets or sets the value of the graphic
        /// </summary>

        public GraphicSetting Graphic { get; set; }

        /// <summary>
        ///     Gets or sets the value of the input
        /// </summary>

        public InputSetting Input { get; set; }

        /// <summary>
        ///     Gets or sets the value of the network
        /// </summary>

        public NetworkSetting Network { get; set; }

        /// <summary>
        ///     Gets or sets the value of the physic
        /// </summary>

        public PhysicSetting Physic { get; set; }

        /// <summary>
        ///     Ons the load
        /// </summary>
        public void OnLoad()
        {
            General = GeneralSetting.OnLoad();

            /*
            string directory = Path.Combine(Environment.CurrentDirectory, "Data", "Setting");
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string fileGeneral = Path.Combine(directory, "General.json");
            if (File.Exists(fileGeneral))
            {
                General = JsonSerializer.Deserialize<GeneralSetting>(File.ReadAllText(fileGeneral), new JsonOptions
                {
                    DateTimeFormat = "yyyy-MM-dd HH:mm:ss",
                    SerializationOptions = JsonSerializationOptions.Default
                });
            }

            string fileAudio = Path.Combine(directory, "Audio.json");
            if (File.Exists(fileAudio))
            {
                Audio = JsonSerializer.Deserialize<AudioSetting>(File.ReadAllText(fileAudio), new JsonOptions
                {
                    DateTimeFormat = "yyyy-MM-dd HH:mm:ss",
                    SerializationOptions = JsonSerializationOptions.Default
                });
            }

            string fileGraphic = Path.Combine(directory, "Graphic.json");
            if (File.Exists(fileGraphic))
            {
                Graphic = JsonSerializer.Deserialize<GraphicSetting>(File.ReadAllText(fileGraphic), new JsonOptions
                {
                    DateTimeFormat = "yyyy-MM-dd HH:mm:ss",
                    SerializationOptions = JsonSerializationOptions.Default
                });
            }

            string fileInput = Path.Combine(directory, "Input.json");
            if (File.Exists(fileInput))
            {
                Input = JsonSerializer.Deserialize<InputSetting>(File.ReadAllText(fileInput), new JsonOptions
                {
                    DateTimeFormat = "yyyy-MM-dd HH:mm:ss",
                    SerializationOptions = JsonSerializationOptions.Default
                });
            }

            string fileNetwork = Path.Combine(directory, "Network.json");
            if (File.Exists(fileNetwork))
            {
                Network = JsonSerializer.Deserialize<NetworkSetting>(File.ReadAllText(fileNetwork), new JsonOptions
                {
                    DateTimeFormat = "yyyy-MM-dd HH:mm:ss",
                    SerializationOptions = JsonSerializationOptions.Default
                });
            }

            string filePhysic = Path.Combine(directory, "Physic.json");
            if (File.Exists(filePhysic))
            {
                Physic = JsonSerializer.Deserialize<PhysicSetting>(File.ReadAllText(filePhysic), new JsonOptions
                {
                    DateTimeFormat = "yyyy-MM-dd HH:mm:ss",
                    SerializationOptions = JsonSerializationOptions.Default
                });
            }*/
        }

        /// <summary>
        ///     Ons the save
        /// </summary>
        public void OnSave()
        {
            General.OnSave();

            /*
            string directory = Path.Combine(Environment.CurrentDirectory, "Data", "Setting");
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string fileGeneral = Path.Combine(directory, "General.json");
            File.WriteAllText(fileGeneral, JsonSerializer.Serialize(General, new JsonOptions
            {
                DateTimeFormat = "yyyy-MM-dd HH:mm:ss",
                SerializationOptions = JsonSerializationOptions.Default
            }));

            string fileAudio = Path.Combine(directory, "Audio.json");
            File.WriteAllText(fileAudio, JsonSerializer.Serialize(Audio, new JsonOptions
            {
                DateTimeFormat = "yyyy-MM-dd HH:mm:ss",
                SerializationOptions = JsonSerializationOptions.Default
            }));

            string fileGraphic = Path.Combine(directory, "Graphic.json");
            File.WriteAllText(fileGraphic, JsonSerializer.Serialize(Graphic, new JsonOptions
            {
                DateTimeFormat = "yyyy-MM-dd HH:mm:ss",
                SerializationOptions = JsonSerializationOptions.Default
            }));

            string fileInput = Path.Combine(directory, "Input.json");
            File.WriteAllText(fileInput, JsonSerializer.Serialize(Input, new JsonOptions
            {
                DateTimeFormat = "yyyy-MM-dd HH:mm:ss",
                SerializationOptions = JsonSerializationOptions.Default
            }));

            string fileNetwork = Path.Combine(directory, "Network.json");
            File.WriteAllText(fileNetwork, JsonSerializer.Serialize(Network, new JsonOptions
            {
                DateTimeFormat = "yyyy-MM-dd HH:mm:ss",
                SerializationOptions = JsonSerializationOptions.Default
            }));

            string filePhysic = Path.Combine(directory, "Physic.json");
            File.WriteAllText(filePhysic, JsonSerializer.Serialize(Physic, new JsonOptions
            {
                DateTimeFormat = "yyyy-MM-dd HH:mm:ss",
                SerializationOptions = JsonSerializationOptions.Default
            }));
            */
        }
    }
}