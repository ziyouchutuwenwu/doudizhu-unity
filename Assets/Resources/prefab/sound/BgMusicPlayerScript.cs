using UnityEngine;
using System.Collections;

public class BgMusicPlayerScript : MonoBehaviour {

    private AudioSource _musicSource = null;

	void Awake () {
        _musicSource = this.transform.GetComponent<AudioSource>();
        _musicSource.playOnAwake = false;
        _musicSource.loop = true;
	}

    public void setVolume(float volume)
    {
        _musicSource.volume = volume;
    }

    public void play()
    {
        _musicSource.Play();
    }

    public void pause()
    {
        _musicSource.Pause();
    }

    public void stop()
    {
        _musicSource.Stop();
    }
}