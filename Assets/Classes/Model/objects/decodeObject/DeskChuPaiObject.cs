using UnityEngine;
using System.Collections.Generic;

public class DeskChuPaiObject
{
    private UserObject _firstPreviousUserObject;
    private UserObject _secondPreviousUserObject;
    private UserObject _nextUserObject;

    private bool _isFirstPreviousUserBuYao;
    private bool _isFirstPreviousUserDaNi;
    private List<int> _firstPreviousUserSendCards;
    private CardInfo.CardPromptType _firstPreviousUserSendCardsType;

    private List<int> _secondPreviousUserSendCards;
    private bool _isSecondPreviousUserBuYao;

    private bool _isNextUserMustChuPai;

    public void resetPlaying()
    {
        _firstPreviousUserObject = new UserObject();
        _secondPreviousUserObject = new UserObject();
        _nextUserObject = new UserObject();

        _isFirstPreviousUserBuYao = false;
        _isFirstPreviousUserDaNi = false;
        _firstPreviousUserSendCards = new List<int>();
        _firstPreviousUserSendCardsType = CardInfo.CardPromptType.CARD_PROMPT_INVALID_TYPE;

        _secondPreviousUserSendCards = new List<int>();
        _isSecondPreviousUserBuYao = false;
        _isNextUserMustChuPai = false;
    }

    public void reset()
    {
        _firstPreviousUserObject = new UserObject();
        _secondPreviousUserObject = new UserObject();
        _nextUserObject = new UserObject();

        _isFirstPreviousUserBuYao = false;
        _isFirstPreviousUserDaNi = false;
        _firstPreviousUserSendCards = new List<int>();
        _firstPreviousUserSendCardsType = CardInfo.CardPromptType.CARD_PROMPT_INVALID_TYPE;

        _secondPreviousUserSendCards = new List<int>();
        _isSecondPreviousUserBuYao = false;
        _isNextUserMustChuPai = false;
    }

    public UserObject getFirstPreviousUserObject()
    {
        return _firstPreviousUserObject;
    }

    public void setFirstPreviousUserObject(UserObject firstPreviousUserObject)
    {
        _firstPreviousUserObject = firstPreviousUserObject;
    }

    public bool getIsFirstPreviousUserBuYao()
    {
        return _isFirstPreviousUserBuYao;
    }

    public void setIsFirstPreviousUserBuYao(bool isFirstPreviousUserBuYao)
    {
        _isFirstPreviousUserBuYao = isFirstPreviousUserBuYao;
    }

    public bool getIsFirstPreviousUserDaNi()
    {
        return _isFirstPreviousUserDaNi;
    }

    public void setIsFirstPreviousUserDaNi(bool isFirstPreviousUserDaNi)
    {
        _isFirstPreviousUserDaNi = isFirstPreviousUserDaNi;
    }

    public List<int> getFirstPreviousUserSendCards()
    {
        return _firstPreviousUserSendCards;
    }

    public void setFirstPreviousUserSendCards(List<int> firstPreviousUserSendCards)
    {
        _firstPreviousUserSendCards.Clear();
        _firstPreviousUserSendCards = CloneHelper.clone(firstPreviousUserSendCards);
    }

    public CardInfo.CardPromptType getFirstPreviousUserSendCardsType()
    {
        return _firstPreviousUserSendCardsType;
    }

    public void setFirstPreviousUserSendCardsType(CardInfo.CardPromptType firstPreviousUserSendCardsType)
    {
        _firstPreviousUserSendCardsType = firstPreviousUserSendCardsType;
    }

    public UserObject getSecondPreviousUserObject()
    {
        return _secondPreviousUserObject;
    }

    public void setSecondPreviousUserObject(UserObject secondPreviousUserObject)
    {
        _secondPreviousUserObject = secondPreviousUserObject;
    }

    public bool getIsSecondPreviousUserBuYao()
    {
        return _isSecondPreviousUserBuYao;
    }

    public void setIsSecondPreviousUserBuYao(bool isSecondPreviousUserBuYao)
    {
        _isSecondPreviousUserBuYao = isSecondPreviousUserBuYao;
    }

    public List<int> getSecondPreviousUserSendCards()
    {
        return _secondPreviousUserSendCards;
    }

    public void setSecondPreviousUserSendCards(List<int> secondPreviousUserSendCards)
    {
        _secondPreviousUserSendCards.Clear();
        _secondPreviousUserSendCards = CloneHelper.clone(secondPreviousUserSendCards);
    }

    public bool getIsNextUserMustChuPai()
    {
        return _isNextUserMustChuPai;
    }

    public void setIsNextUserMustChuPai(bool isNextUserMustChuPai)
    {
        _isNextUserMustChuPai = isNextUserMustChuPai;
    }

    public UserObject getNextUserObject()
    {
        return _nextUserObject;
    }

    public void setNextUserObject(UserObject nextUserObject)
    {
        _nextUserObject = nextUserObject;
    }
}