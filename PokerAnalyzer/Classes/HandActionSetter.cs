public static class HandCalculations
{
    public static Dictionary<int, string> PositionNumbersDictionary = new(){
        {0,"utg"},
        {1,"utg1"},
        {2,"utg2"},
        {3,"lj"},
        {4,"hj"},
        {5,"co"},
        {6,"btn"},
        {7,"sb"},
        {8,"bb"},
        {9,"??"},
        };
   
    public static void DefinePlayersAction(Hand handOBJ)
    {
       
        int changer = 9 - handOBJ.table_limit;
        string[] hand = handOBJ.hand;
        // RFI
        int numberofiteration = handOBJ.preflop_index + handOBJ.table_limit;
      
        
        for (int i = handOBJ.preflop_index; i < numberofiteration-1; i++)
        {


            char action = hand[i][hand[i].IndexOf(':') + 2];
          
            if (action == 'r')
            {
                if (hand[i].Contains("all-in"))
                {
                    
                    handOBJ.ListofPlayers[PositionNumbersDictionary[i - handOBJ.preflop_index + changer]].action = Action.OpenShove;
                    break;
                }
                handOBJ.ListofPlayers[PositionNumbersDictionary[i - handOBJ.preflop_index + changer]].action = Action.RFI;

                break;
            }
            if (action == 'c' && i < numberofiteration-2)
            {

            if (hand[i].Contains("all-in"))
                    {
                    handOBJ.ListofPlayers[PositionNumbersDictionary[i - handOBJ.preflop_index + changer]].action = Action.OpenShove;
                    return;
                }
                handOBJ.ListofPlayers[PositionNumbersDictionary[i - handOBJ.preflop_index + changer]].action = Action.Call;
                return;
            }
            if (i == numberofiteration-2 && action == 'c')
            {

                if (hand[i].Contains("all-in"))
                {
                    handOBJ.ListofPlayers[PositionNumbersDictionary[i - handOBJ.preflop_index + changer]].action = Action.OpenShove;
                    
                }else handOBJ.ListofPlayers["sb"].action = Action.Limp;
                
            }

        }
    }
    public static void DefinePlayerParameters(string[] hand, int i, ref string number, out string name)
    {

        bool ishero = hand[i].Contains("Hero");
        int starting_index = ishero ? 14 : 18;
        name = ishero ? "Hero" : hand[i].Substring(8, 7);
        for (int j = starting_index; j < hand[i].Length; j++)
        {
            if (hand[i][j] == ' ')
            {
                number = hand[i].Substring(starting_index, j - starting_index).Replace(",", "").Replace(" ", "");
                break;
            }
        }


    }
   

}