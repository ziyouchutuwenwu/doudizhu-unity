using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SettingViewScript : MonoBehaviour {

    public delegate void VolumeChangeCallBack(SettingViewScript script,float percent);
    private VolumeChangeCallBack _bgMusicVolumeChangeCallBack = null;
    private VolumeChangeCallBack _soundVolumeChangeCallBack = null;

    public delegate void ToggleSwitchCallBack(SettingViewScript script, bool isOn);
    private ToggleSwitchCallBack _bgMusicMuteSwitchCallBack = null;
    private ToggleSwitchCallBack _soundMuteSwitchCallBack = null;

    public delegate void InitCallBack(SettingViewScript script);
    private InitCallBack _initCallBack = null;

    public delegate void TouchCallBack(SettingViewScript script);
    private TouchCallBack _touchCallBack = null;

    private Slider _bgMusicVolumeSlider = null;
    private Slider _soundVolumeSlider = null;

    private Toggle _bgMusicMuteToggle = null;
    private Toggle _soundMuteToggle = null;

    public void setBgMusicVolume(float musicVolPercentage)
    {
        _bgMusicVolumeSlider.value = musicVolPercentage;
    }

    public void setSoundVolume(float soundVolPercentage)
    {
        _soundVolumeSlider.value = soundVolPercentage;
    }

    public void setBgMusicMute(bool isMute)
    {
        _bgMusicMuteToggle.isOn = isMute;
    }

    public void setSoundMute(bool isMute)
    {
        _soundMuteToggle.isOn = isMute;
    }

    public void setBgMusicVolumeChangeCallBack(VolumeChangeCallBack bgMusicVolumeChangeCallBack)
    {
        _bgMusicVolumeChangeCallBack = bgMusicVolumeChangeCallBack;
    }

    public void setSoundVolumeChangeCallBack(VolumeChangeCallBack soundVolumeChangeCallBack)
    {
        _soundVolumeChangeCallBack = soundVolumeChangeCallBack;
    }

    public void setBgMusicMuteSwitchCallBack(ToggleSwitchCallBack bgMusicMuteSwitchCallBack)
    {
        _bgMusicMuteSwitchCallBack = bgMusicMuteSwitchCallBack;
    }

    public void setSoundMuteSwitchCallBack(ToggleSwitchCallBack soundMuteSwitchCallBack)
    {
        _soundMuteSwitchCallBack = soundMuteSwitchCallBack;
    }

    public void setInitCallBack(InitCallBack initCallBack)
    {
        _initCallBack = initCallBack;
    }

    public void setTouchCallBack(TouchCallBack touchCallBack)
    {
        _touchCallBack = touchCallBack;
    }

    void Awake()
    {
        _bgMusicVolumeSlider = this.transform.FindChild("Canvas").FindChild("bgMusicVolumeSlider").GetComponent<Slider>();
        _soundVolumeSlider = this.transform.FindChild("Canvas").FindChild("soundVolumeSlider").GetComponent<Slider>();
        _bgMusicMuteToggle = this.transform.FindChild("Canvas").FindChild("bgMusicMuteToggle").GetComponent<Toggle>();
        _soundMuteToggle = this.transform.FindChild("Canvas").FindChild("soundMuteToggle").GetComponent<Toggle>();
        this.transform.FindChild("Canvas").GetComponent<Canvas>().worldCamera = Camera.main;
    }

    void Start()
    {
        if (_initCallBack != null)
        {
            _initCallBack(this);
        }

        _bgMusicVolumeSlider.onValueChanged.AddListener(delegate
        { 
            bgMusicVolumeSliderValueChanged();
        });
        _soundVolumeSlider.onValueChanged.AddListener(delegate
        {
            soundVolumeSliderValueChanged();
        });

        _bgMusicMuteToggle.onValueChanged.AddListener(delegate
        {
            bgMusicVolumeToggleValueChanged();
        });

        _soundMuteToggle.onValueChanged.AddListener(delegate
        {
            soundVolumeToggleValueChanged();
        });

        this.transform.FindChild("Canvas").FindChild("buttonOk").GetComponent<Button>().onClick.AddListener(delegate()
        {
            this.okClick();
        });
    }

    private void bgMusicVolumeSliderValueChanged()
    {
        if (null != _bgMusicVolumeChangeCallBack) _bgMusicVolumeChangeCallBack(this,_bgMusicVolumeSlider.value);
    }

    private void soundVolumeSliderValueChanged()
    {
        if (null != _soundVolumeChangeCallBack) _soundVolumeChangeCallBack(this, _soundVolumeSlider.value);
    }

    private void bgMusicVolumeToggleValueChanged()
    {
        if (null != _bgMusicMuteSwitchCallBack) _bgMusicMuteSwitchCallBack(this, _bgMusicMuteToggle.isOn);
    }

    private void soundVolumeToggleValueChanged()
    {
        if (null != _soundMuteSwitchCallBack) _soundMuteSwitchCallBack(this, _soundMuteToggle.isOn);
    }

    private void okClick()
    {
        if (_touchCallBack != null)
        {
            _touchCallBack(this);
        }
    }
}