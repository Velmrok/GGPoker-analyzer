
string[] file = LoadFile();

List<Hand> Listofhands = new();
Listofhands = LoadHands(file);
System.Console.WriteLine($"Loaded {Listofhands.Count} hands");
 string[] LoadFile()
    {
        string rootpath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        string path = Path.Combine(rootpath, "Data", "test2.txt");

        if (File.Exists(path))
        {
            // Używamy StreamReader do odczytu linii po linii
            var lines = new List<string>();
            using (var reader = new StreamReader(path))
            {
                string line;
            while ((line = reader.ReadLine()) != null)
            {
                lines.Add(line);
                    
                }
            }
        

            return lines.ToArray(); // Zwracamy tablicę stringów
            
        }
        else
        {
            return null; // Plik nie istnieje
        }
    }
List<Hand> LoadHands(string[] file)
{
    List<Hand> Listofhands = new();
    Hand hand;
    int index_holder = -1;
    int preflop_index = 0;
    int flop_index = 0;
    for (int i = 0; i < file.Length; i++)
    {
        if (file[i] == "")
        {
            int length = i - index_holder;
            string[] temp = new string[length];
            for (int j = index_holder + 1; j < i; j++)
            {
                temp[j - index_holder - 1] = file[j];
                FindIndexes(ref flop_index, ref preflop_index, j, i, index_holder);
                
            }
            hand = new(temp, flop_index, preflop_index);
            Listofhands.Add(hand);
            i++;
            index_holder = i;
        }
         
    }
    
    return Listofhands;

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
        if (file[j].Contains("returned")) flop_index = -1;
        
            
        
        
    }
}