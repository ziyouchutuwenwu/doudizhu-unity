using UnityEngine;
using System.Collections;

public class SettingViewHelper : MonoBehaviour
{
    public static void addSettingView(
        SettingViewScript.InitCallBack initCallBack,
        SettingViewScript.VolumeChangeCallBack bgMusicVolumeChangeCallBack,
        SettingViewScript.VolumeChangeCallBack soundVolumeChangeCallBack,
        SettingViewScript.ToggleSwitchCallBack bgMusicMuteSwitchCallBack,
        SettingViewScript.ToggleSwitchCallBack soundMuteSwitchCallBack,
        SettingViewScript.TouchCallBack touchCallBack
        )
    {
        if (null != GameObject.Find(SpriteNameConst.SETTING_VIEW_NAME)) return;

        Transform prefab = Resources.Load<Transform>("prefab/settingView/settingView");
        Transform transform = Instantiate(prefab, new Vector3(0,1, 1), Quaternion.identity) as Transform;
        transform.gameObject.name = SpriteNameConst.SETTING_VIEW_NAME;

        SettingViewScript settingViewScript = transform.GetComponent<SettingViewScript>();
        CanvasHelper.setOtherCanvasTouchEnabled(transform, false);
        settingViewScript.setInitCallBack(initCallBack);
        settingViewScript.setBgMusicVolumeChangeCallBack(bgMusicVolumeChangeCallBack);
        settingViewScript.setSoundVolumeChangeCallBack(soundVolumeChangeCallBack);
        settingViewScript.setBgMusicMuteSwitchCallBack(bgMusicMuteSwitchCallBack);
        settingViewScript.setSoundMuteSwitchCallBack(soundMuteSwitchCallBack);
        settingViewScript.setTouchCallBack(touchCallBack);
    }

    public static void setBgMusicVolume(float musicVolPercentage)
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.SETTING_VIEW_NAME);
        if (null != gameObject)
        {
            SettingViewScript settingViewScript = gameObject.GetComponent<SettingViewScript>();
            settingViewScript.setBgMusicVolume(musicVolPercentage);
        }
    }

    public static void setSoundVolume(float soundVolPercentage)
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.SETTING_VIEW_NAME);
        if (null != gameObject)
        {
            SettingViewScript settingViewScript = gameObject.GetComponent<SettingViewScript>();
            settingViewScript.setSoundVolume(soundVolPercentage);
        }
    }

    public static void setBgMusicMute(bool isMute)
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.SETTING_VIEW_NAME);
        if (null != gameObject)
        {
            SettingViewScript settingViewScript = gameObject.GetComponent<SettingViewScript>();
            settingViewScript.setBgMusicMute(isMute);
        }
    }

    public static void setSoundMute(bool isMute)
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.SETTING_VIEW_NAME);
        if (null != gameObject)
        {
            SettingViewScript settingViewScript = gameObject.GetComponent<SettingViewScript>();
            settingViewScript.setSoundMute(isMute);
        }
    }

    public static void removeSettingView()
    {
        GameObject gameObject = GameObject.Find(SpriteNameConst.SETTING_VIEW_NAME);
        if (null != gameObject)
        {
            CanvasHelper.setOtherCanvasTouchEnabled(gameObject.transform, true);
            Destroy(gameObject);
        }
    }
}