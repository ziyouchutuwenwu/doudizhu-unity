using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DelayCallerScript : MonoBehaviour {

    public delegate void DelayCallBack(params object[] args);
    private Queue _delayCallBackQueue = null;
    private Queue _delayDurationQueue = null;
    private int _count = 0;

    void Awake()
    {
        _delayCallBackQueue = new Queue();
        _delayDurationQueue = new Queue();
    }

    void Update()
    {
        if (_count > 0 )
        {
            _count--;

            if (_delayDurationQueue.Count > 0)
            {
                Dictionary<string, object> queueElement = (Dictionary<string, object>)_delayDurationQueue.Peek();
                float delayDuration = (float)queueElement["duration"];
                StartCoroutine(delayCallProc(delayDuration));
            }
        }
    }

    public void delayCall(float delayDuration,DelayCallBack delayCallBack, params object[] args)
    {
        _count++;

        lock (_delayCallBackQueue)
        {
            Dictionary<string, object> queueElement = new Dictionary<string, object>();
            queueElement["callBack"] = delayCallBack;
            queueElement["params"] = args;

            _delayCallBackQueue.Enqueue(queueElement);
        }

        lock (_delayDurationQueue)
        {
            Dictionary<string, object> queueElement = new Dictionary<string, object>();
            queueElement["duration"] = delayDuration;

            _delayDurationQueue.Enqueue(queueElement);
        }
    }

    IEnumerator delayCallProc(float waitTime)
    {
        if (_delayDurationQueue.Count > 0)
        {
            lock (_delayDurationQueue)
            {
                _delayDurationQueue.Dequeue();
            }
        }
        yield return new WaitForSeconds(waitTime);

        if (_delayCallBackQueue.Count > 0)
        {
            Dictionary<string, object> queueElement = (Dictionary<string, object>)_delayCallBackQueue.Peek();
            DelayCallBack delayCallBack = (DelayCallBack)queueElement["callBack"];
            object[] paramList = (object[])queueElement["params"];

            if (null != delayCallBack) delayCallBack(paramList);
            lock (_delayCallBackQueue)
            {
                _delayCallBackQueue.Dequeue();
            }
        }
    }
}