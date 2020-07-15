using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        private Player _player;

        public LifeController LifeController
        {
            get => lifeController;
            set => lifeController = value;
        }
        public Enemy(Vector2 initialPosition, string texturePath, float angle, Vector2 size, float speed,
            int index, Player player)
            : base(initialPosition, texturePath, angle, size)
        {
            position = initialPosition;
            _index = index;
            _speed = speed;
            _player = player;
            lifeController = new LifeController(100);
        }
        public void AssignSpawnpoint(SpawnPoint newSpawnpoint)
        {
            spawnPoint = newSpawnpoint;
        }
        public override void Update()
        {
            PlayerFollow(_player.Position);

            if (lifeController.CurrentLife <= 0)
            {
                
            }
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

            if (Math.Abs(playerposition.y) - Math.Abs(playerposition.x) > 1)
            {
                _horizMovement = false;
            }

            if (Math.Abs(playerposition.x) - Math.Abs(playerposition.y) > 1)
            {
                _horizMovement = true;
            }

            if (!_horizMovement)
            {
                direction = new Vector2(playerposition.x - transform.Position.x, playerposition.y - transform.Position.y);
                
                
                Engine.Debug(direction.normalize().x);
                Engine.Debug(direction.normalize().y);

                //transform.Position = new Vector2(direction.normalize().x - _speed * Program.deltaTime, transform.Position.y);
            }
            else
            {
                //transform.Position = new Vector2(transform.Position.x, transform.Position.y + _speed * Program.deltaTime);
            }
        }

    }
}