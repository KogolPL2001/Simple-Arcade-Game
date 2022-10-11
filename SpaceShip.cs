using System;

namespace Arcade
{
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
