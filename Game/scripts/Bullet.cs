using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.scripts
{
    public class Bullet
    {
        private Texture texture;
        private string texturePath = "textures/bullet.png";
        private float scale;
        private float speed = 200f;
        private float angle = 0f;
        private float radio;
        private Vector2 direction;
        private Vector2 position;

        public float Radio => radio;
        public float Width => texture.Width * scale;
        public float Height => texture.Height * scale;
        public float OffsetX => Width / 2f;
        public float OffsetY => Height / 2f;

        public Bullet(Vector2 initialPosition, Vector2 direction)
        {
            this.position = position;
            this.direction = direction;
            texture = Engine.GetTexture(texturePath);
        }
        public void Update()
        {
            position.x += direction.x * speed * Time.DeltaTime;
            position.y += direction.y * speed * Time.DeltaTime;
        }

        public void Render()
        {
            Engine.Draw(texture, position.x, position.y, scale, scale, angle, OffsetX, OffsetY);
        }

    }

}