public class RFI
{
    public static void Calculate_RFI(List<Hand> hands, float minstack, float maxstack, int bblessthan = 0)
    {

        float[] allhands = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        float[] openshovedhands = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        float[] openlimpedhands = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        float[] openedhands = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        
        Dictionary<int, string> Position = HandCalculations.PositionNumbersDictionary;

        foreach (var hand in hands)
        {
            
            if (hand.blind < bblessthan) continue;


            int changer = 9 - hand.table_limit;
            for (int i = 0; i < 8 - changer; i++)
            {
                Player player = hand.ListofPlayers[Position[i + changer]];
                Action playeraction = player.action;
                if (player.bb_stack > minstack && player.bb_stack < maxstack)
                {
                    if (player.name == "Hero") break; // Hero opens
                    if (playeraction == Action.OpenShove) // Player openshove action
                    {
                        openshovedhands[i + changer]++;
                        break;
                    }
                    if (playeraction == Action.Call || playeraction == Action.Limp)// Player limps + on SB
                    {
                        openlimpedhands[i + changer]++;
                        break;
                    }
                    if (playeraction == Action.Fold) allhands[i + changer]++; // Player folds

                    if (playeraction == Action.RFI)
                    {
                        openedhands[i + changer]++;
                        allhands[i + changer]++;
                        break;
                    }
                }
                if (playeraction == Action.RFI || playeraction == Action.Limp) break;


            }


        }
        System.Console.WriteLine();
        System.Console.WriteLine("Blinds more than :" + bblessthan / 2 + " / " + bblessthan);
        System.Console.WriteLine(minstack + "bb - " + maxstack + "bb");
        for (int i = 0; i < 8; i++)
        {
            System.Console.WriteLine($"{Position[i]}" +
            $"  RFI - {Math.Round(openedhands[i] * 100f / allhands[i], 1)} %" +
            $"       Open shove   - {Math.Round(openshovedhands[i] * 100f / allhands[i], 1)} %   " +
            $"        Open limp   - {Math.Round(openlimpedhands[i] * 100f / allhands[i], 1)} %     //////        opened:  {openedhands[i]}      all : {allhands[i]}");
        }




    }


  
}