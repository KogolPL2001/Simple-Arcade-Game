using System;
using System.Threading;

namespace Arcade
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Arcade arcade = new Arcade(30, 30);
            arcade.Run();
        }
    }
    public class Arcade
    {
        private int width;
        private int height;
        SpaceShip spaceship;
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
            spaceship = new SpaceShip(width,height);
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
                            spaceship.moveLeft();
                            break;
                        case ConsoleKey.D:
                            spaceship.moveRight();
                            break;
                    }
                    consoleKey = ConsoleKey.X;
                    spaceship.WriteSpaceShip();
                    spaceship.WriteFlame();
                    Thread.Sleep(1000/60);
                }
            }
        }
    }
    public class Board
    {
        private int width;
        private int height;
        public Board() { }
        public Board(int w, int h) { this.width = w; this.height = h; }

        public void WriteBoard()
        {
            for (int i = 0; i < width; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write('█');
            }
            for (int i = 0; i < height; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("█");
                Console.SetCursorPosition(width, i);
                Console.Write("█");
            }
            for (int i = 0; i <= width; i++)
            {
                Console.SetCursorPosition(i, height);
                Console.Write('█');
            }

        }
    }
    public class SpaceShip
    {
        private char[,] body = new char[3, 3];
        private int cursorX,cursorY;
        private int width,height;
        public SpaceShip(int width,int height)
        {
            body[1, 0] = '▲';
            body[0, 1] = '<';
            body[1, 1] = '█';
            body[2, 1] = '>';
            body[1, 2] = '#';
            cursorX = (width - 2) / 2;
            cursorY = height - 4;
            this.width = width;
            this.height = height;
        }
        public void moveLeft()
        {
            if (cursorX > 1)
            {
                Console.SetCursorPosition(cursorX, cursorY);
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Console.SetCursorPosition(cursorX + i, cursorY + j);
                        Console.Write(' ');
                    }
                }
                cursorX--;
            }
        }
        public void moveRight()
        {
            if (cursorX < width - 3)
            {
                Console.SetCursorPosition(cursorX, cursorY);
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Console.SetCursorPosition(cursorX + i, cursorY + j);
                        Console.Write(' ');
                    }
                }
                cursorX++;
            }
        }
        public void WriteSpaceShip()
        {
            Console.SetCursorPosition(cursorX,cursorY);
            for (int i = 0; i<3; i++)
            {
                for(int j=0;j<3;j++)
                {
                    Console.SetCursorPosition(cursorX+i, cursorY+j);
                    Console.Write(body[i, j]);
                }
            }
        }
        public void WriteFlame()
        {
            string chars = "$#&";
            Random rand = new Random();
            int num = rand.Next(0, chars.Length);
            body[1, 2] = chars[num];
        }

    }
}
