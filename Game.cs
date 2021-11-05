using System;
using System.Linq;

namespace game
{
    public class Game
    {
        string[] gameMoves;
        int oneHalfMoves;
        public int[,] rules;
        string[] GameResult = {"You Lose!", "Draw!","You Win!"};
        public void PrintChooseMassage()
        {
            Console.WriteLine("Available moves:");
            for (int i = gameMoves.GetLowerBound(0); i <= gameMoves.GetUpperBound(0); i++)
                Console.WriteLine("{0,2} - {1}", i+1, gameMoves[i]);
            Console.Write(" 0 - exit\n ? - help\nEnter your move: ");
        }
        public void GetResultGame(int compMove, int userMove, byte[] key)
        {
            Console.WriteLine("Your move: {0}\nComputer move: {1}\n{2}", gameMoves[userMove], gameMoves[compMove], GameResult[rules[userMove,compMove]+1]);
            Console.WriteLine("HMAC Key: {0}", Convert.ToHexString(key));
        }
        public void CreateRules(int argsLength)
        {
            Rules rulesGenerator = new Rules();
            this.rules = rulesGenerator.CreateRules(argsLength);
        }
        public string UserChoose()
        {
            return Console.ReadLine();
        }
        public byte[] CompChoose()
        {
            byte[] compChoose = new Byte[1];
            HMACGenerator HMACgen = new HMACGenerator();
            compChoose[0] = Convert.ToByte(HMACgen.GetRandomBytes(1)[0] % (this.gameMoves.Length));
            return compChoose;
        }
        public bool ValidateInputArgs(string[] args)
        {
            string ErrorMassage = "";
            if(args.Length % 2 == 0)
            {
                ErrorMassage = "Error: Number args is even!";
            }
            if(args.Length < 3)
            {
                ErrorMassage = "Error: Number args < 3!";
            }
            if(args.Distinct().Count() != args.Length)
            {
                ErrorMassage = "Error: Args is no unique!";
            }
            if(ErrorMassage.Length != 0)
            {
                Console.Write("{0} Correct: rock paper scissors", ErrorMassage);
                return false;
            }
            else
            {
                this.gameMoves = args;
                this.oneHalfMoves = this.gameMoves.Length/2;
                return true;
            }
        }
    }
}