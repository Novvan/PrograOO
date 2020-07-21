using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game.scripts
{
    public class Enemy : GameObject
    {
        private int _index;
        private float _speed;
        private LifeController _lifecontroller;
        public LifeController LifeController => _lifecontroller;
        //private bool _horizMovement;
        //private float _timer;

        public Enemy(Vector2 initialPosition, string texturePath, float angle, Vector2 size, float speed, float life)
            : base(initialPosition, texturePath, angle, size)
        {
            _lifecontroller = new LifeController(life);
            transform.Position = initialPosition;
            _index = GameManager.Instance.Enemies.Count ;
            _speed = speed;
        }

        public override void Update()
        {

            if (_lifecontroller.CurrentLife <= 0)
            {
                GameManager.Instance.LevelWindow.Heals.Add(new Healthup(transform.Position));
                GameManager.Instance.Enemies.Remove(this);
            }

        }

        public void PlayerFollow(Vector2 playerposition)
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
    }
}