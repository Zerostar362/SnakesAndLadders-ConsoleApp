using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConssoleApp
{
    class Program
    {
        public bool WinningCondition = false;

        public void SetWinner()
        {

        }

        class Player
        {
            public int X;
            public int Y;
            private String color;
            private String name;

            public Player(String PlayerName, int PlayerColor)
            {
                name = PlayerName;
                String[] Colors = { "Magenta", "Pink", "Red", "Yellow" };
                color = Colors[PlayerColor];
            }

            //public int eject()
            //{ 
            //return
            //}

            public void getPlayerPosition(out int posX, out int posY)
            {
                posX = X;
                posY = Y;
            }

            public void setStartingPosition()
            {
                X = 0;
                Y = 0;
            }

            public string getColor()
            {
                return color;
            }

            public void movePlayer(int movementValue, out bool Won)
            {
                //algorithm completed, should work
                board GameBoard = new board();

                GameBoard.getSize(out int maximumX, out int maximumY);

                Won = false;
                if (X + movementValue > maximumX) 
                {
                    X = +movementValue;
                    X = -maximumX;
                    if (Y + 1 > maximumY)
                    {
                        Won = true;
                    }
                    else
                    {
                        Y++;
                    }
                }
                else
                {
                    X = +movementValue;
                }
            }
        }

        class board
        {
            private int Xmax = 10;
            private int Ymax = 10;

            public void Render()
            {
                //need to implement render of player position
                for(int i = 0; i < Ymax; i++)
                {
                    Console.WriteLine();
                    for(int o = 0; o < Xmax; o++)
                    {
                        Console.Write("O");
                        Console.Write(" ");
                    }
                }
            }

            public void getSize(out int maximumX, out int maximumY)
            {
                maximumX = Xmax;
                maximumY = Ymax;
            }
        }

        class Dice
        {
            private int value;

            public int Throw()
            {
                Random random = new Random();
                value = random.Next(1, 6);
                return value;
            }
        }

        static void Main(string[] args)
        {

            bool validNumber = false;
            int NumberOfPlayers = 0;

            Console.Title = "Snakes and ladders";
            board GameBoard = new board();

            Console.WriteLine("How many players will play ?");
            
            while (validNumber == false)
            {
                try
                {
                    NumberOfPlayers = Int32.Parse(Console.ReadLine());
                    validNumber = true;
                }
                catch
                {
                    Console.WriteLine("Not a valid input");
                    validNumber = false;
                }
            }
            for(int i = 0; i <= NumberOfPlayers; i++)
            {

            }
        }
    }
}
