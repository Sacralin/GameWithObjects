using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWithObjects
{
    internal class GameObject
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public string Sprite { get; private set; }

        public GameObject(int x, int y, string sprite)
        {
            X = x;
            Y = y;
            Sprite = sprite;
        }

        public void Move(int dx, int dy, int maxX, int maxY)
        {
            int newX = X + dx;
            int newY = Y + dy;

            if (newX >= 0 && newX < maxX)
            {
                X = newX;
            }
            if (newY >= 0 && newY < maxY)
            {
                Y = newY;
            }
        }

        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(Sprite);
        }

    }
}
