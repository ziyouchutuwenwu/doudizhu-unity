using UnityEngine;
using System.Collections.Generic;

public class UserObject {

    public enum Gender
    {
        MALE = 1,
        FEMALE = 2
    }

    public enum UserType
    {
        FARMER = 1,
        LANDOWNER = 2
    }

    public enum OnLineType
    {
        ONLINE = 1,
        OFFLINE = 2
    }

    private Gender _gender;
    private UserType _userType;
    private OnLineType _online;
    private string _id;
    private bool _isReady;
    private List<int> _cards;
    private int _cardNumber;
    private bool _isWin;

    public void resetPlaying()
    {
        _userType = UserType.FARMER;
        _isReady = false;
        _cards = new List<int>();
        _cardNumber = 0;
        _isWin = false;
    }

    public void reset()
    {
        _gender = Gender.MALE;
        _userType = UserType.FARMER;
        _online = OnLineType.OFFLINE;
        _id = "";
        _isReady = false;
        _cards = new List<int>();
        _cardNumber = 0;
        _isWin = false;
    }

    public Gender getGender()
    {
        return _gender;
    }

    public void setGender(Gender gender)
    {
        _gender = gender;
    }

    public string getId()
    {
        return _id;
    }

    public void setId(string id)
    {
        _id = id;
    }

    public UserType getUserType()
    {
        return _userType;
    }

    public void setUserType(UserType userType)
    {
        _userType = userType;
    }

    public OnLineType getOnline()
    {
        return _online;
    }

    public void setOnline(OnLineType online)
    {
        _online = online;
    }

    public bool getReady()
    {
        return _isReady;
    }

    public void setReady(bool isReady)
    {
        _isReady = isReady;
    }

    public List<int> getCards()
    {
        return CloneHelper.clone(_cards);
    }

    public void setCards(List<int> cards)
    {
        _cards.Clear();
        _cards = CloneHelper.clone(cards);
    }

    public int getCardNumber()
    {
        return _cardNumber;
    }

    public void setCardNumber(int cardNumber)
    {
        _cardNumber = cardNumber;
    }

    public bool getIsWin()
    {
        return _isWin;
    }

    public void setIsWin(bool isWin)
    {
        _isWin = isWin;
    }
}