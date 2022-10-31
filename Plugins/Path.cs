namespace OpenVMS.Service;

public class Path
{
    public string Join(string[] paths)
    {
        var result = System.AppDomain.CurrentDomain.BaseDirectory;
        foreach (var path in paths)
        {
            result += "/" + path;
        }

        return result;
    }
}