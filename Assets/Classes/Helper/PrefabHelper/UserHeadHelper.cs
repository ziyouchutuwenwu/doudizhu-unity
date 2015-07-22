using UnityEngine;
using System.Collections;

public class UserHeadHelper : MonoBehaviour {

    public static void addLeftUserHead()
    {
        if (null != GameObject.Find(SpriteNameConst.LEFT_USER_HEAD_NAME)) return;

        Transform prefab = Resources.Load<Transform>("prefab/userHead/userHead");
		Transform transform = Instantiate(prefab, new Vector3(-7f, 4f, 0.01f), Quaternion.identity) as Transform;
        transform.gameObject.name = SpriteNameConst.LEFT_USER_HEAD_NAME;
    }

    public static void setLeftUserHead(UserObject.Gender gender, UserObject.UserType userType, UserObject.OnLineType onlineType)
    {
        UserHeadScript userHeadScript = GameObject.Find(SpriteNameConst.LEFT_USER_HEAD_NAME).GetComponent<UserHeadScript>();
        userHeadScript.setUserType(gender,userType,onlineType);
    }

    public static void doLeftUserHeadFlip()
    {
        UserHeadScript userHeadScript = GameObject.Find(SpriteNameConst.LEFT_USER_HEAD_NAME).GetComponent<UserHeadScript>();
        userHeadScript.triggerFlip(); 
    }

    public static bool isLeftUserHeadFront()
    {
        UserHeadScript userHeadScript = GameObject.Find(SpriteNameConst.LEFT_USER_HEAD_NAME).GetComponent<UserHeadScript>();
        return userHeadScript.isFront();
    }

    public static bool isLeftUserHeadTuringToFront()
    {
        UserHeadScript userHeadScript = GameObject.Find(SpriteNameConst.LEFT_USER_HEAD_NAME).GetComponent<UserHeadScript>();
        if (userHeadScript.getFlipingStatus() == UserHeadScript.FlipingStatus.FLIPING_FRONT)
        {
            return true;
        }
        return false;
    }

    public static bool isLeftUserHeadTuringToBack()
    {
        UserHeadScript userHeadScript = GameObject.Find(SpriteNameConst.LEFT_USER_HEAD_NAME).GetComponent<UserHeadScript>();
        if (userHeadScript.getFlipingStatus() == UserHeadScript.FlipingStatus.FLIPING_BACK)
        {
            return true;
        }
        return false;
    }

    public static void removeLeftUserHead()
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.LEFT_USER_HEAD_NAME);
        if (null != gameObject)
        {
            Destroy(gameObject);
        }
    }

    public static void addRightUserHead()
    {
        if (null != GameObject.Find(SpriteNameConst.RIGHT_USER_HEAD_NAME)) return;

        Transform prefab = Resources.Load<Transform>("prefab/userHead/userHead");
		Transform transform = Instantiate(prefab, new Vector3(7f, 4f, 0.01f), Quaternion.identity) as Transform;
        transform.gameObject.name = SpriteNameConst.RIGHT_USER_HEAD_NAME;
    }

    public static void setRightUserHead(UserObject.Gender gender, UserObject.UserType userType, UserObject.OnLineType onlineType)
    {
        UserHeadScript userHeadScript = GameObject.Find(SpriteNameConst.RIGHT_USER_HEAD_NAME).GetComponent<UserHeadScript>();
        userHeadScript.setUserType(gender, userType, onlineType);
    }

    public static void doRightUserHeadFlip()
    {
        UserHeadScript userHeadScript = GameObject.Find(SpriteNameConst.RIGHT_USER_HEAD_NAME).GetComponent<UserHeadScript>();
        userHeadScript.triggerFlip();
    }

    public static bool isRightUserHeadFront()
    {
        UserHeadScript userHeadScript = GameObject.Find(SpriteNameConst.RIGHT_USER_HEAD_NAME).GetComponent<UserHeadScript>();
        return userHeadScript.isFront();
    }

    public static bool isRightUserHeadTuringToFront()
    {
        UserHeadScript userHeadScript = GameObject.Find(SpriteNameConst.RIGHT_USER_HEAD_NAME).GetComponent<UserHeadScript>();
        if (userHeadScript.getFlipingStatus() == UserHeadScript.FlipingStatus.FLIPING_FRONT)
        {
            return true;
        }
        return false;
    }

    public static bool isRightUserHeadTuringToBack()
    {
        UserHeadScript userHeadScript = GameObject.Find(SpriteNameConst.RIGHT_USER_HEAD_NAME).GetComponent<UserHeadScript>();
        if (userHeadScript.getFlipingStatus() == UserHeadScript.FlipingStatus.FLIPING_BACK)
        {
            return true;
        }
        return false;
    }

    public static void removeRightUserHead()
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.RIGHT_USER_HEAD_NAME);
        if (null != gameObject)
        {
            Destroy(gameObject);
        }
    }

    public static void addSelfUserHead()
    {
        if (null != GameObject.Find(SpriteNameConst.SELF_USER_HEAD_NAME)) return;

        Transform prefab = Resources.Load<Transform>("prefab/userHead/userHead");
		Transform transform = Instantiate(prefab, new Vector3(-7f, -0.5f, 0.01f), Quaternion.identity) as Transform;
        transform.gameObject.name = SpriteNameConst.SELF_USER_HEAD_NAME;
    }

    public static void setSelfUserHead(UserObject.Gender gender, UserObject.UserType userType, UserObject.OnLineType onlineType)
    {
        UserHeadScript userHeadScript = GameObject.Find(SpriteNameConst.SELF_USER_HEAD_NAME).GetComponent<UserHeadScript>();
        userHeadScript.setUserType(gender, userType, onlineType);
    }

    public static void doSelfUserHeadFlip()
    {
        UserHeadScript userHeadScript = GameObject.Find(SpriteNameConst.SELF_USER_HEAD_NAME).GetComponent<UserHeadScript>();
        userHeadScript.triggerFlip();
    }

    public static bool isSelfUserHeadFront()
    {
        UserHeadScript userHeadScript = GameObject.Find(SpriteNameConst.SELF_USER_HEAD_NAME).GetComponent<UserHeadScript>();
        return userHeadScript.isFront();
    }

    public static bool isSelfUserHeadTuringToFront()
    {
        UserHeadScript userHeadScript = GameObject.Find(SpriteNameConst.SELF_USER_HEAD_NAME).GetComponent<UserHeadScript>();
        if (userHeadScript.getFlipingStatus() == UserHeadScript.FlipingStatus.FLIPING_FRONT)
        {
            return true;
        }
        return false;
    }

    public static bool isSelfUserHeadTuringToBack()
    {
        UserHeadScript userHeadScript = GameObject.Find(SpriteNameConst.SELF_USER_HEAD_NAME).GetComponent<UserHeadScript>();
        if (userHeadScript.getFlipingStatus() == UserHeadScript.FlipingStatus.FLIPING_BACK)
        {
            return true;
        }
        return false;
    }

    public static void removeSelfUserHead()
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.SELF_USER_HEAD_NAME);
        if (null != gameObject)
        {
            Destroy(gameObject);
        }
    }
}
