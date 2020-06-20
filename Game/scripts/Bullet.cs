using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.scripts
{
    public class Bullet : GameObject
    {

        private string _texturePath = "textures/bullet.png";
        private float _speed = 200f;
        private float _scale;

        private Vector2 _position;
        private Vector2 _direction;
        private float _angle;

        public event Action<Bullet> OnDeactivate;



        public Bullet(Vector2 initialPosition, string texturePath, float angle, float scaleX, float scaleY, float speed) : base(initialPosition, texturePath, angle, scaleX, scaleY)
        {
            this._position = initialPosition;
            this._speed = speed;
            this._scale = scaleX;
            this._angle = angle;


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

            texture = Engine.GetTexture(_texturePath);
            GameManager.Instance.LevelWindow.Bullets.Add(this);
        }

        public override void Update()
        {
            _position.x += _direction.x * _speed * Time.DeltaTime;
            _position.y += _direction.y * _speed * Time.DeltaTime;

        }

        public void Reset()
        {
            GameManager.Instance.LevelWindow.GameObjects.Add(this);
        }
    }

}