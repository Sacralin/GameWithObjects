namespace GameWithObjects
{
    internal class Program
    {
        static int playerX = 0;
        static int playerY = 0;
        static int enemyX = 0;
        static int enemyY = 0;


        static Random random = new Random();
        static bool isRunning = true;
        static DateTime lastUpdateTime = DateTime.Now;
        static double deltaTime;
        static double gameTimeElapsed;

        static int windowWidth = 40;
        static int windowHeight = 20;

        static bool enemyMoveToggle = false;

        static void Main(string[] args)
        {
            Console.BufferHeight = Console.WindowHeight * 2;
            Console.CursorVisible = false;

            PlacePlayer(0, 0);
            PlaceEnemy(10, 10);


            while (isRunning)
            {
                // Update the time
                DateTime currentTime = DateTime.Now;
                deltaTime = (currentTime - lastUpdateTime).TotalMilliseconds;
                lastUpdateTime = currentTime;
                gameTimeElapsed += deltaTime;
                Update();
                Draw();
                Thread.Sleep(100); // 100 milliseconds delay
            }
        }

        private static void PlaceEnemy(int x, int y)
        {
            enemyX = x;
            enemyY = y;
        }

        private static void PlacePlayer(int x, int y)
        {
            playerX = x;
            playerY = y;
        }

        static void Update()
        {
            // Handle input
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.Q:
                        isRunning = false;
                        break;
                    case ConsoleKey.UpArrow:
                        if (playerY > 0) playerY--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (playerY < windowHeight) playerY++;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (playerX > 0) playerX--;
                        break;
                    case ConsoleKey.RightArrow:
                        if (playerX < windowWidth) playerX++;
                        break;
                    default:
                        break;
                }
            }

            if (enemyMoveToggle)
            {
                if (enemyX < playerX && enemyX < windowWidth -1) enemyX++;
                else if (enemyX > playerX && enemyX > 0) enemyX--;

                if (enemyY < playerY && enemyX < windowHeight -1) enemyY++;
                else if (enemyY > playerY && enemyY > 0) enemyY--;
            }
            enemyMoveToggle = !enemyMoveToggle;
        }
        static void Draw()
        {
            Console.Clear();

            Console.SetCursorPosition(playerX,playerY);
            Console.Write("@");

            Console.SetCursorPosition(enemyX, enemyY);
            Console.Write("X");

            Console.SetCursorPosition(0, 21);
            Console.WriteLine($"Time elapsed (ms): {Math.Round(gameTimeElapsed /1000)}");
        }
    }
}