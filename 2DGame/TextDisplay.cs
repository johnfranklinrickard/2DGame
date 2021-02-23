using Game.Properties;
using SFML.Graphics;
using SFML.System;

namespace Game
{
    internal class TextDisplay : Drawable
    {
        public bool Visible { get; set; }

        private readonly Font font;
        private readonly Text text;

        public TextDisplay()
        {
            Visible = true;
            font = new Font(Resources.Manrope_Regular);
            text = new Text
            {
                Font = font,
                FillColor = Color.Red,
                OutlineColor = Color.Black,
                OutlineThickness = 1f,
                CharacterSize = 22
            };
            text.DisplayedString = "Hello there!";
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            if (!Visible)
                return;

            var oldView = new View(target.GetView());
            var view = target.DefaultView;
            target.SetView(view);
            text.Position = target.MapPixelToCoords(new Vector2i(20, 20));
            text.Draw(target, states);
            target.SetView(oldView);
        }
    }
}
