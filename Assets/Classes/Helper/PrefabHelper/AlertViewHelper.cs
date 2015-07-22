using UnityEngine;
using System.Collections;

public class AlertViewHelper : MonoBehaviour {

    public static void addUpdateAlertView(
        ActionViewScript.TouchCallBack okTouchCallBack,
        ActionViewScript.TouchCallBack cancelTouchCallBack)
    {
        if (null != GameObject.Find(SpriteNameConst.UPDATE_ALERT_VIEW_NAME)) return;

        Transform prefab = Resources.Load<Transform>("prefab/alertView/actionView");
        Transform transform = Instantiate(prefab, new Vector3(0,1, 1), Quaternion.identity) as Transform;
        transform.gameObject.name = SpriteNameConst.UPDATE_ALERT_VIEW_NAME;

        ActionViewScript actionViewScript = transform.GetComponent<ActionViewScript>();
        actionViewScript.setMessageInfo("有新版本，是否更新？");
        CanvasHelper.setOtherCanvasTouchEnabled(transform, false);
        actionViewScript.setOkTouchCallBack(okTouchCallBack);
        actionViewScript.setCancelTouchCallBack(cancelTouchCallBack);
    }

    public static void removeUpdateAlertView()
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.UPDATE_ALERT_VIEW_NAME);
        if (null != gameObject)
        {
            CanvasHelper.setOtherCanvasTouchEnabled(gameObject.transform, true);
            Destroy(gameObject);
        }
    }

    public static void addDisableLeaveAlertView(AlertViewScript.TouchCallBack touchCallBack)
    {
        if (null != GameObject.Find(SpriteNameConst.DISABLE_LEAVE_ALERT_VIEW_NAME)) return;

        Transform prefab = Resources.Load<Transform>("prefab/alertView/alertView");
        Transform transform = Instantiate(prefab, new Vector3(0, 1, 1), Quaternion.identity) as Transform;
        transform.gameObject.name = SpriteNameConst.DISABLE_LEAVE_ALERT_VIEW_NAME;

        AlertViewScript alertViewScript = transform.GetComponent<AlertViewScript>();
        CanvasHelper.setOtherCanvasTouchEnabled(transform, false);
        alertViewScript.setInfo("正在游戏中，禁止离开！");
        alertViewScript.setTouchCallBack(touchCallBack);
    }

    public static void removeDisableLeaveAlertView()
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.DISABLE_LEAVE_ALERT_VIEW_NAME);
        if (null != gameObject)
        {
            CanvasHelper.setOtherCanvasTouchEnabled(gameObject.transform, true);
            Destroy(gameObject);
        }
    }

    public static void addSitOnDeskErrorAlertView(AlertViewScript.TouchCallBack touchCallBack)
    {
        if (null != GameObject.Find(SpriteNameConst.SIT_ON_DESK_ERROR_ALERT_VIEW_NAME)) return;

        Transform prefab = Resources.Load<Transform>("prefab/alertView/alertView");
        Transform transform = Instantiate(prefab, new Vector3(0, 1, 1), Quaternion.identity) as Transform;
        transform.gameObject.name = SpriteNameConst.SIT_ON_DESK_ERROR_ALERT_VIEW_NAME;

        AlertViewScript alertViewScript = transform.GetComponent<AlertViewScript>();
        CanvasHelper.setOtherCanvasTouchEnabled(transform, false);
        alertViewScript.setInfo("桌子已满，请重新选择");
        alertViewScript.setTouchCallBack(touchCallBack);
    }

    public static void removeSitOnDeskErrorAlertView()
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.SIT_ON_DESK_ERROR_ALERT_VIEW_NAME);
        if (null != gameObject)
        {
            CanvasHelper.setOtherCanvasTouchEnabled(gameObject.transform, true);
            Destroy(gameObject);
        }
    }

    public static void addConnectErrorAlertView(ActionViewScript.TouchCallBack okTouchCallBack,ActionViewScript.TouchCallBack cancelTouchCallBack,string infoText)
    {
        if (null != GameObject.Find(SpriteNameConst.CONNECT_ERROR_ALERT_VIEW_NAME)) return;

        Transform prefab = Resources.Load<Transform>("prefab/alertView/actionView");
        Transform transform = Instantiate(prefab, new Vector3(0, 1, 1), Quaternion.identity) as Transform;
        transform.gameObject.name = SpriteNameConst.CONNECT_ERROR_ALERT_VIEW_NAME;

        ActionViewScript actionViewScript = transform.GetComponent<ActionViewScript>();
        actionViewScript.setMessageInfo(infoText);
        CanvasHelper.setOtherCanvasTouchEnabled(transform, false);
        actionViewScript.setOkTouchCallBack(okTouchCallBack);
        actionViewScript.setCancelTouchCallBack(cancelTouchCallBack);
    }

    public static void removeConnectErrorAlertView()
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.CONNECT_ERROR_ALERT_VIEW_NAME);
        if (null != gameObject)
        {
            CanvasHelper.setOtherCanvasTouchEnabled(gameObject.transform, true);
            Destroy(gameObject);
        }
    }

    public static void addLoginSuccessAlertView(AlertViewScript.TouchCallBack touchCallBack)
    {
        if (null != GameObject.Find(SpriteNameConst.LOGIN_SUCCESS_ALERT_VIEW_NAME)) return;

        Transform prefab = Resources.Load<Transform>("prefab/alertView/alertView");
        Transform transform = Instantiate(prefab, new Vector3(0, 1, 1), Quaternion.identity) as Transform;
        transform.gameObject.name = SpriteNameConst.LOGIN_SUCCESS_ALERT_VIEW_NAME;

        AlertViewScript alertViewScript = transform.GetComponent<AlertViewScript>();
        CanvasHelper.setOtherCanvasTouchEnabled(transform, false);
        alertViewScript.setInfo("登录成功");
        alertViewScript.setTouchCallBack(touchCallBack);
    }

    public static void removeLoginSuccessAlertView()
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.LOGIN_SUCCESS_ALERT_VIEW_NAME);
        if (null != gameObject)
        {
            CanvasHelper.setOtherCanvasTouchEnabled(gameObject.transform, true);
            Destroy(gameObject);
        }
    }

    public static void addLoginErrorAlertView(AlertViewScript.TouchCallBack touchCallBack)
    {
        if (null != GameObject.Find(SpriteNameConst.LOGIN_ERROR_ALERT_VIEW_NAME)) return;

        Transform prefab = Resources.Load<Transform>("prefab/alertView/alertView");
        Transform transform = Instantiate(prefab, new Vector3(0, 1, 1), Quaternion.identity) as Transform;
        transform.gameObject.name = SpriteNameConst.LOGIN_ERROR_ALERT_VIEW_NAME;

        AlertViewScript alertViewScript = transform.GetComponent<AlertViewScript>();
        CanvasHelper.setOtherCanvasTouchEnabled(transform, false);
        alertViewScript.setInfo("登录失败，请重新登录！");
        alertViewScript.setTouchCallBack(touchCallBack);
    }

    public static void removeLoginErrorAlertView()
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.LOGIN_ERROR_ALERT_VIEW_NAME);
        if (null != gameObject)
        {
            CanvasHelper.setOtherCanvasTouchEnabled(gameObject.transform, true);
            Destroy(gameObject);
        }
    }

    public static void addRegisterSuccessAlertView(AlertViewScript.TouchCallBack touchCallBack)
    {
        if (null != GameObject.Find(SpriteNameConst.REGISTER_SUCCESS_ALERT_VIEW_NAME)) return;

        Transform prefab = Resources.Load<Transform>("prefab/alertView/alertView");
        Transform transform = Instantiate(prefab, new Vector3(0, 1, 1), Quaternion.identity) as Transform;
        transform.gameObject.name = SpriteNameConst.REGISTER_SUCCESS_ALERT_VIEW_NAME;

        AlertViewScript alertViewScript = transform.GetComponent<AlertViewScript>();
        CanvasHelper.setOtherCanvasTouchEnabled(transform, false);
        alertViewScript.setInfo("恭喜您，注册成功");
        alertViewScript.setTouchCallBack(touchCallBack);
    }

    public static void removeRegisterSuccessAlertView()
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.REGISTER_SUCCESS_ALERT_VIEW_NAME);
        if (null != gameObject)
        {
            CanvasHelper.setOtherCanvasTouchEnabled(gameObject.transform, true);
            Destroy(gameObject);
        }
    }

    public static void addRegisterErrorAlertView(AlertViewScript.TouchCallBack touchCallBack)
    {
        if (null != GameObject.Find(SpriteNameConst.REGISTER_ERROR_ALERT_VIEW_NAME)) return;

        Transform prefab = Resources.Load<Transform>("prefab/alertView/alertView");
        Transform transform = Instantiate(prefab, new Vector3(0, 1, 1), Quaternion.identity) as Transform;
        transform.gameObject.name = SpriteNameConst.REGISTER_ERROR_ALERT_VIEW_NAME;

        AlertViewScript alertViewScript = transform.GetComponent<AlertViewScript>();
        CanvasHelper.setOtherCanvasTouchEnabled(transform, false);
        alertViewScript.setInfo("注册失败，请修改信息！");
        alertViewScript.setTouchCallBack(touchCallBack);
    }

    public static void removeRegisterErrorAlertView()
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.REGISTER_ERROR_ALERT_VIEW_NAME);
        if (null != gameObject)
        {
            CanvasHelper.setOtherCanvasTouchEnabled(gameObject.transform, true);
            Destroy(gameObject);
        }
    }

    public static void addEditProfileSuccessAlertView(AlertViewScript.TouchCallBack touchCallBack)
    {
        if (null != GameObject.Find(SpriteNameConst.EDIT_PROFILE_ERROR_ALERT_VIEW_NAME)) return;

        Transform prefab = Resources.Load<Transform>("prefab/alertView/alertView");
        Transform transform = Instantiate(prefab, new Vector3(0, 1, 1), Quaternion.identity) as Transform;
        transform.gameObject.name = SpriteNameConst.EDIT_PROFILE_ERROR_ALERT_VIEW_NAME;

        AlertViewScript alertViewScript = transform.GetComponent<AlertViewScript>();
        CanvasHelper.setOtherCanvasTouchEnabled(transform, false);
        alertViewScript.setInfo("更新资料信息成功");
        alertViewScript.setTouchCallBack(touchCallBack);
    }

    public static void removeEditProfileSuccessAlertView()
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.EDIT_PROFILE_ERROR_ALERT_VIEW_NAME);
        if (null != gameObject)
        {
            CanvasHelper.setOtherCanvasTouchEnabled(gameObject.transform, true);
            Destroy(gameObject);
        }
    }

    public static void addEditProfileErrorAlertView(AlertViewScript.TouchCallBack touchCallBack)
    {
        if (null != GameObject.Find(SpriteNameConst.EDIT_PROFILE_ERROR_ALERT_VIEW_NAME)) return;

        Transform prefab = Resources.Load<Transform>("prefab/alertView/alertView");
        Transform transform = Instantiate(prefab, new Vector3(0, 1, 1), Quaternion.identity) as Transform;
        transform.gameObject.name = SpriteNameConst.EDIT_PROFILE_ERROR_ALERT_VIEW_NAME;

        AlertViewScript alertViewScript = transform.GetComponent<AlertViewScript>();
        CanvasHelper.setOtherCanvasTouchEnabled(transform, false);
        alertViewScript.setInfo("更新失败，请重新输入！");
        alertViewScript.setTouchCallBack(touchCallBack);
    }

    public static void removeEditProfileErrorAlertView()
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.EDIT_PROFILE_ERROR_ALERT_VIEW_NAME);
        if (null != gameObject)
        {
            CanvasHelper.setOtherCanvasTouchEnabled(gameObject.transform, true);
            Destroy(gameObject);
        }
    }
}