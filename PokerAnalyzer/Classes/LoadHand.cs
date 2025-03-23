public class LoadHand
{
    static string[] LoadedFile = LoadFiles.LoadAllFilesToArray();
    public static List<Hand> LoadHands()
    {
        
        List<Hand> Listofhands = new();
        Hand hand;
        int index_holder = -1;
        int preflop_index = 0;
        int flop_index = 0;


        for (int i = 0; i < LoadedFile.Length; i++)
        {
            bool isthereflop = false;
            if (LoadedFile[i] == "")
            {
                if (LoadedFile[index_holder + 1].Contains("ShortDeck") || LoadedFile[index_holder + 1].Contains("PLO"))
                {
                    System.Console.WriteLine(LoadedFile[index_holder + 1]);
                    i += 3;
                    index_holder++;

                }
                else
                {
                    int length = i - index_holder;
                    string[] temp = new string[length];
                    for (int j = index_holder + 1; j < i; j++)
                    {
                        temp[j - index_holder - 1] = LoadedFile[j];
                        FindIndexes(ref flop_index, ref preflop_index, j, i, index_holder);
                        if (LoadedFile[j].Contains("FLOP")) isthereflop = true;
                    }
                    flop_index = !isthereflop ? -1 : flop_index;
                    hand = new(temp, flop_index, preflop_index, PlayerStatsCalculations.CalculateBlind(LoadedFile, index_holder));
                    Listofhands.Add(hand);
                    i++;
                    index_holder = i;
                }
            }

        }

        return Listofhands;

    }

static void FindIndexes(ref int flop_index, ref int preflop_index, int j, int i, int index_holder)
{
    

    if (j != i - 1)
        {
            if (LoadedFile[j].Contains("Dealt") && !LoadedFile[j + 1].Contains("Dealt")) preflop_index = j - index_holder;
            if (LoadedFile[j].Contains("FLOP"))
            {
                if (LoadedFile[j - 1].Contains("shows")) flop_index = -1;
                else flop_index = j - index_holder;
            }





        }
}
}