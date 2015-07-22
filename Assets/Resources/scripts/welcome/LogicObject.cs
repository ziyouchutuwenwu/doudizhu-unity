using UnityEngine;
using System.Collections;
using NetworkRequest;
using ClientSocket.Business;

namespace WelcomeScene
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
            if (LoginTypeHelper.getIsLocalLoginTypeGuestUser())
            {
                SceneHelper.switchToSceneAtOnce("main");
            }
            else if (LoginTypeHelper.getIsLocalLoginTypeRegisteredUser())
            {
                SceneHelper.switchToSceneAtOnce("main");
            }
            else
            {
                _networkObject.registerDelegates();
                RequestSender.doConnectServer();
            }
        }
    }
}