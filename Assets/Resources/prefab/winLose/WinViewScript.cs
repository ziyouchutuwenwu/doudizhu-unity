using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WinViewScript : MonoBehaviour
{
    public delegate void CloseCallBack();
    public delegate void PlayAgainCallBack();

    private CloseCallBack _closeCallBack = null;
    private PlayAgainCallBack _playAgainCallBack = null;

    public void setCloseCallBack(CloseCallBack closeCallBack)
    {
        _closeCallBack = closeCallBack;
    }

    public void setPlayAgainCallBack(PlayAgainCallBack playAgainCallBack)
    {
        _playAgainCallBack = playAgainCallBack;
    }

    private void initButtonCallBack()
    {
        Button closeButton = this.transform.FindChild("Canvas").FindChild("closeButton").GetComponent<Button>();
        closeButton.onClick.AddListener(delegate()
        {
            this.onCloseButtonTapped();
        });

        Button againButton = this.transform.FindChild("Canvas").FindChild("againButton").GetComponent<Button>();
        againButton.onClick.AddListener(delegate()
        {
            this.onAgainButtonTapped();
        });
    }

    void onCloseButtonTapped()
    {
        if (null != _closeCallBack)
        {
            _closeCallBack();
        }

        CanvasHelper.setOtherCanvasTouchEnabled(transform, true);
        Destroy(this.gameObject);
    }

    void onAgainButtonTapped()
    {
        if (null != _playAgainCallBack)
        {
            _playAgainCallBack();
        }
    }

    void Awake()
    {
        this.transform.FindChild("Canvas").GetComponent<Canvas>().worldCamera = Camera.main;
        initButtonCallBack();
    }
}