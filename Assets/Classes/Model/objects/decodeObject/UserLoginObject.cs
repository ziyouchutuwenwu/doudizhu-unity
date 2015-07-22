using UnityEngine;
using System.Collections.Generic;

public class UserLoginObject
{
    private bool _isError;
    private bool _islogin;

    public void reset()
    {
        _isError = false;
        _islogin = false;
    }

    public bool getIsError()
    {
        return _isError;
    }

    public void setIsError(bool isError)
    {
        _isError = isError;
    }

    public bool getIsLogin()
    {
        return _islogin;
    }

    public void setIsLogin(bool isLogin)
    {
        _islogin = isLogin;
    }
}