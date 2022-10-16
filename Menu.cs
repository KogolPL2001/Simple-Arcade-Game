using System;

namespace Arcade
{
    public class Menu
    {
        private int selectedIndex;
        private int difficultyIndex;
        private string[] menuOptions = { "Play", "About", "Difficulty", "Exit" };
        private string[] difficulty = { "Easy", "Medium", "Hard" };
        public Menu()
        {
            selectedIndex = 0;
            difficultyIndex = 0;
        }

        public void MainMenu()         //switch between menu options
        {
            int index;
            while (true)
            {
                index = Run();
                switch (index)
                {
                    case 0:
                        RunGame();
                        break;
                    case 1:
                        ShowAbout();
                        break;
                    case 2:
                        ChangeDifficulty();
                        break;
                    case 3:
                        ExitGame();
                        break;
                }
            }
        }
        private void RunGame()           //run game with certain difficulty
        {
            Arcade arcade;
            int width=20, height=10;
            switch(difficultyIndex)
            {
                case 0:
                    width = 20;
                    height = 20;
                    break;
                case 1:
                    width = 30;
                    height = 15;
                    break;
                case 2:
                    width = 40;
                    height = 20;
                    break;
            }
            arcade = new Arcade(width, height);
            arcade.Run();
            return;
        }
        private void ChangeDifficulty()
        {
            difficultyIndex++;
            if (difficultyIndex > difficulty.Length - 1)
                difficultyIndex = 0;
        }
        private void ShowAbout()
        {
            Console.Clear();
            WriteTheme();
            Console.WriteLine("This game was created by Kornel Golebiewski for studies project.");
            Console.WriteLine("Nothing to see here.");
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey(true);
            return;
        }
        private void ExitGame()
        {
            Console.Clear();
            WriteTheme();
            Console.WriteLine("Press any key to exit the game.");
            Console.ReadKey(true);
            Environment.Exit(0);
        }
        private void WriteTheme()
        {
            Console.WriteLine(@"
                                                     
     _____ _____ _____ _____ _____ _____ _____ _____ 
    | __  | __  |   __|  _  |  |  |     |  |  |_   _|
    | __ -|    -|   __|     |    -|  |  |  |  | | |  
    |_____|__|__|_____|__|__|__|__|_____|_____| |_|  
                                                     
");
        }
        private int Run()             //returns value in main menu to switch between menu options
        {
            Console.SetCursorPosition(2, 2);
            ConsoleKeyInfo keyPressed;
            do
            {
                Console.Clear();
                WriteTheme();
                DisplayOptions();
                keyPressed = Console.ReadKey();
                switch (keyPressed.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedIndex--;
                        if (selectedIndex<0)
                            selectedIndex=menuOptions.Length-1;
                        break;
                    case ConsoleKey.DownArrow:
                        selectedIndex++;
                        if (selectedIndex > menuOptions.Length-1)
                            selectedIndex=0;
                        break;

                }
                Console.ReadKey(true);
            } while (keyPressed.Key != ConsoleKey.Enter);
            return selectedIndex;
        }
        private void DisplayOptions()                //display menu options
        {
            for(int i=0;i<menuOptions.Length;i++)
            {
                Console.Write("                       ");
                string currentOption = menuOptions[i];
                if (selectedIndex == i)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    if(selectedIndex==2)
                    {
                        Console.WriteLine($"<<{currentOption}: {difficulty[difficultyIndex]}>>");
                    }
                    else
                        Console.WriteLine($"<<{currentOption}>>");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine(currentOption);
                }
                Console.ResetColor();
            }
        }
    }
}
