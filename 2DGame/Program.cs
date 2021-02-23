﻿using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;

namespace Game
{
    internal static class Program
    {
        public static List<Drawable> shapes = new List<Drawable>();

        public static void Main()
        {
            var mode = new VideoMode(1280, 960);
            var window = new RenderWindow(mode, "SFML works!", Styles.Close);
            window.KeyPressed += OnKeyPress;
            window.MouseWheelScrolled += OnMouseScroll;
            window.MouseButtonPressed += OnMouseClick;
            window.Closed += (_, _) => window.Close();
            window.SetFramerateLimit(60);

            shapes.Add(new CircleShape(100f) { FillColor = Color.Green });

            var music = new Music(@"..\..\..\music\First Quarter.ogg");
            music.Play();

            Console.WriteLine();

            var clock = new Clock();

            while (window.IsOpen)
            {
                window.DispatchEvents();
                var dispatchTime = clock.ElapsedTime;

                window.Clear(Color.White);
                foreach (var shape in shapes)
                {
                    window.Draw(shape);
                }

                var drawTime = clock.ElapsedTime - dispatchTime;

                window.Display();

                var end = clock.ElapsedTime;
                Console.WriteLine($"Dispatch: {dispatchTime.AsMicroseconds()}us  " +
                    $"Draw: {drawTime.AsMicroseconds()}us  Total: {end.AsMicroseconds()}us");

                clock.Restart();
            }
        }

        private static void OnMouseClick(object sender, MouseButtonEventArgs e)
        {
            if (e.Button != Mouse.Button.Left)
                return;
            var window = sender as RenderWindow;
            var pixelPos = Mouse.GetPosition(window);
            var pos = window.MapPixelToCoords(pixelPos);
            const float radius = 10f;
            var circle = new CircleShape(radius)
            {
                FillColor = Color.Red,
                Origin = new Vector2f(radius, radius),
                Position = pos
            };
            shapes.Add(circle);
        }

        private static void OnMouseScroll(object sender, MouseWheelScrollEventArgs e)
        {
            if (e.Wheel != Mouse.Wheel.VerticalWheel)
                return;

            var window = sender as RenderWindow;
            var view = window.GetView();
            float factor = 1f + (0.1f * e.Delta);
            view.Zoom(factor);
            window.SetView(view);
        }

        private static void OnKeyPress(object sender, KeyEventArgs e)
        {
            var window = sender as RenderWindow;
            var view = window.GetView();
            switch (e.Code)
            {
                case Keyboard.Key.W:
                    view.Move(new Vector2f(0f, -1f));
                    window.SetView(view);
                    break;
                case Keyboard.Key.S:
                    view.Move(new Vector2f(0f, 1f));
                    window.SetView(view);
                    break;
                case Keyboard.Key.A:
                    view.Move(new Vector2f(-1f, 0f));
                    window.SetView(view);
                    break;
                case Keyboard.Key.D:
                    view.Move(new Vector2f(1f, 0f));
                    window.SetView(view);
                    break;
                case Keyboard.Key.Escape:
                    window.Close();
                    break;
                default:
                    Console.WriteLine($"Keypress {e.Code} not used yet.");
                    break;
            }
        }
    }
}
