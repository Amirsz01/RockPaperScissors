namespace game
{
    public class Rules
    {
        public int[,] CreateRules(int argsLength)
        {
            int[,] rules = new int[argsLength, argsLength];
            for (int i = 0; i < argsLength; i++)
            {
                for (int j = i; j < argsLength; j++)
                {
                    if(i == j) 
                    {
                        rules[i,j] = rules [j,i] = 0;
                        continue;
                    }
                    if((i>j && (i - j) > argsLength/2) || (j > i && (j-i <= argsLength/2)))
                    {
                        rules[i,j] = -1;
                        rules[j,i] = 1; 
                    }
                    else
                    {
                        rules[i,j] = 1; 
                        rules[j,i] = -1; 
                    }
                }
            }
            return rules;
        }
    }
}