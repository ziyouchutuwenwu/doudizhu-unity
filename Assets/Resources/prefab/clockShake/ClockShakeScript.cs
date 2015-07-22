using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*
    ClockShakeScript clockShakeScript = GameObject.Find("clockShake").GetComponent<ClockShakeScript>();
    clockShakeScript.setTimerCallBack(timerCallBack);

    public void timerCallBack(ClockShakeScript clockShakeScript)
    {
        Debug.Log("timer end");
    } 
*/
public class ClockShakeScript : MonoBehaviour
{
    //20秒钟结束时钟
    private const int TIMER_DURATION = 20;

    public delegate void TimeOutCallBack(ClockShakeScript clockShakeScript);
    private TimeOutCallBack _timeOutCallBack = null;

    public delegate void TimeAlarmCallBack(ClockShakeScript clockShakeScript);
    private TimeAlarmCallBack _alarmCallBack = null;

    private Text _timerInfoText = null;
    private Animator _shakeAnimator = null;

    private int _secondsCount = 1;

    void Awake()
    {
        _timerInfoText = this.transform.FindChild("timerInfo").GetComponent<Text>();
        _shakeAnimator = this.transform.GetComponent<Animator>();
        _shakeAnimator.enabled = false;

        InvokeRepeating("timerProc", 0, 1.0F);
	}

    void timerProc()
    {
        _timerInfoText.text = _secondsCount.ToString();

        if (_secondsCount >= TIMER_DURATION - 3 )
        {
            if (_alarmCallBack != null)
            {
                _alarmCallBack(this);
            }
            _shakeAnimator.enabled = true;
            _shakeAnimator.Play("clockShake");
        }
        if (_secondsCount == TIMER_DURATION )
        {
            if (_timeOutCallBack != null)
            {
                _timeOutCallBack(this);
            }
            _shakeAnimator.enabled = false;
            Destroy(this.gameObject);
        }

        _secondsCount++;
    }

    public void setTimeOutCallBack(TimeOutCallBack timeOutCallBack)
    {
        _timeOutCallBack = timeOutCallBack;
    }

    public void setTimeAlarmCallBack(TimeAlarmCallBack alarmCallBack)
    {
        _alarmCallBack = alarmCallBack;
    }
}