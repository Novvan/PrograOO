using Game.scripts.Game.scripts;
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
        private GameObject _background;
        private GameObject _waveIndicator;
        private GameObject _healthbar;
        private List<Healthup> _heals;
        private List<Enemy> _enemies;
        private List<Bullet> _bullets;
        private List<GameObject> _gameObjects;
        public List<GameObject> GameObjects { get => _gameObjects; set => _gameObjects = value; }
        public List<Bullet> Bullets { get => _bullets; set => _bullets = value; }
        public List<Healthup> Heals { get => _heals; set => _heals = value; }
        public Level()
        {
            _gameObjects = new List<GameObject>();
            _bullets = new List<Bullet>();
            _heals = new List<Healthup>();
            _enemies = GameManager.Instance.Enemies;

            _spawnPoint = new Vector2(_width / 2, _height / 2);
            player = new Player(_spawnPoint, "textures/assets/Player/player.png", 0, new Vector2(0.5f, 0.5f), 200f, 3);
            _background = new GameObject(new Vector2(_width / 2, _height / 2), "textures/assets/bkg.png", 0, new Vector2(1, 1));
            _waveIndicator = new WaveIndicator(new Vector2(_width - 175, _height - 90), "textures/assets/wave1.png", 0, new Vector2(1, 1));
            _healthbar = new HealthIndicator(new Vector2(_width - 175, 90), "textures/assets/Healthbar/1heart.png", 0, new Vector2(0.35f, 0.35f));
            _gameObjects.Add(_background);
            _gameObjects.Add(player);
            _gameObjects.Add(_waveIndicator);
            _gameObjects.Add(_healthbar);
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

                if (_enemies.Count() != 0)
                {
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

            if (_gameObjects.Count > 0)
            {
                foreach (GameObject go in _gameObjects)
                {
                    go.Update();
                }
            }
            if (_enemies.Count > 0)
            {
                for (var i = 0; i < _enemies.Count; i++)
                {
                    if (!player.Invencible)
                    {
                        collisionDetectionPlayer(_enemies[i], 35, 35);
                    }

                    foreach (Bullet bl in _bullets)
                    {
                        collisionDetectionEnemyBullet(_enemies[i], 25, bl, 15);
                    }

                    if (_enemies.Count > 0)
                    {
                        _enemies[i].Update();
                        if (i != _enemies.Count)
                        {
                            _enemies[i].PlayerFollow(player.Position);
                        }
                    }
                }
            }
            if (_bullets.Count >= 0)
            {
                for (var x = _bullets.Count - 1; x >= 0; x--)
                {
                    _bullets[x].Update();
                }
            }

            if (_heals.Count >= 0)
            {
                for (var x = _heals.Count - 1; x >= 0; x--)
                {
                    CollisionPlayerHeal(_heals[x], 25, 35);
                    if (x != _heals.Count)
                    {

                        _heals[x].Update();
                    }
                }
            }
        }


        public void Render()
        {
            if (_gameObjects.Count > 0)
            {
                foreach (GameObject go in _gameObjects)
                {
                    go.Render();
                }

                if (_enemies.Count > 0)
                {
                    for (var x = _enemies.Count - 1; x >= 0; x--)
                    {
                        _enemies[x].Render();
                    }
                }

                if (_bullets.Count >= 0)
                {
                    for (var x = _bullets.Count - 1; x >= 0; x--)
                    {
                        _bullets[x].Render();
                    }
                }

                if (_heals.Count >= 0)
                {
                    for (var x = _heals.Count - 1; x >= 0; x--)
                    {
                        _heals[x].Render();
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
        public void CollisionPlayerHeal(Healthup healthbuff, float diamup, float diamplayer)
        {
            Vector2 distance = new Vector2(healthbuff.Position.x - player.Position.x, healthbuff.Position.y - player.Position.y);

            bool _flag = distance.magnitude() <= diamup + diamplayer;
            if (_flag)
            {
                healthbuff.OnOverlap(player);
                Engine.Debug(player.LifeController.CurrentLife);
            }
        }


    }


}


