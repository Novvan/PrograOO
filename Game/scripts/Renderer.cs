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
        private string texturePath;


        protected Vector2 offset;
        protected Vector2 size;
        protected Texture texture;

        public Vector2 Offset => offset;
        
        public string TexturePath { get => texturePath; set => texturePath = value; }
        public Texture Texture { get => texture; set => texture = value; }
        public Renderer(Transform _transform, string _texturePath)
        {
            transform = _transform;
            texturePath = _texturePath;
            size = _transform.Size;
            texture = Engine.GetTexture(texturePath);
         offset = new Vector2(texture.Width / 2 * size.x, texture.Height / 2 * size.y);
        }

        public void Render(Transform transform)
        {
            Engine.Draw(texture, transform.Position.x, transform.Position.y, size.x, size.y, transform.Rotation, offset.x, offset.y);
        }
    }
}
