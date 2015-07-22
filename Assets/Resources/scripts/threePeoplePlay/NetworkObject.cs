using UnityEngine;  
using System.Collections;  
using System.Collections.Generic;  
using UnityEngine.Events;  
using UnityEngine.UI;
using ClientSocket.Business;
using System.Runtime.InteropServices;
using NetworkRequest;

namespace ThreePeoplePlayScene
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

            OtherClientDisconnectedController otherClientDisconnectedController = new OtherClientDisconnectedController();
            genSocket.addToResponseDelegates(otherClientDisconnectedController);

            //siton和leave组合在一起成为换桌接口
            UserSitOnDeskController userSitOnDeskController = new UserSitOnDeskController();
            genSocket.addToResponseDelegates(userSitOnDeskController);

            UserLeaveDeskController userLeaveDeskController = new UserLeaveDeskController();
            genSocket.addToResponseDelegates(userLeaveDeskController);

            UserPromptReadyController userPromptReadyController = new UserPromptReadyController();
            genSocket.addToResponseDelegates(userPromptReadyController);

            UserReadyController userReadyController = new UserReadyController();
            genSocket.addToResponseDelegates(userReadyController);

            DeskFaPaiController deskFaPaiController = new DeskFaPaiController();
            genSocket.addToResponseDelegates(deskFaPaiController);

            DeskPromptUserJiaoDiZhuController deskPromptUserJiaoDiZhuController = new DeskPromptUserJiaoDiZhuController();
            genSocket.addToResponseDelegates(deskPromptUserJiaoDiZhuController);

            DeskJiaoDiZhuController deskJiaoDiZhuController = new DeskJiaoDiZhuController();
            genSocket.addToResponseDelegates(deskJiaoDiZhuController);

            DeskJiaoDiZhuFinishController deskJiaoDiZhuFinishController = new DeskJiaoDiZhuFinishController();
            genSocket.addToResponseDelegates(deskJiaoDiZhuFinishController);

            DeskFaDiPaiController deskFaDiPaiController = new DeskFaDiPaiController();
            genSocket.addToResponseDelegates(deskFaDiPaiController);

            //出牌部分
            DeskChuPaiController deskChuPaiController = new DeskChuPaiController();
            genSocket.addToResponseDelegates(deskChuPaiController);

            DeskCardsPromptController deskCardsPromptController = new DeskCardsPromptController();
            genSocket.addToResponseDelegates(deskCardsPromptController);

            DeskCardsValidateController deskCardsValidateController = new DeskCardsValidateController();
            genSocket.addToResponseDelegates(deskCardsValidateController);

            DeskDaPaiEndController deskDaPaiEndController = new DeskDaPaiEndController();
            genSocket.addToResponseDelegates(deskDaPaiEndController);

            //自动叫地主
            AutoDeskJiaoDiZhuController autoDeskJiaoDiZhuController = new AutoDeskJiaoDiZhuController();
            genSocket.addToResponseDelegates(autoDeskJiaoDiZhuController);

            //自动出牌
            AutoDeskChuPaiController autoDeskChuPaiController = new AutoDeskChuPaiController();
            genSocket.addToResponseDelegates(autoDeskChuPaiController);

            //断线重连
            QueryDeskUsersController queryDeskUsersController = new QueryDeskUsersController();
            genSocket.addToResponseDelegates(queryDeskUsersController);

            QueryDeskFaPaiController queryDeskFaPaiController = new QueryDeskFaPaiController();
            genSocket.addToResponseDelegates(queryDeskFaPaiController);

            QueryDeskPromptUserJiaoDiZhuController queryDeskPromptUserJiaoDiZhuController = new QueryDeskPromptUserJiaoDiZhuController();
            genSocket.addToResponseDelegates(queryDeskPromptUserJiaoDiZhuController);

            QueryDeskJiaoDiZhuController queryDeskJiaoDiZhuController = new QueryDeskJiaoDiZhuController();
            genSocket.addToResponseDelegates(queryDeskJiaoDiZhuController);

            QueryDeskJiaoDiZhuFinishController queryDeskJiaoDiZhuFinishController = new QueryDeskJiaoDiZhuFinishController();
            genSocket.addToResponseDelegates(queryDeskJiaoDiZhuFinishController);

            QueryDeskFaDiPaiController queryDeskFaDiPaiController = new QueryDeskFaDiPaiController();
            genSocket.addToResponseDelegates(queryDeskFaDiPaiController);

            QueryDeskChuPaiController queryDeskChuPaiController = new QueryDeskChuPaiController();
            genSocket.addToResponseDelegates(queryDeskChuPaiController);
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
			case SocketConst.CMD_CLIENT_DISCONNECTED:
                networkHandlerObject.onClientDisconnected();
				break;
            case SocketConst.CMD_OTHER_CLIENT_DISCONNECTED:
                networkHandlerObject.onOtherClientDisconnected();
			    break;
			case SocketConst.CMD_USER_SIT_ON_DESK:
                networkHandlerObject.onUserSitOnDesk();
				break;
			case SocketConst.CMD_USER_LEAVE_DESK:
                networkHandlerObject.onUserLeaveDesk();
				break;
			case SocketConst.CMD_USER_PROMPT_READY:
                networkHandlerObject.onUserPromptReady();
				break;
			case SocketConst.CMD_USER_READY_TO_PLAY:
                networkHandlerObject.onUserReady();
				break;
			case SocketConst.CMD_DESK_FA_PAI:
                networkHandlerObject.onDeskFaPai();
				break;
			case SocketConst.CMD_DESK_PROMPT_USER_JIAO_DI_ZHU:
                networkHandlerObject.onDeskPromptUserJiaoDiZhu();
				break;
			case SocketConst.CMD_DESK_JIAO_DI_ZHU:
                networkHandlerObject.onDeskJiaoDiZhu();
				break;
			case SocketConst.CMD_DESK_JIAO_DI_ZHU_FINISH:
                networkHandlerObject.onDeskJiaoDiZhuFinish();
				break;
			case SocketConst.CMD_DESK_FA_DI_PAI:
                networkHandlerObject.onDeskFaDiPai();
				break;
			case SocketConst.CMD_DESK_CHU_PAI:
                networkHandlerObject.onDeskChuPai();
				break;
			case SocketConst.CMD_DESK_CARDS_VALIDATE:
                networkHandlerObject.onDeskCardsValidate();
				break;
			case SocketConst.CMD_DESK_CRADS_PROMPT:
                networkHandlerObject.onDeskCardsPrompt();
				break;
			case SocketConst.CMD_DESK_DA_PAI_END:
                networkHandlerObject.onDeskDaPaiEnd();
				break;
				//自动叫地主
			case SocketConst.CMD_AUTO_DESK_JIAO_DI_ZHU:
                networkHandlerObject.onAutoDeskJiaoDiZhu();
				break;
				//自动出牌
			case SocketConst.CMD_AUTO_DESK_CHU_PAI:
                networkHandlerObject.onAutoDeskChuPai();
				break;
				//断线重连
			case SocketConst.CMD_QUERY_DESK_USERS:
                networkHandlerObject.onQueryDeskUsers();
				break;
			case SocketConst.CMD_QUERY_DESK_FA_PAI:
                networkHandlerObject.onQueryDeskFaPai();
				break;
			case SocketConst.CMD_QUERY_DESK_PROMPT_USER_JIAO_DI_ZHU:
                networkHandlerObject.onQueryDeskPromptUserJiaoDiZhu();
				break;
			case SocketConst.CMD_QUERY_DESK_JIAO_DI_ZHU:
                networkHandlerObject.onQueryDeskJiaoDiZhu();
				break;
			case SocketConst.CMD_QUERY_DESK_JIAO_DI_ZHU_FINISH:
                networkHandlerObject.onQueryDeskJiaoDiZhuFinish();
				break;
			case SocketConst.CMD_QUERY_DESK_FA_DI_PAI:
                networkHandlerObject.onQueryDeskFaDiPai();
				break;
			case SocketConst.CMD_QUERY_DESK_CHU_PAI:
                networkHandlerObject.onQueryDeskChuPai();
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