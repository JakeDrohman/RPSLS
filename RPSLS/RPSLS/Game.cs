using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    class Game
    {
        public bool playing=true;
        public bool onePlayer;
         
        
        public void playAgain()
        {
            Console.WriteLine("Play Again?");
            if (!(Console.ReadLine() == "yes"))
            {
                Console.WriteLine("Please enter [yes] or [no]");
                playAgain();
            }
            else if (Console.ReadLine()== "no")
            {
                playing = false;
            }
        }
        public void tie()
        {
            
            Console.WriteLine("Tie!");
            playAgain();
            
        }
        public void lose(string loser)
        {
            Console.WriteLine("{0} loses :(",loser);
            playAgain();
        }
        public void win(string winner)
        {
            Console.WriteLine("{0}wins yay", winner);
        }
        public void decidewinner(Player playerone,Player playertwo, int firstInput, int secondInput)
        {
            int derivedvariable = (5 + firstInput - secondInput) % 5;
                if (derivedvariable == 1 || derivedvariable == 3)
            {
                win(playerone.playername);
                playerone.wins = +1;
                playertwo.losses = +1;
                Console.WriteLine("{0}{1}Wins:{2}{1}Losses:{3}",playerone.playername,Environment.NewLine,playerone.wins,playerone.losses);
                Console.WriteLine("{0}{1}Wins:{2}{1}Losses:{3}", playertwo.playername, Environment.NewLine, playertwo.wins, playertwo.losses);
                lose(playertwo.playername);
            }
                else if(derivedvariable == 2 || derivedvariable == 4)
            {
                win(playertwo.playername);
                playertwo.wins = +1;
                playerone.losses = +1;
                Console.WriteLine("{0}{1}Wins:{2}{1}Losses:{3}", playerone.playername, Environment.NewLine, playerone.wins, playerone.losses);
                Console.WriteLine("{0}{1}Wins:{2}{1}Losses:{3}", playertwo.playername, Environment.NewLine, playertwo.wins, playertwo.losses);
                lose(playerone.playername);
            }
                else
            {
                Console.WriteLine("{0}{1}Wins:{2}{1}Losses:{3}", playerone.playername, Environment.NewLine, playerone.wins, playerone.losses);
                Console.WriteLine("{0}{1}Wins:{2}{1}Losses:{3}", playertwo.playername, Environment.NewLine, playertwo.wins, playertwo.losses);
                tie();
            }
        }
        Random random = new Random();
        List<string> moves = new List<string>() { "rock", "paper", "scissors", "spock", "lizard", };

        public Player makingPlayer()
        {
            Console.WriteLine("What is your name?");
            Player playerOne = new Player(Console.ReadLine());
            return playerOne;
        }
        public  string askingTwoPlayers()
        {
            Console.WriteLine("Are there 2 players?");
            string response = (Console.ReadLine());
            return response;
        }
        public Player makeComputer()
        {
            Player computer = new Player("HAL");
            return computer;
        }
        public int computerInput()
        {
            int randominteger = random.Next(0, 5);
            return randominteger;
        }
        public Player makingDifferentPlayers()
        {
            string response =askingTwoPlayers();
            if(response == "yes")
            {
                Player playerTwo = makingPlayer();
                return playerTwo;
            }
            else if(response == "no")
            {
                Player computer = makeComputer();
                onePlayer = true;
                return computer;
            }
            else
            {
                Console.WriteLine("Please enter yes or no.");
                Player output = makingDifferentPlayers();
                return output;
            }
        }
        public void gameRun()
        {
            Player firstPlayer = makingPlayer();
            Player secondPlayer = makingDifferentPlayers();
            while (playing == true)
            {
                int playerOneInput = convertingInput(firstPlayer.getinput());
                int playerTwoInput;
                if(onePlayer == true)
                {
                    playerTwoInput = computerInput();
                }
                else
                {
                    playerTwoInput = convertingInput(secondPlayer.getinput());
                }
                
                decidewinner(firstPlayer, secondPlayer, playerOneInput, playerTwoInput);
            }

        }
        public int convertingInput(string input)
        {
            return moves.IndexOf(input);
        }


    }
}
