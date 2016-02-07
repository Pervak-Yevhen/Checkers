using System;
using MyConsole;


namespace Checkers
{
    class Program
    {
        static void Main()
        {
            var meny = new SimpleMenu(@"main.bgr", ConsoleColor.Black, 1, 1, '*');
            var musicForStart = new Audio(@"Logo.mp3");
            var musicForEnd = new Audio(@"Game Over.mp3");
            musicForStart.Play();
            
            Console.Title = "ITLabs - Checkers v1.0";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WindowWidth = 90;
            Console.WindowHeight = 30;
            
            meny.AddItem(41, 16, "S T A R T");
            meny.AddItem(41, 18, " E X I T");

            var choose = meny.StartMenu();
            var game = new Game();

            switch (choose)
            {
                case 1:

                    Console.Clear();
                    musicForStart.Stop();

                    game.Start();

                    while (!game.IsGameOver())
                    {
                        game.FindCheckersWithTakes();
                        game.SetMove();
                        game.SwitchPlayer();
                    }
                    game.ClearMessageBar();
                    Console.SetCursorPosition(50, 10);
                    Console.Write("Game Over");
                    musicForEnd.Play();
                    Console.ReadLine();

                    break;

                case 2:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}