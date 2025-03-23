public class LoadFiles
{
    public static string[] LoadAllFilesToArray()
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
}