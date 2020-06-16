using System.IO;
using System.Xml.Serialization;

public class XMLSerializer
{
    public static T Deserialize<T>(string input) where T : class
    {
        var ser = new XmlSerializer(typeof(T));
        using (var sr = new StringReader(input))
        {
            return (T)ser.Deserialize(sr);
        }
    }

    public static string Serialize<T>(T ObjectToSerialize)
    {
        var xmlSerializer = new XmlSerializer(ObjectToSerialize.GetType());
        using (var textWriter = new StringWriter())
        {
            xmlSerializer.Serialize(textWriter, ObjectToSerialize);
            return textWriter.ToString();
        }
    }
}
