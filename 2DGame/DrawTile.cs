using SFML.Graphics;

namespace Game
{
    internal class DrawTile : Drawable
    {
        public static readonly uint Size = 100;

        private readonly Drawable content;

        public DrawTile(Drawable content)
        {
            this.content = content;
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            content.Draw(target, states);
        }
    }
}
