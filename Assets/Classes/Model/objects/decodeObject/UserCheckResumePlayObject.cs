using UnityEngine;
using System.Collections.Generic;

public class UserCheckResumePlayObject
{
    private bool _shouldResumePlay;

    public void resetPlaying()
    {
        _shouldResumePlay = false;
    }

    public void reset()
    {
        _shouldResumePlay = false;
    }

    public bool getShouldResumePlay()
    {
        return _shouldResumePlay;
    }

    public void setShouldResumePlay(bool shouldResumePlay)
    {
        _shouldResumePlay = shouldResumePlay;
    }
}