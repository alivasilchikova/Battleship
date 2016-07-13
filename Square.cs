using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Square
    {
        private float _x;
        private float _y;
        private bool _isShot;
        // стреляли ли?

        public float X
        {
            get { return _x; }
            set { _x = value; }
        }
        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public bool IsShot
        {
            get { return _isShot; }
            set { _isShot = value; }
        }

        public Square(float x, float y)
        { _x = x;
          _y = y;
          _isShot = false;
        }
        public Square()
        {
            _x = 0;
            _y = 0;
            _isShot = false;
        }

        public void AreFired()
        {
            IsShot = true;
        }
    }
}
