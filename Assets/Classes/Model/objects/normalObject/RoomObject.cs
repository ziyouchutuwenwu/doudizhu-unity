using UnityEngine;
using System.Collections;

public class RoomObject {

    private string _id;

    public void reset()
    {
        _id = "";
    }

    public string getId()
    {
        return _id;
    }

    public void setId(string id)
    {
        _id = id;
    }
}
