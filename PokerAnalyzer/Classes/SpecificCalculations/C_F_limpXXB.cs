public static class CalculateSpecific
{

    public static void Fold_to_sb_pot_bet_after_XX(List<Hand> handlist)
    {

        int sbfoldscounter = 0;
        int sbNotfoldscounter = 0;
        foreach (var hand in handlist)
        {
            bool isitlimpedpot = false;


            foreach (var p in hand.ListofPlayers)
            {
               
                //if(p.Value.action == Action.Limp)System.Console.WriteLine(p.Value.action + "   " + hand.ListofPlayers["bb"].action);
                if (p.Value.action == Action.Limp && hand.ListofPlayers["bb"].action == Action.Call) isitlimpedpot = true; break;

            }

            
            if (hand.isthereflop && isitlimpedpot)
            {

                string[] flop = {
        hand.hand[hand.flop_index], // after ** flop, first action
        hand.hand[hand.flop_index+1], // second action
        hand.hand[hand.flop_index+3], // first action on turn
        hand.hand[hand.flop_index+4] // second action on turn
        };

                //RTQ23WAFTQ3GG83021T31T38HT38=H3TH8T318QHJ
                char[] action = {
            flop[0][flop[0].IndexOf(':') + 2], // first flop action
            flop[1][flop[1].IndexOf(':') + 2],  // second flop action
            flop[2][flop[2].IndexOf(':') + 2], // 3
            flop[3][flop[3].IndexOf(':') + 2], // 4
        };
                float blindval = hand.blind;

                if (!flop[0].Contains("shows"))
                {
                    bool flopXX = action[0] == 'c' && action[1] == 'c';
                    bool turnBF = action[2] == 'b' && action[3] == 'f';
                    bool turnBC_or_BR = action[2] == 'b' && !(action[3] == 'f');
                    bool isbetclosetopot = false;

                    if (flopXX && !flop[2].Contains("all") && !flop[2].Contains("checks"))
                    {

                        int index = flop[2].LastIndexOf('s') + 2;
                        int betnum = int.Parse(flop[2].Substring(index).Replace(",", "").Replace(" ", "")); /// find bets X,XXX where X are numbers
                        isbetclosetopot = betnum / hand.blind > 2f && betnum / hand.blind < 4f;
                    }


                    if (turnBF && isbetclosetopot)
                    {

                        sbfoldscounter++;
                    }
                    if (turnBC_or_BR && isbetclosetopot)
                    {


                        sbNotfoldscounter++;
                    }
                }
            Foreachend:
                continue;
            }

        }
        int all = sbfoldscounter + sbNotfoldscounter;
        System.Console.WriteLine("SB folds to bet after     LIMP CALL ->CHECK CHECK -> BET FOLD " +
             $"  :    {Math.Round(sbfoldscounter * 100f / all, 1)} %   //////      folded : {sbfoldscounter}   all : {all}");

    }
}
/*
ed3ac3ca: folds
6c288ea1: folds
Hero: calls 16,000
*** FLOP *** [Ks Th Jc]
Hero: checks
34d0e592: bets 20,585
Hero: folds
Uncalled bet (20,585) returned to 34d0e592
*** SHOWDOWN ***
*/