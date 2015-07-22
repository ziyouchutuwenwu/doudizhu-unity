using UnityEngine;  
using System.Collections;  
using System.Collections.Generic;  
using UnityEngine.Events;  
using UnityEngine.UI;
using ClientSocket.Business;
using System.Runtime.InteropServices;
using NetworkRequest;

namespace RegisterScene
{
    public class NetworkObject : MonoBehaviour
    {
        public bool isConnected()
        {
            return AsyncSocket.shareInstance().isConnected();
        }

        public void registerDelegates()
        {
            AsyncSocket genSocket = AsyncSocket.shareInstance();

            ClientStatusController statusCtller = new ClientStatusController();
            genSocket.setStatusDelegate(statusCtller);

            UserRegisterController registerCtller = new UserRegisterController();
            genSocket.addToResponseDelegates(registerCtller);
        }
        /*************************************************************************************************************************/

        void OnDestroy()
        {
            unregisterDelegates();
        }

		void flushUI()
		{
			int queueSize = ReceivedDataStatusQueue.shareInstance().getSize();
			if (queueSize == 0) return;

            NetworkHandlerObject networkHandlerObject = GameObject.Find("networkHandlerObject").GetComponent<NetworkHandlerObject>();
			bool isValidResponse = true;
			int status = ReceivedDataStatusQueue.shareInstance().getStatus();
			
			switch (status)
			{
			case SocketConst.CMD_CLIENT_CONNECTED:
                networkHandlerObject.onClientConnected();
				break;
			case SocketConst.CMD_CLIENT_CONNECTED_FAIL:
                networkHandlerObject.onClientConnectFail();
				break;
			case SocketConst.CMD_CLIENT_DISCONNECTED:
                networkHandlerObject.onClientDisconnected();
				break;
            case SocketConst.CMD_USER_REGISTER:
                networkHandlerObject.onUserRegister();
				break;
			default:
				isValidResponse = false;
				break;
			}
			
			if (isValidResponse) ReceivedDataStatusQueue.shareInstance().removeStatus();
		}

        void Update()
        {
            if (Time.frameCount % UIUpdateRefreshConst.ITME_DURATION == 0) 
			{
				flushUI ();
			}
        }

        void unregisterDelegates()
        {
            AsyncSocket genSocket = AsyncSocket.shareInstance();
            genSocket.resetResponseDelegates();
            genSocket.resetStatusDelegate();
        }
    }
}