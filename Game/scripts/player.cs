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

        private IWeapon currentWeapon;
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

            transform.Position = initialPosition;
            _lifeController = new LifeController(100);
            this.speed = speed;
            //TODO: ver por que pija no andan las bullets
            _bulletPull = new PullGenerico<Bullet>();
        }

        public void MoveDown(Vector2 _position, float _speed)
        {
            transform.Position = new Vector2(transform.Position.x, transform.Position.y + _speed * Program.deltaTime);
            transform.Rotation = 90f;
            Engine.Debug("abajo");

        }
        public void MoveUp(Vector2 _position, float _speed)
        {
            transform.Position = new Vector2(transform.Position.x, transform.Position.y - _speed * Program.deltaTime);
            transform.Rotation = 270f;
            Engine.Debug("arriba");
        }
        public void MoveLeft(Vector2 _position, float _speed)
        {
            transform.Position = new Vector2(transform.Position.x - _speed * Program.deltaTime, transform.Position.y);
            transform.Rotation = 180f;
            Engine.Debug("izq");
        }
        public void MoveRight(Vector2 _position, float _speed)
        {
            transform.Position = new Vector2(transform.Position.x + _speed * Program.deltaTime, transform.Position.y);
            transform.Rotation = 0f;
            Engine.Debug("der");

        }


        public override void Update()
        {

            if (Engine.GetKey(Keys.D))
            {
                MoveRight(position, speed);
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
                Shoot(transform.Rotation);
            }

            if (!Engine.GetKey(Keys.P))
            {
                _pPressed = false;
            }
            
            if (Engine.GetKey(Keys.K)
                   && currentWeapon is object)
            {
                currentWeapon.StartAttack();
            }

        }

        public void AssignWeapon(IWeapon newWeapon)
        {
            currentWeapon = newWeapon;
        }



        //add _bpPoint

        public void Shoot(float angle)
        {
            Bullet bullet = _bulletPull.GetBullet(angle);
            bullet.Init(transform.Position, "textures/bullet.png", angle, new Vector2(1, 1), 100f);
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