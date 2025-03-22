using System.Text.RegularExpressions;

public class Hand
{
    public Hand(string[] _hand, int _flop_index, int _preflop_index)
    {

        flop_index = _flop_index;
        preflop_index = _preflop_index;
        hand = new string[_hand.Length];
        hand = _hand;
        
        if(hand[1].IndexOf('-')>=1) table_limit = int.Parse(hand[1][hand[1].IndexOf('-') - 1].ToString());
       
        
        tag = LoadTag();
        CountRFIperc();
        ListofPlayers = CreatePlayerList();
        System.Console.WriteLine(tag);
        foreach (var item in ListofPlayers)
        {
            System.Console.WriteLine(item.position + "   " + item.name);
        }
        System.Console.WriteLine();
    }
    List<Player> ListofPlayers = new();

    public string tag;
    public string[] hand;
    public int table_limit;
    public int flop_index;
    public int preflop_index;

    void CountRFIperc()
    {


        if (flop_index != -1)
        {
            // System.Console.WriteLine(tag);
            // System.Console.WriteLine(hand[flop_index]);
            // System.Console.WriteLine(hand[flop_index + player_count]);
        }

    }
    string LoadTag()
    {
        return hand[0].Substring(11, 13);

    }
    List<Player> CreatePlayerList()
    {
        List<Player> list = new();
        for (int i = 2; i < hand.Length; i++)
        {
            if (hand[i].Contains("Seat"))
            {
                Player player;

                string number = "";
                string name;
                DefinePlayerParameters(i, ref number, out name);

                if (!(number == ""))
                {
                    player = new(int.Parse(number), name,DefinePlayerSeat(i));
                    list.Add(player);
                }

            }
            else break;
        }
        // DefinePlayersAction();
        return list;

    }

    void DefinePlayerParameters(int i, ref string number, out string name)
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
    string DefinePlayerSeat(int i)
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
        System.Console.WriteLine(seat + " seat");
        System.Console.WriteLine(button_seat + " butnnseat");
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
                if (table_limit == 8) return "utg";
                if (table_limit == 7) return "utg1";
                if (table_limit == 6) return "lj";
                break;
            case 4:
                if (table_limit == 8) return "utg1";
                if (table_limit == 7) return "lj";
                if (table_limit == 6) return "hj";
                break;
            case 5:
                if (table_limit == 8) return "lj";
                if (table_limit == 7) return "hj";
                if (table_limit == 6) return "co";
                break;
            case 6:
                if (table_limit == 8) return "hj";
                if (table_limit == 7) return "co";
                break;
            case 7:
                return "co";
            default:
                break;
        }
        return "ERROR";
        
    }
    // Action DefinePlayersAction()
    // {

    //     string action = "";
    //     for (int j = preflop_index; j < flop_index; j++)
    //     {
    //         bool ishero = hand[j].Contains("Hero");
    //         if (hand[j].Contains(name))
    //         {
    //             action = ishero ? hand[j].Substring(6) : hand[j].Substring(10);
    //         }

    //     }
    //     switch (action)
    //     {
    //         case "Folds":
    //             break;
    //         case "Folds":
    //             break;
    //         default:
    //             break;
    //     }
    // }


}