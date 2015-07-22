using UnityEngine;
using System.Collections;

public class LevelLoadFade : MonoBehaviour
{
    public static void FadeAndLoadLevel(string levelName, Texture2D fadeTexture, float fadeLength)
    {
        if (null == fadeTexture)
        {
            FadeAndLoadLevel(levelName, Color.white, fadeLength);
        }

        GameObject fade = new GameObject("Fade");
        fade.AddComponent<LevelLoadFade>();

        fade.GetComponent<LevelLoadFade>().DoFade(levelName, fadeLength, fadeTexture, Color.white, false);
    }

    public static void FadeAndLoadLevel(string levelName, Color color, float fadeLength)
    {
        color.a = 1;
        Texture2D fadeTexture = new Texture2D(1, 1);
        fadeTexture.SetPixel(0, 0, color);
        fadeTexture.Apply();
        DontDestroyOnLoad(fadeTexture);

        GameObject fade = new GameObject("Fade");
        fade.AddComponent<LevelLoadFade>();
        fade.GetComponent<LevelLoadFade>().DoFade(levelName, fadeLength, fadeTexture, color, true);
    }

    private Texture2D m_FadeTexture;
    private Rect m_Rect;
    private Color m_Color;


    void Awake()
    {
        m_Rect = new Rect(0, 0, Screen.width, Screen.height);
        m_FadeTexture = null;
    }


    void OnGUI()
    {
        if (m_FadeTexture != null)
        {
            GUI.depth = -100;
            GUI.color = m_Color;
            GUI.DrawTexture(m_Rect, m_FadeTexture);
        }
    }

    void DoFade(string levelName, float fadeLength,
        Texture2D fadeTexture, Color color, bool destroyTexture)
    {
        transform.position = Vector3.zero;
        // Don't destroy the fade game object during level load
        DontDestroyOnLoad(gameObject);
        m_Color = color;
        m_FadeTexture = fadeTexture;

        StartCoroutine(DoCoroutineFade(levelName, fadeLength, fadeTexture, color, destroyTexture));
    }

    IEnumerator DoCoroutineFade(string levelName, float fadeLength, Texture2D fadeTexture, Color color, bool destroyTexture)
    {
        // Fade texture in
        float time = 0;
        while (time < fadeLength)
        {
            time += Time.deltaTime;
            m_Color.a = Mathf.InverseLerp(0, 1, time / fadeLength);
            yield return null;
        }

        // Fadeout to start with
        color.a = 1;

        Application.LoadLevel(levelName);

        // Fade texture out
        time = 0;
        while (time < fadeLength)
        {
            time += Time.deltaTime;
            m_Color.a = Mathf.InverseLerp(1, 0, time / fadeLength);
            yield return null;
        }

        m_Color.a = 0;

        m_FadeTexture = null;
        Destroy(gameObject);

        if (destroyTexture)
        {
            Destroy(m_FadeTexture);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}