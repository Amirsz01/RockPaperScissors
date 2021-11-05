using System;
namespace game
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            HMACGenerator HMACgen = new HMACGenerator();
            ASCIITable table = new ASCIITable();
            if(game.ValidateInputArgs(args))
            {
                var key = HMACgen.GetKey();
                var compChoose = game.CompChoose();

                game.CreateRules(args.Length);
                HMACgen.GetHMAC(key, compChoose);
                game.PrintChooseMassage();
                var userChoose = game.UserChoose();
                switch(userChoose)
                {
                    case "0": return;
                    case "?": 
                        table.PrintTable(args, game.rules);
                        return;
                }
                game.GetResultGame(compChoose[0], Convert.ToInt32(userChoose)-1, key); 
            }
            else
                return;          
        }
    }
}
