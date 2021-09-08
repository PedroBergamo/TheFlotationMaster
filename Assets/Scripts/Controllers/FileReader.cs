using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;

public class FileReader {

    static TextAsset ScoreBoardXmlFile;

    public static List<PlayerScore> XmlScores()
    {
        ScoreBoardXmlFile = Resources.Load<TextAsset>("FirstLevel");
        return Deserialize(ScoreBoardXmlFile.text);
    }

    public static string Serialize(List<PlayerScore> toSerialize)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(toSerialize.GetType());
        using (StringWriter textWriter = new StringWriter())
        {
            xmlSerializer.Serialize(textWriter, toSerialize);
            return textWriter.ToString();
        }
    }

    public static List<PlayerScore> Deserialize(string input)
    {
        XmlSerializer ser = new XmlSerializer(typeof(List<PlayerScore>));

        using (StringReader sr = new StringReader(input))
            return (List<PlayerScore>)ser.Deserialize(sr);
    }
}