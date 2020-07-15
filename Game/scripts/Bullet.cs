using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.scripts
{
    public class Bullet : GameObject, IPooleable<Bullet>
    {
        private float _speed = 200f;
        private Vector2 _scale;

        private Vector2 _position;
        private Vector2 _direction;
        private float _angle;

        public event Action<Bullet> OnDeactivate;

        public Bullet()
        {
            transform = new Transform(new Vector2(), new Vector2(), angle);
            renderer = new Renderer(transform, "textures/bullet.png");

        }

        public void Init(Vector2 initialPosition, string texturePath, float angle, Vector2 scale, float speed)
        {
            transform.Position = initialPosition;
            this._speed = speed;
            transform.Size = scale;
            transform.Rotation = angle;
            renderer.TexturePath = texturePath;

            switch (_angle)
            {
                case 0:
                    _direction.x = 1;
                    break;
                case 90:
                    _direction.y = 1;
                    break;
                case 180:
                    _direction.x = -1;
                    break;
                case 270:
                    _direction.y = -1;
                    break;
            }

            texture = Engine.GetTexture(texturePath);
            GameManager.Instance.LevelWindow.Bullets.Add(this);
            //GameManager.Instance.LevelWindow.GameObjects.Add(this);
        }

        public override void Update()
        {
            transform.Position = new Vector2(transform.Position.x + _direction.x * _speed * Time.DeltaTime, transform.Position.y);
            transform.Position = new Vector2(transform.Position.x, transform.Position.y + _direction.y * _speed * Time.DeltaTime);

        }

        public void Reset()
        {
            GameManager.Instance.LevelWindow.GameObjects.Add(this);
        }


    }

}