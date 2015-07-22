using UnityEngine;
using System.Collections.Generic;
using NetworkRequest;
using ClientSocket.Business;

namespace ThreePeoplePlayScene
{
    public class LogicObject : MonoBehaviour
    {
        private NetworkObject _networkObject = null;

        void Awake()
        {
            _networkObject = GameObject.Find("networkObject").GetComponent<NetworkObject>();
        }

        void Start()
        {
            _networkObject.registerDelegates();

            if (_networkObject.isConnected())
            {
                UserCheckResumePlayObject userCheckResumePlayObject = ModelManager.shareInstance().getUserCheckResumePlayObject();
                if (userCheckResumePlayObject.getShouldResumePlay())
                {
                    //断线重连
                    RequestSender.doUserResumePlayRequest();
                }
                else
                {
                    //不需要重连，刷新进桌子UI
                    RequestSender.doUserSitOnDeskRequest();
                }
            }
        }
    }
}