using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game.scripts
{
    public class Enemy : GameObject
    {
        private bool _isBoss;
        private float _speed;
        private LifeController _lifecontroller;
        public LifeController LifeController => _lifecontroller;

        public Enemy(Vector2 initialPosition, string texturePath, float angle, Vector2 size, float speed, float life, bool isboss)
            : base(initialPosition, texturePath, angle, size)
        {

            _lifecontroller = new LifeController(life);
            transform.Position = initialPosition;
            _speed = speed;
            _isBoss = isboss;
        }

        public override void Update()
        {

            if (_lifecontroller.CurrentLife <= 0)
            {
                switch (GameManager.Instance.Random.Next(1, 5))
                {
                    default:
                        break;
                    case 1:
                        //Crear ammo
                        break;
                    case 2:
                        GameManager.Instance.LevelWindow.Heals.Add(new Healthup(transform.Position));
                        break;
                }

                GameManager.Instance.Enemies.Remove(this);
            }

        }

        public void PlayerFollow(Vector2 playerposition)
        {
            if (!_isBoss)
            {
                Vector2 direction;
                direction = new Vector2(playerposition.x - transform.Position.x, playerposition.y - transform.Position.y);

                transform.Position = new Vector2(transform.Position.x + direction.normalize().x * Time.DeltaTime * _speed, transform.Position.y + direction.normalize().y * Time.DeltaTime * _speed);

                if (Math.Abs(direction.y) > Math.Abs(direction.x))
                {
                    if (direction.y > 0)
                    {
                        transform.Rotation = 90f;
                    }
                    else
                    {
                        transform.Rotation = 270f;
                    }
                }
                else
                {
                    if (direction.x > 0)
                    {
                        transform.Rotation = 0f;
                    }
                    else
                    {
                        transform.Rotation = 180f;
                    }
                }
            }
            else
            {
                Vector2 direction;
                direction = new Vector2(playerposition.x - transform.Position.x,0);
                transform.Position = new Vector2(transform.Position.x + direction.normalize().x * Time.DeltaTime * _speed, transform.Position.y);

            }
        }
    }
}