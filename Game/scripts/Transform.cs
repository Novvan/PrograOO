using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.scripts
{
    public class Transform
    {
        private Vector2 _position;

        public Vector2 Position
        {
            get => _position;
            set => _position = value;
        }

        private Vector2 _size;

        public Vector2 Size
        {
            get => _size;
            set => _size = value;
        }

        private float _rotation;

        public float Rotation
        {
            get => _rotation;
            set => _rotation = value;
        }

        public Transform(Vector2 _position, Vector2 _size, float _rotation)
        {
            this._position = _position;
            this._size = _size;
            this._rotation = _rotation;
        }
    }
}
