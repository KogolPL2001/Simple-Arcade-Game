using System;

namespace Arcade
{
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
}
