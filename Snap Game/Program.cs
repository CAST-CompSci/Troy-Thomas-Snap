using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snap_Game
{
    struct card
    {
        string number, suitSymbol;
        Boolean isUsed;
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
    }
}
