using System;

namespace ConssoleApp
{

    class Program
    {

        class Game
        {
            private int number;
            public int RoundNumber;

            public bool WinningCondition = false;

            public void SetWinner()
            {

            }

            public void CreatePlayers(int Count, out Player player1, out Player player2, out Player player3, out Player player4)
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
                                Player playerOne = new Player(Console.ReadLine(), i, i);
                                player1 = playerOne;
                                break;
                            }
                        case 1:
                            {
                                Console.WriteLine("Choose player name");
                                Player playerTwo = new Player(Console.ReadLine(), i, i);
                                player2 = playerTwo;
                                break;
                            }
                        case 2:
                            {
                                Console.WriteLine("Choose player name");
                                Player playerThree = new Player(Console.ReadLine(), i, i);
                                player3 = playerThree;
                                break;
                            }
                        case 3:
                            {
                                Console.WriteLine("Choose player name");
                                Player playerFour = new Player(Console.ReadLine(), i, i);
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

            public void setPlayerTurn(Player player1, Player player2, Player player3, Player player4, Game game)  //writes Turn directly into objects
            {

                int ID = 0;

                Player[] OArr = { player1, player2, player3, player4 };
                foreach (Player O in OArr)
                {
                    if (game.RoundNumber == 1)
                    {
                        ID = 1;
                    }
                    else
                    {
                        if (O.onTurn == true)
                        {

                            if (O.playerID + 1 > 4)
                            {
                                ID = 1;
                            }
                            else
                            {
                                ID = O.playerID + 1;
                            }
                        }
                    }
                }

                switch (ID)
                {
                    case 1:
                        {
                            Console.WriteLine(player1.name + " is on turn");
                            player1.onTurn = true;
                            player2.onTurn = false;
                            player3.onTurn = false;
                            player4.onTurn = false;
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine(player2.name + " is on turn");
                            player1.onTurn = false;
                            player2.onTurn = true;
                            player3.onTurn = false;
                            player4.onTurn = false;
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine(player3.name + " is on turn");
                            player1.onTurn = false;
                            player2.onTurn = false;
                            player3.onTurn = true;
                            player4.onTurn = false;
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine(player4.name + " is on turn");
                            player1.onTurn = true;
                            player2.onTurn = false;
                            player3.onTurn = false;
                            player4.onTurn = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Error, no player on turn");
                            player1.onTurn = false;
                            player2.onTurn = false;
                            player3.onTurn = false;
                            player4.onTurn = false;
                            break;
                        }
                }
            }
        }

        class Player
        {
            public int X { get; set; }
            public int Y { get; set; }
            public String color { get; set; }
            public String name { get; set; }
            public int playerID { get; set; }
            public bool onTurn { get; set; }
            public bool won { get; set; }

            public Player(String PlayerName, int PlayerColor, int ID)
            {
                playerID = ID;
                name = PlayerName;
                String[] Colors = { "Magenta", "Pink", "Red", "Yellow" };
                color = Colors[PlayerColor];
            }

            //public int eject()
            //{ 
            //return
            //}

            public void setStartingPosition()
            {
                X = 0;
                Y = 0;
            }

            public void movePlayer(int movementValue, out bool Won)
            {
                //algorithm completed, should work
                board GameBoard = new board();

                Console.WriteLine(movementValue);

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
                for (int i = 0; i < Ymax; i++)
                {
                    Console.WriteLine();
                    for (int o = 0; o < Xmax; o++)
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

            int TurnPlayerID = 0;
            Player playerOnTurn = null;

            Console.Title = "Snakes and ladders";
            board GameBoard = new board();
            Game General = new Game();
            Dice dice = new Dice();

            //this block creates all wanted player objects-----------------------------------------
            Console.WriteLine("How many players will play ?");
            General.CreatePlayers(General.CheckValidInt(Console.ReadLine()), out Player playerOne, out Player playerTwo, out Player playerThree, out Player playerFour);
            //-------------------------------------------------------------------------------------

            Player[] PArr = { playerOne, playerTwo, playerThree, playerFour };

            while (General.WinningCondition == false)
            {
                General.ClearConsole();
                General.OverHead();
                GameBoard.Render();
                General.Footer();
                General.setPlayerTurn(playerOne, playerTwo, playerThree, playerFour, General);

                foreach (Player player in PArr)
                {
                    if (player.onTurn == true)
                    {
                        TurnPlayerID = player.playerID;
                        playerOnTurn = player;
                        break;
                    }
                }

                Console.WriteLine(" ");
                Console.WriteLine("Roll the dice!");
                Console.ReadLine();
                playerOnTurn.movePlayer(dice.Throw(),out bool Won);

                if(Won == true)
                {
                    playerOnTurn.won = true;
                    General.WinningCondition = true;
                }

                Console.ReadLine();
            }
        }
    }
}