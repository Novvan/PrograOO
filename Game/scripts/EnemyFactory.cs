using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.scripts
{
    public static class EnemyFactory
    {
        private static float _scale = 0.6f;
        private static string _zombie = "textures/assets/Zombie Normal/zombie_normal.png";
        private static string _tankZombie = "textures/assets/Zombie Tanque/skeleton-attack_0.png";
        private static string _Larvae = "textures/assets/Zombie Light/lightzombie.png";
        private static string _boss = "textures/assets/Boss/boss.png";


        public enum Enemies
        {
            larvae,
            regular,
            tank,
            boss
        }

        public static Enemy Create(Enemies _selectedEnemy, Vector2 _position, float _angle)
        {
            switch (_selectedEnemy)
            {
                case Enemies.larvae:
                    return new Enemy(_position, _Larvae, _angle, new Vector2(_scale, _scale), 100, 1, false);
                case Enemies.regular:
                    return new Enemy(_position, _zombie, _angle, new Vector2(_scale, _scale), 80, 2, false);
                case Enemies.tank:
                    return new Enemy(_position, _tankZombie, _angle, new Vector2(_scale, _scale), 40, 5, false);
                case Enemies.boss:
                    return new Enemy(_position, _boss, _angle, new Vector2(_scale, _scale), 100, 15, true);
            }
            return null; 
        }


    }
}
