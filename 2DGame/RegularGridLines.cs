using SFML.Graphics;
using SFML.System;

namespace Game
{
    internal class RegularGridLines : Drawable
    {
        private readonly VertexArray lines;

        public RegularGridLines(float lineWidth = 5f)
        {
            var lineColor = new Color(128, 128, 128, 64);

            const uint pixelsPerQuad = 4;
            uint linesPerDirection = Chunk.TileCountPerDirection + 1;
            uint verticesPerDirection = pixelsPerQuad * linesPerDirection;
            lines = new VertexArray(PrimitiveType.Quads, verticesPerDirection * 2);

            float halfWidth = lineWidth / 2f;
            float totalWidth = DrawTile.Size * Chunk.TileCountPerDirection;

            for (uint i = 0; i < linesPerDirection; i++)
            {
                uint index = i * pixelsPerQuad;
                float left = -halfWidth + i * DrawTile.Size;
                float right = left + lineWidth;

                lines[index + 0] = new Vertex(new Vector2f(left, 0f), lineColor);
                lines[index + 1] = new Vertex(new Vector2f(right, 0f), lineColor);
                lines[index + 2] = new Vertex(new Vector2f(right, totalWidth), lineColor);
                lines[index + 3] = new Vertex(new Vector2f(left, totalWidth), lineColor);
            }

            for (uint i = 0; i < linesPerDirection; i++)
            {
                uint index = i * pixelsPerQuad + verticesPerDirection;
                float up = -halfWidth + i * DrawTile.Size;
                float down = up + lineWidth;

                lines[index + 0] = new Vertex(new Vector2f(0f, up), lineColor);
                lines[index + 1] = new Vertex(new Vector2f(totalWidth, up), lineColor);
                lines[index + 2] = new Vertex(new Vector2f(totalWidth, down), lineColor);
                lines[index + 3] = new Vertex(new Vector2f(0f, down), lineColor);
            }
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            lines.Draw(target, states);
        }
    }
}
