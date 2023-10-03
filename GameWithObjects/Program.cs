namespace GameWithObjects
{
    internal class Program
    {
        static GameObject player;
        static Enemy enemy;

        static Random random = new Random();
        static bool isRunning = true;
        static DateTime lastUpdateTime = DateTime.Now;
        static double deltaTime;
        static double gameTimeElapsed;

        static int windowWidth = 40;
        static int windowHeight = 20;


        static void Main(string[] args)
        {
            Console.BufferHeight = Console.WindowHeight * 2;
            Console.CursorVisible = false;

            player = new GameObject(0, 0, "@");
            enemy = new Enemy(10, 10, "X", 4);
            


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
                        player.Move(0,-1, windowWidth, windowHeight);
                        break;
                    case ConsoleKey.DownArrow:
                        player.Move(0, 1, windowWidth, windowHeight); 
                        break;
                    case ConsoleKey.LeftArrow:
                        player.Move(-1, 0, windowWidth, windowHeight); 
                        break;
                    case ConsoleKey.RightArrow:
                        player.Move(1, 0, windowWidth, windowHeight); 
                        break;
                    default:
                        break;
                }
            }


            enemy.Update(player, windowWidth, windowHeight);
        }
        static void Draw()
        {
            Console.Clear();

            player.Draw();
            enemy.Draw();

            
            Console.SetCursorPosition(0, 21);
            Console.WriteLine($"Time elapsed (ms): {Math.Round(gameTimeElapsed /1000)}");
        }
    }
}