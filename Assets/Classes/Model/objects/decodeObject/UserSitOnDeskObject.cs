using UnityEngine;
using System.Collections;

public class UserSitOnDeskObject {

    private bool _isError;

    public void reset()
    {
        _isError = false;
    }

    public bool getError()
    {
        return _isError;
    }

    public void setError(bool isError)
    {
        _isError = isError;
    }
}