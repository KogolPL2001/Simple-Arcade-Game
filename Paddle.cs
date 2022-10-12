using System;

namespace Arcade
{
    public class Ball
    {
        private char body;
        private int cursorX, cursorY;
        private int boardwidth,boardheight;
        private int directionX, directionY;
        Random r = new Random();
        int rInt;
        public Ball(int width,int height)
        {
            body = '■';
            this.boardwidth = width;
            this.boardheight = height;
            cursorX = width / 2;
            cursorY = height / 2;
            directionX = 1;
            directionY = 1;
        }
        public int getcursorY() { return cursorY; }
        public void Logic(Paddle paddle)
        {
            Console.SetCursorPosition(cursorX, cursorY);
            if(cursorY != paddle.getcursorY())
            {
                    Console.Write(' ');
            }
            else if (cursorX < paddle.getcursorX() || cursorX > paddle.getcursorX() + paddle.getpaddleWidth())
                Console.Write(' ');
            if (cursorX==1||cursorX==boardwidth-1)
            {
                directionX *= -1;
            }
            if(cursorY==1||cursorY==boardheight-1)
            {
                directionY *= -1;
                changeXdiraction();
            }
            if (cursorY == paddle.getcursorY())
            {
                if (cursorX > paddle.getcursorX() && cursorX < paddle.getcursorX() + paddle.getpaddleWidth())
                {
                    directionY *= -1;
                    changeXdiraction();
                }
            }
            if(directionX==1)
            {
                cursorX++;
            }
            else if(directionX==-1)
            {
                cursorX--;
            }
            if(directionY==1)
            {
                cursorY++;
            }
            else
            {
                cursorY--;
            }
        }
        private void changeXdiraction()
        {
            rInt = r.Next(0, 3);
            switch (rInt)
            {
                case 0:
                    directionX = 0;
                    break;
                case 1:
                    if (directionX == 0 && cursorX == boardwidth - 1)
                        directionX = -1;
                    else if (directionX == 0 && cursorX == 1)
                        directionX = 1;
                    else
                        directionX = -1;
                    break;
                case 2:
                        directionX = 1;
                    break;
            }
            if (cursorX == boardwidth - 1)
                directionX = -1;
            if (cursorX == 1)
                directionX = 1;
        }
        public void WriteBall()
        {
            Console.SetCursorPosition(cursorX, cursorY);
            Console.Write(body);
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
