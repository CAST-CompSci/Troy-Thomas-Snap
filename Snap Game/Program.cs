using System;
using System.Collections.Generic;
using System.Threading;

namespace Snap_Game
{
    struct Card
    {
        public string number, suitSymbol;
        public Boolean isUsed;
    }

    class Program
    {
        static Queue<Card> playerOneQueue = new Queue<Card>(52);
        static Queue<Card> playerTwoQueue = new Queue<Card>(52);
        static Stack<Card> playerOneStack = new Stack<Card>(52);
        static Stack<Card> playerTwoStack = new Stack<Card>(52);

        

        static void Main(string[] args)
        {
            while (true)
            {
                Menu();
                AddCards();
                Game();
            }
        }

        static void Menu()
        {
            string Option;
            while (true)
            {
                Console.WriteLine("Welcome to Snap \n 1. Play \n 2. Quit");
                Option = Console.ReadLine();

                if (Option == "1")
                    break;
                else
                    Environment.Exit(1);
            }
        }

        static void AddCards()
        {
            Card[] cardArray = new Card[52];
            int loopCount = 0;
            //Create cards in array
            for (int a = 0; a < 4; a++)
            {
                for (int b = 0; b <= 12; b++)
                {
                    //Create the number/value of the cards
                    if (b == 0)
                    {
                        cardArray[loopCount].number = "A";
                    }
                    else if (b == 10)
                    {
                        cardArray[loopCount].number = "J";
                    }
                    else if (b == 11)
                    {
                        cardArray[loopCount].number = "Q";
                    }
                    else if (b == 12)
                    {
                        cardArray[loopCount].number = "K";
                    }
                    else
                    {
                        cardArray[loopCount].number = Convert.ToString(b + 1);
                    }

                    //Create the suit of cards
                    if (a == 0)
                    {
                        cardArray[loopCount].suitSymbol = "S";
                    }
                    else if (a == 1)
                    {
                        cardArray[loopCount].suitSymbol = "H";
                    }
                    else if (a == 2)
                    {
                        cardArray[loopCount].suitSymbol = "D";
                    }
                    else if (a == 3)
                    {
                        cardArray[loopCount].suitSymbol = "C";
                    }

                    //Say the cards are not yet added to the array
                    cardArray[loopCount].isUsed = false;
                    loopCount++;
                }
            }

            Random rnd = new Random();
            for (int a = 0; a <= 25; a++)
            {
                int randomNumber = rnd.Next(52);
                if (cardArray[randomNumber].isUsed == true)
                {
                    a--;
                }
                else
                {
                    playerOneQueue.Enqueue(cardArray[randomNumber]);
                    cardArray[randomNumber].isUsed = true;
                }
            }

            for (int a = 0; a <= 25; a++)
            {
                int randomNumber = rnd.Next(52);
                if (cardArray[randomNumber].isUsed == true)
                {
                    a--;
                }
                else
                {
                    playerTwoQueue.Enqueue(cardArray[randomNumber]);
                    cardArray[randomNumber].isUsed = true;
                }
            }
            
        }

        static void Game()
        {
            while (true)
            {
                if (playerOneQueue.Count == 52)
                {
                    Win("Player 1");
                }
                else if (playerTwoQueue.Count == 52)
                {
                    Win("Player 2");
                }

                playerOneStack.Push(playerOneQueue.Dequeue());
                playerTwoStack.Push(playerTwoQueue.Dequeue());

                Console.CursorLeft = 0;
                displayCard(playerOneStack.Peek());

                Console.CursorLeft = 20;
                displayCard(playerTwoStack.Peek());

                ConsoleKeyInfo key = Console.ReadKey();
                Thread.Sleep(1000);

                if (key.Key == ConsoleKey.Z)
                {
                    if (playerOneStack.Peek().number == playerTwoStack.Peek().number)
                    {
                        playerOneScore();
                    }
                    else
                    {
                        playerTwoScore();
                    }
                }
                else if (key.Key == ConsoleKey.M)
                {
                    if (playerOneStack.Peek().number == playerTwoStack.Peek().number)
                    {
                        playerTwoScore();
                    }
                    else
                    {
                        playerOneScore();
                    }
                }

            }
        }

        static void playerOneScore()
        {
            for (int a = 0; a < playerTwoStack.Count - 1; a++)
            {
                playerOneQueue.Enqueue(playerTwoStack.Pop());
            }
            for (int a = 0; a < playerOneStack.Count - 1; a++)
            {
                playerOneQueue.Enqueue(playerOneStack.Pop());
            }
        }

        static void playerTwoScore()
        {
            for (int i = 0; i < playerTwoStack.Count - 1; i++)
            {
                playerTwoQueue.Enqueue(playerTwoStack.Pop());
            }

            for (int i = 0; i < playerOneStack.Count - 1; i++)
            {
                playerTwoQueue.Enqueue(playerOneStack.Pop());
            }
        }

        static void displayCard(Card card)
        {
            string number = card.number;
            string suitChar = card.suitSymbol;
            
            Action Curset = () =>
            {
                Console.CursorTop = Console.CursorTop + 1;
                Console.CursorLeft = Console.CursorLeft - 16;
            };

            if (number.Length == 1)
            {
                number = number + " ";
            }

            Console.Write("  ______________ ");
            Curset();
            Console.Write(" | " + number + "         | ");
            for (int i = 0; i < 3; i++)
            {
                Curset();
                Console.Write(" |            | ");
            }
            Curset();
            Console.Write(" |      " + suitChar + "     | ");

            for (int i = 0; i < 3; i++)
            {
                Curset();
                Console.Write(" |            | ");
            }
            Curset();
            Console.Write(" |         " + number + " | ");
            Curset();
            Console.Write(" ______________ ");
        }

        static void Win(string player)
        {
            Console.WriteLine("Congratulations {0} you have won!", player);
            Thread.Sleep(2000);
        }

    }
}
