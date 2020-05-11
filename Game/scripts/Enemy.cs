using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.scripts
{
    public class Enemy
    {
        private float _enemX;
        private float _enemY;
        private float _enemAngle;
        private Texture _texture;
        private string _texturePath;
        private float _scale;
        private LifeController _lifeController;

        private float _width => _texture.Width * _scale;
        private float _height => _texture.Height * _scale;
        private float _offsetX => _width / 2;
        private float _offsetY => _height / 2;

        public LifeController EnemyLifeController
        {
            get => _lifeController;
            set => _lifeController = value;
        }

        public float EnemX
        {
            get => _enemX;
            set => _enemX = value;
        }

        public float EnemY
        {
            get => _enemY;
            set => _enemY = value;
        }
    }
}