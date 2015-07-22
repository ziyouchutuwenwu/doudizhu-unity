using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class CardButtonScript : MonoBehaviour
{
    public delegate void TouchCallBack(CardButtonScript cardSpriteScript);

    private TouchCallBack _touchCallBack = null;
    private bool _touchEnabled = false;
    private int _tag = 0;

    private Transform _oldParentTransform = null;

    public void setTouchCallBack(TouchCallBack callBack)
    {
        _touchCallBack = callBack;
    }

    public void setTouchEnabled(bool touchEnabled)
    {
        _touchEnabled = touchEnabled;
    }

    private void initButtonCallBack()
    {
        Button btn = this.transform.GetComponent<Button>();
        btn.onClick.AddListener(delegate()
        {
            this.buttonButtonTapped();
        });
    }

    public int getTag()
    {
        return _tag;
    }

    public void setTag(int tag)
    {
        _tag = tag;
    }

    void buttonButtonTapped()
    {
        if (_touchEnabled && _touchCallBack != null)
        {
            _touchCallBack(this);
        }
    }

    public CardBgScript getTopParentScript()
    {
        return this.transform.parent.parent.GetComponent<CardBgScript>();
    }

    public void setParent(Transform parentTransform)
    {
        this.transform.SetParent(parentTransform.FindChild("Canvas"));
        Destroy(_oldParentTransform.gameObject);
    }

    void Awake()
    {
        _oldParentTransform = this.transform.parent;
        initButtonCallBack();
    }

    public void moveTo(Vector3 position)
    {
        this.transform.DOLocalMove(position, 2).
                        SetEase(Ease.OutQuint).
                        SetLoops(0);
    }

    public void remove()
    {
        Destroy(this.transform.gameObject);
    }
}