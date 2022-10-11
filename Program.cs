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
        SpaceShip spaceship1,spaceship2;
        Board board;
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
            spaceship1 = new SpaceShip(width,height);
            spaceship2 = new SpaceShip(width, 5);
            keyInfo = new ConsoleKeyInfo();
            consoleKey = new ConsoleKey();
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
            int i=20;
            while (true)
            {
                Console.Clear();
                Setup();
                board.WriteBoard();
                while (true)
                {
                    Input();
                    switch (consoleKey)
                    {
                        case ConsoleKey.A:
                            spaceship1.moveLeft();
                            break;
                        case ConsoleKey.D:
                            spaceship1.moveRight();
                            break;
                        case ConsoleKey.LeftArrow:
                            spaceship2.moveLeft();
                            break;
                        case ConsoleKey.RightArrow:
                            spaceship2.moveRight();
                            break;
                    }
                    consoleKey = ConsoleKey.X;

                    spaceship1.WriteSpaceShip();
                    spaceship1.WriteFlame();
                    spaceship2.WriteSpaceShip();
                    spaceship2.WriteFlame();
                    Thread.Sleep(1000/60);
                }
            }
        }
    }
}
