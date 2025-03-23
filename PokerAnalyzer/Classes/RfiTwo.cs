public class RFItwo
{
    public static void Calculate_RFI(List<Hand> hands, float minstack, float maxstack)
    {
        float[] allhands = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        float[] openedhands = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        Dictionary<int, string> Position = HandCalculations.PositionNumbersDictionary;

        foreach (var hand in hands)
        {
            int changer = 9 - hand.table_limit;
            for (int i = 0; i < 8 - changer; i++)
            {
                Action playeraction = hand.ListofPlayers[Position[i + changer]].action;
               // if (playeraction == Action.Call) { callrfi++; break; }
                if (playeraction == Action.Fold || playeraction == Action.Limp) allhands[i + changer]++;
                if (playeraction == Action.RFI || playeraction == Action.Call)
                {
                    openedhands[i + changer]++;
                    allhands[i + changer]++;
                    break;
                }


            }
            
            
        }
      for (int i = 0; i < 8; i++)
        {
            System.Console.WriteLine($"{Position[i]}" +
            $"  RFI - {(int)(openedhands[i] * 100f/allhands[i])} %"+
            $"         //////        opened:  {openedhands[i]}      all : {allhands[i]}" );
        }



    }
}