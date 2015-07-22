using UnityEngine;
using System.Collections;
using NetworkRequest;
using ClientSocket.Business;

namespace MainScene
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

            if (!_networkObject.isConnected())
            {
                RequestSender.doConnectServer();
            }
        }
    }
}