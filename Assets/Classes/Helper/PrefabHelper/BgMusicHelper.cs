using UnityEngine;
using System.Collections;

public class BgMusicHelper : MonoBehaviour {

    public static void addBgMusicPlayer()
    {
        if (null != GameObject.Find(SpriteNameConst.BG_MUSIC_NAME)) return;

        Transform prefab = Resources.Load<Transform>("prefab/sound/bgMusicPlayer");
        Transform transform = Instantiate(prefab, new Vector3(-1, 1, 0.01f), Quaternion.identity) as Transform;
        transform.gameObject.name = SpriteNameConst.BG_MUSIC_NAME;
    }

    public static void setBgVolume(float volume)
    {
        BgMusicPlayerScript bgMusicPlayerScript = GameObject.Find(SpriteNameConst.BG_MUSIC_NAME).GetComponent<BgMusicPlayerScript>();
        if (null != bgMusicPlayerScript)
        {
            bgMusicPlayerScript.setVolume(volume);
        }
    }

    public static void playBgMusic()
    {
        BgMusicPlayerScript bgMusicPlayerScript = GameObject.Find(SpriteNameConst.BG_MUSIC_NAME).GetComponent<BgMusicPlayerScript>();
        if (null != bgMusicPlayerScript)
        {
            bgMusicPlayerScript.play();
        }
    }
}