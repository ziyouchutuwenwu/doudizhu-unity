using UnityEngine;
using System.Collections;

public class SceneNameHelper : MonoBehaviour
{
    public static string getCurrentSceneName()
    {
        return Application.loadedLevelName;
    }

    //previousSceneName
    public static string getPreviousSceneName()
    {
        return LocalStorageHelper.getStringVal("previousSceneName");
    }

    public static void setPreviousSceneName(string sceneName)
    {
        LocalStorageHelper.setStringVal("previousSceneName", sceneName);
    }

    public static void removePreviousSceneName()
    {
        LocalStorageHelper.removeStringVal("previousSceneName");
    }

    //nextSceneName
    public static string getNextSceneName()
    {
        return LocalStorageHelper.getStringVal("nextSceneName");
    }

    public static void setNextSceneName(string sceneName)
    {
        LocalStorageHelper.setStringVal("nextSceneName", sceneName);
    }

    public static void removeNextSceneName()
    {
        LocalStorageHelper.removeStringVal("nextSceneName");
    }
}