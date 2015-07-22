using UnityEngine;
using System.Collections;

public class InfoSpriteHelper : MonoBehaviour {

	public static void addLeftUserReadyInfo()
    {
        if (null != GameObject.Find(SpriteNameConst.LEFT_USER_READY_INFO_NAME)) return;

        Transform prefab = Resources.Load<Transform>("prefab/info/readyInfo");
        Transform transform = Instantiate(prefab, new Vector3(-5.5f, 3.5f, 0.01f), Quaternion.identity) as Transform;
        transform.gameObject.name = SpriteNameConst.LEFT_USER_READY_INFO_NAME;
    }

    public static void removeLeftUserReadyInfo()
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.LEFT_USER_READY_INFO_NAME);
        if (null != gameObject)
        {
            Destroy(gameObject);
        }
    }

    public static void addRightUserReadyInfo()
    {
        if (null != GameObject.Find(SpriteNameConst.RIGHT_USER_READY_INFO_NAME)) return;

        Transform prefab = Resources.Load<Transform>("prefab/info/readyInfo");
        Transform transform = Instantiate(prefab, new Vector3(5.5f, 3.5f, 0.01f), Quaternion.identity) as Transform;
        transform.gameObject.name = SpriteNameConst.RIGHT_USER_READY_INFO_NAME;
    }

    public static void removeRightUserReadyInfo()
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.RIGHT_USER_READY_INFO_NAME);
        if (null != gameObject)
        {
            Destroy(gameObject);
        }
    }

    public static void addSelfUserReadyInfo()
    {
        if (null != GameObject.Find(SpriteNameConst.SELF_USER_READY_INFO_NAME)) return;

        Transform prefab = Resources.Load<Transform>("prefab/info/readyInfo");
        Transform transform = Instantiate(prefab, new Vector3(0, -0.8f, 0.01f), Quaternion.identity) as Transform;
        transform.gameObject.name = SpriteNameConst.SELF_USER_READY_INFO_NAME;
    }

    public static void removeSelfUserReadyInfo()
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.SELF_USER_READY_INFO_NAME);
        if (null != gameObject)
        {
            Destroy(gameObject);
        }
    }

    public static void addLeftUserJiaoDiZhuInfo()
    {
        if (null != GameObject.Find(SpriteNameConst.LEFT_USER_JIAO_DI_ZHU_INFO_NAME)) return;

        Transform prefab = Resources.Load<Transform>("prefab/info/jiaoDiZhuInfo");
        Transform transform = Instantiate(prefab, new Vector3(-5, 3.5f, 0.01f), Quaternion.identity) as Transform;
        transform.gameObject.name = SpriteNameConst.LEFT_USER_JIAO_DI_ZHU_INFO_NAME;
    }

    public static void removeLeftUserJiaoDiZhuInfo()
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.LEFT_USER_JIAO_DI_ZHU_INFO_NAME);
        if (null != gameObject)
        {
            Destroy(gameObject);
        }
    }

    public static void addRightUserJiaoDiZhuInfo()
    {
        if (null != GameObject.Find(SpriteNameConst.RIGHT_USER_JIAO_DI_ZHU_INFO_NAME)) return;

        Transform prefab = Resources.Load<Transform>("prefab/info/jiaoDiZhuInfo");
        Transform transform = Instantiate(prefab, new Vector3(5, 3.5f, 0.01f), Quaternion.identity) as Transform;
        transform.gameObject.name = SpriteNameConst.RIGHT_USER_JIAO_DI_ZHU_INFO_NAME;
    }

    public static void removeRightUserJiaoDiZhuInfo()
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.RIGHT_USER_JIAO_DI_ZHU_INFO_NAME);
        if (null != gameObject)
        {
            Destroy(gameObject);
        }
    }

    public static void addSelfUserJiaoDiZhuInfo()
    {
        if (null != GameObject.Find(SpriteNameConst.SELF_USER_JIAO_DI_ZHU_INFO_NAME)) return;

        Transform prefab = Resources.Load<Transform>("prefab/info/jiaoDiZhuInfo");
        Transform transform = Instantiate(prefab, new Vector3(0, -1.3f, 0.01f), Quaternion.identity) as Transform;
        transform.gameObject.name = SpriteNameConst.SELF_USER_JIAO_DI_ZHU_INFO_NAME;
    }

    public static void removeSelfUserJiaoDiZhuInfo()
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.SELF_USER_JIAO_DI_ZHU_INFO_NAME);
        if (null != gameObject)
        {
            Destroy(gameObject);
        }
    }

    public static void addLeftUserBuJiaoInfo()
    {
        if (null != GameObject.Find(SpriteNameConst.LEFT_USER_BU_JIAO_INFO_NAME)) return;

        Transform prefab = Resources.Load<Transform>("prefab/info/buJiaoInfo");
        Transform transform = Instantiate(prefab, new Vector3(-5.5f, 3.5f, 0.01f), Quaternion.identity) as Transform;
        transform.gameObject.name = SpriteNameConst.LEFT_USER_BU_JIAO_INFO_NAME;
    }

    public static void removeLeftUserBuJiaoInfo()
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.LEFT_USER_BU_JIAO_INFO_NAME);
        if (null != gameObject)
        {
            Destroy(gameObject);
        }
    }

    public static void addRightUserBuJiaoInfo()
    {
        if (null != GameObject.Find(SpriteNameConst.RIGHT_USER_BU_JIAO_INFO_NAME)) return;

        Transform prefab = Resources.Load<Transform>("prefab/info/buJiaoInfo");
        Transform transform = Instantiate(prefab, new Vector3(5.5f, 3.5f, 0.01f), Quaternion.identity) as Transform;
        transform.gameObject.name = SpriteNameConst.RIGHT_USER_BU_JIAO_INFO_NAME;
    }

    public static void removeRightUserBuJiaoInfo()
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.RIGHT_USER_BU_JIAO_INFO_NAME);
        if (null != gameObject)
        {
            Destroy(gameObject);
        }
    }

    public static void addSelfUserBuJiaoInfo()
    {
        if (null != GameObject.Find(SpriteNameConst.SELF_USER_BU_JIAO_INFO_NAME)) return;

        Transform prefab = Resources.Load<Transform>("prefab/info/buJiaoInfo");
        Transform transform = Instantiate(prefab, new Vector3(0, -1.3f, 0.01f), Quaternion.identity) as Transform;
        transform.gameObject.name = SpriteNameConst.SELF_USER_BU_JIAO_INFO_NAME;
    }

    public static void removeSelfUserBuJiaoInfo()
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.SELF_USER_BU_JIAO_INFO_NAME);
        if (null != gameObject)
        {
            Destroy(gameObject);
        }
    }

    public static void addLeftUserQiangDiZhuInfo()
    {
        if (null != GameObject.Find(SpriteNameConst.LEFT_USER_QIANG_DI_ZHU_INFO_NAME)) return;

        Transform prefab = Resources.Load<Transform>("prefab/info/qiangDiZhuInfo");
        Transform transform = Instantiate(prefab, new Vector3(-5.5f, 3.5f, 0.01f), Quaternion.identity) as Transform;
        transform.gameObject.name = SpriteNameConst.LEFT_USER_QIANG_DI_ZHU_INFO_NAME;
    }

    public static void removeLeftUserQiangDiZhuInfo()
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.LEFT_USER_QIANG_DI_ZHU_INFO_NAME);
        if (null != gameObject)
        {
            Destroy(gameObject);
        }
    }

    public static void addRightUserQiangDiZhuInfo()
    {
        if (null != GameObject.Find(SpriteNameConst.RIGHT_USER_QIANG_DI_ZHU_INFO_NAME)) return;

        Transform prefab = Resources.Load<Transform>("prefab/info/qiangDiZhuInfo");
        Transform transform = Instantiate(prefab, new Vector3(5.5f, 3.5f, 0.01f), Quaternion.identity) as Transform;
        transform.gameObject.name = SpriteNameConst.RIGHT_USER_QIANG_DI_ZHU_INFO_NAME;
    }

    public static void removeRightUserQiangDiZhuInfo()
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.RIGHT_USER_QIANG_DI_ZHU_INFO_NAME);
        if (null != gameObject)
        {
            Destroy(gameObject);
        }
    }

    public static void addSelfUserQiangDiZhuInfo()
    {
        if (null != GameObject.Find(SpriteNameConst.SELF_USER_QIANG_DI_ZHU_INFO_NAME)) return;

        Transform prefab = Resources.Load<Transform>("prefab/info/qiangDiZhuInfo");
        Transform transform = Instantiate(prefab, new Vector3(0, -1.3f, 0.01f), Quaternion.identity) as Transform;
        transform.gameObject.name = SpriteNameConst.SELF_USER_QIANG_DI_ZHU_INFO_NAME;
    }

    public static void removeSelfUserQiangDiZhuInfo()
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.SELF_USER_QIANG_DI_ZHU_INFO_NAME);
        if (null != gameObject)
        {
            Destroy(gameObject);
        }
    }

    public static void addLeftUserBuQiangInfo()
    {
        if (null != GameObject.Find(SpriteNameConst.LEFT_USER_BU_QIANG_INFO_NAME)) return;

        Transform prefab = Resources.Load<Transform>("prefab/info/buQiangInfo");
        Transform transform = Instantiate(prefab, new Vector3(-5.5f, 3.5f, 0.01f), Quaternion.identity) as Transform;
        transform.gameObject.name = SpriteNameConst.LEFT_USER_BU_QIANG_INFO_NAME;
    }

    public static void removeLeftUserBuQiangInfo()
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.LEFT_USER_BU_QIANG_INFO_NAME);
        if (null != gameObject)
        {
            Destroy(gameObject);
        }
    }

    public static void addRightUserBuQiangInfo()
    {
        if (null != GameObject.Find(SpriteNameConst.RIGHT_USER_BU_QIANG_INFO_NAME)) return;

        Transform prefab = Resources.Load<Transform>("prefab/info/buQiangInfo");
        Transform transform = Instantiate(prefab, new Vector3(5.5f, 3.5f, 0.01f), Quaternion.identity) as Transform;
        transform.gameObject.name = SpriteNameConst.RIGHT_USER_BU_QIANG_INFO_NAME;
    }

    public static void removeRightUserBuQiangInfo()
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.RIGHT_USER_BU_QIANG_INFO_NAME);
        if (null != gameObject)
        {
            Destroy(gameObject);
        }
    }

    public static void addSelfUserBuQiangInfo()
    {
        if (null != GameObject.Find(SpriteNameConst.SELF_USER_BU_QIANG_INFO_NAME)) return;

        Transform prefab = Resources.Load<Transform>("prefab/info/buQiangInfo");
        Transform transform = Instantiate(prefab, new Vector3(0, -1.3f, 0.01f), Quaternion.identity) as Transform;
        transform.gameObject.name = SpriteNameConst.SELF_USER_BU_QIANG_INFO_NAME;
    }

    public static void removeSelfUserBuQiangInfo()
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.SELF_USER_BU_QIANG_INFO_NAME);
        if (null != gameObject)
        {
            Destroy(gameObject);
        }
    }

    public static void addLeftUserBuChuInfo()
    {
        if (null != GameObject.Find(SpriteNameConst.LEFT_USER_BU_CHU_INFO_NAME)) return;

        Transform prefab = Resources.Load<Transform>("prefab/info/buChuInfo");
        Transform transform = Instantiate(prefab, new Vector3(-5.5f, 3.5f, 0.01f), Quaternion.identity) as Transform;
        transform.gameObject.name = SpriteNameConst.LEFT_USER_BU_CHU_INFO_NAME;
    }

    public static void removeLeftUserBuChuInfo()
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.LEFT_USER_BU_CHU_INFO_NAME);
        if (null != gameObject)
        {
            Destroy(gameObject);
        }
    }

    public static void addRightUserBuChuInfo()
    {
        if (null != GameObject.Find(SpriteNameConst.RIGHT_USER_BU_CHU_INFO_NAME)) return;

        Transform prefab = Resources.Load<Transform>("prefab/info/buChuInfo");
        Transform transform = Instantiate(prefab, new Vector3(5.5f, 3.5f, 0.01f), Quaternion.identity) as Transform;
        transform.gameObject.name = SpriteNameConst.RIGHT_USER_BU_CHU_INFO_NAME;
    }

    public static void removeRightUserBuChuInfo()
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.RIGHT_USER_BU_CHU_INFO_NAME);
        if (null != gameObject)
        {
            Destroy(gameObject);
        }
    }

    public static void addSelfUserBuChuInfo()
    {
        if (null != GameObject.Find(SpriteNameConst.SELF_USER_BU_CHU_INFO_NAME)) return;

        Transform prefab = Resources.Load<Transform>("prefab/info/buChuInfo");
        Transform transform = Instantiate(prefab, new Vector3(0, -1.3f, 0.01f), Quaternion.identity) as Transform;
        transform.gameObject.name = SpriteNameConst.SELF_USER_BU_CHU_INFO_NAME;
    }

    public static void removeSelfUserBuChuInfo()
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.SELF_USER_BU_CHU_INFO_NAME);
        if (null != gameObject)
        {
            Destroy(gameObject);
        }
    }

    public static void addSelfUserChuPaiErrorInfo()
    {
        if (null != GameObject.Find(SpriteNameConst.SELF_USER_CHU_PAI_ERROR_INFO_NAME)) return;

        Transform prefab = Resources.Load<Transform>("prefab/info/chuPaiErrorInfo");
        Transform transform = Instantiate(prefab, new Vector3(0, -1.3f, 0.01f), Quaternion.identity) as Transform;
        transform.gameObject.name = SpriteNameConst.SELF_USER_CHU_PAI_ERROR_INFO_NAME;
    }

    public static void removeSelfUserChuPaiErrorInfo()
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.SELF_USER_CHU_PAI_ERROR_INFO_NAME);
        if (null != gameObject)
        {
            Destroy(gameObject);
        }
    }
}