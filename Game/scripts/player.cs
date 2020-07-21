using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.scripts
{
    public class Player : GameObject
    {
        private IWeapon currentWeapon;
        private float speed;
        private bool _pPressed;
        //private Vector2 _bPoint;
        private PullGenerico<Bullet> _bulletPull;
        private LifeController _lifeController;
        public LifeController LifeController => _lifeController;

        public bool Invencible { get => invencible; set => invencible = value; }
         
        private bool invencible;
        private float invencibleTimer;

        public Player(Vector2 initialPosition, string texturePath, float angle, Vector2 size, float speed, float life)
            : base(initialPosition, texturePath, angle, size)
        {
            _lifeController = new LifeController(life);
            transform.Position = initialPosition;
            this.speed = speed;
            _bulletPull = new PullGenerico<Bullet>();
        }

        public void MoveDown(Vector2 _position, float _speed)
        {
            transform.Position = new Vector2(transform.Position.x, transform.Position.y + _speed * Program.deltaTime);
            transform.Rotation = 90f;
            //Engine.Debug("abajo");

        }
        public void MoveUp(Vector2 _position, float _speed)
        {
            transform.Position = new Vector2(transform.Position.x, transform.Position.y - _speed * Program.deltaTime);
            transform.Rotation = 270f;
            //Engine.Debug("arriba");
        }
        public void MoveLeft(Vector2 _position, float _speed)
        {
            transform.Position = new Vector2(transform.Position.x - _speed * Program.deltaTime, transform.Position.y);
            transform.Rotation = 180f;
            //Engine.Debug("izq");
        }
        public void MoveRight(Vector2 _position, float _speed)
        {
            transform.Position = new Vector2(transform.Position.x + _speed * Program.deltaTime, transform.Position.y);
            transform.Rotation = 0f;
            //Engine.Debug("der");

        }


        public override void Update()
        {
            if (invencible) 
            {
                if (invencibleTimer >= 2f)
                {
                    invencible = false;
                    invencibleTimer = 0;
                }
                else 
                {
                    invencibleTimer += Time.DeltaTime;
                }
            }
            if (LifeController.CurrentLife <= 0) GameManager.Instance.currentState = State.Lose;

            if (Engine.GetKey(Keys.D))
            {
                MoveRight(transform.Position, speed);
            }

            if (Engine.GetKey(Keys.A))
            {
                MoveLeft(transform.Position, speed);

            }

            if (Engine.GetKey(Keys.S))
            {
                MoveDown(transform.Position, speed);

            }

            if (Engine.GetKey(Keys.W))
            {
                MoveUp(transform.Position, speed);

            }

            if (Engine.GetKey(Keys.Q))
            {
                _lifeController.GetDamage(1);
                //Engine.Debug(lifecontroller.CurrentLife);
            }

            if (Engine.GetKey(Keys.P) && !_pPressed)
            {
                _pPressed = true;
                Shoot(transform.Rotation);
                //Engine.Debug("Shot");
            }

            if (!Engine.GetKey(Keys.P))
            {
                _pPressed = false;
            }

            /*
            if (Engine.GetKey(Keys.K)
                   && currentWeapon is object)
            {
                currentWeapon.StartAttack();
            }
            */

        }

        public void AssignWeapon(IWeapon newWeapon)
        {
            currentWeapon = newWeapon;
        }



        //add _bpPoint

        public void Shoot(float angle)
        {
            Bullet bullet = _bulletPull.GetBullet(angle);
            bullet.Init(transform.Position, "textures/assets/bullet.png", angle, new Vector2(1, 1), 1500f, 1, 1);
        }
    }
}