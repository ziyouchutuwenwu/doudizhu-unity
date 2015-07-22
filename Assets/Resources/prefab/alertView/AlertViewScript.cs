using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AlertViewScript : MonoBehaviour
{
    public delegate void TouchCallBack(AlertViewScript script);
    private TouchCallBack _touchCallBack = null;

    public void setTouchCallBack(TouchCallBack touchCallBack)
    {
        _touchCallBack = touchCallBack;
    }

    public void setInfo(string info)
    {
        this.transform.FindChild("Canvas").FindChild("infoText").GetComponent<Text>().text = info;
    }

    void Awake()
    {
        this.transform.FindChild("Canvas").FindChild("buttonOk").GetComponent<Button>().onClick.AddListener(delegate()
        {
            this.okClick();
        });
        this.transform.FindChild("Canvas").GetComponent<Canvas>().worldCamera = Camera.main;
    }

    private void okClick()
    {
        if (_touchCallBack != null)
        {
            _touchCallBack(this);
        }
    }
}