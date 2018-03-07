using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snap_Game
{
    struct card
    {
        public string number, suitSymbol;
        public Boolean isUsed;
    }
    
    class Program
    {
        static Queue<card> playerOneQueue = new Queue<card>(52);
        static Queue<card> playerTwoQueue = new Queue<card>(52);
        static Stack<card> playerOneStack = new Stack<card>(52);
        static Stack<card> playerTwoStack = new Stack<card>(52);


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
            card[] cardArray = new card[52];
            int loopCount = 0;
            //Create cards in array
            for (int a = 0; a <= 4; a++)
            {
                for (int b = 0; b < 12; b++)
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
                }
            }

            Random rnd = new Random();
            for (int a = 0; a <=25; a++)
            {
                int randomNumber = rnd.Next(0, 51);
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

            for (int a = 0; a <=25; a++)
            {
                int randomNumber = rnd.Next(0, 51);
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
        }

    }
}
