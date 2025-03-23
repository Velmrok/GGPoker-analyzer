public static class RFI{
     public static void Calculate_RFI(List<Hand> hands,float minstack, float maxstack)
    {
        bool hasanyoneRFI = false;
        
        float[] allhands = { 0, 0, 0,    0, 0, 0,    0, 0, 0 };
        float[] openedhands = { 0, 0, 0,    0, 0, 0,    0, 0, 0 };
        Dictionary<int, string> Position = HandCalculations.PositionNumbersDictionary;
       

        foreach (var hand in hands)
        {
            for (int i = 0; i < 8; i++)
            {
                if (hand.ListofPlayers["sb"].action == Action.Limp &&
            hand.ListofPlayers["sb"].bb_stack > minstack &&
            hand.ListofPlayers["sb"].bb_stack < maxstack)
                {
                    allhands[7]++;
                    break;
                }
                if (hand.ListofPlayers.ContainsKey(Position[i]) &&
            hand.ListofPlayers[Position[i]].bb_stack > minstack &&
            hand.ListofPlayers[Position[i]].bb_stack < maxstack
            )
                {


                    if (hand.ListofPlayers.ContainsKey(Position[i]) &&
                hand.ListofPlayers[Position[i]].action == Action.RFI)
                    {
                        hasanyoneRFI = true;
                        openedhands[i]++;
                        for (int j = 9 - hand.table_limit; j < i + 1; j++)
                        {
                            allhands[j]++;
                        }
                    }


                }
            }
            if (!hasanyoneRFI && !(hand.ListofPlayers["sb"].action == Action.Limp) &&
             hand.ListofPlayers["sb"].bb_stack > minstack &&
            hand.ListofPlayers["sb"].bb_stack < maxstack)
            {
                for (int j = 9 - hand.table_limit; j < 8; j++)
                {
                    allhands[j]++;
                }
            }

        }
        for (int i = 0; i < 9; i++)
        {
            System.Console.WriteLine($"{Position[i]}" +
            $"    RFI - {openedhands[i] * 100f/allhands[i]} %"+
            $"              //////           opened:  {openedhands[i]}      all : {allhands[i]}" );
        }
       
    }
}