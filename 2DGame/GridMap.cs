using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;

namespace Game
{
    internal class GridMap : Drawable
    {
        private readonly Dictionary<(int, int), Chunk> chunks;

        public GridMap()
        {
            chunks = new Dictionary<(int, int), Chunk>();
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            foreach (var chunk in chunks.Values)
            {
                chunk.Draw(target, states);
            }
        }

        public void AddChunk(int x, int y)
        {
            chunks[(x, y)] = new Chunk(ChunkOffset(x, y));
        }

        private static Vector2f ChunkOffset(int x, int y)
        {
            return new Vector2f(x * Chunk.Size, y * Chunk.Size);
        }
    }
}
