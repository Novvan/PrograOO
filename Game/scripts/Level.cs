using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.scripts
{
    public class Level
    {
        private float _width = Program.Width;
        private float _height = Program.Height;
        public Player player;
        private Vector2 _spawnPoint;
        private bool _tPressed;
        private bool _uPressed;
        private bool _started = false;
        private GameObject background;
        private GameObject waveIndicator;
        private List<Enemy> Enemies;
        private List<Bullet> bullets;
        private List<GameObject> gameObjects;
        public List<GameObject> GameObjects { get => gameObjects; set => gameObjects = value; }
        public List<Bullet> Bullets { get => bullets; set => bullets = value; }

        public Level()
        {
            gameObjects = new List<GameObject>();
            bullets = new List<Bullet>();

            Enemies = GameManager.Instance.Enemies;
            _spawnPoint = new Vector2(_width / 2, _height / 2);
            player = new Player(_spawnPoint, "textures/assets/Player/player.png", 0, new Vector2(0.5f, 0.5f), 200f, 3);
            background = new GameObject(new Vector2(_width / 2, _height / 2), "textures/assets/bkg.png", 0, new Vector2(1, 1));
            waveIndicator = new WaveIndicator(new Vector2(_width - 175, _height - 90), "textures/assets/wave1.png", 0, new Vector2(1, 1));
            gameObjects.Add(background);
            gameObjects.Add(player);
            gameObjects.Add(waveIndicator);
        }


        public void Initialize()
        {

        }
        public void Update()
        {
            if (Engine.GetKey(Keys.T) && !_tPressed)
            {
                if (!_started)
                {
                    _tPressed = true;
                    //Engine.Debug("Spawn");
                    GameManager.Instance.NewWave();
                    _started = true;
                }
                Engine.Debug("Round has started");
            }

            if (!Engine.GetKey(Keys.T))
            {
                _tPressed = false;
            }

            if (Engine.GetKey(Keys.U) && !_uPressed)
            {
                _uPressed = true;

                if (Enemies.Count() != 0)
                {
                    //Engine.Debug("Enemy killed");
                    GameManager.Instance.KillEnemy();
                }
            }

            if (!Engine.GetKey(Keys.U))
            {
                _uPressed = false;
            }

            if (_started)
            {
                GameManager.Instance.CheckEnemies();
            }

            if (gameObjects.Count > 0)
            {
                foreach (GameObject go in gameObjects)
                {
                    go.Update();
                }
            }
            if (Enemies.Count > 0)
            {
                for (var i = 0; i < Enemies.Count; i++)
                {
                    if (!player.Invencible)
                    {
                        collisionDetectionPlayer(Enemies[i], 100, 100);
                    }
                    

                    foreach (Bullet bl in bullets)
                    {
                        collisionDetectionEnemyBullet(Enemies[i], 100, bl, 35);
                    }
                    if (Enemies.Count > 0)
                    {
                        Enemies[i].Update();
                        if (i != Enemies.Count)
                        {
                            Enemies[i].PlayerFollow(player.Position);
                        }
                    }
                }
            }
            if (bullets.Count >= 0)
            {
                for (var x = bullets.Count - 1; x >= 0; x--)
                {
                    bullets[x].Update();
                }
            }
        }


        public void Render()
        {
            if (gameObjects.Count > 0)
            {
                foreach (GameObject go in gameObjects)
                {
                    go.Render();
                }

                if (Enemies.Count > 0)
                {
                    for (var x = Enemies.Count - 1; x >= 0; x--)
                    {
                        Enemies[x].Render();
                    }
                }

                if (bullets.Count >= 0)
                {
                    for (var x = bullets.Count - 1; x >= 0; x--)
                    {
                        bullets[x].Render();
                    }
                }
            }
        }


        public void collisionDetectionEnemyBullet(Enemy enemy, float diamenemy, Bullet bullet, float diambullet)
        {
            Vector2 distance = new Vector2(enemy.Position.x - bullet.Position.x, enemy.Position.y - bullet.Position.y);

            bool _flag = distance.magnitude() <= diamenemy + diambullet;
            if (_flag)
            {
                enemy.LifeController.GetDamage(bullet.BulletDamage);
                bullet.Lifecontroller.GetDamage(1);
            }
        }

        public void collisionDetectionPlayer(Enemy enemy, float diamenemy, float diamplayer)
        {

            Vector2 distance = new Vector2(enemy.Position.x - player.Position.x, enemy.Position.y - player.Position.y);

            bool _flag = distance.magnitude() <= diamenemy + diamplayer;
            if (_flag)
            {

                Engine.Debug("COLISION");
                player.LifeController.GetDamage(2);
                player.Invencible = true;
            }
        }


    }


}


