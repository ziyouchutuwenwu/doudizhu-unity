using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class LoadingViewScript : MonoBehaviour {

    private SpriteRenderer _progressSpriteRender = null;

    void Awake()
    {
        _progressSpriteRender = this.transform.FindChild("bg").FindChild("progress").GetComponent<SpriteRenderer>();
        _progressSpriteRender.transform.localPosition = new Vector3(-1.708f, -0.306f, 0f);

        doLeftToRightAnimation();
    }

    void doLeftToRightAnimation()
    {
        _progressSpriteRender.transform.DOMoveX(1.693f, 3.5f).SetEase(Ease.Unset).SetLoops(0).OnComplete(onLeftToRightAnimationStop);
    }

    void doRightToLeftAnimation()
    {
        _progressSpriteRender.transform.DOMoveX(-1.708f, 3.5f).SetEase(Ease.Unset).SetLoops(0).OnComplete(onRightToLeftAnimationStop);
    }

    //callBack
    void onLeftToRightAnimationStop()
    {
        doRightToLeftAnimation();
    } 

    void onRightToLeftAnimationStop()
    {
        doLeftToRightAnimation();
    }
}