using UnityEngine;
using System.Collections;

public class TimerHelper : MonoBehaviour {

    public static void addLeftUserTimer(ClockShakeScript.TimeOutCallBack timeOutCallBack, ClockShakeScript.TimeAlarmCallBack alarmCallBack)
    {
        if (null != GameObject.Find(SpriteNameConst.LEFT_USER_TIMER_NAME)) return;

        Transform prefab = Resources.Load<Transform>("prefab/clockShake/clockShake");
		Transform transform = Instantiate(prefab, new Vector3(-5.5f, 4f, 0.01f), Quaternion.identity) as Transform;
        transform.gameObject.name = SpriteNameConst.LEFT_USER_TIMER_NAME;

        ClockShakeScript clockShakeScript = transform.GetComponent<ClockShakeScript>();
        clockShakeScript.setTimeOutCallBack(timeOutCallBack);
        clockShakeScript.setTimeAlarmCallBack(alarmCallBack);
    }

    public static void removeLeftUserTimer()
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.LEFT_USER_TIMER_NAME);
        if (null != gameObject)
        {
            Destroy(gameObject);
        }
    }

    public static void addRightUserTimer(ClockShakeScript.TimeOutCallBack timeOutCallBack, ClockShakeScript.TimeAlarmCallBack alarmCallBack)
    {
        if (null != GameObject.Find(SpriteNameConst.RIGHT_USER_TIMER_NAME)) return;

        Transform prefab = Resources.Load<Transform>("prefab/clockShake/clockShake");
        Transform transform = Instantiate(prefab, new Vector3(5.5f, 4f, 0.01f), Quaternion.identity) as Transform;
        transform.gameObject.name = SpriteNameConst.RIGHT_USER_TIMER_NAME;

        ClockShakeScript clockShakeScript = transform.GetComponent<ClockShakeScript>();
        clockShakeScript.setTimeOutCallBack(timeOutCallBack);
        clockShakeScript.setTimeAlarmCallBack(alarmCallBack);
    }

    public static void removeRightUserTimer()
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.RIGHT_USER_TIMER_NAME);
        if (null != gameObject)
        {
            Destroy(gameObject);
        }
    }

    public static void addSelfUserTimer(ClockShakeScript.TimeOutCallBack timeOutCallBack, ClockShakeScript.TimeAlarmCallBack alarmCallBack)
    {
        if (null != GameObject.Find(SpriteNameConst.SELF_USER_TIMER_NAME)) return;

        Transform prefab = Resources.Load<Transform>("prefab/clockShake/clockShake");
        Transform transform = Instantiate(prefab, new Vector3(-5.5f, -0.5f, 0.01f), Quaternion.identity) as Transform;
        transform.gameObject.name = SpriteNameConst.SELF_USER_TIMER_NAME;

        ClockShakeScript clockShakeScript = transform.GetComponent<ClockShakeScript>();
        clockShakeScript.setTimeOutCallBack(timeOutCallBack);
        clockShakeScript.setTimeAlarmCallBack(alarmCallBack);
    }

    public static void removeSelfUserTimer()
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.SELF_USER_TIMER_NAME);
        if (null != gameObject)
        {
            Destroy(gameObject);
        }
    }
}