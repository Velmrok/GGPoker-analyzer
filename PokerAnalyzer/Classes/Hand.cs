using System.Text.RegularExpressions;

public class Hand
{
    public Hand(string[] _hand, int _flop_index, int _preflop_index)
    {
        flop_index = _flop_index;
        preflop_index = _preflop_index;
        hand = new string[_hand.Length];
        hand = _hand;
        for (int i = 2; i < hand.Length; i++)
        {
            if (hand[i].Contains("Seat")) player_count++;
            else break;
        }
        tag = LoadTag();
        CountRFIperc();
    }
    public string tag;
    public string[] hand;
    public int player_count = 0;
    public int flop_index;
    public int preflop_index;

    void CountRFIperc()
    {
     
       
        if (flop_index!=-1)
        {
            System.Console.WriteLine(tag);
            System.Console.WriteLine(hand[flop_index]);
        }

    }
    string LoadTag()
    {
        return hand[0].Substring(11, 13);
        
    }
    
}