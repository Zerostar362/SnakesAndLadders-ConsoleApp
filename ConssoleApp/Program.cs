using System;
using System.Collections.Generic;

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
                                Player playerOne = new Player(Console.ReadLine(), i, i + 1);
                                player1 = playerOne;
                                break;
                            }
                        case 1:
                            {
                                Console.WriteLine("Choose player name");
                                Player playerTwo = new Player(Console.ReadLine(), i, i + 1);
                                player2 = playerTwo;
                                break;
                            }
                        case 2:
                            {
                                Console.WriteLine("Choose player name");
                                Player playerThree = new Player(Console.ReadLine(), i, i + 1);
                                player3 = playerThree;
                                break;
                            }
                        case 3:
                            {
                                Console.WriteLine("Choose player name");
                                Player playerFour = new Player(Console.ReadLine(), i, i + 1);
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

            public void setPlayerTurn(List<Player> OArr, Game game)  //writes Turn directly into objects
            {

                int ID = 0;
                int NumberOfPlayers = 0;

                foreach(Player i in OArr)
                {
                    if (i.playerID != 0)
                    {
                        NumberOfPlayers++;
                    }
                }

                foreach (Player O in OArr)
                {
                    if (O.playerID != 0)
                    {
                        if (game.RoundNumber == 0)
                        {
                            ID = 1;
                        }
                        else
                        {
                            if (O.onTurn == true)
                            {

                                if (O.playerID + 1 > NumberOfPlayers)
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
                }

                switch (ID)
                {
                    case 1:
                        {
                            Console.WriteLine(OArr[0].name + " is on turn");
                            OArr[0].onTurn = true; 
                            OArr[1].onTurn = false;
                            OArr[2].onTurn = false;
                            OArr[3].onTurn = false;
                            game.RoundNumber++;
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine(OArr[1].name + " is on turn");
                            OArr[0].onTurn = false;
                            OArr[1].onTurn = true;
                            OArr[2].onTurn = false;
                            OArr[3].onTurn = false;
                            game.RoundNumber++;
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine(OArr[2].name + " is on turn");
                            OArr[0].onTurn = false;
                            OArr[1].onTurn = false;
                            OArr[2].onTurn = true;
                            OArr[3].onTurn = false;
                            game.RoundNumber++;
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine(OArr[3].name + " is on turn");
                            OArr[0].onTurn = true;
                            OArr[1].onTurn = false;
                            OArr[2].onTurn = false;
                            OArr[3].onTurn = false;
                            game.RoundNumber++;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Error, no player on turn");
                            OArr[0].onTurn = false;
                            OArr[1].onTurn = false;
                            OArr[2].onTurn = false;
                            OArr[3].onTurn = false;
                            game.RoundNumber++;
                            break;
                        }
                }
            }
            
            public void EmptyPlayerCreation(Player playerOne,Player playerTwo,Player playerThree,Player playerFour, List<Player> Array)
            {
                for (int i = 0; i < 4; i++)
                {
                    switch (i)
                    {
                        case 0:
                            {
                                if (playerOne != null)
                                {
                                    Array.Add(playerOne);
                                }
                                else
                                {
                                    Player player1 = new Player("NULL", 0, 0);
                                    Array.Add(player1);
                                }
                                break;
                            }
                        case 1:
                            {
                                if (playerTwo != null)
                                {
                                    Array.Add(playerTwo);
                                }
                                else
                                {
                                    Player player2 = new Player("NULL", 0, 0);
                                    Array.Add(player2);
                                }
                                break;
                            }
                        case 2:
                            {
                                if (playerThree != null)
                                {
                                    Array.Add(playerThree);
                                }
                                else
                                {
                                    Player player3 = new Player("NULL", 0, 0);
                                    Array.Add(player3);
                                }
                                break;
                            }
                        case 3:
                            {
                                if (playerFour != null)
                                {
                                    Array.Add(playerOne);
                                }
                                else
                                {
                                    Player player4 = new Player("NULL", 0, 0);
                                    Array.Add(player4);
                                }
                                break;
                            }
                    }
                }
            }

            public void PrintWinner(Player Winner, List<Player> PArr)
            {
                int x;

                Console.Clear();
                Console.WriteLine();
                char[] charArr = ((Winner.name + " IS A WINNER").ToUpper()).ToCharArray(); 
                foreach(char ch in charArr)
                {
                    Console.Beep();
                    Console.Write(ch);
                    Console.Write(" ");
                }

                Console.WriteLine();

                for (x = 0; x < 4; x++) 
                {
                    
                }
            }
        }

        class Player
        {
            public int X { get; set; }
            public int Y { get; set; }
            public ConsoleColor color { get; }
            public String name { get; }
            public int playerID { get; set; }
            public bool onTurn { get; set; }
            public bool won { get; set; }
            public int position {get; set;}

            public Player(String PlayerName, int PlayerColor, int ID)
            {
                playerID = ID;
                name = PlayerName;
                ConsoleColor[] Colors = { ConsoleColor.Magenta, ConsoleColor.Cyan, ConsoleColor.Red, ConsoleColor.Yellow };
                color = Colors[PlayerColor];
            }

            public void eject()
            {
                X = 0;
            }

            public void setStartingPosition()
            {
                X = 0;
                Y = 0;
            }

            public void movePlayer(int movementValue, out bool Won, board Board, List<Player> PArr)
            {
                //algorithm completed, should work

                Console.WriteLine(movementValue);

                Board.getSize(out int maximumX,out int maximumY);

                Won = false;
                if ((X + movementValue) > maximumX - 1)
                {
                    X += movementValue;
                    X -= maximumX;
                    if (Y + 1 > maximumY - 1)
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
                    X += movementValue;
                }

                foreach(Player o in PArr)
                {
                    if(playerID != o.playerID & playerID != 0)
                    {
                        if (X == o.X)
                        {
                            if (Y == o.Y)
                            {
                                o.eject();
                            }
                        }
                    }
                }
            }
        }

        class board
        {
            private String[,] GameBoard;
            private int Ymax;
            private int Xmax;

            public board(int x, int y)
            {
                GameBoard = new string[x,y];
                Ymax = y;
                Xmax = x;
            }

            public void ClearBoard()
            {
                for (int y = 0; y < Ymax; y++)
                {
                    for (int x = 0; x < Xmax; x++)
                    {
                        GameBoard[x, y] = "0";
                    }
                }
            }

            public void RenderPreparations(List<Player> PArr)
            {
                for (int y = 0; y < Ymax; y++)
                {
                    for (int x = 0; x < Xmax; x++)
                    {
                        foreach(Player o in PArr)
                        {
                            if (o.X == x & o.Y == y & o.playerID != 0)
                            {
                                GameBoard[x, y] = "X";
                            }
                            else if (GameBoard[x,y] != "X")
                            {
                                GameBoard[x, y] = "0";
                            }
                        }
                    }
                }
            }

            public void getSize(out int maximumX, out int maximumY)
            {
                maximumX = this.Xmax;
                maximumY = this.Ymax;
            }

            public void Render(List<Player> PArr)
            {
                ClearBoard();
                RenderPreparations(PArr);
                for (int y = 0; y < Ymax; y++)
                {
                    Console.WriteLine();
                    for (int x = 0; x < Xmax; x++)
                    {
                        foreach (Player o in PArr)
                        {
                            if (x == o.X & y == o.Y & o.playerID != 0)
                            {
                                Console.ForegroundColor = o.color;
                            }
                        } 
                        Console.Write(GameBoard[x, y]);
                        Console.Write(" ");
                        Console.ResetColor();
                    }    
                }
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
            board GameBoard = new board(10,10);
            Game General = new Game();
            Dice dice = new Dice();

            //this block creates all wanted player objects-----------------------------------------
            Console.WriteLine("How many players will play ?");
            General.CreatePlayers(General.CheckValidInt(Console.ReadLine()), out Player playerOne, out Player playerTwo, out Player playerThree, out Player playerFour);
            //-------------------------------------------------------------------------------------

            List <Player> PArr = new List<Player>(); //essential list of usable objects

            General.EmptyPlayerCreation(playerOne, playerTwo, playerThree, playerFour, PArr); //this method takes care of empty object in case of less players playing

            foreach(Player o in PArr)
            {
                o.setStartingPosition(); //sets the 0,0 starting position for each player
            }

            //gameloop starts herere -------------------------------------------------------------------------------
            while (General.WinningCondition == false) 
            {

                //-------basic graphic starts here ------//
                General.ClearConsole();
                General.OverHead();
                GameBoard.Render(PArr); //this method renders board and players
                General.Footer();
                //-------basic graphic ends here -----//

                General.setPlayerTurn(PArr, General);

                foreach (Player player in PArr)  //search for parameter Player.OnTurn == true using List<Player> PArr
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
                playerOnTurn.movePlayer(dice.Throw(),out bool Won, GameBoard, PArr );  //calculates the player movement and save it to player object

                if(Won == true)
                {
                    playerOnTurn.won = true;
                    General.WinningCondition = true; //checks if anybody finished the game
                }

                Console.ReadLine();
            }

            General.PrintWinner(playerOnTurn, PArr);
        }
    }
}