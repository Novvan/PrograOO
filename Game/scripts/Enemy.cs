using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game.scripts
{
    public class Enemy : GameObject, IDamageable
    {
        private int hitPoints;
        public int HitPoints => hitPoints;

        public bool IsDestroyed { get; set; }

        public event Action<IDamageable> OnDestroy;
        private float x;
        private float y;
        private LifeController lifeController;
        private float speed = 100f;
        private SpawnPoint spawnPoint;
        private int _index;
        private float _speed;
        private bool _isAlive;
        private bool _horizMovement;
        private float _timer;



        public LifeController LifeController
        {
            get => lifeController;
            set => lifeController = value;
        }
        public Enemy(Vector2 initialPosition, string texturePath, float angle, Vector2 size, float speed,
            int index)
            : base(initialPosition, texturePath, angle, size)
        {
            position = initialPosition;
            _index = index;
            _speed = speed;
            lifeController = new LifeController(100);
        }
        public void AssignSpawnpoint(SpawnPoint newSpawnpoint)
        {
            spawnPoint = newSpawnpoint;
        }
        public override void Update()
        {

        }
        public void Destroy()
        {
            IsDestroyed = true;
            OnDestroy?.Invoke(this);
        }

        public void GetDamage(int damage)
        {
            hitPoints -= damage;
            if (hitPoints <= 0)
            {
                Destroy();
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

            /*if (_timer >= 0.5f)
            {
                if (Math.Abs(playerposition.y) > Math.Abs(playerposition.x))
                {
                    _horizMovement = false;
                }
                else
                {
                    _horizMovement = true;
                }

                _timer = 0f;
            }
            else
            {
                _timer += Time.DeltaTime;
            }

            if (_horizMovement)
            {    
                //Engine.Debug(direction.normalize().x);
                //Engine.Debug(direction.normalize().y);

                transform.Position = new Vector2(transform.Position.x + direction.normalize().x * _speed * Program.deltaTime, transform.Position.y);
            }
            else
            {
                transform.Position = new Vector2(transform.Position.x, transform.Position.y + direction.normalize().y * _speed * Program.deltaTime);
            }*/
        }

    }
}