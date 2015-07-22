using UnityEngine;
using System.Collections;

public class DelayCallerHelper : MonoBehaviour {

    public static void addDelayCallerObject()
    {
        if (null != GameObject.Find(SpriteNameConst.DELAY_CALLER_OBJECT_NAME)) return;

        Transform prefab = Resources.Load<Transform>("prefab/delayCaller/delayCaller");
        Transform transform = Instantiate(prefab, new Vector3(0,0, 1), Quaternion.identity) as Transform;
        transform.gameObject.name = SpriteNameConst.DELAY_CALLER_OBJECT_NAME;
    }

    public static void removeDelayCallerObject()
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.DELAY_CALLER_OBJECT_NAME);
        if (null != gameObject)
        {
            Destroy(gameObject);
        }
    }

    public static void doDelayCall(DelayCallerScript.DelayCallBack delayCallBack, params object[] args)
    {
        if (null == GameObject.Find(SpriteNameConst.DELAY_CALLER_OBJECT_NAME)) return;

        DelayCallerScript script = GameObject.Find(SpriteNameConst.DELAY_CALLER_OBJECT_NAME).GetComponent<DelayCallerScript>();
        script.delayCall(0.1f,delayCallBack, args);
    }
}