using UnityEngine;
using System.Collections;

public class SceneHelper : MonoBehaviour {

    public static void switchToScene(string sceneName)
    {
        if (sceneName.Length > 0)
        {
            SceneNameHelper.setPreviousSceneName(SceneNameHelper.getCurrentSceneName());

            SceneNameHelper.setNextSceneName(sceneName);
            LevelLoadFade.FadeAndLoadLevel("transitionScene", Color.black, 0.5f);
        }
    }

    public static void switchToSceneAtOnce(string sceneName)
    {
        if (sceneName.Length > 0)
        {
            SceneNameHelper.setPreviousSceneName(SceneNameHelper.getCurrentSceneName());

            SceneNameHelper.setNextSceneName(sceneName);
            Application.LoadLevel(sceneName);
        }
    }

    public static void switchSceneBack()
    {
        string previousSceneName = SceneNameHelper.getPreviousSceneName();
        if (previousSceneName.Length > 0)
        {
            switchToScene(previousSceneName);
            SceneNameHelper.removePreviousSceneName();
        }
    }
}