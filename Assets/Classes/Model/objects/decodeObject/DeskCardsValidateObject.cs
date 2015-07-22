using UnityEngine;
using System.Collections.Generic;

public class DeskCardsValidateObject
{
    private bool _isCardsValidate;

    public void resetPlaying()
    {
        _isCardsValidate = true;
    }

    public void reset()
    {
        _isCardsValidate = true;
    }

    public bool getIsCardsValidate()
    {
        return _isCardsValidate;
    }

    public void setIsCardsValidate(bool isCardsValidate)
    {
        _isCardsValidate = isCardsValidate;
    }
}