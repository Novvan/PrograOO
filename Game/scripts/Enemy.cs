using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.scripts
{
    public class Enemy : GameObject
    {
        private float x;
        private float y;
        private LifeController lifeController;
        private float speed = 300f;
        private SpawnPoint spawnPoint;
        private bool _isAlive;
        public LifeController LifeController
        {
            get => lifeController;
            set => lifeController = value;
        }

        public Enemy(Vector2 initialPosition, string texturePath, float angle, float scaleX, float scaleY, float speed)
            : base(initialPosition, texturePath, angle, scaleX, scaleY)
        {
            position = initialPosition;

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
                _isAlive = false;
            }
        }
        public override void Render()
        {
            base.Render();
        }
    }
}