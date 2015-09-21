using UnityEngine;
using System.Collections.Generic;
using NetworkRequest;
using ClientSocket.Business;

namespace NetworkRequest
{
    public class RequestSender : MonoBehaviour
    {
        public static void doConnectServer()
        {
            ModelManager.shareInstance().registerModelObjects();
            ModelManager.shareInstance().reset();

            AsyncSocket.shareInstance().setPackageMaxSize(10000);
            AsyncSocket.shareInstance().setTimeout(10000);
            AsyncSocket.shareInstance().connect(ServerConst.SERVER_IP, ServerConst.SERVER_PORT);
        }

        public static void doUpdateCheckRequest()
        {
            string request = UpdateCheckEncoder.encode();
            AsyncSocket.shareInstance().send(SocketConst.CMD_UPDATE_CHECK, request);
        }

        public static void doGuestUserLoginRequest()
        {
            string request = UserGuestLoginEncoder.encode();
            AsyncSocket.shareInstance().send(SocketConst.CMD_USER_GUEST_LOGIN, request);
        }

        public static void doUserLoginRequest(string userName, string password)
        {
            string request = UserLoginEncoder.encode(userName, password);
            AsyncSocket.shareInstance().send(SocketConst.CMD_USER_LOGIN, request);
        }

        public static void doUserRegisterRequest(string userName, string password, bool isMale)
        {
            string request = UserRegisterEncoder.encode(userName, password, isMale);
            AsyncSocket.shareInstance().send(SocketConst.CMD_USER_REGISTER, request);
        }

        public static void doUserEditProfileRequest(string userName, string password, bool isMale)
        {
            string request = UserEditProfileEncoder.encode(userName, password, isMale);
            AsyncSocket.shareInstance().send(SocketConst.CMD_USER_EDIT_PROFILE, request);
        }

        public static void doUserCheckResumePlayRequest()
        {
            string request = UserCheckResumePlayEncoder.encode();
            AsyncSocket.shareInstance().send(SocketConst.CMD_USER_CHECK_RESUME_PLAY, request);
        }

        public static void doUserResumePlayRequest()
        {
            string request = UserResumePlayEncoder.encode();
            AsyncSocket.shareInstance().send(SocketConst.CMD_USER_RESUME_PLAY, request);
        }

        public static void doUserUserEnterRoomRequest()
        {
            string request = UserEnterRoomEncoder.encode();
            AsyncSocket.shareInstance().send(SocketConst.CMD_USER_ENTER_ROOM, request);
        }

        public static void doUserSitOnDeskRequest()
        {
            string request = UserSitOnDeskEncoder.encode();
            AsyncSocket.shareInstance().send(SocketConst.CMD_USER_SIT_ON_DESK, request);
        }

        public static void doUserLeaveDeskRequest()
        {
            string request = UserLeaveDeskEncoder.encode();
            AsyncSocket.shareInstance().send(SocketConst.CMD_USER_LEAVE_DESK, request);
        }

        public static void doUserChangeDeskRequest()
        {
            string request = UserChangeDeskEncoder.encode();
            AsyncSocket.shareInstance().send(SocketConst.CMD_USER_CHANGE_DESK, request);
        }

        public static void doUserReadyRequest()
        {
            string request = UserReadyEncoder.encode();
            AsyncSocket.shareInstance().send(SocketConst.CMD_USER_READY_TO_PLAY, request);
        }

        public static void doUserJiaoDiZhuRequest(bool JiaoDiZhu)
        {
            string request = DeskJiaoDiZhuEncoder.encode(JiaoDiZhu);
            AsyncSocket.shareInstance().send(SocketConst.CMD_DESK_JIAO_DI_ZHU, request);
        }

        public static void doUserChuPaiRequest(List<int> cards)
        {
            string request = DeskChuPaiEncoder.encode(cards);
            AsyncSocket.shareInstance().send(SocketConst.CMD_DESK_CHU_PAI, request);
        }

        public static void doUserCardsPromptRequest()
        {
            string request = DeskCardsPromptEncoder.encode();
            AsyncSocket.shareInstance().send(SocketConst.CMD_DESK_CRADS_PROMPT, request);
        }
    }
}
