using SFML.Graphics;
using SFML.System;
using System.Diagnostics;

namespace Game
{
    public class Chunk : Drawable
    {
        public static readonly uint TileCountPerDirection = 32;
        public static readonly uint Size = TileCountPerDirection * DrawTile.Size;

        private readonly DrawTile?[,] tiles;
        private readonly RegularGridLines gridLines;
        private readonly Vector2f offset;

        public Chunk(Vector2f position)
        {
            offset = position;
            tiles = new DrawTile[TileCountPerDirection, TileCountPerDirection];
            gridLines = new RegularGridLines();
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform.Translate(offset);

            gridLines.Draw(target, states);

            foreach (var tile in tiles)
            {
                tile?.Draw(target, states);
            }
        }

        public void AddTile(uint x, uint y)
        {
            var quad = new RectangleShape(new Vector2f(DrawTile.Size, DrawTile.Size))
            {
                Position = Offset(x, y),
                FillColor = Color.Blue
            };
            tiles[x, y] = new DrawTile(quad);
        }

        private static Vector2f Offset(uint x, uint y)
        {
            Debug.Assert(x < TileCountPerDirection && y < TileCountPerDirection);
            return new Vector2f(x * DrawTile.Size, y * DrawTile.Size);
        }
    }
}
