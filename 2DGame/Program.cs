using SFML.Audio;
using SFML.Graphics;
using SFML.Window;

namespace Game
{
    internal static class Program
    {
        public static void Main()
        {
            var mode = new VideoMode(1280, 960);
            var window = new RenderWindow(mode, "SFML works!");
            window.KeyPressed += OnKeyPress;

            var circle = new CircleShape(100f)
            {
                FillColor = Color.Green
            };

            var music = new Music(@"..\..\..\music\First Quarter.ogg");
            music.Play();

            while (window.IsOpen)
            {
                window.DispatchEvents();
                window.Clear(Color.White);
                window.Draw(circle);
                window.Display();
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
