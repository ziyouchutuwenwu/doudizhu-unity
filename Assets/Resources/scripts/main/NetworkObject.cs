using UnityEngine;  
using System.Collections;  
using System.Collections.Generic;  
using UnityEngine.Events;  
using UnityEngine.UI;
using ClientSocket.Business;
using System.Runtime.InteropServices;
using NetworkRequest;

namespace MainScene
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

            VersionUpdateCheckController updateCheckController = new VersionUpdateCheckController();
            genSocket.addToResponseDelegates(updateCheckController);

            UserGuestLoginController guestLoginCtller = new UserGuestLoginController();
            genSocket.addToResponseDelegates(guestLoginCtller);

            UserLoginController loginCtller = new UserLoginController();
            genSocket.addToResponseDelegates(loginCtller);

            UserCheckResumePlayController userCheckResumePlayController = new UserCheckResumePlayController();
            genSocket.addToResponseDelegates(userCheckResumePlayController);

            UserEnterRoomController userEnterRoomController = new UserEnterRoomController();
            genSocket.addToResponseDelegates(userEnterRoomController);
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
			case SocketConst.CMD_UPDATE_CHECK:
                networkHandlerObject.onVersionUpdateCheck();
				break;
			case SocketConst.CMD_USER_GUEST_LOGIN:
                networkHandlerObject.onUserGuestLogin();
				break;
            case SocketConst.CMD_USER_LOGIN:
                networkHandlerObject.onUserLogin();
                break;
			case SocketConst.CMD_USER_CHECK_RESUME_PLAY:
                networkHandlerObject.onUserCheckResumePlay();
				break;
			case SocketConst.CMD_USER_ENTER_ROOM:
                networkHandlerObject.onUserEnterRoom();
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