
string[] file = LoadAllFilesToArray();

List<Hand> Listofhands = new();
Listofhands = LoadHands(file);


foreach (var hand in Listofhands)
{
    
    HandCalculations.DefinePlayersAction(hand);
  
}
HandCalculations.Calculate_RFI("utg", Listofhands);
System.Console.WriteLine($"Loaded {Listofhands.Count} hands");


string[] LoadAllFilesToArray()
{
    string rootpath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
    string folderPath = Path.Combine(rootpath, "Data");

    // Pobranie wszystkich plików TXT w katalogu
    string[] files = Directory.GetFiles(folderPath, "*.txt");

    var allLines = new List<string>();

    foreach (string path in files)
    {
        string[] lines = File.ReadAllLines(path); // Wczytuje cały plik do pamięci
        allLines.AddRange(lines); // Dodaje linie do listy
    }

    return allLines.ToArray(); // Konwersja listy na tablicę
}

// TERRIBLE CODE, NEEDS REWRITING
List<Hand> LoadHands(string[] file)
{
    List<Hand> Listofhands = new();
    Hand hand;
    int index_holder = -1;
    int preflop_index = 0;
    int flop_index = 0;
    for (int i = 0; i < file.Length; i++)
    {
        bool isthereflop = false;
        if (file[i] == "")
        {
            if (file[index_holder + 1].Contains("ShortDeck") || file[index_holder + 1].Contains("PLO"))
            {
                System.Console.WriteLine(file[index_holder + 1]);
                i += 3;
                index_holder++;
                
            }
            else
            {
                int length = i - index_holder;
                string[] temp = new string[length];
                for (int j = index_holder + 1; j < i; j++)
                {
                    temp[j - index_holder - 1] = file[j];
                    FindIndexes(ref flop_index, ref preflop_index, j, i, index_holder);
                    if (file[j].Contains("FLOP")) isthereflop = true;
                }
                flop_index = !isthereflop ? -1 : flop_index;
                hand = new(temp, flop_index, preflop_index, CalculateBlind(file, index_holder));
                Listofhands.Add(hand);
                i++;
                index_holder = i;
            }
        }

    }

    return Listofhands;

}
float CalculateBlind(string[] hand, int index_holder)
{
    int length = hand[index_holder + 1].IndexOf(')') - 1 - hand[index_holder + 1].IndexOf('/');
    
    int indexstart = hand[index_holder + 1].IndexOf('/') + 1;
    return float.Parse(hand[index_holder + 1].Substring(indexstart, length).Replace(",", "").Replace(" ", ""));

}
void FindIndexes(ref int flop_index, ref int preflop_index, int j, int i, int index_holder)
{

    if (j != i - 1)
    {
        if (file[j].Contains("Dealt") && !file[j + 1].Contains("Dealt")) preflop_index = j - index_holder;
        if (file[j].Contains("FLOP"))
        {
            if (file[j - 1].Contains("shows")) flop_index = -1;
            else flop_index = j - index_holder;
        }
      
        
            
        
        
    }
}