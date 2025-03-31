using System;
using System.IO;

public static class FileHelper
{
    public static void PrependToFile( string[] text2)
    {
        string rootpath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        string filePath = Path.Combine(rootpath,"test.txt");
        string text = "";
        foreach (var item in text2)
        {
            text += "\n" + item;
        }
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("Plik nie istnieje.", filePath);
        }

        string existingContent = File.ReadAllText(filePath);
        string newContent = text + "\n" + existingContent;
        File.WriteAllText(filePath, newContent);
    }
}
