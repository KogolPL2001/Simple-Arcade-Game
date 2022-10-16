using System;

namespace Arcade
{
    public class Paddle
    {
        private char[] body;
        private int cursorX,cursorY;
        private int width,height;
        private int paddleWidth;
        public Paddle(int width,int height,int paddleWidth)
        {
            body = new char[paddleWidth];
            for (int i = 0; i < paddleWidth; i++)
                body[i] = '■';
            cursorX = (width - 2) / 2;
            cursorY = height - 2;
            this.width = width;
            this.height = height;
            this.paddleWidth = paddleWidth;
        }
        public int getcursorX()
        {
            return cursorX;
        }
        public int getcursorY()
        {
            return cursorY;
        }
        public int getpaddleWidth()
        {
            return paddleWidth;
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
