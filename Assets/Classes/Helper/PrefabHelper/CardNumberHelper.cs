using UnityEngine;
using System.Collections;

public class CardNumberHelper : MonoBehaviour {

    public static void addLeftUserCardNumber()
    {
        if (null != GameObject.Find(SpriteNameConst.LEFT_USER_CARD_NUMBER_NAME)) return;

        Transform prefab = Resources.Load<Transform>("prefab/cardNumber/cardNumber");
        Transform transform = Instantiate(prefab, new Vector3(-7f, 3f, 0.01f), Quaternion.identity) as Transform;
        transform.gameObject.name = SpriteNameConst.LEFT_USER_CARD_NUMBER_NAME;
    }

    public static void setLeftUserCardNumber(int nubmer)
    {
        if (null == GameObject.Find(SpriteNameConst.LEFT_USER_CARD_NUMBER_NAME)) return;

        CardNumberScript cardNumberScript = (CardNumberScript)GameObject.Find(SpriteNameConst.LEFT_USER_CARD_NUMBER_NAME).GetComponent<CardNumberScript>();
        cardNumberScript.setCardNumber(nubmer);
    }

    public static void removeLeftUserCardNumber()
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.LEFT_USER_CARD_NUMBER_NAME);
        if (null != gameObject)
        {
            Destroy(gameObject);
        }
    }

    public static void addRightUserCardNumber()
    {
        if (null != GameObject.Find(SpriteNameConst.RIGHT_USER_CARD_NUMBER_NAME)) return;

        Transform prefab = Resources.Load<Transform>("prefab/cardNumber/cardNumber");
		Transform transform = Instantiate(prefab, new Vector3(7f, 3f, 0.01f), Quaternion.identity) as Transform;
        transform.gameObject.name = SpriteNameConst.RIGHT_USER_CARD_NUMBER_NAME;
    }

    public static void setRightUserCardNumber(int nubmer)
    {
        if (null == GameObject.Find(SpriteNameConst.LEFT_USER_CARD_NUMBER_NAME)) return;

        CardNumberScript cardNumberScript = (CardNumberScript)GameObject.Find(SpriteNameConst.RIGHT_USER_CARD_NUMBER_NAME).GetComponent<CardNumberScript>();
        cardNumberScript.setCardNumber(nubmer);
    }

    public static void removeRightUserCardNumber()
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.RIGHT_USER_CARD_NUMBER_NAME);
        if (null != gameObject)
        {
            Destroy(gameObject);
        }
    }
}