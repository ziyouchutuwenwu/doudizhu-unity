using UnityEngine;
using System.Collections;

/*
//button之类的ui控件，必须放在canvas里面，建议canvas直接设置世界坐标，event camera必须配置，否则点击没反映
    Transform parentTransform = GameObject.Find("Canvas").transform;
    ButtonHelper.addTiShiButton(parentTransform, true, touchCallBack);

    public void touchCallBack(ButtonScript buttonScript)
    {
        Debug.Log("1111");
    }
 
*/
public class ButtonHelper : MonoBehaviour {

    private const float ButtonY = 1.0f;

    //不出，重选，提示，出牌四个按钮的位置
    private const float PlayingButtonXOffset = 1f;
	private const float PlayingButtonY = -0.5f;

    public static void addReadyButton(Transform parentTransform, ButtonScript.TouchCallBack touchCallBack)
    {
        if (null != GameObject.Find(SpriteNameConst.READY_BUTTON_NAME)) return;

        Transform prefab = Resources.Load<Transform>("prefab/button/button");
        Transform transform = Instantiate(prefab, new Vector3(-2, ButtonY, 0.01f), Quaternion.identity) as Transform;
        transform.gameObject.name = SpriteNameConst.READY_BUTTON_NAME;
        transform.SetParent(parentTransform);

        ButtonScript buttonScript = transform.GetComponent<ButtonScript>();
        buttonScript.setImage("imgs/threePersonsPlay/cardExtra/zhunbei_btn");
        buttonScript.setEnabled(true);
        buttonScript.setTouchCallBack(touchCallBack);
    }

    public static void addChangeDeskButton(Transform parentTransform, ButtonScript.TouchCallBack touchCallBack)
    {
        if (null != GameObject.Find(SpriteNameConst.CHANGE_DESK_BUTTON_NAME)) return;

        Transform prefab = Resources.Load<Transform>("prefab/button/button");
        Transform transform = Instantiate(prefab, new Vector3(2, ButtonY, 0.01f), Quaternion.identity) as Transform;
        transform.gameObject.name = SpriteNameConst.CHANGE_DESK_BUTTON_NAME;
        transform.SetParent(parentTransform);

        ButtonScript buttonScript = transform.GetComponent<ButtonScript>();
        buttonScript.setImage("imgs/threePersonsPlay/cardExtra/huanzhuo_btn");
        buttonScript.setEnabled(true);
        buttonScript.setTouchCallBack(touchCallBack);
    }

    public static void addJiaoDiZhuButton(Transform parentTransform, ButtonScript.TouchCallBack touchCallBack)
    {
        if (null != GameObject.Find(SpriteNameConst.JIAO_DI_ZHU_BUTTON_NAME)) return;

        Transform prefab = Resources.Load<Transform>("prefab/button/button");
		Transform transform = Instantiate(prefab, new Vector3(-2, PlayingButtonY, 0.01f), Quaternion.identity) as Transform;
        transform.gameObject.name = SpriteNameConst.JIAO_DI_ZHU_BUTTON_NAME;
        transform.SetParent(parentTransform);

        ButtonScript buttonScript = transform.GetComponent<ButtonScript>();
        buttonScript.setImage("imgs/threePersonsPlay/cardExtra/jiaodizhu_btn");
        buttonScript.setEnabled(true);
        buttonScript.setTouchCallBack(touchCallBack);
    }

    public static void addBuJiaoButton(Transform parentTransform, ButtonScript.TouchCallBack touchCallBack)
    {
        if (null != GameObject.Find(SpriteNameConst.BU_JIAO_BUTTON_NAME)) return;

        Transform prefab = Resources.Load<Transform>("prefab/button/button");
		Transform transform = Instantiate(prefab, new Vector3(2, PlayingButtonY, 0.01f), Quaternion.identity) as Transform;
        transform.gameObject.name = SpriteNameConst.BU_JIAO_BUTTON_NAME;
        transform.SetParent(parentTransform);

        ButtonScript buttonScript = transform.GetComponent<ButtonScript>();
        buttonScript.setImage("imgs/threePersonsPlay/cardExtra/bujiao_btn");
        buttonScript.setEnabled(true);
        buttonScript.setTouchCallBack(touchCallBack);
    }

    public static void addQiangDiZhuButton(Transform parentTransform, ButtonScript.TouchCallBack touchCallBack)
    {
        if (null != GameObject.Find(SpriteNameConst.QIANG_DI_ZHU_BUTTON_NAME)) return;

        Transform prefab = Resources.Load<Transform>("prefab/button/button");
		Transform transform = Instantiate(prefab, new Vector3(-2, PlayingButtonY, 0.01f), Quaternion.identity) as Transform;
        transform.gameObject.name = SpriteNameConst.QIANG_DI_ZHU_BUTTON_NAME;
        transform.SetParent(parentTransform);

        ButtonScript buttonScript = transform.GetComponent<ButtonScript>();
        buttonScript.setImage("imgs/threePersonsPlay/cardExtra/qiangdizhu_btn");
        buttonScript.setEnabled(true);
        buttonScript.setTouchCallBack(touchCallBack);
    }

