using System;
using System.Runtime.InteropServices;
using System.Text;
namespace Arcade
{
    public class Ball
    {
        private char body;
        private int points;
        private int cursorX, cursorY;
        private int boardwidth,boardheight;
        private int directionX, directionY;
        Random r = new Random();
        int rInt;
        public Ball(int width,int height)
        {
            body = '■';
            points = 0;
            this.boardwidth = width;
            this.boardheight = height;
            cursorX = width / 2;
            cursorY = height / 2;
            directionX = 1;
            directionY = 1;
        }
        public int getcursorY() { return cursorY; }
        private void WritePoints()
        {
            Console.SetCursorPosition(boardwidth+5, 5);
            Console.Write("Points: " + points);
        }
        public void Logic(Paddle paddle)
        {
            WritePoints();
            Console.SetCursorPosition(cursorX, cursorY);
            if(cursorY != paddle.getcursorY())
            {
                    Console.Write(' ');
            }
            else if (cursorX < paddle.getcursorX() || cursorX >= paddle.getcursorX() + paddle.getpaddleWidth())
                Console.Write(' ');
            if (cursorX==1||cursorX==boardwidth-1)
            {
                changeXdirection();
            }
            if(cursorY==1||cursorY==boardheight-1)
            {
                directionY *= -1;
                changeXdirection();
            }
            if (cursorY == paddle.getcursorY())
            {
                if (cursorX >= paddle.getcursorX() && cursorX < paddle.getcursorX() + paddle.getpaddleWidth())
                {
                    directionY *= -1;
                    changeXdirection();
                }
            }
            if(directionY==-1)
            {
                switch(directionX)
                {
                    case 0:
                        if(ReadCharacterAt(cursorX, cursorY - 1) == 'O')
                         {
                            changeXdirection();
                            directionY *= -1;
                            Console.SetCursorPosition(cursorX, cursorY - 1);
                            Console.Write(' ');
                            points += 10;
                            Console.SetCursorPosition(cursorX, cursorY);
                        }
                        break;
                    case 1:
                        if (ReadCharacterAt(cursorX+1, cursorY - 1) == 'O')
                        {
                            changeXdirection();
                            directionY *= -1;
                            Console.SetCursorPosition(cursorX+1, cursorY - 1);
                            Console.Write(' ');
                            points += 10;
                            Console.SetCursorPosition(cursorX, cursorY);
                        }
                        break;
                    case -1:
                        if (ReadCharacterAt(cursorX - 1, cursorY - 1) == 'O')
                        {
                            changeXdirection();
                            directionY *= -1;
                            Console.SetCursorPosition(cursorX - 1, cursorY - 1);
                            Console.Write(' ');
                            points += 10;
                            Console.SetCursorPosition(cursorX, cursorY);
                        }
                        break;
                }
            }
            else if (directionY == 1)
            {
                switch (directionX)
                {
                    case 0:
                        if (ReadCharacterAt(cursorX, cursorY + 1) == 'O')
                        {
                            changeXdirection();
                            directionY *= -1;
                            Console.SetCursorPosition(cursorX, cursorY + 1);
                            Console.Write(' ');
                            Console.SetCursorPosition(cursorX, cursorY);
                        }
                        break;
                    case 1:
                        if (ReadCharacterAt(cursorX + 1, cursorY + 1) == 'O')
                        {
                            changeXdirection();
                            directionY *= -1;
                            Console.SetCursorPosition(cursorX + 1, cursorY + 1);
                            Console.Write(' ');
                            Console.SetCursorPosition(cursorX, cursorY);
                        }
                        break;
                    case -1:
                        if (ReadCharacterAt(cursorX - 1, cursorY + 1) == 'O')
                        {
                            changeXdirection();
                            directionY *= -1;
                            Console.SetCursorPosition(cursorX - 1, cursorY + 1);
                            Console.Write(' ');
                            Console.SetCursorPosition(cursorX, cursorY);
                        }
                        break;
                }
            }
            if (directionY == -1 && cursorY==1)
            {
                directionY= 1;
                cursorY++;
                return;
            }
            if (directionX==1)
                cursorX++;
            else if(directionX==-1)
                cursorX--;
            if(directionY==1)
                cursorY++;
            else
                cursorY--;

        }
        private void changeXdirection()
        {
            rInt = r.Next(0, 3);
            switch (rInt)
            {
                case 0:
                    directionX = 0;
                    break;
                case 1:
                    directionX = -1;
                    break;
                case 2:
                    directionX = 1;
                    break;
            }
            if (cursorX == boardwidth-1)
                directionX = -1;
            if (cursorX == 1)
                directionX = 1;
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetStdHandle(int nStdHandle);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool ReadConsoleOutputCharacter(
            IntPtr hConsoleOutput,
            [Out] StringBuilder lpCharacter,
            uint length,
            COORD bufferCoord,
            out uint lpNumberOfCharactersRead);

        [StructLayout(LayoutKind.Sequential)]
        public struct COORD
        {
            public short X;
            public short Y;
        }

        public static char ReadCharacterAt(int x, int y)
        {
            IntPtr consoleHandle = GetStdHandle(-11);
            if (consoleHandle == IntPtr.Zero)
            {
                return '\0';
            }
            COORD position = new COORD
            {
                X = (short)x,
                Y = (short)y
            };
            StringBuilder result = new StringBuilder(1);
            uint read = 0;
            if (ReadConsoleOutputCharacter(consoleHandle, result, 1, position, out read))
            {
                return result[0];
            }
            else
            {
                return '\0';
            }
        }
        public void WriteBall()
        {
            Console.SetCursorPosition(cursorX, cursorY);
                Console.Write(body);
        }
    }
}
