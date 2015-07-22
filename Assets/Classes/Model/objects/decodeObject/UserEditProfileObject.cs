using UnityEngine;
using System.Collections.Generic;

public class UserEditProfileObject
{
    private bool _isError;

    public void reset()
    {
        _isError = false;
    }

    public bool getIsError()
    {
        return _isError;
    }

    public void setIsError(bool isError)
    {
        _isError = isError;
    }
}