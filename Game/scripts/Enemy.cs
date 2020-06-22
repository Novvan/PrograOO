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
        private float speed = 300f;
        private SpawnPoint spawnPoint;
        private int _index;
        private float _speed;
        private bool _isAlive;

        public LifeController LifeController
        {
            get => lifeController;
            set => lifeController = value;
        }

        public Enemy(Vector2 initialPosition, string texturePath, float angle, float scaleX, float scaleY, float speed, int index)
            : base(initialPosition, texturePath, angle, scaleX, scaleY)
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

    }
}