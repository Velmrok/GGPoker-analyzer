// See https://aka.ms/new-console-template for more information
LoadFile();



void LoadFile()
{
    string rootpath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
      string path = Path.Combine(rootpath, "Data", "test.txt");
       
        if (File.Exists(path))
        {
            string[] lines = File.ReadAllLines(path); 

            foreach (string line in lines)  
            {
                Console.WriteLine(line);
            }
        }
        else
        {
            Console.WriteLine("Plik nie istnieje.");
        }
}