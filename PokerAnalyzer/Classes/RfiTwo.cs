public class RFItwo
{
    public static void Calculate_RFI(List<Hand> hands, float minstack, float maxstack)
    {
        int blindeslessthan = 1000;
        float[] allhands = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        float[] openshovedhands = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        float[] openedhands = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        float sblimps = 0;
        Dictionary<int, string> Position = HandCalculations.PositionNumbersDictionary;

        foreach (var hand in hands)
        {
            if (hand.blind < blindeslessthan) continue;


            int changer = 9 - hand.table_limit;
            for (int i = 0; i < 8 - changer; i++)
            {
                Player player = hand.ListofPlayers[Position[i + changer]];
                Action playeraction = player.action;
                if (player.bb_stack > minstack && player.bb_stack < maxstack)
                {
                    if (playeraction == Action.OpenShove)
                    {
                        openshovedhands[i + changer]++;
                        break;
                    }
                    if (playeraction == Action.Call) { break; }
                    if (playeraction == Action.Fold) allhands[i + changer]++;
                    if (playeraction == Action.Limp)
                    {
                        sblimps++;
                        allhands[i + changer]++;
                    }
                    if (playeraction == Action.RFI )
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
        System.Console.WriteLine("Blinds less than :" + blindeslessthan/2 + " / "+blindeslessthan);
        System.Console.WriteLine(minstack+"bb - "+maxstack+"bb");
        for (int i = 0; i < 8; i++)
        {
            System.Console.WriteLine($"{Position[i]}" +
            $"  RFI - {Math.Round(openedhands[i] * 100f / allhands[i],1)} %" +
            $"       Open shove   - {Math.Round(openshovedhands[i]* 100f / allhands[i],1)} %    //////        opened:  {openedhands[i]}      all : {allhands[i]}");
        }
        System.Console.WriteLine($"sb" +
            $"  Limp - {Math.Round(sblimps * 100f / allhands[7],1)} %" +
            $"                               //////        limped:  {sblimps}      all : {allhands[7]}");



    }
}