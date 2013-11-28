using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace TronGame
{
    class TronGame
    {
        //Глобални променливи за посоките
        // First: W,S,D,A Second: Up, down, left, right
        static int left = 0;
        static int right = 1;
        static int up = 2;
        static int down = 3;
        static int firstPlayerScore = 0;
        static int secondPlayerScore = 0;


        static int firstPlayerDirection = right;
        static int firstPlayerColumn = 0; // column
        static int firstPlayerRow = 0; // row

        static int secondPlayerDirection = left;
        static int secondPlayerColumn = 40; // column
        static int secondPlayerRow = 5; // row

        static bool[,] IsUsed;

        static void ChangePlayerDirection(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.W)
                firstPlayerDirection = up;

            if (key.Key == ConsoleKey.A)
                firstPlayerDirection = left;

            if (key.Key == ConsoleKey.D)
                firstPlayerDirection = right;

            if (key.Key == ConsoleKey.S)
                firstPlayerDirection = down;

            if (key.Key == ConsoleKey.UpArrow)
                secondPlayerDirection = up;

            if (key.Key == ConsoleKey.LeftArrow)
                secondPlayerDirection = left;

            if (key.Key == ConsoleKey.RightArrow)
                secondPlayerDirection = right;

            if (key.Key == ConsoleKey.DownArrow)
                secondPlayerDirection = down;
        }
        static void WriteOnPosition(int x, int y, char ch)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(ch); 
        }
        static void MovePlayers()
        {
            if (firstPlayerDirection == right)
            {
                firstPlayerColumn++;
            }
            if (firstPlayerDirection == left)
            {
                firstPlayerColumn--;
            }
            if (firstPlayerDirection == up)
            {
                firstPlayerRow--;
            }
            if (firstPlayerDirection == down)
            {
                firstPlayerRow++;
            }

            if (secondPlayerDirection == right)
            {
                secondPlayerColumn++;
            }
            if (secondPlayerDirection == left)
            {
                secondPlayerColumn--;
            }
            if (secondPlayerDirection == up)
            {
                secondPlayerRow--;
            }
            if (secondPlayerDirection == down)
            {
                secondPlayerRow++;
            }    


        }
        static void SetGameField()
        {
            Console.WindowHeight = 30;
            Console.BufferHeight = 30;

            Console.WindowWidth = 100;
            Console.BufferWidth = 100;

            firstPlayerColumn = 0;
            firstPlayerRow = Console.WindowHeight / 2;
            secondPlayerColumn = Console.WindowWidth - 1;
            secondPlayerRow = Console.WindowHeight / 2;
        }
        static int IsGameOver()
        {            
                // 0 =>g game is still active
                // 1 => firstPlayerWins
                // 2 => secondPlayerWins
            if (firstPlayerRow < 0)
                return 2;
            if (firstPlayerColumn < 0)
                return 2;
            if (firstPlayerRow >= Console.WindowHeight)
                return 2;
            if (firstPlayerColumn >= Console.WindowWidth)
                return 2;

            if (secondPlayerRow < 0)
                return 1;
            if (secondPlayerColumn < 0)
                return 1;
            if (secondPlayerRow >= Console.WindowHeight)
                return 1;
            if (secondPlayerColumn >= Console.WindowWidth)
                return 1;

            if (IsUsed[firstPlayerColumn, firstPlayerRow])
                return 2;
            if (IsUsed[secondPlayerColumn, secondPlayerRow])
                return 1;            
            return 0;


        }
        static void ResetGame()
        {
            Console.Clear();
            Console.WriteLine("Press any key to start new Game");
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            

            SetGameField();
            IsUsed = new bool[Console.WindowWidth, Console.WindowHeight];
            while(true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    ChangePlayerDirection(key);
                }

                MovePlayers();
                int winner = IsGameOver();
                if (winner > 0)
                {
                    Console.WriteLine("Game over");
                    if (winner == 1)
                        Console.WriteLine("First Player Win");
                    if (winner == 2)
                        Console.WriteLine("Second Player Win");
                    Environment.Exit(0);
                }
                IsGameOver();
                IsUsed[firstPlayerColumn, firstPlayerRow] = true;
                IsUsed[secondPlayerColumn, secondPlayerRow] = true;
                WriteOnPosition(firstPlayerColumn, firstPlayerRow, '*');
                WriteOnPosition(secondPlayerColumn, secondPlayerRow, '#');
                Thread.Sleep(200);               

            }
        }

    }

}
