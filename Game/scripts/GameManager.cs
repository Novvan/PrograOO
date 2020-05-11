using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Game.scripts
{
    public class GameManager
    {
        private List<Enemy> _enemies = new List<Enemy>();
        private static GameManager _instance;
        private float _gameModifier;
        private float _wave = 0;
        private float _maxEnemies = 5f;

        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameManager();
                }

                return _instance;
            }
        }

        public float GameModifier
        {
            get => _gameModifier;
            set => _gameModifier = value;
        }

        public float Wave
        {
            get => _wave;
        }

        public void SpawnEnemies()
        {
            while (_enemies.Count <= _maxEnemies * _wave)
            {
                Random rnd = new Random();
                int _randomY = rnd.Next(0, 900);
                int _randomX = rnd.Next(0, 1600);
                float _scale = 0.5f;
                Vector2 position = new Vector2(_randomX, _randomY);
                
                for (int i = 0; i <= _maxEnemies*_wave; i++ )
                {
                    _enemies.Add(Enemy(position,"Game/textures/assets/Zombie Normal/attack01_0019.png",0,_scale,_scale,100));
                }
            }
        }

        public void NewWave()
        {
            if (_enemies.Count == 0)
            {
                _wave++;
                SpawnEnemies();
            }
        }
    }
}