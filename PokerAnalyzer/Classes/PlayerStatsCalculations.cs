public class PlayerStatsCalculations
{
    public static float CalculateBigBlind(string[] hand, int index_holder)
{
    int length = hand[index_holder + 1].IndexOf(')') - 1 - hand[index_holder + 1].IndexOf('/');
    
    int indexstart = hand[index_holder + 1].IndexOf('/') + 1;
    return float.Parse(hand[index_holder + 1].Substring(indexstart, length).Replace(",", "").Replace(" ", ""));

}
}