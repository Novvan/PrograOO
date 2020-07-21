using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.scripts
{
    public static class EnemySpawner
    {
        private static float _maxEnemies = GameManager.Instance.maxEnemies;
        private static float _wave = 0;
        private static List<Enemy> _enemies = GameManager.Instance.Enemies;
        private static Vector2 _enemySpawn;
        private static float _angle;
        private static Random rnd = GameManager.Instance.Random;


        private static void _SpawnEnemies()
        {
            if (_wave == 5)
            {
                _enemySpawn = new Vector2(rnd.Next(180, Program.Width-180), 200);
                _enemies.Add(EnemyFactory.Create(EnemyFactory.Enemies.boss, _enemySpawn, 0));
            }
            else
            {
                while (_enemies.Count <= _maxEnemies * _wave)
                {
                    int _randomSpawn = rnd.Next(1, 5);
                    switch (_randomSpawn)
                    {
                        case 1:
                            _enemySpawn = new Vector2(rnd.Next(1, Program.Width), 50); //arriba
                            _angle = 90;
                            break;
                        case 2:
                            _enemySpawn = new Vector2(Program.Width - 50, rnd.Next(1, Program.Height)); //derecha
                            _angle = 180;
                            break;
                        case 3:
                            _enemySpawn = new Vector2(rnd.Next(1, Program.Width), Program.Height - 50); //abajo
                            _angle = 270;
                            break;
                        case 4:
                            _enemySpawn = new Vector2(50, rnd.Next(1, Program.Height)); //izquierda
                            _angle = 0;
                            break;
                        default:
                            _enemySpawn = new Vector2(rnd.Next(1, Program.Width), Program.Height / 2); //por defecto derecha
                            _angle = 180;
                            break;
                    }
                    switch (rnd.Next(0, 3))
                    {
                        case 0:
                            _enemies.Add(EnemyFactory.Create(EnemyFactory.Enemies.tank, _enemySpawn, _angle));
                            break;
                        case 1:
                            _enemies.Add(EnemyFactory.Create(EnemyFactory.Enemies.regular, _enemySpawn, _angle));
                            break;
                        case 2:
                            _enemies.Add(EnemyFactory.Create(EnemyFactory.Enemies.larvae, _enemySpawn, _angle));
                            break;
                    }
                }
            }

        }

        public static void Spawn()
        {
            _wave = GameManager.Instance.wave;
            _SpawnEnemies();
        }
    }
}