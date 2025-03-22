using System.Text.RegularExpressions;

public class Hand
{
    public Hand(string[] _hand, int _flop_index, int _preflop_index)
    {

        flop_index = _flop_index;
        preflop_index = _preflop_index;
        hand = new string[_hand.Length];
        hand = _hand;



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

    string LoadTag()
    {
        return hand[0].Substring(11, 13);

    }
    void FindPlayerCount()
    {
        for (int i = 2; i < 10; i++)
        {
            if (!hand[i + 1].Contains("Seat"))
            {
              
                table_limit = int.Parse(hand[i][5].ToString());
                  System.Console.WriteLine(table_limit);
                break;
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
                    player = new(int.Parse(number), name, HandCalculations.DefinePlayerSeat(i, table_limit, hand));
                    dict.Add(player.position, player);
                }
               
            }
            else break;
        }
        
        return dict;

    }

   
    


}