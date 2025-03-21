public class Hand
{
    public Hand(string[] hand){

        for (int i = 2; i < hand.Length; i++)
        {
            if (hand[i].Contains("Seat")) player_count++;
            else break;
       }
    }
    public int player_count = 0;

    
}