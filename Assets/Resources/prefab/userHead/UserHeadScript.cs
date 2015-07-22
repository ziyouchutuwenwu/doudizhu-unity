using UnityEngine;
using System.Collections;
using DG.Tweening;

/*
UserHeadScript userHeadScript = GameObject.Find("userHead").GetComponent<UserHeadScript>();
userHeadScript.setUserType(UserObject.Gender.FEMALE, UserObject.UserType.FARMER, UserObject.OnLineType.OFFLINE);
userHeadScript.triggerFlip(); 
*/

/*
 * 翻转部分添加循环检测，不判断前面后面
*/
public class UserHeadScript : MonoBehaviour {

    public enum FlipingStatus
    {
        FLIPING_INVALID = -1,
        FLIPING_FRONT = 1,
        FLIPING_BACK = 2
    }

    private bool _isAnimationProceeding = false;

    Transform _rotatedTransform = null;
    private bool _isFront = false;
    private int _flipCount = 0;
    private FlipingStatus _flipingStatus = FlipingStatus.FLIPING_INVALID;

    public void setUserType(UserObject.Gender gender,UserObject.UserType userType, UserObject.OnLineType onlineType)
    {
        string imgName = "";
        string typeNameImg = "";

        if (gender == UserObject.Gender.MALE)
        {
            if (userType == UserObject.UserType.LANDOWNER)
            {
                if (onlineType == UserObject.OnLineType.ONLINE) imgName = "landowner_male_normal";
                if (onlineType == UserObject.OnLineType.OFFLINE) imgName = "landowner_male_gray";
                typeNameImg = "landowner_logo";
            }

            if (userType == UserObject.UserType.FARMER)
            {
                if (onlineType == UserObject.OnLineType.ONLINE) imgName = "farmer_male_normal";
                if (onlineType == UserObject.OnLineType.OFFLINE) imgName = "farmer_male_gray";
                typeNameImg = "farmer_logo";
            }
        }

        if (gender == UserObject.Gender.FEMALE)
        {
            if (userType == UserObject.UserType.LANDOWNER)
            {
                if (onlineType == UserObject.OnLineType.ONLINE) imgName = "landowner_female_normal";
                if (onlineType == UserObject.OnLineType.OFFLINE) imgName = "landowner_female_gray";
                typeNameImg = "landowner_logo";
            }

            if (userType == UserObject.UserType.FARMER)
            {
                if (onlineType == UserObject.OnLineType.ONLINE) imgName = "farmer_female_normal";
                if (onlineType == UserObject.OnLineType.OFFLINE) imgName = "farmer_female_gray";
                typeNameImg = "farmer_logo";
            }
        }

        SpriteRenderer userHeadFrontSpriteRender = _rotatedTransform.FindChild("userHeadFront").GetComponent<SpriteRenderer>();
        string frontHeaderImgFullName = "imgs/threePersonsPlay/userHead/" + imgName;
        userHeadFrontSpriteRender.sprite = Resources.Load<Sprite>(frontHeaderImgFullName);

        SpriteRenderer userTypeSpriteRender = this.transform.FindChild("userType").GetComponent<SpriteRenderer>();
        string userTypeImgFullName = "imgs/threePersonsPlay/userHead/" + typeNameImg;
        userTypeSpriteRender.sprite = Resources.Load<Sprite>(userTypeImgFullName);
    }

    public FlipingStatus getFlipingStatus()
    {
        return _flipingStatus;            
    }

    public void triggerFlip()
    {
        _flipCount++;
    }

    public bool isFront()
    {
        return _isFront;            
    }

    void Awake()
    {
        _flipCount = 0;
        _flipingStatus = FlipingStatus.FLIPING_INVALID;
        _rotatedTransform = this.transform.FindChild("flippedObject");
    }

    void Update()
    {
        if (_flipCount > 0)
        {
            loopCheckFlip();
        }
    }

    void loopCheckFlip()
    {
        if (!_isAnimationProceeding)
        {
            _isAnimationProceeding = true;

            float degree = 180f;

            if (!_isFront)
            {
                _flipingStatus = FlipingStatus.FLIPING_FRONT;
                degree = 180f;
            }
            else
            {
                _flipingStatus = FlipingStatus.FLIPING_BACK;
                degree = 0;
            }

            _rotatedTransform.DORotate(new Vector3(0, degree, 0), 2.5f).
                SetEase(Ease.OutQuint).
                SetLoops(0).
                OnStart(flipStart).
                OnUpdate(flipUpdate).
                OnComplete(flipStop);
        }
    }

    void flipStart(){
    }

    void flipUpdate()
    {
        float rotateAngles = System.Math.Abs(_rotatedTransform.eulerAngles.y);

        if (rotateAngles >= 90 && rotateAngles <= 270) _isFront = true;
        else _isFront = false;
    }

    void flipStop()
    {
        if (_flipCount > 0) _flipCount--;
        _flipingStatus = FlipingStatus.FLIPING_INVALID;
        _isAnimationProceeding = false;
    }
}