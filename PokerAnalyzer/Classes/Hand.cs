using System.Text.RegularExpressions;

public class Hand
{
    public Hand(string[] _hand, int _flop_index, int _preflop_index, float _blind)
    {

        flop_index = _flop_index;
        preflop_index = _preflop_index;
        hand = new string[_hand.Length];
        hand = _hand;
        blind = _blind;
        

        FindPlayerCount();
        tag = LoadTag();
        ListofPlayers = CreatePlayerDict();
    }
    public Dictionary<string,Player> ListofPlayers = new();

    public string tag;
    public string[] hand;
    public int table_limit;
    public int flop_index;
    public int preflop_index;
    public float stack_bb;
    public float blind;

    string LoadTag()
    {
        return hand[0].Substring(11, 13);

    }
    void FindPlayerCount()
    {
        for (int i = 2; i < 12; i++)
        {
            if (hand[i].Contains("Seat") && hand[i].Contains("chips"))
            {
                table_limit++;
            }
        }
    }
    Dictionary<string, Player> CreatePlayerDict()
    {
        Dictionary<string,Player> dict = new();
        for (int i = 2; i < hand.Length; i++)
        {
            if (hand[i].Contains("Seat"))
            {
                Player player;

                string number = "";
                string name;
                HandCalculations.DefinePlayerParameters(hand, i, ref number, out name);

                if (!(number == ""))
                {
                    player = new(int.Parse(number), name, DefPlayerSeat.DefinePlayerSeat(i, table_limit, hand),blind);
                    
                    dict.Add(player.position, player);
                }
               
            }
            else break;
        }
        
        return dict;

    }

   
    


}