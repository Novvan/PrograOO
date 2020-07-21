using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.scripts
{
    public class Bullet : GameObject, IPooleable<Bullet>
    {
        private float _speed = 0f;
        private Vector2 _direction;
        private LifeController _lifecontroller;
        public LifeController Lifecontroller => _lifecontroller;
        public event Action<Bullet> OnDeactivate;
        public float BulletDamage; 
        public Bullet()
        {
            transform = new Transform(new Vector2(), new Vector2(), 0);
            renderer = new Renderer(transform, "textures/assets/bullet.png");
            _lifecontroller = new LifeController(1);
        }

        public void Init(Vector2 initialPosition, string texturePath, float angle, Vector2 scale, float speed, float life, float damage)
        {
            _lifecontroller = new LifeController(life);
            BulletDamage = damage;
            transform.Position = initialPosition;
            this._speed = speed;
            transform.Size = scale;
            transform.Rotation = angle;
            

            switch (transform.Rotation)
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
            renderer = new Renderer(transform, texturePath);
            GameManager.Instance.LevelWindow.Bullets.Add(this);
            Engine.Debug(GameManager.Instance.LevelWindow.Bullets.Count());
            //GameManager.Instance.LevelWindow.GameObjects.Add(this);
        }

        public override void Update()
        {
            transform.Position = new Vector2(transform.Position.x + _direction.x * _speed * Time.DeltaTime, transform.Position.y);
            transform.Position = new Vector2(transform.Position.x, transform.Position.y + _direction.y * _speed * Time.DeltaTime);
            
            if (_lifecontroller.CurrentLife <= 0)
            {
                //Hacer eso que me dijiste del reciclado
                GameManager.Instance.LevelWindow.Bullets.Remove(this);
            }
            

        }

        public void Reset()
        {
            GameManager.Instance.LevelWindow.GameObjects.Add(this);
        }


        



    }

}