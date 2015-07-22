using UnityEngine;
using System.Collections;

public class TransitionScene : MonoBehaviour
{
    public int guiDepth = 0;
    
    public string levelStringToLoad = "";

    public Texture2D splashLogo;
    public float fadeSpeed = 0.8f;
    public float waitTime = 0.2f;
    public bool waitForInput = false;
    public bool startAutomatically = true;

    private float timeFadingInFinished = 0.0f;

    public enum SplashType
    {
        LoadNextLevelThenFadeOut,
        FadeOutThenLoadNextLevel
    }

    public SplashType splashType;
    private float alpha = 0.0f;

    private enum FadeStatus
    {
        Paused,
        FadeIn,
        FadeWaiting,
        FadeOut
    }

    private FadeStatus status = FadeStatus.FadeIn;

    private Camera oldCamera = null;
    private GameObject oldCamGameObject = null;

    private Rect splashLogoPos = new Rect();

    public enum LogoPositioning
    {
        Centered,
        Stretched
    }

    public LogoPositioning logoPositioning;
    private bool loadingNextLevel = false;

    void Start()
    {
        levelStringToLoad = SceneNameHelper.getNextSceneName();

        if (startAutomatically)
        {
            status = FadeStatus.FadeIn;
        }
        else
        {
            status = FadeStatus.Paused;
        }

        oldCamera = Camera.main;
        oldCamGameObject = Camera.main.gameObject;

        if (logoPositioning == LogoPositioning.Centered)
        {
            splashLogoPos.x = (Screen.width * 0.5f) - (splashLogo.width * 0.5f);
            splashLogoPos.y = (Screen.height * 0.5f) - (splashLogo.height * 0.5f);

            splashLogoPos.width = splashLogo.width;
            splashLogoPos.height = splashLogo.height;
        }
        else
        {
            splashLogoPos.x = 0;
            splashLogoPos.y = 0;

            splashLogoPos.width = Screen.width;
            splashLogoPos.height = Screen.height;
        }

        if (splashType == SplashType.LoadNextLevelThenFadeOut)
        {
            DontDestroyOnLoad(this);
            DontDestroyOnLoad(Camera.main);
        }

        if ((Application.levelCount <= 1) || (levelStringToLoad == ""))
        {
            Debug.LogWarning("Invalid levelToLoad value.");
        }
    }

    public void StartSplash()
    {
        status = FadeStatus.FadeIn;
    }

    void Update()
    {
        switch (status)
        {
            case FadeStatus.FadeIn:
                alpha += fadeSpeed * Time.deltaTime;
                break;
            case FadeStatus.FadeWaiting:
                if ((!waitForInput && Time.time >= timeFadingInFinished + waitTime) || (waitForInput && Input.anyKey))
                {
                    status = FadeStatus.FadeOut;
                }
                break;
            case FadeStatus.FadeOut:
                alpha += -fadeSpeed * Time.deltaTime;
                break;
        }
    }

    void OnGUI()
    {
        //图片Alpha控制
        GUI.depth = guiDepth;
        if (splashLogo != null)
        {
            GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, Mathf.Clamp01(alpha));
            GUI.DrawTexture(splashLogoPos, splashLogo);
        }
        if (alpha > 1.0f)
        {
            status = FadeStatus.FadeWaiting;
            timeFadingInFinished = Time.time;
            alpha = 1.0f;
            if (splashType == SplashType.LoadNextLevelThenFadeOut)
            {
                oldCamera.depth = -1000;
                loadingNextLevel = true;
                if ((Application.levelCount) >= 1 && (levelStringToLoad != ""))
                {
                    Application.LoadLevel(levelStringToLoad);
                }
            }
        }
        if (alpha < 0.0f)
        {
            if (splashType == SplashType.FadeOutThenLoadNextLevel)
            {
                if ((Application.levelCount >= 1) || (levelStringToLoad != ""))
                {
                    Application.LoadLevel(levelStringToLoad);
                }
            }
            else
            {
                Destroy(oldCamGameObject);
                Destroy(oldCamera);
            }
        }
    }

    void OnLevelWasLoaded(int lvlIdx)
    {
        if (loadingNextLevel)
        {
            if (alpha == 0.0f)
            {
                Transform[] transforms = (Transform[])Object.FindObjectsOfType(typeof(Transform));
                foreach (Transform transform in transforms)
                {
                    Destroy(transform.gameObject);
                }

                SceneNameHelper.removeNextSceneName();

//                 Destroy(oldCam);
//                 Destroy(oldCamGO);
            }
        }
    }

    //绘制Gizmos
    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1.0f, 0.0f, 0.0f, 0.5f);
        Gizmos.DrawCube(transform.position, new Vector3(1, 1, 1));
    }
}