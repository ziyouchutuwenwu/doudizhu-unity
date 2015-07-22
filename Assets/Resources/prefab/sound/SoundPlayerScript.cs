using UnityEngine;
using System.Collections;

public class SoundPlayerScript : MonoBehaviour {

    private AudioSource _soundSource = null;

    void Awake()
    {
        _soundSource = this.transform.GetComponent<AudioSource>();
        _soundSource.playOnAwake = false;
        _soundSource.loop = false;
    }

    public void play(string soundFullPath)
    {
        AudioClip audioClip = Resources.Load<AudioClip>(soundFullPath) as AudioClip;
        _soundSource.clip = audioClip;
        _soundSource.Play();
    }

    public void setVolume(float volume)
    {
        _soundSource.volume = volume;
    }

    public void delayPlay(string soundFullPath)
    {
        StartCoroutine(delayCallProc(0.1f, soundFullPath));
    }

    IEnumerator delayCallProc(float waitTime, string soundFullPath)
    {
        yield return waitTime;

        play(soundFullPath);
    }
}