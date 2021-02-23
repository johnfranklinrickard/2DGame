using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace Game
{
    internal static class Program
    {
        public static void Main()
        {
            var mode = new VideoMode(1280, 960);
            var window = new RenderWindow(mode, "SFML works!", Styles.Close);
            window.KeyPressed += OnKeyPress;
            window.Closed += (_, _) => window.Close();
            window.SetFramerateLimit(60);

            var circle = new CircleShape(100f)
            {
                FillColor = Color.Green
            };

            var music = new Music(@"..\..\..\music\First Quarter.ogg");
            music.Play();

            Console.WriteLine();

            var clock = new Clock();

            while (window.IsOpen)
            {
                window.DispatchEvents();
                var dispatchTime = clock.ElapsedTime;

                window.Clear(Color.White);
                window.Draw(circle);
                var drawTime = clock.ElapsedTime - dispatchTime;

                window.Display();


                var end = clock.ElapsedTime;
                Console.WriteLine($"Dispatch: {dispatchTime.AsMicroseconds()}us  " +
                    $"Draw: {drawTime.AsMicroseconds()}us  Total: {end.AsMicroseconds()}us");

                clock.Restart();
            }
        }

        private static void OnKeyPress(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.Escape)
            {
                var window = (Window)sender;
                window.Close();
            }
        }
    }
}
