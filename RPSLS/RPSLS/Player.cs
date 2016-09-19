using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    class Player
    {
        public string playername;
        public int wins;
        public int losses;

        public Player(string playername)
        {
            this.playername = playername;
        }
        public string getinput()
        {
            Console.WriteLine("{0}, what is your move?", playername);
            string playerinput = Console.ReadLine();
            if (playerinput == "rock" || playerinput == "paper" || playerinput == "scissors" || playerinput == "lizard" ||
                playerinput == "spock")
            {
                return playerinput;
            }
            else
            {
                Console.WriteLine("Please enter a valid move");
                string correctInput = getinput();
                return correctInput;
            }
        }

    }
}

    

