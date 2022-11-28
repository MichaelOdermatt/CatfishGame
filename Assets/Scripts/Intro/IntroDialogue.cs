using System.Collections.Generic;
using System.Xml;

public class IntroDialogue 
{
    private XmlTextReader reader;
    string URLString = "Assets/Dialogue/IntroDialogue.xml";
    private List<string> lines = new List<string>();
    private int currentStringIndex = 0;

    public IntroDialogue()
    {
        reader = new XmlTextReader(URLString); 
        while (reader.Read())
        {
            if (reader.Name == "item")
            {
                string line = reader.ReadString();
                lines.Add(line);
            }
        }
    }

    public string? GetNextLine()
    {
        if (currentStringIndex >= lines.Count)
            return null;

        string line = lines[currentStringIndex];
        currentStringIndex++;
        return line;
    }
}
