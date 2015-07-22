using UnityEngine;
using System.Collections;

public class ModelManager {

    private static ModelManager _instance = null;

    private VersionObject   _versionObject = null;

    private UserObject      _selfUserObject = null;
    private UserObject      _leftUserObject = null;
    private UserObject      _rightUserObject = null;

    private RoomObject      _roomObject = null;
    private DeskObject      _deskObject = null;

    private UserLoginObject _userLoginObject = null;
    private UserEditProfileObject _userEditProfileObject = null;

    private UserSitOnDeskObject _userSitOnDeskObject = null;
    private DeskJiaoDiZhuObject _deskJiaoDiZhuObject = null;

    private DeskCardsPromptObject _deskCardsPromptObject = null;
    private DeskChuPaiObject _deskChuPaiObject = null;
    private DeskCardsValidateObject _deskCardsValidateObject = null;
    private UserCheckResumePlayObject _userCheckResumePlayObject = null;

    public static ModelManager shareInstance()
    {
        if (null == _instance)
        {
            _instance = new ModelManager();
        }
        return _instance;
    }

    public void registerModelObjects()
    {
        _versionObject = new VersionObject();

        _selfUserObject = new UserObject();
        _leftUserObject = new UserObject();
        _rightUserObject = new UserObject();

        _roomObject = new RoomObject();
        _deskObject = new DeskObject();

        _userLoginObject = new UserLoginObject();
        _userEditProfileObject = new UserEditProfileObject();

        _userSitOnDeskObject = new UserSitOnDeskObject();
        _deskJiaoDiZhuObject = new DeskJiaoDiZhuObject();

        _deskCardsPromptObject = new DeskCardsPromptObject();
        _deskChuPaiObject = new DeskChuPaiObject();
        _deskCardsValidateObject = new DeskCardsValidateObject();
        _userCheckResumePlayObject = new UserCheckResumePlayObject();
    }

    public void reset()
    {
        _versionObject.reset();

        _selfUserObject.reset();
        _leftUserObject.reset();
        _rightUserObject.reset();

        _roomObject.reset();
        _deskObject.reset();

        _userLoginObject.reset();
        _userEditProfileObject.reset();

        _userSitOnDeskObject.reset();
        _deskJiaoDiZhuObject.reset();

        _deskCardsPromptObject.reset();
        _deskChuPaiObject.reset();
        _deskCardsValidateObject.reset();
        _userCheckResumePlayObject.reset();
    }

    public void resetPlaying()
    {
        _selfUserObject.resetPlaying();
        _leftUserObject.resetPlaying();
        _rightUserObject.resetPlaying();

        _deskObject.resetPlaying();

        _deskJiaoDiZhuObject.resetPlaying();

        _deskCardsPromptObject.resetPlaying();
        _deskChuPaiObject.resetPlaying();
        _deskCardsValidateObject.resetPlaying();
        _userCheckResumePlayObject.resetPlaying();
    }

    public VersionObject getVersionObject()
    {
        return _versionObject;
    }

    public UserObject getSelfUserObject()
    {
        return _selfUserObject;
    }

    public UserObject getLeftUserObject()
    {
        return _leftUserObject;
    }

    public UserObject getRightUserObject()
    {
        return _rightUserObject;
    }

    public RoomObject getRoomObject()
    {
        return _roomObject;
    }

    public DeskObject getDeskObject()
    {
        return _deskObject;
    }

    public UserLoginObject getUserLoginObject()
    {
        return _userLoginObject ;
    }

    public UserEditProfileObject getUserEditProfileObject()
    {
        return _userEditProfileObject;
    }

    public UserSitOnDeskObject getUserSitOnDeskObject()
    {
        return _userSitOnDeskObject;
    }

    public DeskJiaoDiZhuObject getDeskJiaoDiZhuObject()
    {
        return _deskJiaoDiZhuObject;
    }

    public DeskCardsPromptObject getDeskCardsPromptObject()
    {
        return _deskCardsPromptObject;
    }

    public DeskChuPaiObject getDeskChuPaiObject()
    {
        return _deskChuPaiObject;
    }

    public DeskCardsValidateObject getDeskCardsValidateObject()
    {
        return _deskCardsValidateObject;
    }

    public UserCheckResumePlayObject getUserCheckResumePlayObject()
    {
        return _userCheckResumePlayObject;
    }
}