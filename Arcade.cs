using System;
using System.Threading;

namespace Arcade
{
    public class Arcade
    {
        private int width;
        private int height;
        private int points;
        Paddle paddle;
        Board board;
        Enemy enemy;
        Ball ball;
        ConsoleKeyInfo keyInfo;
        ConsoleKey consoleKey;
        public Arcade(int width, int height)
        {
            this.width = width;
            this.height = height;
            points = 0;
            board = new Board(width, height);
            ball = new Ball(width, height,ref points);
        }
        public void Setup()
        {
            paddle = new Paddle(width,height,10);
            keyInfo = new ConsoleKeyInfo();
            consoleKey = new ConsoleKey();
            enemy = new Enemy(width-1, height/4);
        }
        public void Input()
        {
            if(Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey(true);
                consoleKey = keyInfo.Key;
            }
        }
        public void Run()
        {
            int i = 0;
            while (ball.getcursorY() != height - 1) 
            {
                Console.Clear();
                Setup();
                board.WriteBoard();
                enemy.WriteEnemy();
                while (ball.getcursorY() != height - 1) 
                {
                    Input();
                    switch (consoleKey)
                    {
                        case ConsoleKey.A:
                        case ConsoleKey.LeftArrow:
                            paddle.moveLeft();
                            break;
                        case ConsoleKey.D:
                        case ConsoleKey.RightArrow:
                            paddle.moveRight();
                            break;

                    }
                    consoleKey = ConsoleKey.X;
                    paddle.WritePaddle();
                    if (i == 2)
                    {
                        ball.Logic(paddle,ref points);
                        ball.WriteBall();
                        i = 0;
                    }
                    i++;
                    Thread.Sleep(1000/60);
                }
            }
            Console.Clear();
            Console.WriteLine(@"
                                                        
     _____ _____ _____ _____    _____ _____ _____ _____ 
    |   __|  _  |     |   __|  |     |  |  |   __| __  |
    |  |  |     | | | |   __|  |  |  |  |  |   __|    -|
    |_____|__|__|_|_|_|_____|  |_____|\___/|_____|__|__|
                                                        
");
            Console.WriteLine("                     Points: "+points);
            Console.WriteLine("         Press any key to exit to the main menu.");
            Console.ReadKey(true);
            return;
        }
    }
}
