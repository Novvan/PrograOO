using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.scripts
{
    public class Renderer
    {
        protected Transform transform;
        protected string texturePath;
        protected Vector2 offset;
        protected Vector2 size;
        protected Texture texture;

        public Renderer(Transform _transform, string _texturePath)
        {
            transform = _transform;
            texturePath = _texturePath;
            size = _transform.Size;
            texture = new Texture(texturePath);
            offset = new Vector2(texture.Width / 2, texture.Height / 2);
        }

        public void Render(Transform transform)
        {
            Engine.Draw(texture, transform.Position.x, transform.Position.y, size.x, size.y, transform.Rotation, offset.x, offset.y);
        }
    }
}
