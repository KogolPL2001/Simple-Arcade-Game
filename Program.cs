using System;
using System.Threading;

namespace Arcade
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Arcade arcade = new Arcade(80, 30);
            arcade.Run();
        }
    }
   
    public class Arcade
    {
        private int width;
        private int height;
        Paddle paddle;
        Board board;
        Enemy enemy;
        ConsoleKeyInfo keyInfo;
        ConsoleKey consoleKey;
        public Arcade(int width, int height)
        {
            this.width = width;
            this.height = height;
            board = new Board(width, height);
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
            while (true)
            {
                Console.Clear();
                Setup();
                board.WriteBoard();
                enemy.WriteEnemy();
                while (true)
                {
                    Input();
                   switch (consoleKey)
                    {
                        case ConsoleKey.A:
                            paddle.moveLeft();
                            break;
                        case ConsoleKey.D:
                            paddle.moveRight();
                            break;
                       
                    }
                    consoleKey = ConsoleKey.X;
                    paddle.WritePaddle();
                    Thread.Sleep(1000/60);
                }
            }
        }
    }
}
