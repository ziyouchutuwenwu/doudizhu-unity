using UnityEngine;
using System.Collections;

public class WinLoseViewHelper : MonoBehaviour {

    public static void addLoseView(LoseViewScript.PlayAgainCallBack playAgainCallBack, LoseViewScript.CloseCallBack closeCallBack)
    {
        if (null != GameObject.Find(SpriteNameConst.LOSE_VIEW_NAME)) return;

        Transform prefab = Resources.Load<Transform>("prefab/winLose/loseView");
        Transform transform = Instantiate(prefab, new Vector3(0, 1, 1), Quaternion.identity) as Transform;
        transform.gameObject.name = SpriteNameConst.LOSE_VIEW_NAME;

        LoseViewScript loseViewScript = transform.GetComponent<LoseViewScript>();
        CanvasHelper.setOtherCanvasTouchEnabled(transform, false);
        loseViewScript.setPlayAgainCallBack(playAgainCallBack);
        loseViewScript.setCloseCallBack(closeCallBack);
    }

    public static void removeLoseView()
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.LOSE_VIEW_NAME);
        if (null != gameObject)
        {
            CanvasHelper.setOtherCanvasTouchEnabled(gameObject.transform, true);
            Destroy(gameObject);
        }
    }

    public static void addWinView(WinViewScript.PlayAgainCallBack playAgainCallBack, WinViewScript.CloseCallBack closeCallBack)
    {
        if (null != GameObject.Find(SpriteNameConst.WIN_VIEW_NAME)) return;

        Transform prefab = Resources.Load<Transform>("prefab/winLose/winView");
        Transform transform = Instantiate(prefab, new Vector3(0, 1, 1), Quaternion.identity) as Transform;
        transform.gameObject.name = SpriteNameConst.WIN_VIEW_NAME;

        WinViewScript winViewScript = transform.GetComponent<WinViewScript>();
        CanvasHelper.setOtherCanvasTouchEnabled(transform, false);
        winViewScript.setPlayAgainCallBack(playAgainCallBack);
        winViewScript.setCloseCallBack(closeCallBack);
    }

    public static void removeWinView()
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.WIN_VIEW_NAME);
        if (null != gameObject)
        {
            CanvasHelper.setOtherCanvasTouchEnabled(gameObject.transform, true);
            Destroy(gameObject);
        }
    }
}
