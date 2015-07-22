using UnityEngine;
using System.Collections.Generic;

public class VolumeStorageHelper : MonoBehaviour
{
    public static void setBgMusicVolume(float volume)
    {
        LocalStorageHelper.setFloatVal("bgMusicVolume", volume);
    }

    public static float getBgMusicVolume()
    {
        return LocalStorageHelper.getFloatVal("bgMusicVolume");
    }

    public static void setSoundVolume(float volume)
    {
        LocalStorageHelper.setFloatVal("soundVolume", volume);
    }

    public static float getSoundVolume()
    {
        return LocalStorageHelper.getFloatVal("soundVolume");
    }

    public static void setBgMusicMute(bool isMute)
    {
        LocalStorageHelper.setBoolVal("bgMusicMute", isMute);
    }

    public static bool getBgMusicMute()
    {
        return LocalStorageHelper.getBoolVal("bgMusicMute");
    }

    public static void setSoundMute(bool isMute)
    {
        LocalStorageHelper.setBoolVal("soundMute", isMute);
    }

    public static bool getSoundMute()
    {
        return LocalStorageHelper.getBoolVal("soundMute");
    }
}