    public static void addBuQiangButton(Transform parentTransform, ButtonScript.TouchCallBack touchCallBack)
    {
        if (null != GameObject.Find(SpriteNameConst.BU_QIANG_BUTTON_NAME)) return;

        Transform prefab = Resources.Load<Transform>("prefab/button/button");
		Transform transform = Instantiate(prefab, new Vector3(2, PlayingButtonY, 0.01f), Quaternion.identity) as Transform;
        transform.gameObject.name = SpriteNameConst.BU_QIANG_BUTTON_NAME;
        transform.SetParent(parentTransform);

        ButtonScript buttonScript = transform.GetComponent<ButtonScript>();
        buttonScript.setImage("imgs/threePersonsPlay/cardExtra/buqiang_btn");
        buttonScript.setEnabled(true);
        buttonScript.setTouchCallBack(touchCallBack);
    }

    public static void addBuChuButton(Transform parentTransform, bool isEnabled, ButtonScript.TouchCallBack touchCallBack)
    {
        if (null != GameObject.Find(SpriteNameConst.BU_CHU_BUTTON_NAME)) return;

        Transform prefab = Resources.Load<Transform>("prefab/button/button");
        Transform transform = Instantiate(prefab, new Vector3(-4.18f + PlayingButtonXOffset, PlayingButtonY, 0.01f), Quaternion.identity) as Transform;
        transform.gameObject.name = SpriteNameConst.BU_CHU_BUTTON_NAME;
        transform.SetParent(parentTransform);

        ButtonScript buttonScript = transform.GetComponent<ButtonScript>();
        buttonScript.setTouchCallBack(touchCallBack);

        if (isEnabled)
        {
            buttonScript.setImage("imgs/threePersonsPlay/cardExtra/buchu_btn");
            buttonScript.setEnabled(true);
        }
        else
        {
            buttonScript.setImage("imgs/threePersonsPlay/cardExtra/buchu_btn_gray");
            buttonScript.setEnabled(false);
        }
    }

    public static void setBuChuButtonEnabled(bool isEnabled)
    {
        if (null == GameObject.Find(SpriteNameConst.BU_CHU_BUTTON_NAME)) return;

        Transform transform = GameObject.Find(SpriteNameConst.BU_CHU_BUTTON_NAME).transform;
        ButtonScript buttonScript = transform.GetComponent<ButtonScript>();
        if (isEnabled)
        {
            buttonScript.setImage("imgs/threePersonsPlay/cardExtra/buchu_btn");
            buttonScript.setEnabled(true);
        }
        else
        {
            buttonScript.setImage("imgs/threePersonsPlay/cardExtra/buchu_btn_gray");
            buttonScript.setEnabled(false);
        }
    }

    public static void addChongXuanButton(Transform parentTransform, bool isEnabled, ButtonScript.TouchCallBack touchCallBack)
    {
        if (null != GameObject.Find(SpriteNameConst.CHONG_XUAN_BUTTON_NAME)) return;

        Transform prefab = Resources.Load<Transform>("prefab/button/button");
        Transform transform = Instantiate(prefab, new Vector3(-1.4f + PlayingButtonXOffset, PlayingButtonY, 0.01f), Quaternion.identity) as Transform;
        transform.gameObject.name = SpriteNameConst.CHONG_XUAN_BUTTON_NAME;
        transform.SetParent(parentTransform);

        ButtonScript buttonScript = transform.GetComponent<ButtonScript>();
        buttonScript.setTouchCallBack(touchCallBack);

        if (isEnabled)
        {
            buttonScript.setImage("imgs/threePersonsPlay/cardExtra/chongxuan_btn");
            buttonScript.setEnabled(true);
        }
        else
        {
            buttonScript.setImage("imgs/threePersonsPlay/cardExtra/chongxuan_btn_gray");
            buttonScript.setEnabled(false);
        }
    }

    public static void setChongXuanButtonEnabled(bool isEnabled)
    {
        if (null == GameObject.Find(SpriteNameConst.CHONG_XUAN_BUTTON_NAME)) return;

        Transform transform = GameObject.Find(SpriteNameConst.CHONG_XUAN_BUTTON_NAME).transform;
        ButtonScript buttonScript = transform.GetComponent<ButtonScript>();
        if (isEnabled)
        {
            buttonScript.setImage("imgs/threePersonsPlay/cardExtra/chongxuan_btn");
            buttonScript.setEnabled(true);
        }
        else
        {
            buttonScript.setImage("imgs/threePersonsPlay/cardExtra/chongxuan_btn_gray");
            buttonScript.setEnabled(false);
        }
    }

