using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ActionViewScript : MonoBehaviour
{
    public delegate void TouchCallBack(ActionViewScript actionViewScript);
    private TouchCallBack _okTouchCallBack = null;
    private TouchCallBack _cancelTouchCallBack = null;

    public void setMessageInfo(string infoText)
    {
        this.transform.FindChild("Canvas").FindChild("infoText").GetComponent<Text>().text = infoText;
    }

    public void setOkTouchCallBack(TouchCallBack okTouchCallBack)
    {
        _okTouchCallBack = okTouchCallBack;
    }

    public void setCancelTouchCallBack(TouchCallBack cancelTouchCallBack)
    {
        _cancelTouchCallBack = cancelTouchCallBack;
    }

    void Awake()
    {
        this.transform.FindChild("Canvas").FindChild("buttonOk").GetComponent<Button>().onClick.AddListener(delegate()
        {
            this.okClick();
        });

        this.transform.FindChild("Canvas").FindChild("buttonCancel").GetComponent<Button>().onClick.AddListener(delegate()
        {
            this.cancelClick();
        });

        this.transform.FindChild("Canvas").GetComponent<Canvas>().worldCamera = Camera.main;
    }

    private void okClick()
    {
        if (_okTouchCallBack != null)
        {
            _okTouchCallBack(this);
        }
    }

    private void cancelClick()
    {
        if (_cancelTouchCallBack != null)
        {
            _cancelTouchCallBack(this);
        }
    }
}