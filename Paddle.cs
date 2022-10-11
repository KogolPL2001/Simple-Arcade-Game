using System;

namespace Arcade
{
    public class Enemy
    {
        private char[,] body;
        private int width,height;
        public Enemy(int width,int height)
        {
            body = new char[width, height];
            this.width = width;
            this.height = height;
            for(int i=0;i<width;i++)
            {
                for (int j = 0; j < height; j++)
                    body[i, j] = 'O';
            }
        }
        public void WriteEnemy()
        {
            for (int i = 0; i <width; i++)
            {
                for (int j = 0; j <height; j++)
                {
                    Console.SetCursorPosition(i + 1, j+1);
                    Console.Write(body[i, j]);
                }
            }
        }
    }
    public class Paddle
    {
        private char[] body;
        private int cursorX,cursorY;
        private int width,height;
        private int paddleWidth;
        public Paddle(int width,int height,int paddleWidth)
        {
            body = new char[paddleWidth];
            for (int i = 1; i < paddleWidth-1; i++)
                body[i] = '■';
            body[0] = '<';
            body[paddleWidth - 1] = '>';
            cursorX = (width - 2) / 2;
            cursorY = height - 2;
            this.width = width;
            this.height = height;
            this.paddleWidth = paddleWidth;
        }
        public void moveLeft()
        {
            if (cursorX > 1)
            {
                Console.SetCursorPosition(cursorX, cursorY);
                for (int i = 0; i < paddleWidth; i++)
                {
                        Console.SetCursorPosition(cursorX + i, cursorY);
                        Console.Write(' ');
                }
                cursorX--;
            }
        }
        public void moveRight()
        {
            if (cursorX < width - paddleWidth)
            {
                Console.SetCursorPosition(cursorX, cursorY);
                for (int i = 0; i < paddleWidth; i++)
                {
                        Console.SetCursorPosition(cursorX + i, cursorY);
                        Console.Write(' ');
                }
                cursorX++;
            }
        }
        public void WritePaddle()
        {
            Console.SetCursorPosition(cursorX,cursorY);
            for (int i = 0; i<paddleWidth; i++)
            {
                    Console.SetCursorPosition(cursorX+i, cursorY);
                    Console.Write(body[i]);
            }
        }

    }
}
