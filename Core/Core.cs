namespace Alis.Core
{
    using System;
    using SFML.Audio;
    using SFML.Graphics;
    using SFML.System;
    using SFML.Window;

    public class Core
    {
        public const int TargetFPS = 60;
        public const float TimeUntilUpdate = 1.0f / TargetFPS;

        public RenderWindow window;

        public RectangleShape shape;

        public void Start()
        {
            shape = new RectangleShape(new Vector2f(100, 100))
            {
                FillColor = Color.Black
            };

            var sound = new Sound(GenerateSineWave(frequency: 440.0, volume: .25, seconds: 1));

            window = new RenderWindow(new VideoMode(800, 600), "SFML running in .NET Core");
            window.Closed += (_, __) => window.Close();

            sound.Play();
        }

        public bool IsRunning()
        {
            return window.IsOpen;
        }

        public RenderWindow Run()
        {
            window.DispatchEvents();
            window.Clear(Color.White);
            window.Draw(shape);
            return window;
        }

        private void Window_KeyPressed(object sender, SFML.Window.KeyEventArgs e)
        {
            var window = (SFML.Window.Window)sender;
            if (e.Code == SFML.Window.Keyboard.Key.Escape)
            {
                window.Close();
            }
        }

        private static SoundBuffer GenerateSineWave(double frequency, double volume, int seconds)
        {
            uint sampleRate = 44100;
            var samples = new short[seconds * sampleRate];

            for (int i = 0; i < samples.Length; i++)
                samples[i] = (short)(Math.Sin(frequency * (2 * Math.PI) * i / sampleRate) * volume * short.MaxValue);

            return new SoundBuffer(samples, 1, sampleRate);
        }
    }
}