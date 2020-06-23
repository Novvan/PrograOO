using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.scripts
{
    public static class EnemyFactory
    {
        private static float _maxEnemies = GameManager.Instance.maxEnemies;
        private static float _wave = 0;
        private static int _enemyIndex;
        private static List<Enemy> _enemies = GameManager.Instance.Enemies;
        private static Vector2 _enemySpawn;
        private static float _angle;
        private static Enemy _newEnemy;
        private static string _zombie ="textures/assets/Zombie Normal/zombie_normal.png";
        private static string _tankZombie = "textures/assets/Zombie Tanque/skeleton-attack_0.png";
        private static string _lightZombie = "textures/assets/Zombie Light/attack01_0019.png";
        private static string _selectedEnemy;


        private static void _SpawnEnemies()
        {
            Random rnd = new Random();
            float _scale = 0.5f;

            while (_enemies.Count <= _maxEnemies * _wave)
            {
                switch (rnd.Next(0,3))
                {
                    case 0:
                        _selectedEnemy = _tankZombie;
                        
                        break;
                    case 1:
                        _selectedEnemy = _zombie;
                        
                        break;
                    case 2:
                        _selectedEnemy = _lightZombie;
                        
                        break;
                    default:
                        _selectedEnemy = _tankZombie;
                        break;

                }
                _enemyIndex++;
                int _randomSpawn = rnd.Next(1, 5);
                switch (_randomSpawn)
                {
                    case 1:
                        _enemySpawn = new Vector2(rnd.Next(1, Program.Width), 50);//arriba
                        _angle = 90;
                        break;
                    case 2:
                        _enemySpawn = new Vector2(Program.Width - 50, rnd.Next(1, Program.Height));//derecha
                        _angle = 180;
                        break;
                    case 3:
                        _enemySpawn = new Vector2(rnd.Next(1, Program.Width), Program.Height - 50);//abajo
                        _angle = 270;
                        break;
                    case 4:
                        _enemySpawn = new Vector2(50, rnd.Next(1, Program.Height));//izquierda
                        _angle = 0;
                        break;
                    default:
                        _enemySpawn = new Vector2(rnd.Next(1, Program.Width), Program.Height / 2);//por defecto derecha
                        _angle = 180;
                        break;
                }


                _newEnemy = new Enemy(_enemySpawn, _selectedEnemy, _angle, new Vector2(_scale,_scale), 100, _enemyIndex);
                _enemies.Add(_newEnemy);
                Engine.Debug("Added Enemy");
            }
        }
        public static void Spawn()  
        {
          _wave = GameManager.Instance.wave;
          _SpawnEnemies();
        }

    }


}

