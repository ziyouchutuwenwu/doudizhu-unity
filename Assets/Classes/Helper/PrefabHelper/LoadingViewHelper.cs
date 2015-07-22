using UnityEngine;
using System.Collections;

public class LoadingViewHelper : MonoBehaviour {

    public static void addLoadingView()
    {
        if (null != GameObject.Find(SpriteNameConst.LOADING_VIEW_NAME)) return;

        Transform prefab = Resources.Load<Transform>("prefab/loadingView/loadingView");
        Transform transform = Instantiate(prefab, new Vector3(0, 1, 1), Quaternion.identity) as Transform;
        transform.gameObject.name = SpriteNameConst.LOADING_VIEW_NAME;

        CanvasHelper.setOtherCanvasTouchEnabled(null,false);
    }

    public static void removeLoadingView()
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.LOADING_VIEW_NAME);
        if (null != gameObject)
        {
            CanvasHelper.setOtherCanvasTouchEnabled(null, true);
            Destroy(gameObject);
        }
    }
}