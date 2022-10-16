using System;

namespace Arcade
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Menu menu = new Menu();
            menu.MainMenu();
        }
    }
}
