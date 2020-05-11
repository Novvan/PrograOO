using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Game.scripts
{
    public class GameManager
    {
        private Enemy[] _enemies;
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
        
        public Enemy[] Enemies => _enemies;

        public float Wave
        {
            get => _wave;
        }
        
        public void SpawnEnemies()
        {
            while (Enemies.Length <= _maxEnemies*_wave)
            {
                
            }
        }

        public void NewWave()
        {
            if (Enemies.Length == 0)
            {
                _wave++;
                SpawnEnemies();
            }
        }
    }
}