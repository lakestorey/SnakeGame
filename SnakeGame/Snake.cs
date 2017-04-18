using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Snake
    {
        public int x, y, size, speed;

        public Snake(int _x, int _y, int _size, int _speed)
        {
            x = _x;
            y = _y;
            size = _size;
            speed = _speed;
        }

        public void Move(int direction, int speed)
        {
            if (direction == 1)
            {
                y = y - speed;
            }
            if (direction == 2)
            {
                y = y + speed;
            }
            if (direction == 3)
            {
                x = x - speed;
            }
            if (direction == 4)
            {
                x = x + speed;
            }
        }
    }
}
