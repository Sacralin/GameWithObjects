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
                        isRunning = false;
                        playerY--;
                        break;
                    case ConsoleKey.DownArrow:
                        isRunning = false;
                        playerY++;
                        break;
                    case ConsoleKey.LeftArrow:
                        isRunning = false;
                        playerX--;
                        break;
                    case ConsoleKey.RightArrow:
                        isRunning = false;
                        playerX++;
                        break;
                    default:
                        break;
                }
            }
        }
        static void Draw()
        {
            Console.Clear();

            Console.SetCursorPosition(playerX,playerY);
            Console.Write("@");

            Console.SetCursorPosition(0, 21);
            Console.WriteLine($"Time elapsed (ms): {Math.Round(gameTimeElapsed /1000)}");
        }
    }
}