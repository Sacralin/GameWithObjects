using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
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

        public virtual void Move(int dx, int dy, int maxX, int maxY)
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

        public virtual void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(Sprite);
        }

    }

    class Enemy : GameObject
    {
        public int Speed { get; private set; }
        private int frameCounter;

        public Enemy(int x, int y, string sprite, int speed) : base(x,y,sprite)
        {
            Speed = speed;
            frameCounter = 0;
        }


        public void Update(GameObject target, int maxX, int maxY)
        {
            frameCounter++;
            if (frameCounter % Speed == 0) // % looks at the decimal number.
            {
                int dx = target.X > X ? 1 : target.X < X ? -1 : 0;
                int dy = target.Y > Y ? 1 : target.Y < Y ? -1 : 0;
                Move(dx, dy, maxX, maxY);
                frameCounter = 0;
            }
        }
        public override void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(Sprite);
            Console.ResetColor();
        }

    }

    class Player : GameObject
    {
        public int HP { get; private set; }
        public Player(int x, int y, string sprite, int hp) : base( x , y , sprite)
        {
            HP = hp;
        } 

        public void CheckCollisionWith(GameObject other)
        {
            if(X == other.X && Y == other.Y)
            {

                HP -= 1;
            }
        }

        public override void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(Sprite);
            Console.ResetColor();
        }

    }

    class Coin : GameObject
    {
        public Coin(int x, int y, string sprite) : base(x, y, sprite)
        {

        }

        public override void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(Sprite);
            Console.ResetColor();
        }


    }

}
