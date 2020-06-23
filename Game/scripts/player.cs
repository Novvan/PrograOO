using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.scripts
{
    public class Player : GameObject, IDamageable
    {
        private int hitPoints;
        public int HitPoints => hitPoints;

        public bool IsDestroyed { get; set; }

        public event Action<IDamageable> OnDestroy;
        private LifeController _lifeController;
        private float speed;
        private SpawnPoint spawnPoint;
        private bool _pPressed;
        private Vector2 _bPoint;
        private PullGenerico<Bullet> _bulletPull;

        public LifeController LifeController
        {
            get => _lifeController;
            set => _lifeController = value;
        }

        public Player(Vector2 initialPosition, string texturePath, float angle, Vector2 size, float speed)
            : base(initialPosition, texturePath, angle, size)
        {
            _lifeController = new LifeController(100);
            this.speed = speed;
            //TODO: ver por que pija no andan las bullets
            //_bulletPull = new PullGenerico<Bullet>();
        }

        public void AssignSpawnpoint(SpawnPoint newSpawnpoint)
        {
            spawnPoint = newSpawnpoint;
        }
        public void MoveDown(Vector2 _position, float _speed)
        {
            position.y += _speed * Program.deltaTime;
            angle = 90f;
            Engine.Debug("abajo");

        }
        public void MoveUp(Vector2 _position, float _speed)
        {
            position.y -= _speed * Program.deltaTime;
            angle = 270f;
            Engine.Debug("arriba");
        }
        public void MoveLeft(Vector2 _position, float _speed)
        {
            position.x -= _speed * Program.deltaTime;
            angle = 180f;
            Engine.Debug("izq");
        }
        public void MoveRight(Vector2 _position, float _speed)
        {
            position.x = _position.x + _speed * Program.deltaTime;
            angle = 0f;
            Engine.Debug("der");

        }


        public override void Update()
        {

            if (Engine.GetKey(Keys.D))
            {
                MoveRight(position, speed);
                Engine.Debug(this.speed);

            }

            if (Engine.GetKey(Keys.A))
            {
                MoveLeft(position, speed);

            }

            if (Engine.GetKey(Keys.S))
            {
                MoveDown(position, speed);

            }

            if (Engine.GetKey(Keys.W))
            {
                MoveUp(position, speed);

            }

            if (Engine.GetKey(Keys.Q))
            {
                LifeController.GetDamage(100);
                Engine.Debug(LifeController.CurrentLife);
            }

            if (Engine.GetKey(Keys.P) && !_pPressed)
            {
                _pPressed = true;
                Engine.Debug("Shot");
                Shoot(angle);
            }

            if (!Engine.GetKey(Keys.P))
            {
                _pPressed = false;
            }

        }



        //add _bpPoint

        public void Shoot(float angle)
        {
            Bullet bullet = _bulletPull.GetBullet(angle);
            bullet.Init(position, "textures/bullet.png", angle, 1, 1, 200);
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
    }
}