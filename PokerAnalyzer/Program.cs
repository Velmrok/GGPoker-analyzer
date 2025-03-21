// See https://aka.ms/new-console-template for more information
string[] file = LoadFile();
List<Hand> Listofhands = new();
Listofhands = LoadHands(file);
foreach (var item in Listofhands)
{
    System.Console.WriteLine(item.player_count);
}

string[] LoadFile()
{
    string rootpath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
    string path = Path.Combine(rootpath, "Data", "test.txt");

    if (File.Exists(path))
    {
        return File.ReadAllLines(path);


    }
    else
    {
        return null;
    }

}
List<Hand> LoadHands(string[] file)
{
    List<Hand> Listofhands = new();
    Hand hand;
    int index_holder = -1;
    for (int i = 0; i < file.Length; i++)
    {
        if (file[i] == "")
        {
            int length = i - index_holder;
            string[] temp = new string[length];
            for (int j = index_holder + 1; j < i; j++)
            {
                temp[j - index_holder - 1] = file[j];
            }
            hand = new(temp);
            Listofhands.Add(hand);


            i++;
            index_holder = i;
        }
    }
    return Listofhands;

}