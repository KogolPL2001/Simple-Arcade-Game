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
}
