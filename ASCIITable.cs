using ConsoleTables;
using System.Collections.Generic;
using System.Linq;

namespace game
{
    public class ASCIITable
    {
        public void PrintTable(string[] args, int[,] rules)
        {
            List<string> argsList = new List<string>(args);

            argsList.Insert(0, "PC/User");
            
            var table = new ConsoleTable(argsList.ToArray());
            for (int i = 0; i < args.Length; i++)
            {
                var rowTable = this.GetRow(rules,i).Select(x =>(x == 0 ? "DRAW!" : x > 0 ? "LOSE" : "WIN")).ToArray().ToList();
                rowTable.Insert(0, args[i]);
                table.AddRow(rowTable.ToArray());
            }
            table.Write();
        }
        private int[] GetRow(int[,] matrix, int rowNumber)
        {
            return Enumerable.Range(0, matrix.GetLength(1)).Select(x => matrix[rowNumber, x]).ToArray();
        }
    }
}