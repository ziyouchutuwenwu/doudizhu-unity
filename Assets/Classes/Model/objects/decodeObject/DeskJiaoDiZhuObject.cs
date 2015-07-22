using UnityEngine;
using System.Collections;

public class DeskJiaoDiZhuObject
{
    private UserObject _secondPreviousUserObject;
    private UserObject _firstPreviousUserObject;
    private UserObject _nextUserObject;
    
    private bool _isFirstPreviousUserJiaoDiZhu;
    private bool _isFirstPreviousUserFirstJiaoDiZhu;

    private bool _isSecondPreviousUserJiaoDiZhu;
    private bool _isSecondPreviousUserFirstJiaoDiZhu;

    private bool _isNextUserFirstJiaoDiZhu;

    public void resetPlaying()
    {
        _firstPreviousUserObject = new UserObject();
        _secondPreviousUserObject = new UserObject();
        _nextUserObject = new UserObject();

        _isFirstPreviousUserJiaoDiZhu = false;
        _isFirstPreviousUserFirstJiaoDiZhu = false;

        _isSecondPreviousUserJiaoDiZhu = false;
        _isSecondPreviousUserFirstJiaoDiZhu = false;

        _isNextUserFirstJiaoDiZhu = false;
    }

    public void reset()
    {
        _firstPreviousUserObject = new UserObject();
        _secondPreviousUserObject = new UserObject();
        _nextUserObject = new UserObject();

        _isFirstPreviousUserJiaoDiZhu = false;
        _isFirstPreviousUserFirstJiaoDiZhu = false;

        _isSecondPreviousUserJiaoDiZhu = false;
        _isSecondPreviousUserFirstJiaoDiZhu = false;

        _isNextUserFirstJiaoDiZhu = false;
    }

    public UserObject getFirstPreviousUserObject()
    {
        return _firstPreviousUserObject;
    }

    public void setFirstPreviousUserObject(UserObject firstPreviousUserObject)
    {
        _firstPreviousUserObject = firstPreviousUserObject;
    }

    public bool getIsFirstPreviousUserJiaoDiZhu()
    {
        return _isFirstPreviousUserJiaoDiZhu;
    }

    public void setIsFirstPreviousUserJiaoDiZhu(bool isFirstPreviousUserJiaoDiZhu)
    {
        _isFirstPreviousUserJiaoDiZhu = isFirstPreviousUserJiaoDiZhu;
    }

    public bool getIsFirstPreviousUserFirstJiaoDiZhu()
    {
        return _isFirstPreviousUserFirstJiaoDiZhu;
    }

    public void setIsFirstPreviousUserFirstJiaoDiZhu(bool isFirstPreviousUserFirstJiaoDiZhu)
    {
        _isFirstPreviousUserFirstJiaoDiZhu = isFirstPreviousUserFirstJiaoDiZhu;
    }

    public UserObject getSecondPreviousUserObject()
    {
        return _secondPreviousUserObject;
    }

    public void setSecondPreviousUserObject(UserObject secondPreviousUserObject)
    {
        _secondPreviousUserObject = secondPreviousUserObject;
    }

    public bool getIsSecondPreviousUserJiaoDiZhu()
    {
        return _isSecondPreviousUserJiaoDiZhu;
    }

    public void setIsSecondPreviousUserJiaoDiZhu(bool isSecondPreviousUserJiaoDiZhu)
    {
        _isSecondPreviousUserJiaoDiZhu = isSecondPreviousUserJiaoDiZhu;
    }

    public bool getIsSecondPreviousUserFirstJiaoDiZhu()
    {
        return _isSecondPreviousUserFirstJiaoDiZhu;
    }

    public void setIsSecondPreviousUserFirstJiaoDiZhu(bool isSecondPreviousUserFirstJiaoDiZhu)
    {
        _isSecondPreviousUserFirstJiaoDiZhu = isSecondPreviousUserFirstJiaoDiZhu;
    }

    public UserObject getNextUserObject()
    {
        return _nextUserObject;
    }

    public void setNextUserObject(UserObject nextUserObject)
    {
        _nextUserObject = nextUserObject;
    }

    public bool getIsNextUserFirstJiaoDiZhu()
    {
        return _isNextUserFirstJiaoDiZhu;
    }

    public void setIsNextUserFirstJiaoDiZhu(bool isNextUserFirstJiaoDiZhu)
    {
        _isNextUserFirstJiaoDiZhu = isNextUserFirstJiaoDiZhu;
    }
}