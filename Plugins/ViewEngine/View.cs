using Newtonsoft.Json.Linq;

namespace OpenVMS.Plugins.ViewEngine;

public class View
{
    private static FileStream DocStream;
    private static StreamReader DocReader;

    public View(string location)
    {
        DocStream = new FileStream(location, FileMode.Open);
        DocReader = new StreamReader(DocStream);
    }

    public string Render(JObject jObject)
    {
        var docFile = DocReader.ReadToEnd();
        return docFile;
    }

    
}