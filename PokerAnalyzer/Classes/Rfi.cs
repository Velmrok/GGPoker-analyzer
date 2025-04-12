public class RFI
{
    public static void Calculate_RFI(List<Hand> hands, float minstack, float maxstack, int bbmorethan = 0, bool onlyhero=false)
    {
        var positionStats = new Dictionary<int, PositionStats>();
        var positionStatsHero =  new Dictionary<int, PositionStats>();
        for (int i = 0; i < 9; i++)
        {
            positionStats[i] = new();
            positionStatsHero[i] = new();
        }


        float[] Heroallhands = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        float[] Heroopenshovedhands = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        float[] Heroopenlimpedhands = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        float[] Heroopenedhands = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        Dictionary<int, string> Position = HandCalculations.PositionNumbersDictionary;

        foreach (var hand in hands)
        {

            if (hand.blind < bbmorethan) continue;


            int changer = 9 - hand.table_limit;
            for (int i = 0; i < 8 - changer; i++)
            {
                Player player = hand.ListofPlayers[Position[i + changer]];
                Action playeraction = player.action;
                if (player.bb_stack > minstack && player.bb_stack < maxstack)
                {
                    PositionStats  stats = positionStats[i + changer];
                    PositionStats herostats = positionStatsHero[i + changer];
                    if (player.name == "Hero") {
                        herostats.AllHands++;
                        switch (player.action)
                        {
                            case Action.Call:
                                herostats.OpenLimpedHands++;
                                break;
                            case Action.OpenShove:
                                herostats.OpenShovedHands++;
                                break;
                            case Action.RFI:
                                herostats.OpenedHands++;
                                break;
                            case Action.Limp:
                                herostats.OpenLimpedHands++;
                                break;

                        }
                    }
                    if (player.name == "Hero" && player.action != Action.Fold) break;
 
                 
                    if (playeraction == Action.OpenShove)
                    {
                        stats.OpenShovedHands++;
                        stats.AllHands++;
                        break;
                    }
                    else if (playeraction == Action.Call || playeraction == Action.Limp)
                    {
                        stats.OpenLimpedHands++;
                        stats.AllHands++;
                        break;
                    }
                    else if (playeraction == Action.Fold)
                    {
                        stats.AllHands++;
                    }
                    else if (playeraction == Action.RFI)
                    {
                        stats.OpenedHands++;
                        stats.AllHands++;
                        break;
                    }
                }
                if (playeraction == Action.RFI || playeraction == Action.Limp) break;


            }


        }
        System.Console.WriteLine();
        System.Console.WriteLine("Blinds more than :" + bbmorethan / 2 + " / " + bbmorethan);
        System.Console.WriteLine(minstack + "bb - " + maxstack + "bb");
        if (onlyhero)
        {
            foreach (var kv in positionStatsHero)
        {
            string posName = Position.ContainsKey(kv.Key) ? Position[kv.Key] : $"Pos{kv.Key}";
            Console.WriteLine($"{posName}  {kv.Value}");
        }
        }
        else
        {
              foreach (var kv in positionStats)
        {
            string posName = Position.ContainsKey(kv.Key) ? Position[kv.Key] : $"Pos{kv.Key}";
            Console.WriteLine($"{posName}  {kv.Value}");
        }
            
        }
      




    }



}