public static class HandCalculations
{
    public static Dictionary<int, string> PositionNumbersDictionary = new(){
        {0,"utg"},
        {1,"utg1"},
        {2,"lj"},
        {3,"hj"},
        {4,"co"},
        {5,"btn"},
        {6,"sb"},
        {7,"bb"},
        };
    public static void Calculate_RFI(string position, List<Hand> hands)
    {
        foreach (var hand in hands)
        {

        }
    }
    public static void DefinePlayersAction(Hand handOBJ)
    {
        int rfi_index = 0;
        int changer = 8 - handOBJ.table_limit;
        string[] hand = handOBJ.hand;
        for (int i = handOBJ.preflop_index; i < handOBJ.flop_index; i++)
        {
            
            char action = hand[i][hand[i].IndexOf(':') + 2];
           
            if (action == 'r')
            {
               
                handOBJ.ListofPlayers[PositionNumbersDictionary[i - handOBJ.preflop_index+changer]].action = Action.RFI;
              
                break;
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
    public static string DefinePlayerSeat(int i, int table_limit, string[] hand)
    {
        int seat = int.Parse(hand[i][5].ToString());
        int button_seat = 0;

        for (int j = 1; j < hand[1].Length; j++)
        {
            if (hand[1][j - 1] == 'i' && hand[1][j] == 's')
            {
                button_seat = int.Parse(hand[1][j - 3].ToString());
                break;
            }
        }
        
        if (seat < button_seat) seat += table_limit;
        
        switch (seat - button_seat)
        {
            case 0:
                return "btn";
            case 1:
                return "sb";
            case 2:
                return "bb";
            case 3:
                return PositionNumbersDictionary[8-table_limit];
            case 4:
               return PositionNumbersDictionary[9-table_limit];
            case 5:
             return PositionNumbersDictionary[10-table_limit];
            case 6:
               return PositionNumbersDictionary[11-table_limit];
            case 7:
                return "co";
            default:
                break;
        }
        return "ERROR";
        
    }

}