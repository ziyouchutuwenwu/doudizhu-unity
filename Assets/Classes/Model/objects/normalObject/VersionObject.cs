using UnityEngine;
using System.Collections;

public class VersionObject
{
    private string _platform = null;
    private string _url = null;

    public void reset()
    {
        _platform = "";
        _url = "";
    }

    public string getPlatform()
    {
        return _platform;
    }

    public void setPlatform(string platform)
    {
        _platform = platform;
    }

    public string getUrl()
    {
        return _url;
    }

    public void setUrl(string url)
    {
        _url = url;
    }
}
