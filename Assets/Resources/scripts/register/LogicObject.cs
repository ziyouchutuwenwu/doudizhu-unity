using UnityEngine;
using System.Collections;
using NetworkRequest;
using ClientSocket.Business;
using UnityEngine.UI;

namespace RegisterScene
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