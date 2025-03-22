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
        };
    public static void Calculate_RFI(string position, List<Hand> hands)
    {
        bool hasanyoneRFI = false;
        float[] allhands = { 0, 0, 0,    0, 0, 0,    0, 0, 0 };
        float[] openedhands = { 0, 0, 0,    0, 0, 0,    0, 0, 0 };
        foreach (var hand in hands)
        {
            for (int i = 0; i < 8; i++)
            {
                if (hand.ListofPlayers["sb"].action == Action.Limp) allhands[7]++;
                if (hand.ListofPlayers.ContainsKey(PositionNumbersDictionary[i]) &&
            hand.ListofPlayers[PositionNumbersDictionary[i]].action == Action.RFI)
                {
                    hasanyoneRFI = true;
                    openedhands[i]++;
                    for (int j = 9 - hand.table_limit; j < i + 1; j++)
                    {
                        allhands[j]++;
                    }
                }
            }
            if (!hasanyoneRFI && !(hand.ListofPlayers["sb"].action == Action.Limp))
            {
                for (int j = 9-hand.table_limit; j <8 ; j++)
                {
                    allhands[j]++;
                }
            }
           
           
        }
        for (int i = 0; i < 9; i++)
        {
            System.Console.WriteLine($"{PositionNumbersDictionary[i]}" +
            $"    RFI - {openedhands[i] * 100f/allhands[i]} %"+
            $"              //////           opened:  {openedhands[i]}      all : {allhands[i]}" );
        }
       
    }
    public static void DefinePlayersAction(Hand handOBJ)
    {
       
        int changer = 9 - handOBJ.table_limit;
        string[] hand = handOBJ.hand;
        // RFI
        for (int i = handOBJ.preflop_index; i < handOBJ.flop_index; i++)
        {


            char action = hand[i][hand[i].IndexOf(':') + 2];

            if (action == 'r')
            {
               
                handOBJ.ListofPlayers[PositionNumbersDictionary[i - handOBJ.preflop_index + changer]].action = Action.RFI;

                break;
            }
            if (i == handOBJ.flop_index - 1)
            {
                handOBJ.ListofPlayers["sb"].action = Action.Limp;
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
        int seat = i - 1;
        int button_seat = 0;

        for (int j = 1; j < hand[1].Length; j++)
        {
            if (hand[1][j - 1] == 'i' && hand[1][j] == 's')
            {
                button_seat = int.Parse(hand[1][j - 3].ToString());
                break;
            }
        }
        for (int j = 2; j < 12; j++)
        {
            if (hand[j].Contains($"Seat {button_seat}"))
            {
                button_seat = j;
                break;
            }
        }
        
        if (seat < button_seat) seat += table_limit;
        //System.Console.WriteLine(seat - button_seat);
        switch (seat - button_seat)
        {
            case 0:
                return "btn";
            case 1:
                return "sb";
            case 2:
                return "bb";
            case 3:
                return PositionNumbersDictionary[9-table_limit];
            case 4:
               return PositionNumbersDictionary[10-table_limit];
            case 5:
             return PositionNumbersDictionary[11-table_limit];
            case 6:
               return PositionNumbersDictionary[12-table_limit];
            case 7:
                return PositionNumbersDictionary[13 - table_limit];
            case 8:
                return "co";
            default:
                break;
        }
        return "ERROR";
        
    }

}