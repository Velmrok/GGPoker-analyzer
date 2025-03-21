// See https://aka.ms/new-console-template for more information
string[] file = LoadFile();

for (int i = 0; i < file.Length; i++)
{
     if (file[i] == "") System.Console.WriteLine(file[i+1]);
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