using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConssoleApp
{

    class Program
    {

        class Game
        {
            private int number;

            public bool WinningCondition = false;

            public void SetWinner()
            {

            }

            public void CreatePlayers(int Count,out object player1,out object player2, out object player3, out object player4)
            {
                player1 = null;
                player2 = null;
                player3 = null;
                player4 = null;

                for (int i = 0; i <= Count - 1; i++)
                {
                    string index = i.ToString();

                    switch (i)
                    {
                        case 0:
                            {
                                Console.WriteLine("Choose player name");
                                Player playerOne = new Player(Console.ReadLine(), i);
                                player1 = playerOne;
                                break;
                            }
                        case 1:
                            {
                                Console.WriteLine("Choose player name");
                                Player playerTwo = new Player(Console.ReadLine(), i);
                                player2 = playerTwo;
                                break;
                            }
                        case 2:
                            {
                                Console.WriteLine("Choose player name");
                                Player playerThree = new Player(Console.ReadLine(), i);
                                player3 = playerThree;
                                break;
                            }
                        case 3:
                            {
                                Console.WriteLine("Choose player name");
                                Player playerFour = new Player(Console.ReadLine(), i);
                                player4 = playerFour;
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Ooops, Something went wrong");
                                break;
                            }
                    }
                }
            }

            public int CheckValidInt(string PlayerCount)
            {
                bool validNumber = false;

                while (validNumber == false)
                {
                    try
                    {
                        number = Int32.Parse(PlayerCount);
                        validNumber = true;
                        return number;
                    }
                    catch
                    {
                        Console.WriteLine("Not a valid input");
                        Console.WriteLine("Enter a valid number");
                        PlayerCount = Console.ReadLine();
                    }
                }

                if (number > 0)
                {
                    return number;
                }
                else
                {
                    return 0;
                }
            }

            public void ClearConsole()
            {
                Console.Clear();
            }

            public void WelcomeMessage()
            {
                Console.WriteLine("Welcome to the game");
            }

            public void OverHead()
            {
                Console.WriteLine(" ");
                Console.WriteLine("Snakes And Ladders");
                Console.WriteLine(" ");
                Console.WriteLine("################################################################");
                Console.WriteLine(" ");
            }

            public void Footer()
            {
                Console.WriteLine(" ");
                Console.WriteLine("################################################################");
                Console.WriteLine(" ");
            }

            public int setPlayerTurn()
            {
                return 0;
            }
        }

        class Player
        {
            public int X { get; set; }
            public int Y { get; set; }
            private String color { get; }
            private String name { get; }

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

            Console.Title = "Snakes and ladders";
            board GameBoard = new board();
            Game General = new Game();
            Dice dice = new Dice();

            //this block creates all wanted player objects-----------------------------------------
            Console.WriteLine("How many players will play ?");
                General.CreatePlayers(General.CheckValidInt(Console.ReadLine()), out object playerOne, out object playerTwo, out object playerThree, out object playerFour);
            //-------------------------------------------------------------------------------------

            while(General.WinningCondition == false)
            {
                General.ClearConsole();
                General.OverHead();
                GameBoard.Render();
                General.Footer();
                Console.ReadLine();
            }
        }
    }
}