    public static void addTiShiButton(Transform parentTransform, bool isEnabled, ButtonScript.TouchCallBack touchCallBack)
    {
        if (null != GameObject.Find(SpriteNameConst.TI_SHI_BUTTON_NAME)) return;

        Transform prefab = Resources.Load<Transform>("prefab/button/button");
        Transform transform = Instantiate(prefab, new Vector3(1.4f + PlayingButtonXOffset, PlayingButtonY, 0.01f), Quaternion.identity) as Transform;
        transform.gameObject.name = SpriteNameConst.TI_SHI_BUTTON_NAME;
        transform.SetParent(parentTransform);

        ButtonScript buttonScript = transform.GetComponent<ButtonScript>();
        buttonScript.setTouchCallBack(touchCallBack);

        if (isEnabled)
        {
            buttonScript.setImage("imgs/threePersonsPlay/cardExtra/tishi_btn");
            buttonScript.setEnabled(true);
        }
        else
        {
            buttonScript.setImage("imgs/threePersonsPlay/cardExtra/tishi_btn_gray");
            buttonScript.setEnabled(false);
        }
    }

    public static void setTiShiButtonEnabled(bool isEnabled)
    {
        if (null == GameObject.Find(SpriteNameConst.TI_SHI_BUTTON_NAME)) return;

        Transform transform = GameObject.Find(SpriteNameConst.TI_SHI_BUTTON_NAME).transform;
        ButtonScript buttonScript = transform.GetComponent<ButtonScript>();
        if (isEnabled)
        {
            buttonScript.setImage("imgs/threePersonsPlay/cardExtra/tishi_btn");
            buttonScript.setEnabled(true);
        }
        else
        {
            buttonScript.setImage("imgs/threePersonsPlay/cardExtra/tishi_btn_gray");
            buttonScript.setEnabled(false);
        }
    }

    public static void addChuPaiButton(Transform parentTransform, bool isEnabled, ButtonScript.TouchCallBack touchCallBack)
    {
        if (null != GameObject.Find(SpriteNameConst.CHU_PAI_BUTTON_NAME)) return;

        Transform prefab = Resources.Load<Transform>("prefab/button/button");
        Transform transform = Instantiate(prefab, new Vector3(4.18f + PlayingButtonXOffset, PlayingButtonY, 0.01f), Quaternion.identity) as Transform;
        transform.gameObject.name = SpriteNameConst.CHU_PAI_BUTTON_NAME;
        transform.SetParent(parentTransform);

        ButtonScript buttonScript = transform.GetComponent<ButtonScript>();
        buttonScript.setTouchCallBack(touchCallBack);

        if (isEnabled)
        {
            buttonScript.setImage("imgs/threePersonsPlay/cardExtra/chupai_btn");
            buttonScript.setEnabled(true);
        }
        else
        {
            buttonScript.setImage("imgs/threePersonsPlay/cardExtra/chupai_btn_gray");
            buttonScript.setEnabled(false);
        }
    }

    public static void setChuPaiButtonEnabled(bool isEnabled)
    {
        if (null == GameObject.Find(SpriteNameConst.CHU_PAI_BUTTON_NAME)) return;

        Transform transform = GameObject.Find(SpriteNameConst.CHU_PAI_BUTTON_NAME).transform;
        ButtonScript buttonScript = transform.GetComponent<ButtonScript>();
        if (isEnabled)
        {
            buttonScript.setImage("imgs/threePersonsPlay/cardExtra/chupai_btn");
            buttonScript.setEnabled(true);
        }
        else
        {
            buttonScript.setImage("imgs/threePersonsPlay/cardExtra/chupai_btn_gray");
            buttonScript.setEnabled(false);
        }
    }

    public static void removeReadyButton()
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.READY_BUTTON_NAME);
        if (null != gameObject)
        {
            Destroy(gameObject);
        }
    }

    public static void removeChangeDeskButton()
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.CHANGE_DESK_BUTTON_NAME);
        if (null != gameObject)
        {
            Destroy(gameObject);
        }
    }

    public static void removeJiaoDiZhuButton()
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.JIAO_DI_ZHU_BUTTON_NAME);
        if (null != gameObject)
        {
            Destroy(gameObject);
        }
    }

    public static void removeBuJiaoButton()
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.BU_JIAO_BUTTON_NAME);
        if (null != gameObject)
        {
            Destroy(gameObject);
        }
    }

    public static void removeQiangDiZhuButton()
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.QIANG_DI_ZHU_BUTTON_NAME);
        if (null != gameObject)
        {
            Destroy(gameObject);
        }
    }

    public static void removeBuQiangButton()
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.BU_QIANG_BUTTON_NAME);
        if (null != gameObject)
        {
            Destroy(gameObject);
        }
    }

    public static void removeBuChuButton()
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.BU_CHU_BUTTON_NAME);
        if (null != gameObject)
        {
            Destroy(gameObject);
        }
    }

    public static void removeChongXuanButton()
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.CHONG_XUAN_BUTTON_NAME);
        if (null != gameObject)
        {
            Destroy(gameObject);
        }
    }

    public static void removeTiShiButton()
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.TI_SHI_BUTTON_NAME);
        if (null != gameObject)
        {
            Destroy(gameObject);
        }
    }

    public static void removeChuPaiButton()
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.CHU_PAI_BUTTON_NAME);
        if (null != gameObject)
        {
            Destroy(gameObject);
        }
    }
}