using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public delegate void TouchCallBack(ButtonScript buttonScript);
    private TouchCallBack _touchCallBack = null;

    public void Awake()
    {
        Button btn = this.transform.GetComponent<Button>();
        btn.onClick.AddListener(delegate()
        {
            this.onClick();
        });
    }

    public void setTouchCallBack(TouchCallBack touchCallBack)
    {
        _touchCallBack = touchCallBack;
    }

    public void setImage(string imgFullPath)
    {
        Image btnImage = this.transform.GetComponent<Image>();
        btnImage.sprite = Resources.Load<Sprite>(imgFullPath);
    }

    public void setEnabled(bool enabled)
    {
        Button btnScript = this.transform.GetComponent<Button>();
        if (enabled)
        {
            btnScript.interactable = true;
        }
        else
        {
            btnScript.interactable = false;
        }
    }

    private void onClick()
    {
        if ( _touchCallBack != null )
        {
            _touchCallBack(this);
        }
    }
}
